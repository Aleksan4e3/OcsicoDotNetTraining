using System;
using System.Linq;
using System.Threading.Tasks;
using EntityModels;

namespace ContractsDAL.Repositories
{
    public interface IRepository<T> where T : class, IBaseEntity
    {
        IQueryable<T> GetQuery();
        ValueTask<T> GetAsync(Guid id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task RemoveAsync(Guid id);
    }
}
