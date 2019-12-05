using AutoMapper;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class AssignCourses : PageModel
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public AssignCourses(IInstructorRepository instructorRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public CourseAssignmentViewModel CourseAssignments { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Instructor = await _instructorRepository.GetInstructorAsync(id);

            if (Instructor == null)
            {
                return NotFound();
            }

            CourseAssignments = new CourseAssignmentViewModel()
            {
                InstructorId = id
            };

            var assignedCourses = await _instructorRepository.GetAssignedCourseData(id);
            var allCourses = await _courseRepository.GetCoursesAndDepartmentsAsync();
            var checkBoxListItems = allCourses
                .Select(course => new CheckBoxListItem
                {
                    Id = course.Id, 
                    Display = course.Title,
                    IsChecked = assignedCourses.Any(x => x.CourseId == course.Id)
                }).ToList();

            CourseAssignments.AssignedCourses = checkBoxListItems;
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id, string[] selectedCourses)
        {
            await _instructorRepository.UpdateCourses(id, selectedCourses);
            
            return RedirectToPage("./Index");
        }
    }
}