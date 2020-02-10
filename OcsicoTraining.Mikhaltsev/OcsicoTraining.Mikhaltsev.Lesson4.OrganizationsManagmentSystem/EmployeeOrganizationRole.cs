using System;
using System.Diagnostics.CodeAnalysis;
using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Attributes;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    [Path("EmployeeOrganizationRole.json")]
    public class EmployeeOrganizationRole : IEquatable<EmployeeOrganizationRole>
    {
        public Employee Employee { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }

        public int GetHashCode([DisallowNull] EmployeeOrganizationRole obj) => obj.Employee.Id ^ obj.Organization.Id;

        public bool Equals([AllowNull] EmployeeOrganizationRole other)
        {
            if (other == null)
            {
                return false;
            }

            return Employee.Id == other.Employee.Id && Organization.Id == other.Organization.Id;
        }
    }
}
