using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
