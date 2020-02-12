using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("Organizations.json")]
    public class Organization : IEquatable<Organization>
    {
        public Organization() => EmployeesId = new List<int>();

        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> EmployeesId { get; set; }

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
