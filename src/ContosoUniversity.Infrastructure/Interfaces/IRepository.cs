using ContosoUniversity.Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ContosoUniversity.Infrastructure.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        EntityEntry<T> GetDbEntityEntry(T entity);
    }
}
