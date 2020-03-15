using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        [Display(Name = "Login")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "RepeatPassword")]
        public string PasswordConfirm { get; set; }
    }
}
