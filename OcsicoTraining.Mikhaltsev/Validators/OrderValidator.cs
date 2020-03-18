using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.Comment)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Comment"]);

            RuleFor(x => x.Address)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Address"]);

            RuleFor(x => x.Date)
                .NotNull().NotEmpty()
                .GreaterThan(DateTime.Now)
                .WithName(x => localizer["DeliveryTime"]);
        }
    }
}
