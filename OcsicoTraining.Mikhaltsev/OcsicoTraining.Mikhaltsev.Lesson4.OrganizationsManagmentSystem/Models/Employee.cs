using System;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("Employees.json")]
    public class Employee
    {
        public Employee() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
