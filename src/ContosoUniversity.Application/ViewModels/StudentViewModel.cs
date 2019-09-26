using ContosoUniversity.Application.Validators;
using ContosoUniversity.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoUniversity.Application.ViewModels
{
    public class StudentViewModel: IValidatableObject
    {
        public StudentViewModel()
        {
            
        }
        public StudentViewModel(DateTime auditCreateDateTime, DateTime auditUpdateDateTime, bool isActive, byte[] rowVersion)
        {
            AuditCreateDateTime = auditCreateDateTime;
            AuditUpdateDateTime = auditUpdateDateTime;
            IsActive = isActive;
            RowVersion = rowVersion;
        }

        [Display(Name = "Student Id")]
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{LastName} , {FirstName} {MiddleName}";

        public DateTime AuditCreateDateTime { get; }

        public DateTime AuditUpdateDateTime { get; }

        public bool IsActive { get; }

        [Timestamp]
        public byte[] RowVersion { get; }

        public ICollection<Enrollment> Enrollments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new StudentViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
