using System;
using System.Collections.Generic;

namespace ContosoUniversity.Core.Entities
{
    public class Student : BaseEntity
    {
        public Student()
        {
            Enrollments =  new List<Enrollment>();
        }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public string FullName => $"{LastName} , {FirstName} {MiddleName}";

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}