using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class OrganizationManagementContext : DbContext
    {
        public OrganizationManagementContext(DbContextOptions<OrganizationManagementContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
