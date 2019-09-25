using System;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class InstructorRepository : EfRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Instructor>> GetInstructorsAsync()
        {
            return await DbContext.Instructors
                .OrderBy(a=>a.FullName)
                .ToListAsync();
        }

        public async Task<List<Instructor>> GetInstructorsWithChildrenAsync()
        {
            return await DbContext.Instructors
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .ThenInclude(i => i.Department)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .ThenInclude(i => i.Enrollments)
                .ThenInclude(i => i.Student)
            .OrderBy(i => i.LastName)
                .ToListAsync();
        }

        public List<Instructor> GetInstructors()
        {
            return  DbContext.Instructors
                .OrderBy(a => a.FullName)
                .ToList();
        }

        public async Task<Instructor> GetInstructorAsync(Guid? id)
        {
            return await DbContext.Instructors
                .Include(i => i.CourseAssignments)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Instructor> GetInstructorWithChildrenAsync(Guid? id)
        {
            return await DbContext.Instructors
                .Include(i => i.CourseAssignments)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public List<AssignedCourseViewModel> GetAssignedCourseData(Instructor instructor)
        {
            var allCourses = DbContext.Courses;
            var instructorCourses = new HashSet<Guid>(instructor.CourseAssignments.Select(c => c.CourseId));
            return allCourses.Select(course => new AssignedCourseViewModel
            {
                CourseId = course.Id,
                CourseTitle = course.Title,
                HasInstructorAssigned = instructorCourses.Contains(course.Id)
            }).ToList();
        }
    }
}
