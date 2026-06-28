using FluentValidation;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Validators;

public class TaxClassBaseValidator<T> : AbstractValidator<T> where T : ITaxClassInputModel
{
    public TaxClassBaseValidator()
    {
        RuleFor(p => p.TaxRate)
            .NotNull().WithMessage("{PropertyName} is required.")
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal than 0.")
            .LessThanOrEqualTo(100).WithMessage("{PropertyName} must be less or equal than 100.");
    }
}