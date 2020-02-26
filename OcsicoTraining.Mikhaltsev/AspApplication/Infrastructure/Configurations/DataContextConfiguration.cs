using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Infrastructure.Configurations
{
    public static class DataContextConfiguration
    {
        public static void ConfigureDataContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDataContext, DataContext>();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"])
                        .UseLazyLoadingProxies());
        }
    }
}
