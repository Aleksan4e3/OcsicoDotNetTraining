using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrganizationManagement;Trusted_Connection=True;")
                .EnableSensitiveDataLogging();

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
