using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContosoUniversity.Infrastructure.EntityConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "dbo");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).HasColumnName("DepartmentGuid");

            builder.Property(a => a.Budget).HasColumnType("money");
        }
    }
}
