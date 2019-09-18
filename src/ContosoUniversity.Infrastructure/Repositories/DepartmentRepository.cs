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
    public class DepartmentRepository : EfRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(SchoolContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await DbContext.Departments
                .OrderBy(a => a.DepartmentName)
                .AsNoTracking()
                .Include(a=>a.Administrator)
                .ToListAsync();
        }


        public List<Department> GetDepartments()
        {
            return DbContext.Departments
                .OrderBy(a => a.DepartmentName)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Department> GetDepartmentAsync(int? departmentId)
        {
            return await DbContext.Departments
                .AsNoTracking()
                .Include(a => a.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentId == departmentId);
        }

        public async Task<List<Department>> GetDepartmentsFromInstructor(Guid? instructorId)
        {
            return await  DbContext.Departments
                .Where(d => d.DepartmentChairId == instructorId)
                .Include(a => a.Administrator)
                .ToListAsync();
        }
    }
}
