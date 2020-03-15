using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
        public LoginValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.UserName)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Login"]);

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Password"]);
        }
    }
}
