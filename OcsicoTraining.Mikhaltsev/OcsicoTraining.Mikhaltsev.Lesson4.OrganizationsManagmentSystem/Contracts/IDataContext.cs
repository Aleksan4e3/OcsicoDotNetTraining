using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
