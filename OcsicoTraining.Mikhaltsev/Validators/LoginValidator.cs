using FluentValidation;
using ViewModels;

namespace Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull();

            RuleFor(x => x.Password)
                .NotNull();
        }
    }
}
