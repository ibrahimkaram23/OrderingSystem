using OrderingSystem.Core.Features.Categories.Commands.Models;
using FluentValidation;

namespace OrderingSystem.Core.Features.Categories.Commands.Validators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required.");
            RuleFor(x => x.Name.NameAr).NotEmpty().WithMessage("Arabic name is required.");
            RuleFor(x => x.Name.NameEn).NotEmpty().WithMessage("English name is required.");
            RuleFor(x => x.Description).NotNull().WithMessage("Description is required.");
        }
    }
}
