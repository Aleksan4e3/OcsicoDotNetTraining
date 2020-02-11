using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    [Path("Organizations.json")]
    public class Organization : IEquatable<Organization>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Role> Roles { get; set; }

        public Organization()
        {
            Employees = new List<Employee>();
            Roles = new List<Role>();
        }

        public int GetHashCode([DisallowNull] Organization obj) => 271 ^ obj.Id;

        public bool Equals([AllowNull] Organization other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }
    }
}
