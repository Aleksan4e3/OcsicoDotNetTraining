using FluentValidation;
using ViewModels;

namespace Validators
{
    public class OrderDetailValidator : AbstractValidator<OrderDetailViewModel>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().NotEmpty();

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.Weight)
                .InclusiveBetween(500, 2000);
        }
    }
}
