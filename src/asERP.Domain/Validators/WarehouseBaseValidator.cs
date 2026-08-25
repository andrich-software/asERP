using asERP.Domain.Interfaces;
using FluentValidation;

namespace asERP.Domain.Validators;

public class WarehouseBaseValidator<T> : AbstractValidator<T> where T : IWarehouseInputModel
{
    public WarehouseBaseValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}
