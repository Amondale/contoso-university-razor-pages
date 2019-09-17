using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Courses
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly ICourseRepository _courseRepository;

        public CreateModel(IDepartmentRepository departmentRepository, ICourseRepository courseRepository): base(departmentRepository)
        {
            _courseRepository = courseRepository;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList();
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyCourse = new Course();

            if (await TryUpdateModelAsync<Course>(
                emptyCourse,
                "course",
                s => s.CourseId, s => s.DepartmentId, s => s.Title, s => s.Credits))
            {

                await _courseRepository.AddAsync(emptyCourse);
                return RedirectToPage("./Index");
            }

            // Select DepartmentId if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(emptyCourse.DepartmentId);
            return Page();
        }
    }
}