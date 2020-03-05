using System;
using System.Linq;
using System.Threading.Tasks;
using EntityModels;
using Microsoft.EntityFrameworkCore;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ShopDAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntityModel
    {
        public Repository(IDataContext dataContext)
        {
            EntitiesSet = dataContext.Set<T>();
        }

        protected DbSet<T> EntitiesSet { get; }

        public IQueryable<T> GetQuery() => EntitiesSet;

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            await EntitiesSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            EntitiesSet.Update(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            EntitiesSet.Attach(entity);
            EntitiesSet.Remove(entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await EntitiesSet.FirstOrDefaultAsync(x => x.Id == id);
            Remove(entity);
        }
    }
}