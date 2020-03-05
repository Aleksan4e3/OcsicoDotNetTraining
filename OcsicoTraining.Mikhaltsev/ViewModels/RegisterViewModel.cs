using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
