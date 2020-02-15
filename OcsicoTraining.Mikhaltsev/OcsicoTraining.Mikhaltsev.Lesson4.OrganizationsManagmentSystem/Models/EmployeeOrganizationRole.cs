using System;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("EmployeeOrganizationRole.json")]
    public class EmployeeOrganizationRole
    {
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }
    }
}
