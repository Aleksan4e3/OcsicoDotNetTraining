using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class OrderDetailValidator : AbstractValidator<OrderDetailViewModel>
    {
        public OrderDetailValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.ProductId)
                .NotNull().NotEmpty();

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1,5)
                .WithName(x => localizer["Quantity"]);

            RuleFor(x => x.Weight)
                .InclusiveBetween(500, 2000)
                .WithName(x => localizer["Weight"]);
        }
    }
}
