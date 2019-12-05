using System;

namespace ContosoUniversity.Core.Entities
{
    public class CourseAssignment : BaseEntity
    {
        public Guid InstructorId { get; set; }

        public Guid CourseId { get; set; }

        public Instructor Instructor { get; set; }

        public Course Course { get; set; }
    }
}
