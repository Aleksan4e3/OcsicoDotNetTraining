using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("Employees.json")]
    public class Employee : IEquatable<Employee>
    {
        public Employee() => CompaniesId = new List<int>();

        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> CompaniesId { get; set; }

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
