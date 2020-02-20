using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.DbContexts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;
using OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static async Task Main()
        {
            var serviceProvider = GetServiceProvider();
            var organizationService = serviceProvider.GetService<IOrganizationService>();
            var employeeService = serviceProvider.GetService<IEmployeeService>();
            var roleService = serviceProvider.GetService<IRoleService>();

            var developerRole = new Role { Name = "Developer" };
            var qaRole = new Role { Name = "QA" };
            var managerRole = new Role { Name = "Manager" };
            var orgOcsico = await organizationService.CreateOrganizationAsync("Ocsico");
            var orgMicrosoft = await organizationService.CreateOrganizationAsync("Microsoft");
            var employeeAlex = new Employee { Name = "Alex" };
            var employeeIvan = new Employee { Name = "Ivan" };
            var employeeVadim = new Employee { Name = "Vadim" };

            await roleService.CreateRoleAsync(developerRole);
            await roleService.CreateRoleAsync(qaRole);
            await roleService.CreateRoleAsync(managerRole);
            await employeeService.CreateEmployeeAsync(employeeAlex);
            await employeeService.CreateEmployeeAsync(employeeIvan);
            await employeeService.CreateEmployeeAsync(employeeVadim);


            await organizationService.AddEmployeeToOrganizationAsync(orgOcsico.Id, employeeAlex.Id, qaRole.Id);
            await organizationService.AddEmployeeToOrganizationAsync(orgOcsico.Id, employeeIvan.Id, developerRole.Id);
            await organizationService.AddEmployeeToOrganizationAsync(orgMicrosoft.Id, employeeVadim.Id, managerRole.Id);
            await organizationService.AssignNewRoleAsync(orgMicrosoft.Id, employeeVadim.Id, developerRole.Id, null);
            await employeeService.RemoveEmployeeAsync(employeeIvan.Id);
            //await roleService.RemoveRoleAsync(qaRole);


            var employees = await organizationService.GetEmployeesAsync(orgOcsico.Id);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id} {employee.Name}");
            }

            foreach (var role in await roleService.GetAllRolesAsync())
            {
                Console.WriteLine($"{role.Id} {role.Name}");
            }
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            serviceCollection.AddDbContext<OrganizationManagementContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OrganizationManagement;Trusted_Connection=True;")
                    .UseLazyLoadingProxies()
                    .EnableSensitiveDataLogging());

            containerBuilder.Populate(serviceCollection);
            containerBuilder.RegisterType<DataContext>().As<IDataContext>();
            containerBuilder.RegisterType<DbRoleRepository>().As<IRoleRepository>();
            containerBuilder.RegisterType<DbEmployeeRepository>().As<IEmployeeRepository>();
            containerBuilder.RegisterType<DbOrganizationRepository>().As<IOrganizationRepository>();
            containerBuilder.RegisterType<DbEmployeeOrganizationRoleRepository>().As<IEmployeeOrganizationRoleRepository>();
            containerBuilder.RegisterType<RoleService>().As<IRoleService>();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();
            containerBuilder.RegisterType<OrganizationService>().As<IOrganizationService>();


            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        private static void RunUserPrintTask()
        {
            var user = new User { Name = "Alex", PhoneNumber = "+375(44)744-52-41", Salary = 1000 };

            Console.WriteLine(user.PrintInfo(new NamePrinter()));
            Console.WriteLine(user.PrintInfo(new NameSalaryPrinter()));
            Console.WriteLine(user.PrintInfo(new AllUserInfoPrinter()));
        }
    }
}
