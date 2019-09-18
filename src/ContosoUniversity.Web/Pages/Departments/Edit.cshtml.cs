using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IInstructorRepository _instructorRepository;

        public EditModel(IDepartmentRepository departmentRepository, IInstructorRepository instructorRepository)
        {
            _departmentRepository = departmentRepository;
            _instructorRepository = instructorRepository;
        }

        [BindProperty]
        public Department Department { get; set; }
        
        public SelectList InstructorNameSl { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Department = await _departmentRepository.GetDepartmentAsync(id);

            if (Department == null)
            {
                return NotFound();
            }

            InstructorNameSl = new SelectList(_instructorRepository.GetInstructors(), "Id", "FullName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var departmentToUpdate = await _departmentRepository.GetDepartmentAsync(id);

            // null means Department was deleted by another user.
            if (departmentToUpdate == null)
            {
                return HandleDeletedDepartment();
            }

            // Update the RowVersion to the value when this entity was
            // fetched. If the entity has been updated after it was
            // fetched, RowVersion won't match the DB RowVersion and
            // a DbUpdateConcurrencyException is thrown.
            // A second postback will make them match, unless a new 
            // concurrency issue happens.
            _departmentRepository
                .GetDbEntityEntry(departmentToUpdate)
                .Property("RowVersion").OriginalValue = Department.RowVersion;


            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "Department",
                s => s.DepartmentName, s => s.FoundedDate, s => s.Budget, s => s.DepartmentChairId))
            {
                try
                {
                    await _departmentRepository.UpdateAsync(departmentToUpdate);
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Department)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. " +
                            "The department was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (Department)databaseEntry.ToObject();
                    await SetDbErrorMessage(dbValues, clientValues);

                    // Save the current RowVersion so next postback
                    // matches unless an new concurrency issue happens.
                    Department.RowVersion = (byte[])dbValues.RowVersion;

                    // Must clear the model error for the next postback.
                    ModelState.Remove("Department.RowVersion");
                }
            }

            InstructorNameSl = new SelectList(_instructorRepository.GetInstructors(), "ID", "FullName", departmentToUpdate.DepartmentChairId);
            return Page();
        }

        private IActionResult HandleDeletedDepartment()
        {
            // ModelState contains the posted data because of the deletion error and will overide the Department instance values when displaying Page().
            ModelState.AddModelError(string.Empty,"Unable to save. The department was deleted by another user.");

            InstructorNameSl = new SelectList(_instructorRepository.GetInstructors(), "ID", "FullName", Department.DepartmentChairId);

            return Page();
        }

        private async Task SetDbErrorMessage(Department dbValues, Department clientValues)
        {

            if (dbValues.DepartmentName != clientValues.DepartmentName)
            {
                ModelState.AddModelError("Department.Name",
                    $"Current value: {dbValues.DepartmentName}");
            }
            if (dbValues.Budget != clientValues.Budget)
            {
                ModelState.AddModelError("Department.Budget",
                    $"Current value: {dbValues.Budget:c}");
            }
            if (dbValues.FoundedDate != clientValues.FoundedDate)
            {
                ModelState.AddModelError("Department.StartDate",
                    $"Current value: {dbValues.FoundedDate:d}");
            }
            if (dbValues.DepartmentChairId != clientValues.DepartmentChairId)
            {
                Instructor dbInstructor = await _instructorRepository.GetInstructorWithChildrenAsync(dbValues.DepartmentChairId ?? new Guid());
                ModelState.AddModelError("Department.InstructorID",
                    $"Current value: {dbInstructor?.FullName}");
            }

            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit "
              + "was modified by another user after you. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again.");
        }
    }
}
