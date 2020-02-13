using System;
using System.Diagnostics.CodeAnalysis;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role : IEquatable<Role>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetHashCode([DisallowNull] Role obj) => obj.Id;

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
