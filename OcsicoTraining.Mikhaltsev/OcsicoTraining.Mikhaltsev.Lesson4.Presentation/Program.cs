using System;
using Autofac;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;
using OcsicoTraining.Mikhaltsev.Lesson4.UserPrinter;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static void Main() => Initialize();

        private static void Initialize()
        {
            //when testing, FILES with entities DON`T delete, but DELETE CONTENTS inside the file
            var builder = new ContainerBuilder();

            _ = builder.RegisterGeneric(typeof(FileRepository<>)).As(typeof(IRepository<>));
            _ = builder.RegisterType<OrganizationService>();
            _ = builder.RegisterType<EmployeeService>();
            _ = builder.RegisterType<RoleService>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var orgService = scope.Resolve<OrganizationService>();
                var empService = scope.Resolve<EmployeeService>();
                var roleService = scope.Resolve<RoleService>();

                var role1 = new Role { Id = 1, Name = "Developer" };
                var role2 = new Role { Id = 2, Name = "QA" };
                var role3 = new Role { Id = 3, Name = "Manager" };

                roleService.AddRole(role1);
                roleService.AddRole(role2);
                roleService.AddRole(role3);

                role2.Name = "Lead";
                roleService.UpdateRole(role2);
                roleService.RemoveRole(role3);

                orgService.AddOrganization(1, "Ocsico");
                orgService.AddOrganization(2, "Microsoft");

                var emp1 = empService.CreateEmployee(1, "Alex");
                var emp2 = empService.CreateEmployee(2, "Ivan");
                var emp3 = empService.CreateEmployee(3, "Vadim");

                orgService.AddEmployee(1, emp1);
                orgService.AddEmployee(1, emp2);
                orgService.AddEmployee(2, emp3);

                orgService.AssignNewRole(1, 1, 2);
                orgService.AssignNewRole(1, 2, 1);
                orgService.AssignNewRole(2, 3, 1);
                orgService.AssignNewRole(1, 1, 1, 2);
                empService.RemoveEmployee(1);
                emp2.Name = "Updated";
                empService.UpdateEmployee(emp2);
                orgService.RemoveEmployee(2, 3);

                var roles = roleService.GetAllRoles();
                foreach (var role in roles)
                {
                    Console.WriteLine($"{role.Id} {role.Name}");
                }
            }
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
