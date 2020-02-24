using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace AspApplication.Infrastructure.Configurations
{
    public static class DependencyResolverConfiguration
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, DbEmployeeRepository>();
            services.AddTransient<IOrganizationRepository, DbOrganizationRepository>();
            services.AddTransient<IEmployeeRoleRepository, DbEmployeeRoleRepository>();
            services.AddTransient<IRoleRepository, DbRoleRepository>();

            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<IRoleService, RoleService>();
        }
    }
}
