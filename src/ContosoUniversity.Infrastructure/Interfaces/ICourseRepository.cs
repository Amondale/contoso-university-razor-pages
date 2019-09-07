using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
        Task<List<Course>> GetCoursesAsync();

        Task<Course> GetCourseAsync(int? courseId);

    }
}
