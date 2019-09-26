using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }

        public int Credits { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}