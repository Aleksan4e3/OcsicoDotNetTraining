using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Configurations;
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

            var developerRole = new Role { Name = "Developer" };
            var qaRole = new Role { Name = "QA" };
            var managerRole = new Role { Name = "Manager" };
            var orgOcsico = orgService.CreateOrganization("Ocsico");
            var orgMicrosoft = orgService.CreateOrganization("Microsoft");
            var employeeAlex = new Employee { Name = "Alex" };
            var employeeIvan = new Employee { Name = "Ivan" };
            var employeeVadim = new Employee { Name = "Vadim" };

            roleService.CreateRole(developerRole);
            roleService.CreateRole(qaRole);
            roleService.CreateRole(managerRole);
            empService.CreateEmployee(employeeAlex);
            empService.CreateEmployee(employeeIvan);
            empService.CreateEmployee(employeeVadim);
            orgService.AddEmployeeToOrganization(orgOcsico.Id, employeeAlex.Id, qaRole.Id);
            orgService.AddEmployeeToOrganization(orgOcsico.Id, employeeIvan.Id, developerRole.Id);
            orgService.AddEmployeeToOrganization(orgMicrosoft.Id, employeeVadim.Id, managerRole.Id);
            orgService.AssignNewRole(orgMicrosoft.Id, employeeVadim.Id, developerRole.Id);

            qaRole.Name = "Tester";
            roleService.UpdateRole(qaRole);

            var employees = orgService.GetEmployees(orgOcsico.Id);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id} {employee.Name}");
            }

            foreach (var role in roleService.GetAllRoles())
            {
                Console.WriteLine($"{role.Id} {role.Name}");
            }
        }

        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(serviceCollection);
            _ = containerBuilder.RegisterType<EmployeeConfiguration>().As<IEmployeeConfiguration>();
            _ = containerBuilder.RegisterType<OrganizationConfiguration>().As<IOrganizationConfiguration>();
            _ = containerBuilder.RegisterType<EmployeeOrganizationRolesConfiguration>().As<IEmployeeOrganizationRoleConfiguration>();
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
