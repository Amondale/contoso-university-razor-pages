using System;
using ContosoUniversity.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IAsyncRepository<Department>, IRepository<Department>
    {
        Task<List<Department>> GetDepartmentsAsync();

        List<Department> GetDepartments();

        Task<Department> GetDepartmentAsync(int? departmentId);

        Task<List<Department>> GetDepartmentsFromInstructor(Guid? instructorId);
    }
}
