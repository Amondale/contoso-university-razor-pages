using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class CourseRepository : EfRepository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await DbContext.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Course> GetCourseAsync(Guid? id)
        {
            return await DbContext.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
