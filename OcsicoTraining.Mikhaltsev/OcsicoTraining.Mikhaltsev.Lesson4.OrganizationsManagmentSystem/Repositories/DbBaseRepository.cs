using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbBaseRepository<T> : IRepository<T> where T : class
    {
        public DbBaseRepository(IDataContext dataContext)
        {
            Entities = dataContext.Set<T>();
        }

        protected DbSet<T> Entities { get; private set; }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            await Entities.AddAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            await Task.Run(() => Entities.Remove(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            await Task.Run(() => Entities.Update(entity));
        }

        public IQueryable<T> GetQuery() => Entities;
    }
}
