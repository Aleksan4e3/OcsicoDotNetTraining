using System;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class EmployeeOrganizationRole
    {
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }
    }
}
