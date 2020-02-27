using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson9.AspOrganizations.Infrastructure.Configurations
{
    public static class IdentityConfiguration
    {
        public static void ConfigureDataContext(this IServiceCollection services) =>
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationContext>();
    }
}
