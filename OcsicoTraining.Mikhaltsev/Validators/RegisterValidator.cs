using FluentValidation;
using ViewModels;

namespace Validators
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty();

            RuleFor(x => x.Password)
                .NotNull().NotEmpty();

            RuleFor(x => x.PasswordConfirm)
                .NotNull().NotEmpty()
                .Equal(x => x.Password);
        }
    }
}
