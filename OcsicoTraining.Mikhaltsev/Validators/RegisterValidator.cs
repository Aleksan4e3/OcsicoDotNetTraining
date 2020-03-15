using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.Email)
                .NotNull().NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Login"]);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Password"]);

            RuleFor(x => x.PasswordConfirm)
                .NotNull().NotEmpty()
                .Equal(x => x.Password)
                .WithName(x => localizer["RepeatPassword"]);
        }
    }
}
