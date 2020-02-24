using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public interface IDataContext
    {
        DbSet<T> Set<T>() where T : class, IModelEntity;

        Task<int> SaveChangesAsync();
    }
}
