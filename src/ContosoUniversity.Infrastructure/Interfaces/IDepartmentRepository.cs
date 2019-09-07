using ContosoUniversity.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IDepartmentRepository : IAsyncRepository<Department>
    {
        Task<List<Department>> GetDepartmentsAsync();

        List<Department> GetDepartments();

        Task<Department> GetDepartmentAsync(int? departmentId);

    }
}
