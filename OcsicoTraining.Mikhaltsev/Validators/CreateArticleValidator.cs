using FluentValidation;
using ViewModels;

namespace Validators
{
    public class CreateArticleValidator : AbstractValidator<CreateArticleViewModel>
    {
        public CreateArticleValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().NotEmpty();

            RuleFor(x => x.Text)
                .NotNull().NotEmpty();

            RuleFor(x => x.ImageUrl)
                .NotNull().NotEmpty();
        }
    }
}
