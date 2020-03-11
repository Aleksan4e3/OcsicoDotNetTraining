using System;
using FluentValidation;
using ViewModels;

namespace Validators
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Comment)
                .NotNull().NotEmpty();

            RuleFor(x => x.Address)
                .NotNull().NotEmpty();

            RuleFor(x => x.Date)
                .NotNull().NotEmpty()
                .GreaterThan(DateTime.Now);
        }
    }
}
