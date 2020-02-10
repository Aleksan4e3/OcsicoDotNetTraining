using System;
using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Repositories;

namespace OcsicoTraining.Mikhaltsev.Lesson4.Presentation
{
    internal class Program
    {
        private static void Main() => Initialize();

        private static void Initialize()
        {
            var repository = new FileRepository<Employee>();
            var repositoryCompany = new FileRepository<Organization>();

            var role1 = new Role { Id = 1, Name = "Manager" };
            var role2 = new Role { Id = 2, Name = "Developer" };
            var role3 = new Role { Id = 3, Name = "QA" };
            var company1 = new Organization { Id = 1, Name = "Ocsico", Roles = { role1, role2 } };
            var company2 = new Organization { Id = 2, Name = "Epam", Roles = { role1, role3 } };
            var emp1 = new Employee { Id = 1, Name = "Alex", Organizations = { company1 }, Roles = { role1 } };
            var emp2 = new Employee { Id = 2, Name = "Andrew", Organizations = { company2 }, Roles = { role1 } };
            var emp3 = new Employee { Id = 3, Name = "Bob", Organizations = { company1, company2 }, Roles = { role2, role3 } };
            //company1.Employees.Add(emp1);
            //company1.Employees.Add(emp3);
            //company2.Employees.Add(emp2);
            //company2.Employees.Add(emp3);

            repository.Add(emp1);
            repository.Add(emp2);
            repository.Add(emp3);
            Console.WriteLine($"{emp1},{emp3}");
            //emp3.Name = "Rename";
            repository.Remove(emp3);
            var employees = repository.GetAll();

            repositoryCompany.Add(company1);
            repositoryCompany.Add(company2);
            company2.Name = "test";
            repositoryCompany.Update(company2);

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Id} {employee.Name}");
            }
        }

    }
}
