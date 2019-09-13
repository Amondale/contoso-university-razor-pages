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

            builder.HasKey(a => a.ID);

            builder.Ignore(a => a.SelectedCourses);

            builder.Property(a => a.LastName).IsRequired();

            builder.Property(a => a.FirstMidName).IsRequired();

            builder.Property(a => a.FirstMidName).HasColumnName("FirstName");
        }
    }
}