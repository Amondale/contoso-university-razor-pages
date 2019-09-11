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
            return await _dbContext.Departments
                .OrderBy(a => a.Name)
                .AsNoTracking()
                .Include(a=>a.Administrator)
                .ToListAsync();
        }


        public List<Department> GetDepartments()
        {
            return _dbContext.Departments
                .OrderBy(a => a.Name)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Department> GetDepartmentAsync(int? departmentId)
        {
            return await _dbContext.Departments
                .AsNoTracking()
                .Include(a => a.Administrator)
                .FirstOrDefaultAsync(m => m.DepartmentID == departmentId);
        }

        public async Task<List<Department>> GetDepartmentsFromInstructor(int? instructorId)
        {
            return await  _dbContext.Departments
                .Where(d => d.InstructorID == instructorId)
                .Include(a => a.Administrator)
                .ToListAsync();
        }
    }
}
