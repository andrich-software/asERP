using FluentValidation;
using maERP.Domain.Interfaces;

namespace maERP.Domain.Validators;

public class ProductAttributeBaseValidator<T> : AbstractValidator<T> where T : IProductAttributeInputModel
{
    public ProductAttributeBaseValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must be less than {MaxLength} characters.");
    }
}
