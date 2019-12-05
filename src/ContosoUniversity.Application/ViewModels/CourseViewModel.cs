using ContosoUniversity.Application.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoUniversity.Application.ViewModels
{
    public class CourseViewModel : IValidatableObject
    {
        public CourseViewModel()
        {

        }

        public CourseViewModel(Guid departmentId, DateTime auditCreateDateTime, DateTime auditUpdateDateTime, bool isActive, byte[] rowVersion)
        {
            AuditCreateDateTime = auditCreateDateTime;
            AuditUpdateDateTime = auditUpdateDateTime;
            IsActive = isActive;
            RowVersion = rowVersion;
            DepartmentId = departmentId;
        }

        [Display(Name = "Course Id")]
        public Guid Id { get; set; }

        [Display(Name = "Course Title")]
        public string Title { get; set; }

        [Display(Name = "Credits")]
        public int Credits { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Id")]
        public Guid DepartmentId { get; }

        public DateTime AuditCreateDateTime { get; }

        public DateTime AuditUpdateDateTime { get; }

        public bool IsActive { get; }

        [Timestamp]
        public byte[] RowVersion { get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new CourseViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
