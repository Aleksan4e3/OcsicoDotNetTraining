using OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.Models;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class EmployeeRoleViewModel
    {
        public Employee Employee { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
    }
}
