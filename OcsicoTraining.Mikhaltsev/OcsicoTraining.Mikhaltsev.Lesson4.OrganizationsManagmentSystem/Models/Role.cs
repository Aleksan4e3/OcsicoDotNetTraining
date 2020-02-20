using System;
using System.Collections.Generic;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EmployeeOrganizationRole> EmployeeOrganizationRoles { get; set; }
    }
}
