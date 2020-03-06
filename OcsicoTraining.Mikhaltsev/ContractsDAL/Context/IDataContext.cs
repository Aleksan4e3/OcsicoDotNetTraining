using System.Threading.Tasks;
using EntityModels;
using Microsoft.EntityFrameworkCore;

namespace ContractsDAL.Context
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IBaseEntity;
        Task<int> SaveChangesAsync();
    }
}
