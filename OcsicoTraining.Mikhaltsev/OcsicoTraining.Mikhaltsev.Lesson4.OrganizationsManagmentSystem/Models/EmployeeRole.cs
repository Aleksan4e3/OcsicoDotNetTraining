using System;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    public class EmployeeRole : IModelEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Role Role { get; set; }
    }
}
