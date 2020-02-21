using System;
using System.Collections.Generic;
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

        protected DbSet<T> Entities { get; }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            await Entities.AddAsync(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }

            Entities.Attach(entity);
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Update(T entity)
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
