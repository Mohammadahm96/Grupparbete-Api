using Application.Dto;
using FluentValidation;

namespace Application.Validators.SommarHusList
{
    public class SommarHusListValidator : AbstractValidator<SommarHusListDto>
    {
        public SommarHusListValidator()
        {
            RuleFor(sommarHusList => sommarHusList.HouseName)
               .NotEmpty().WithMessage("Housename is required.")
               .MinimumLength(3).WithMessage("Housename must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Housename cannot exceed 20 characters.")
                .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Housename can only contain letters, numbers, underscores, and hyphens.");
            RuleFor(sommarHusList => sommarHusList.ArticleName)
                .NotEmpty().WithMessage("Articlename is required.")
                .MinimumLength(3).WithMessage("Articlename must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Articlename cannot exceed 20 characters.")
                .Matches("^[a-zA-Z0-9_-]+$").WithMessage("Articlename can only contain letters, numbers, underscores, and hyphens.");
            RuleFor(sommarHusList => sommarHusList.ArticleQuantity)
                .NotEmpty().WithMessage("ArticleQuantity is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("ArticleQuantity must be greater than 0.");
        }
    }
}
