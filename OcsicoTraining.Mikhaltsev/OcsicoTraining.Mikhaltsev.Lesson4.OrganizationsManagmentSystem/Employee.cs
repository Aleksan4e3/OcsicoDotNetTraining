using System.Collections.Generic;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    [Path("Employees.json")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Organization> Organizations { get; set; }
        public IList<Role> Roles { get; set; }

        public Employee()
        {
            Organizations = new List<Organization>();
            Roles = new List<Role>();
        }
    }
}
