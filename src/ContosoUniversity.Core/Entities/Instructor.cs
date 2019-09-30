using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Entities
{
    public class Instructor : BaseEntity
    {
        public Instructor()
        {
            CourseAssignments = new List<CourseAssignment>();
        }

        public string Prefix { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string OfficeLocation { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{LastName} , {FirstName} {MiddleName}";

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}