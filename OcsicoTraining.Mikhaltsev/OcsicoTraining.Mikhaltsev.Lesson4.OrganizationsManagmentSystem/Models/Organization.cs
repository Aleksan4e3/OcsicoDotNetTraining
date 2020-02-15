using System;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("Organizations.json")]
    public class Organization
    {
        public Organization() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
