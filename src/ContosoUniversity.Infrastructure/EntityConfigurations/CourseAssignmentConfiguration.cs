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

            builder.Property(a => a.CourseId).HasColumnName("CourseID");
            builder.Property(a => a.InstructorId).HasColumnName("InstructorID");

            builder.HasKey(a => new {CourseID = a.CourseId, InstructorID = a.InstructorId });

        }
    }
}
