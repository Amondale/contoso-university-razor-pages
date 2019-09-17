using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Entities
{
    public class Department : BaseEntity
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime FoundedDate { get; set; }

        public Guid? DepartmentChairId { get; set; }

        public Instructor Administrator { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
