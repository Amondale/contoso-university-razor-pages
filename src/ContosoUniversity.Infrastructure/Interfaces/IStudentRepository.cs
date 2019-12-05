using System;
using ContosoUniversity.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;


namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<List<Student>> GetStudentsAsync();

        List<Student> GetStudents();

        Task<Student> GetStudentAsync(Guid? id);

        Task<List<Student>> GetStudentsByFilter(string searchString, string sortOrder);
    }
}