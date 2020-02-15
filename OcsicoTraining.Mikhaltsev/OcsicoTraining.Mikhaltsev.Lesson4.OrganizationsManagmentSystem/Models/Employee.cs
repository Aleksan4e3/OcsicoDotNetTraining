using System;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("Employees.json")]
    public class Employee : IEquatable<Employee>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Employee() => Id = Guid.NewGuid();

        public int GetHashCode([DisallowNull] Employee obj) => obj.Id.GetHashCode();

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
