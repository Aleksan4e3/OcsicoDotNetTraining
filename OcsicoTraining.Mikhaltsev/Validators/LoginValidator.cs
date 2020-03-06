using FluentValidation;
using ViewModels;

namespace Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty();

            RuleFor(x => x.Password)
                .NotNull().NotEmpty();
        }
    }
}
