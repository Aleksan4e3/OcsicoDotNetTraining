using System.Linq;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts
{
    public interface IRepository<T> where T : class, IModelEntity
    {
        Task AddAsync(T entity);
        void RemoveAsync(T entity);
        void UpdateAsync(T entity);
        IQueryable<T> GetQuery();
    }
}
