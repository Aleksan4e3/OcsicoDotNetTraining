using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
