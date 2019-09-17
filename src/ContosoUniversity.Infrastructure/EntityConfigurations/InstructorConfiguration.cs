using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructor", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("InstructorGuid");

            builder.Ignore(a => a.SelectedCourses);

            builder.Ignore(a => a.FullName);

            builder.Property(a => a.LastName).IsRequired();

            builder.Property(a => a.FirstName).IsRequired();

            builder.Property(a => a.AuditCreateDateTime).IsRequired();

            builder.Property(a => a.AuditUpdateDateTime).IsRequired();
        }
    }
}