using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class OrganizationManagementContext : DbContext
    {
        public OrganizationManagementContext(DbContextOptions<OrganizationManagementContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
