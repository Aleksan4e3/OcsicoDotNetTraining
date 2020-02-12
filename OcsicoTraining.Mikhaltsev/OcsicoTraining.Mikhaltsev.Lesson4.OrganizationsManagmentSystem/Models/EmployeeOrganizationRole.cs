using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    [Path("EmployeeOrganizationRole.json")]
    public class EmployeeOrganizationRole : IEquatable<EmployeeOrganizationRole>
    {
        public EmployeeOrganizationRole() => Roles = new List<Role>();
        public int EmployeeId { get; set; }
        public int OrganizationId { get; set; }
        public List<Role> Roles { get; set; }

        public int GetHashCode([DisallowNull] EmployeeOrganizationRole obj) => obj.EmployeeId ^ obj.OrganizationId;

        public bool Equals([AllowNull] EmployeeOrganizationRole other)
        {
            if (other == null)
            {
                return false;
            }

            return EmployeeId == other.EmployeeId && OrganizationId == other.OrganizationId;
        }
    }
}
