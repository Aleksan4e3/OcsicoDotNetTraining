using System;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role
    {
        public Role() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Id} {Name};";
    }
}
