using System.Collections.Generic;
using System.Threading.Tasks;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public abstract class MemoryBaseRepository<T> //: IRepository<T> where T : class
    {
        protected readonly List<T> Entities;

        protected MemoryBaseRepository() => Entities = new List<T>();

        public async Task AddAsync(T entity) => await Task.Run(() => Entities.Add(entity));

        public async Task<List<T>> GetAllAsync() => await Task.Run(() => Entities);

        public virtual async Task RemoveAsync(T entity) => await Task.Run(() => Entities.Remove(entity));

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Entities.Remove(entity));
            await Task.Run(() => Entities.Add(entity));
        }
    }
}
