using System;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("EmployeeOrganizationRole.json")]
    public class EmployeeOrganizationRole : IEquatable<EmployeeOrganizationRole>
    {
        public Guid EmployeeId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid RoleId { get; set; }

        public int GetHashCode([DisallowNull] EmployeeOrganizationRole obj) =>
            obj.EmployeeId.GetHashCode() ^ obj.OrganizationId.GetHashCode() ^ obj.RoleId.GetHashCode();

        public bool Equals([AllowNull] EmployeeOrganizationRole other)
        {
            if (other == null)
            {
                return false;
            }

            return EmployeeId == other.EmployeeId && OrganizationId == other.OrganizationId && RoleId == other.RoleId;
        }
    }
}
