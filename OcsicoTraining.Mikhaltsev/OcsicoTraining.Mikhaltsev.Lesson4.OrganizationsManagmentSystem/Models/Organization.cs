using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Organization : IModelEntity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
