using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Entities
{
    public abstract class BaseEntity : IValidatableObject 
    {
        public Guid Id { get; set; }

        public DateTime AuditCreateDateTime { get; set; } = DateTime.Now;

        public DateTime AuditUpdateDateTime { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [Timestamp]
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Is the model in an added state?
        /// </summary>
        public virtual bool IsAdd => Id.Equals(default(Guid));

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new List<ValidationResult>();
        }
    }
}
