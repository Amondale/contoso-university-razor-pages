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
    public class EnrollmentRepository : EfRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _dbContext.Enrollments
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentAsync(int? enrollmentId)
        {
            return await _dbContext.Enrollments
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EnrollmentID == enrollmentId);
        }

        public async Task<List<EnrollmentTotalsViewModel>> GetEnrollmentTotalsAsync()
        {
            var data =
                from student in _dbContext.Students
                group student by student.EnrollmentDate
                into dateGroup
                select new EnrollmentTotalsViewModel()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

            return await data.AsNoTracking().ToListAsync();
        }
    }
}
