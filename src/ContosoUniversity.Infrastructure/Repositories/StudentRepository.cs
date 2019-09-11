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
            return await _dbContext.Students
                .OrderBy(a => a.FullName)
                .AsNoTracking()
                .ToListAsync();
        }

        public List<Student> GetStudents()
        {
            return _dbContext.Students
                .OrderBy(a => a.FullName)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Student> GetStudentAsync(int? studentId)
        {
            return await _dbContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == studentId);
        }

        public async Task<IPagedList<Student>> GetStudentsByFilter(string searchString, string sortOrder, int? pageIndex)
        {
            IQueryable<Student> enumerableStudents;

            if (!string.IsNullOrEmpty(searchString))
            {
                enumerableStudents = _dbContext.Students
                                    .Where(s => s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
            }
            else
            {
                enumerableStudents = _dbContext.Students;
            }

            switch (sortOrder)
            {
                case "name_desc":
                    return await enumerableStudents.OrderByDescending(s => s.LastName).ToPagedListAsync(pageIndex, 10);
                case "Date":
                    return await enumerableStudents.OrderBy(s => s.EnrollmentDate).ToPagedListAsync(pageIndex, 10);
                case "date_desc":
                    return await enumerableStudents.OrderByDescending(s => s.EnrollmentDate).ToPagedListAsync(pageIndex, 10);
                default:
                    return await enumerableStudents.OrderBy(s => s.LastName).ToPagedListAsync(pageIndex, 10);
            }
        }
    }
}
