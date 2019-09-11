using ContosoUniversity.Core.Entities;
using System.Collections.Generic;

namespace ContosoUniversity.Application.ViewModels
{
    public class InstructorsIndexViewModel
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
