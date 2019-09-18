using ContosoUniversity.Common;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Repositories;
using ContosoUniversity.Infrastructure.Tests.Infrastructure;
using System;
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
            var courseTitle = StringGenerator.GenerateRandomString(15);

            var newCourse = new Course
            {
                Id = new Guid(),
                Title = courseTitle,
                Credits = 3,
                DepartmentId = department
            };

            var savedCourse = courseRepository.AddAsync(newCourse);

            Assert.Equal(courseTitle, savedCourse.Result.Title);
            Assert.Equal(3, savedCourse.Result.Credits);
            Assert.Equal(department, savedCourse.Result.DepartmentId);
        }

    }
}
