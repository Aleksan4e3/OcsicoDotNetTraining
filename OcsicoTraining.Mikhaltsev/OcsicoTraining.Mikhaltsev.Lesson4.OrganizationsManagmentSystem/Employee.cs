using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
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
