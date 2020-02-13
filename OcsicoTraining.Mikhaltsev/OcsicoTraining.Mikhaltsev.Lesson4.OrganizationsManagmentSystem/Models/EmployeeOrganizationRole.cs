using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models
{
    [Path("EmployeeOrganizationRole.json")]
    public class EmployeeOrganizationRole : IEquatable<EmployeeOrganizationRole>
    {
        public int EmployeeId { get; set; }
        public int OrganizationId { get; set; }
        public int RoleId { get; set; }

        public int GetHashCode([DisallowNull] EmployeeOrganizationRole obj) =>
            obj.EmployeeId ^ obj.OrganizationId ^ obj.RoleId;

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
