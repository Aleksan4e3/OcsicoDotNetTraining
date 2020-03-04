using System;
using System.Linq;
using System.Threading.Tasks;
using EntityModels;

namespace ShopDAL.Repositories.Contracts
{
    public interface IRepository<T> where T : class, IEntityModel
    {
        IQueryable<T> GetQuery();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task RemoveAsync(Guid id);
    }
}
