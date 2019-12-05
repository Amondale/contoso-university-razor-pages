using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContosoUniversity.Application.ViewModels;
using ContosoUniversity.Core.Entities;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IEnrollmentRepository : IAsyncRepository<Enrollment>
    {
        Task<List<Enrollment>> GetEnrollmentsAsync();

        Task<Enrollment> GetEnrollmentAsync(Guid? id);

        Task<List<EnrollmentTotalsViewModel>> GetEnrollmentTotalsAsync();
    }
}