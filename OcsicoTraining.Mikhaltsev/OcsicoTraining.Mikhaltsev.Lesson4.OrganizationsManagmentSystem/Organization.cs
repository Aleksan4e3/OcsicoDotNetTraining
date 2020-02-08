using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<Role> Roles { get; set; }
    }
}
