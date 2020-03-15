using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class ProductForOrderValidator : AbstractValidator<ProductForOrderViewModel>
    {
        public ProductForOrderValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.ProductId)
                .NotNull().NotEmpty();

            RuleFor(x => x.Quantity)
                .NotNull().NotEmpty()
                .InclusiveBetween(1, 5)
                .WithName(x => localizer["Quantity"]);

            RuleFor(x => x.Weight)
                .NotNull().NotEmpty()
                .InclusiveBetween(500, 2000)
                .WithName(x => localizer["Weight"]);
        }
    }
}
