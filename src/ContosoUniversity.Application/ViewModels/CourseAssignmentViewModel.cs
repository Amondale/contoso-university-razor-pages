using System;
using System.Collections.Generic;

namespace ContosoUniversity.Application.ViewModels
{
    public class CourseAssignmentViewModel
    {
        public CourseAssignmentViewModel()
        {
            
        }

        public Guid InstructorId { get; set; }

        public List<CheckBoxListItem> AssignedCourses { get; set; }
    }
}
