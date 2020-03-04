using System.Threading.Tasks;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ShopDAL.Context
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IEntityModel;
        Task<int> SaveChangesAsync();
    }
}
