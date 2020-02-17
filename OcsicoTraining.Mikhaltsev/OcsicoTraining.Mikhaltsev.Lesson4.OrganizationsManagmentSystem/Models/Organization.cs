using System;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Organization
    {
        public Organization() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
