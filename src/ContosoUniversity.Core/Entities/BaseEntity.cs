using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Core.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime AuditCreateDateTime { get; set; } = DateTime.Now;

        public DateTime AuditUpdateDateTime { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
