using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IRepository<T> where T : class
    {
        void AddAsync(T entity);
        void RemoveAsync(T entity);
        void UpdateAsync(T entity);
        List<T> GetAll();
    }
}
