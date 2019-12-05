using System;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Course>> GetCoursesAndDepartmentsAsync()
        {
            return await DbContext.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .AsNoTracking()
                .OrderBy(d=> d.Department.DepartmentName)
                .ThenBy(c=>c.Title)
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

        public IReadOnlyList<Course> ListAll()
        {
            return DbContext.Courses
                .AsNoTracking()
                .Include(c => c.Department)
                .OrderBy( a=> a.Department.DepartmentName)
                .ThenBy(b => b.Title)
                .ToList();
        }

    }
}
