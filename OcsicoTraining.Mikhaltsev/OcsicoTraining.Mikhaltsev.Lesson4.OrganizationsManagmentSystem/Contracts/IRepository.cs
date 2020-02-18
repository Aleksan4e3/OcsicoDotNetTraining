using System.Collections.Generic;
using System.Threading.Tasks;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        void RemoveAsync(T entity);
        void UpdateAsync(T entity);
        List<T> GetAll();
    }
}
