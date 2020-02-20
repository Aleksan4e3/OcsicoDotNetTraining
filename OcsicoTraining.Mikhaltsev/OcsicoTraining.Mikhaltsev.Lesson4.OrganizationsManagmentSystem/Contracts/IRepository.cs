using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
    }
}
