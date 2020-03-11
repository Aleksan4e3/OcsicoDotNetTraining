using FluentValidation;
using ViewModels;

namespace Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty();

            RuleFor(x => x.Description)
                .NotNull().NotEmpty();

            RuleFor(x => x.Price)
                .NotNull().NotEmpty();

            RuleFor(x => x.Image)
                .NotNull().NotEmpty();
        }
    }
}
