using System;
using System.Collections.Generic;
using Autofac;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Contracts;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Services;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static void Main() => Initialize();

        private static void Initialize()
        {
            var builder = new ContainerBuilder();

            _ = builder.RegisterGeneric(typeof(FileRepository<>)).As(typeof(IFileRepository<>));
            _ = builder.RegisterType<OrganizationService>();
            _ = builder.RegisterType<EmployeeService>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var orgService = scope.Resolve<OrganizationService>();
                var empService = scope.Resolve<EmployeeService>();
                orgService.AddOrganization(1, "Ocsico");
                orgService.AddOrganization(2, "Microsoft");
                var emp1 = empService.CreateEmployee(1, "Alex", new List<Role>() { new Role { Id = 1, Name = "Developer" } });
                var emp2 = empService.CreateEmployee(2, "Ivan", new List<Role>() { new Role { Id = 2, Name = "QA" } });
                var emp3 = empService.CreateEmployee(3, "Vadim", new List<Role>() { new Role { Id = 1, Name = "Developer" } });
                orgService.AddEmployee(1, emp1);
                orgService.AddEmployee(1, emp2);
                orgService.AddEmployee(2, emp3);

                orgService.RemoveEmployee(1, 2);
                orgService.AssignNewRole(1, emp1, new Role { Id = 2, Name = "QA" });
                empService.RemoveEmployee(emp1);
                emp2.Name = "Updated";
                empService.UpdateEmployee(emp2);
            }
        }

    }
}
