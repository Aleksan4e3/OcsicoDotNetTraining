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
                .WithMessage("Поле {PropertyName} не должно быть пустым!")
                .EmailAddress()
                .WithMessage("Здесь должен быть Email!");

            RuleFor(x => x.UserName)
                .NotNull().NotEmpty()
                .WithMessage("Поле {PropertyName} не должно быть пустым!");

            RuleFor(x => x.Password)
                .NotNull().NotEmpty()
                .WithMessage("Поле {PropertyName} не должно быть пустым!");

            RuleFor(x => x.PasswordConfirm)
                .NotNull().NotEmpty()
                .WithMessage("Поле {PropertyName} не должно быть пустым!")
                .Equal(x => x.Password)
                .WithMessage("Не совпадает с полем {ComparisonName}");
        }
    }
}
