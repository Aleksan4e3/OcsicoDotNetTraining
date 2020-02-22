using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services.Contracts;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    public class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            serviceCollection.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrganizationManagement;Trusted_Connection=True;")
                    .UseLazyLoadingProxies()
                    .EnableSensitiveDataLogging());

            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterType<DataContext>().As<IDataContext>();
            containerBuilder.RegisterType<DbRoleRepository>().As<IRoleRepository>();
            containerBuilder.RegisterType<DbEmployeeRepository>().As<IEmployeeRepository>();
            containerBuilder.RegisterType<DbOrganizationRepository>().As<IOrganizationRepository>();
            containerBuilder.RegisterType<DbEmployeeRoleRepository>().As<IEmployeeRoleRepository>();
            containerBuilder.RegisterType<RoleService>().As<IRoleService>();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();
            containerBuilder.RegisterType<OrganizationService>().As<IOrganizationService>();

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
