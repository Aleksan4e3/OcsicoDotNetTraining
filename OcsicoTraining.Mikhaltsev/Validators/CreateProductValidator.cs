using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty()
                .WithName(x => localizer["ProductName"]);

            RuleFor(x => x.Description)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Description"]);

            RuleFor(x => x.Price)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Price"]);

            RuleFor(x => x.Image)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Image"]);
        }
    }
}
