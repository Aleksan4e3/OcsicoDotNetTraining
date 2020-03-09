using FluentValidation;
using ViewModels;

namespace Validators
{
    public class ProductForOrderValidator : AbstractValidator<ProductForOrderViewModel>
    {
        public ProductForOrderValidator()
        {
            RuleFor(x => x.ProductId)
                .NotNull().NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Weight)
                .InclusiveBetween(500, 2000);
        }
    }
}
