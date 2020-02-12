using System;
using System.Collections.Generic;
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
            var builder = new ContainerBuilder();

            _ = builder.RegisterGeneric(typeof(FileRepository<>)).As(typeof(IRepository<>));
            _ = builder.RegisterType<OrganizationService>();
            _ = builder.RegisterType<EmployeeService>();
            _ = builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
                .AsClosedTypesOf(typeof(IRepository<>));

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var orgService = scope.Resolve<OrganizationService>();
                var empService = scope.Resolve<EmployeeService>();
                var memRepository = scope.Resolve<MemoryRepository>();

                orgService.AddOrganization(1, "Ocsico");
                orgService.AddOrganization(2, "Microsoft");
                //var role1 = new Role { Id = 1, Name = "Developer" };
                var role2 = new Role { Id = 2, Name = "QA" };
                var emp1 = empService.CreateEmployee(1, "Alex", new List<int> { 1 });
                var emp2 = empService.CreateEmployee(2, "Ivan", new List<int> { 2 });
                var emp3 = empService.CreateEmployee(3, "Vadim", new List<int> { 1 });
                orgService.AddEmployee(1, emp1);
                orgService.AddEmployee(1, emp2);
                orgService.AddEmployee(2, emp3);

                orgService.RemoveEmployee(1, 2);
                orgService.AssignNewRole(1, 1, 1, role2);
                empService.RemoveEmployee(emp1);
                emp2.Name = "Updated";
                empService.UpdateEmployee(emp2);

                var roles = memRepository.GetAll();
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
