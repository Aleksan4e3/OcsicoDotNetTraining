using FluentValidation;
using Microsoft.Extensions.Localization;
using ViewModels;

namespace Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticleViewModel>
    {
        public CreateArticleValidator(IStringLocalizer<DataAnnotationResource> localizer)
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty()
                .WithName(x => localizer["ArticleName"]);

            RuleFor(x => x.Text)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Text"]);

            RuleFor(x => x.ImageUrl)
                .NotNull().NotEmpty()
                .WithName(x => localizer["Image"]);
        }
    }
}
