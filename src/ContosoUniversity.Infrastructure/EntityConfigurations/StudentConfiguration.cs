using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("StudentGuid");

            builder.Ignore(a => a.FullName);

            builder.Property(a => a.LastName).IsRequired();

            builder.Property(a => a.FirstName).IsRequired();

            builder.Property(a => a.AuditCreateDateTime).IsRequired();

            builder.Property(a => a.AuditUpdateDateTime).IsRequired();

            builder.Property(a => a.RowVersion).HasColumnName("RecordVersion");
        }
    }
}