using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;
using OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static void Main()
        {
            var orgService = GetServiceProvider().GetService<IOrganizationService>();
            var empService = GetServiceProvider().GetService<IEmployeeService>();
            var roleService = GetServiceProvider().GetService<IRoleService>();

            var role1 = new Role { Id = 1, Name = "Developer" };
            var role2 = new Role { Id = 2, Name = "QA" };
            var role3 = new Role { Id = 3, Name = "Manager" };

            roleService.AddRole(role1);
            roleService.AddRole(role2);
            roleService.AddRole(role3);

            orgService.AddOrganization(1, "Ocsico");
            orgService.AddOrganization(2, "Microsoft");

            var emp1 = empService.CreateEmployee(1, "Alex");
            var emp2 = empService.CreateEmployee(2, "Ivan");
            var emp3 = empService.CreateEmployee(3, "Vadim");

            orgService.AddEmployee(1, emp1, 2);
            orgService.AddEmployee(1, emp2, 1);
            orgService.AddEmployee(2, emp3, 3);
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);
            _ = containerBuilder.RegisterType<RoleRepository>().As<IRoleRepository>();
            _ = containerBuilder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            _ = containerBuilder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>();
            _ = containerBuilder.RegisterType<EmployeeOrganizationRoleRepository>().As<IEmployeeOrganizationRoleRepository>();
            _ = containerBuilder.RegisterType<RoleService>().As<IRoleService>();
            _ = containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();
            _ = containerBuilder.RegisterType<OrganizationService>().As<IOrganizationService>();

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
