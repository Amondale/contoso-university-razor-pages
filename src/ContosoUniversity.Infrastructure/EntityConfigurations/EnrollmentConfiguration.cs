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

            builder.Property(a => a.EnrollmentId).UseSqlServerIdentityColumn();

            builder.Property(a => a.Id).HasColumnName("EnrollmentGuid");



        }
    }
}
