using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly ICourseRepository _repository;

        public EditModel(IDepartmentRepository departmentRepository, ICourseRepository repository) : base(departmentRepository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _repository.GetCourseAsync(id);

            if (Course == null)
            {
                return NotFound();
            }

            // Select current DepartmentId.
            PopulateDepartmentsDropDownList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var courseToUpdate = await _repository.GetCourseAsync(id);

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "course",
                c => c.Credits, c => c.DepartmentId, c => c.Title))
            {
                await _repository.UpdateAsync(courseToUpdate);
                return RedirectToPage("./Index");
            }

            // Select DepartmentId if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList();
            return Page();
        }


    }
}
