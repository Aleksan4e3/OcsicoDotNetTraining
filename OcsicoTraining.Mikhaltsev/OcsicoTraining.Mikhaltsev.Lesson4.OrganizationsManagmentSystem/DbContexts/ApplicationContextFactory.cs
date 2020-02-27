using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrganizationManagement;Trusted_Connection=True;");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
