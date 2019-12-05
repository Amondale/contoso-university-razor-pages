using ContosoUniversity.Application.Validators;
using ContosoUniversity.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoUniversity.Application.ViewModels
{
    public class InstructorViewModel : IValidatableObject
    {
        public InstructorViewModel()
        {
        }
        public InstructorViewModel(DateTime auditCreateDateTime, DateTime auditUpdateDateTime, bool isActive, byte[] rowVersion)
        {
            AuditCreateDateTime = auditCreateDateTime;
            AuditUpdateDateTime = auditUpdateDateTime;
            IsActive = isActive;
            RowVersion = rowVersion;
        }

        [Display(Name = "Instructor Id")]
        public Guid Id { get; set; }

        [Display(Name = "Prefix")]
        public string Prefix { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Suffix")]
        public string Suffix { get; set; }

        [Display(Name = "Office Location")]
        public string OfficeLocation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{LastName} , {FirstName} {MiddleName}";

        public DateTime AuditCreateDateTime { get; }

        public DateTime AuditUpdateDateTime { get; }

        public bool IsActive { get; }

        [Timestamp]
        public byte[] RowVersion { get; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new InstructorCreateViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
