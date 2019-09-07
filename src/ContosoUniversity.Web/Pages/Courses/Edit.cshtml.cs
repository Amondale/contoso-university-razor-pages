using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        
        private readonly ICourseRepository _courseRepository;

        public EditModel(IDepartmentRepository departmentRepository, ICourseRepository courseRepository) : base(departmentRepository)
        {
            _courseRepository = courseRepository;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course = await _courseRepository.GetCourseAsync(id);


            if (Course == null)
            {
                return NotFound();
            }

            PopulateDepartmentsDropDownList( Course.DepartmentID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var courseToUpdate = await _courseRepository.GetByIdAsync(id);

            if (await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "course",
                c => c.Credits, c => c.DepartmentID, c => c.Title))
            {
                await _courseRepository.UpdateAsync(courseToUpdate);
                return RedirectToPage("./Index");
            }

            PopulateDepartmentsDropDownList(courseToUpdate.DepartmentID);
            return Page();
        }
    }
}
