using ContosoUniversity.Application.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ContosoUniversity.Application.ViewModels
{
    public class DepartmentViewModel : IValidatableObject
    {
        public DepartmentViewModel()
        {
            
        }

        public DepartmentViewModel(DateTime auditCreateDateTime, DateTime auditUpdateDateTime, bool isActive, byte[] rowVersion)
        {
            AuditCreateDateTime = auditCreateDateTime;
            AuditUpdateDateTime = auditUpdateDateTime;
            IsActive = isActive;
            RowVersion = rowVersion;
        }


        [Display(Name = "Department Id")]
        public Guid Id { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Chair Id")]
        public Guid? DepartmentChairId { get; set; }

        [Display(Name = "Department Chair Name")]
        public string DepartmentChairName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Founded")]
        public DateTime FoundedDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        public DateTime AuditCreateDateTime { get; }

        public DateTime AuditUpdateDateTime { get; }

        public bool IsActive { get; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new DepartmentViewModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
