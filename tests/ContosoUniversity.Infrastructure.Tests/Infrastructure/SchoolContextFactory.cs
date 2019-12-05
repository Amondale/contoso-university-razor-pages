using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Infrastructure.Tests.Infrastructure
{
    public class SchoolContextFactory
    {
        public SchoolContext Create()
        {
            var options = new DbContextOptionsBuilder<SchoolContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SchoolContext(options);

            context.Database.EnsureCreated();

            
            context.Departments.AddRange(
                new Department { Id = new Guid("D7A8F435-66D9-E911-B7F0-989096C0B27B"), DepartmentName = "English", Budget = 10000, FoundedDate = new DateTime(2001, 01, 01) },
                new Department { Id = new Guid("D8A8F435-66D9-E911-B7F0-989096C0B27B"),DepartmentName = "Mathematics", Budget = 20000, FoundedDate = new DateTime(2001, 02, 02) },
                new Department { Id = new Guid("D9A8F435-66D9-E911-B7F0-989096C0B27B"), DepartmentName = "Science", Budget = 30000, FoundedDate = new DateTime(2001, 03, 03) }
            );

            context.Instructors.AddRange(
                new Instructor { Id = new Guid("E0A8F435-66D9-E911-B7F0-989096C0B27B"), LastName = "Ruth", FirstName = "Babe", HireDate = new DateTime(1925, 01, 01)},
                new Instructor { Id = new Guid("E1A8F435-66D9-E911-B7F0-989096C0B27B"), LastName = "Gehrig", FirstName = "Lou", HireDate = new DateTime(1925, 02, 02) },
                new Instructor { Id = new Guid("E2A8F435-66D9-E911-B7F0-989096C0B27B"), LastName = "Dimaggio", FirstName = "Joe", HireDate = new DateTime(1925, 03, 03) }
                );

            context.SaveChanges();

            return context;
        }

        public void Destroy(SchoolContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
