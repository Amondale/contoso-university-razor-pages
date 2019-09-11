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
            return await _dbContext.Instructors
                .OrderBy(a=>a.FullName)
                .ToListAsync();
        }

        public async Task<List<Instructor>> GetInstructorsWithChildrenAsync()
        {
            return await _dbContext.Instructors
            .Include(i => i.OfficeAssignment)
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
            return _dbContext.Instructors
                .OrderBy(a => a.FullName)
                .ToList();
        }

        public async Task<Instructor> GetInstructorWithChildrenAsync(int? instructorId)
        {
            return await _dbContext.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .SingleOrDefaultAsync(m => m.ID == instructorId);
        }

        public async Task<Instructor> GetInstructorAsync(int? instructorId)
        {
            return await _dbContext.Instructors
                .SingleOrDefaultAsync(m => m.ID == instructorId);
        }

        public List<AssignedCourseViewModel> GetAssignedCourseData(Instructor instructor)
        {
            var allCourses = _dbContext.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseId));
            return allCourses.Select(course => new AssignedCourseViewModel
            {
                CourseId = course.CourseID,
                CourseTitle = course.Title,
                HasInstructorAssigned = instructorCourses.Contains(course.CourseID)
            }).ToList();
        }
    }
}
