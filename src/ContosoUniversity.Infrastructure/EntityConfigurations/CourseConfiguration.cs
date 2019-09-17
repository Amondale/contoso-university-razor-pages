using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.CourseId).UseSqlServerIdentityColumn();

            builder.Property(a => a.Id).HasColumnName("CourseGuid");

            builder.Property(a => a.DepartmentId).HasColumnName("DepartmentGuid");

            builder.Property(a => a.RowVersion).HasColumnName("RecordVersion");

            builder.HasOne(a => a.Department)
                .WithMany(b => b.Courses)
                .HasForeignKey(a => a.DepartmentId);
        }
    }
}
