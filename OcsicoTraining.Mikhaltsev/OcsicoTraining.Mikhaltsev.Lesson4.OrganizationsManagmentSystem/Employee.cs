using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    [Path("Employees.json")]
    public class Employee : IEquatable<Employee>
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

        public int GetHashCode([DisallowNull] Employee obj) => obj.Id;

        public bool Equals([AllowNull] Employee other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }
    }
}
