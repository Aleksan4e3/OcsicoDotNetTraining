using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class DataContext : IDataContext
    {
        private readonly OrganizationManagementContext organizationManagementContext;

        public DataContext(OrganizationManagementContext organizationManagementContext)
        {
            this.organizationManagementContext = organizationManagementContext;
        }

        public DbSet<T> Set<T>() where T : class => organizationManagementContext.Set<T>();

        public Task<int> SaveChangesAsync() => organizationManagementContext.SaveChangesAsync();
    }
}