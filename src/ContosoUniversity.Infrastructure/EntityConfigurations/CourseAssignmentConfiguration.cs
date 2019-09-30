using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
    {
        public void Configure(EntityTypeBuilder<CourseAssignment> builder)
        {
            builder.ToTable("CourseAssignment", "dbo");

            builder.Ignore(b => b.Id);

            builder.Property(a => a.CourseId).HasColumnName("CourseGuid");

            builder.Property(a => a.InstructorId).HasColumnName("InstructorGuid");

            builder.Property(a => a.RowVersion).HasColumnName("RecordVersion");

            builder.HasKey(a => new {CourseID = a.CourseId, InstructorID = a.InstructorId });

            builder.Property(a => a.AuditCreateDateTime).IsRequired();

            builder.Property(a => a.AuditUpdateDateTime).IsRequired();

            builder.HasOne(a => a.Course)
                .WithMany(b=>b.CourseAssignments)
                .HasForeignKey(a => a.CourseId);

            builder.HasOne(a => a.Instructor)
                .WithMany(c=>c.CourseAssignments)
                .HasForeignKey(a => a.InstructorId);
        }
    }
}
