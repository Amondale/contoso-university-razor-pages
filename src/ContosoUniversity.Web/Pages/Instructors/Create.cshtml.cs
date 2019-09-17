using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class Create : PageModel
    {
        [BindProperty]
        public Instructor Instructor { get; set; }

        public List<AssignedCourseViewModel> AssignedCourseViewModels;

        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;

        public Create(IInstructorRepository instructorRepository, ICourseRepository courseRepository)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
        }

        public IActionResult OnGet()
        {
            var instructor = new Instructor();
            AssignedCourseViewModels = _instructorRepository.GetAssignedCourseData(instructor);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var courses = await _courseRepository.ListAllAsync();
            var newInstructor = new Instructor();

            if (await TryUpdateModelAsync<Instructor>(
                newInstructor,
                "Instructor",
                i => i.FirstName, 
                                    i => i.LastName,
                                    i => i.HireDate, 
                                    i => i.OfficeAssignment))
            {
                var createdInstructor = await _instructorRepository.AddAsync(newInstructor);
                if (Instructor.SelectedCourses != null)
                {
                    createdInstructor.HandleCourses(Instructor.SelectedCourses, courses);
                    await _instructorRepository.UpdateAsync(createdInstructor);
                }
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}