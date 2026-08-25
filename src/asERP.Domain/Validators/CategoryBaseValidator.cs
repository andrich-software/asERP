using asERP.Domain.Interfaces;
using FluentValidation;

namespace asERP.Domain.Validators;

public class CategoryBaseValidator<T> : AbstractValidator<T> where T : ICategoryInputModel
{
    public CategoryBaseValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(1).WithMessage("{PropertyName} must be at least 1 character.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.Slug)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.");

        RuleFor(p => p.Description)
            .MaximumLength(4000).WithMessage("{PropertyName} must not exceed 4000 characters.");
    }
}
