using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories
{
    public class DbBaseRepository<T> : IRepository<T> where T : class, IModelEntity
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

        public void RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            Entities.Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            Entities.Update(entity);
        }

        public IQueryable<T> GetQuery() => Entities;
    }
}
