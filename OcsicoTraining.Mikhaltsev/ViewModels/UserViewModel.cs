using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }

        [Display(Name = "Customer")]
        public string Email { get; set; }
    }
}
