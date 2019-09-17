using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using ContosoUniversity.Infrastructure.Repositories;
using ContosoUniversity.Infrastructure.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContosoUniversity.Infrastructure.Tests.Repositories
{
    public class CourseRepositoryTests
    {
        private readonly SchoolContext _factory;

        public CourseRepositoryTests()
        {
            _factory = new SchoolContextFactory().Create();
        }

        [Fact]
        public void CreateCourseSucceeds()
        {
            var courseRepository = new CourseRepository(_factory);
            var department = new Guid("D8A8F435-66D9-E911-B7F0-989096C0B27B");
            var newCourse = new Course()
            {
                Id = new Guid(),
                Title = "Test Course",
                Credits = 3,
                DepartmentId = department
            };

            var savedCourse = courseRepository.AddAsync(newCourse);

            Assert.Equal("Test Course", savedCourse.Result.Title);
            Assert.Equal(3, savedCourse.Result.Credits);
            Assert.Equal(department, savedCourse.Result.DepartmentId);
            Assert.NotNull(savedCourse.Result.CourseId);
        }

    }
}
