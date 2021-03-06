using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role : IModelEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
