using System;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IInstructorRepository : IAsyncRepository<Instructor>
    {
        Task<List<Instructor>> GetInstructorsAsync();

        Task<List<Instructor>> GetInstructorsWithChildrenAsync();

        List<Instructor> GetInstructors();

        Task<Instructor> GetInstructorAsync(Guid? id);

        Task<Instructor> GetInstructorWithChildrenAsync(Guid? id);

        List<AssignedCourseViewModel> GetAssignedCourseData(Instructor instructor);
    }
}
