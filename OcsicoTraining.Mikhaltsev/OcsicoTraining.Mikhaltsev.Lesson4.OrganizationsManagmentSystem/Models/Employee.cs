using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Employee : IModelEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
