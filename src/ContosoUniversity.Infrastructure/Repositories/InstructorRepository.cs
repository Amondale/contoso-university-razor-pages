using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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
                .AsNoTracking()
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

        public async Task<List<CourseAssignment>> GetAssignedCourseData(Guid? id)
        {
            return await DbContext.CourseAssignments.Where(i => i.InstructorId == id).AsNoTracking().ToListAsync();
        }

        public async Task UpdateCourses(Guid id, string[] selectedCourses)
        {
            DbContext.CourseAssignments.RemoveRange(DbContext.CourseAssignments.Where(i => i.InstructorId == id));
            
            await DbContext.SaveChangesAsync();

            foreach (var temp in selectedCourses)
            {
                DbContext.CourseAssignments.Add(new CourseAssignment{InstructorId = id, CourseId = Guid.Parse(temp)});
            }
            await DbContext.SaveChangesAsync();

        }
    }
}
