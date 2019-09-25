using System;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ContosoUniversity.Web.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly IInstructorRepository _repository;

        public IndexModel(IInstructorRepository repository)
        {
            _repository = repository;
        }
        public InstructorsIndexViewModel InstructorsIndex { get; set; }
        public Guid InstructorId { get; private set; }
        public Guid CourseId { get; private set; }

        public async Task OnGetAsync(Guid? id, Guid? courseId)
        {
            InstructorsIndex = new InstructorsIndexViewModel
            {
                Instructors = await _repository.GetInstructorsWithChildrenAsync()
            };

            if (id != null)
            {
                InstructorId = id.Value;
                var instructor = InstructorsIndex.Instructors.Single(i => i.Id == id.Value);
                InstructorsIndex.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseId != null)
            {
                CourseId = courseId.Value;
                InstructorsIndex.Enrollments = InstructorsIndex.Courses.Single(x => x.Id == courseId).Enrollments;
            }
        }
    }
}
