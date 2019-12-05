using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollment", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("EnrollmentGuid");

            builder.Property(a => a.CourseId).HasColumnName("CourseGuid");

            builder.Property(a => a.StudentId).HasColumnName("StudentGuid");

            builder.Property(a => a.RowVersion).HasColumnName("RecordVersion");

            builder.HasOne(a => a.Course)
                .WithMany(b => b.Enrollments)
                .HasForeignKey(a => a.CourseId);

            builder.HasOne(a => a.Student)
                .WithMany(b => b.Enrollments)
                .HasForeignKey(a => a.StudentId);
        }
    }
}
