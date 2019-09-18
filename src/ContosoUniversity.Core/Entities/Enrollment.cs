using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Entities
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment : BaseEntity
    {
        public int EnrollmentId { get; set; }

        public Guid CourseId { get; set; }

        public Guid StudentId { get; set; }

        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}