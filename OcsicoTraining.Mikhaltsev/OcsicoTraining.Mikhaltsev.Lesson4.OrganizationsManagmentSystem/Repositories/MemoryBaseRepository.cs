using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public abstract class MemoryBaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> Entities;

        protected MemoryBaseRepository() => Entities = new List<T>();

        public void AddAsync(T entity) => Entities.Add(entity);

        public List<T> GetAll() => Entities;

        public virtual void RemoveAsync(T entity) => Entities.Remove(entity);

        public virtual void UpdateAsync(T entity)
        {
            _ = Entities.Remove(entity);
            Entities.Add(entity);
        }
    }
}
