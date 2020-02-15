using System;
using System.Diagnostics.CodeAnalysis;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role : IEquatable<Role>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Role() => Id = Guid.NewGuid();

        public int GetHashCode([DisallowNull] Role obj) => obj.Id.GetHashCode();

        public bool Equals([AllowNull] Role other)
        {
            if (other == null)
            {
                return false;
            }

            return Id == other.Id;
        }

        public override string ToString() => $"{Id} {Name};";
    }
}
