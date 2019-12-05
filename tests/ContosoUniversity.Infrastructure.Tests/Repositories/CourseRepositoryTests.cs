using ContosoUniversity.Common;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Repositories;
using ContosoUniversity.Infrastructure.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            var department = new Guid("D7A8F435-66D9-E911-B7F0-989096C0B27B");
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

        [Fact]
        public void GetAllCourses_Succeeds()
        {
            var courseRepository = new CourseRepository(_factory);
            var department = new Guid("D8A8F435-66D9-E911-B7F0-989096C0B27B");
            CreateCourses(courseRepository, 5, department);
            
            var courses =  courseRepository.GetCoursesAsync();
            
            Assert.Equal(5, courses.Result.Count);
        }

        [Fact]
        public void GetAllCoursesAndDepartments_Succeeds()
        {
            var courseRepository = new CourseRepository(_factory);
            var department = new Guid("D9A8F435-66D9-E911-B7F0-989096C0B27B");
            CreateCourses(courseRepository, 7, department);
            
            var courses = courseRepository.GetCoursesAndDepartmentsAsync();
            
            Assert.Equal(7, courses.Result.Count);

            foreach (var course in courses.Result)
            {
                Assert.NotNull(course.Department);
            }


        }

        private async void CreateCourses(CourseRepository courseRepository, int number, Guid department)
        {
            for (var i = 0; i < number; i++)
            {
                var courseTitle = StringGenerator.GenerateRandomString(15);
                var newCourse = new Course
                {
                    Id = new Guid(),
                    Title = courseTitle,
                    Credits = 3,
                    DepartmentId = department
                };
                await courseRepository.AddAsync(newCourse);
            }
        }


    }
}
