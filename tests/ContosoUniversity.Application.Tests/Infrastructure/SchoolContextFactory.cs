using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Application.Tests.Infrastructure
{
    public class SchoolContextFactory
    {
        public static SchoolContext Create()
        {
            var options = new DbContextOptionsBuilder<SchoolContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new SchoolContext(options);

            context.Database.EnsureCreated();

            
            context.Departments.AddRange(
                new Department { Name = "English", Budget = 10000, StartDate = new DateTime(2001, 01, 01) },
                new Department { Name = "Mathematics", Budget = 20000, StartDate = new DateTime(2001, 02, 02) },
                new Department { Name = "Science", Budget = 30000, StartDate = new DateTime(2001, 03, 03) }
            );

            context.Instructors.AddRange(
                new Instructor { LastName = "Ruth", FirstMidName = "Babe", HireDate = new DateTime(1925, 01, 01)},
                new Instructor { LastName = "Gehrig", FirstMidName = "Lou", HireDate = new DateTime(1925, 02, 02) },
                new Instructor { LastName = "Dimaggio", FirstMidName = "Joe", HireDate = new DateTime(1925, 03, 03) }
                );

            context.SaveChanges();

            return context;
        }

        public static void Destroy(SchoolContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
