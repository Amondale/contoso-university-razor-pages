using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;
using ContosoUniversity.Infrastructure.DbContexts;
using ContosoUniversity.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace ContosoUniversity.Infrastructure.Repositories
{
    public class StudentRepository : EfRepository<Student>, IStudentRepository
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await DbContext.Students
                .OrderBy(a => a.FullName)
                .AsNoTracking()
                .ToListAsync();
        }

        public List<Student> GetStudents()
        {
            return DbContext.Students
                .OrderBy(a => a.FullName)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Student> GetStudentAsync(Guid? id)
        {
            return await DbContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Student>> GetStudentsByFilter(string searchString, string sortOrder)
        {
            IQueryable<Student> enumerableStudents;

            if (!string.IsNullOrEmpty(searchString))
            {
                enumerableStudents = DbContext.Students
                                    .Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
            }
            else
            {
                enumerableStudents = DbContext.Students;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    return await enumerableStudents.OrderByDescending(s => s.LastName).ToListAsync();
                case "Date":
                    return await enumerableStudents.OrderBy(s => s.EnrollmentDate).ToListAsync();
                case "date_desc":
                    return await enumerableStudents.OrderByDescending(s => s.EnrollmentDate).ToListAsync();
                default:
                    return await enumerableStudents.OrderBy(s => s.LastName).ToListAsync();
            }
        }
    }
}
