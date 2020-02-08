using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem
{
    public class EmployeeOrganizationRole
    {
        public Employee Employee { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
    }
}
