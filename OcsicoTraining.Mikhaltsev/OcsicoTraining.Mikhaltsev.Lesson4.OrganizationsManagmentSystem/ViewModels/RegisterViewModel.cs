using System.ComponentModel.DataAnnotations;

namespace OcsicoTraining.Mikhaltsev.Lesson4.OrganizationsManagmentSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don`t equals!")]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        public string PasswordConfirm { get; set; }
    }
}
