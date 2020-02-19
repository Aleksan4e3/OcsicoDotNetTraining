using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class OrganizationManagementContextFactory : IDesignTimeDbContextFactory<OrganizationManagementContext>
    {
        public OrganizationManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrganizationManagementContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrganizationManagement;Trusted_Connection=True;");

            return new OrganizationManagementContext(optionsBuilder.Options);
        }
    }
}
