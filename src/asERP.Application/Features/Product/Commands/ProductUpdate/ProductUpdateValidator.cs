using asERP.Domain.Validators;
using FluentValidation;

namespace asERP.Application.Features.Product.Commands.ProductUpdate;

/// <summary>
/// Field rules only. Every "does this row exist?" question is the handler's, because the answers
/// need different statuses — a missing product is a 404, a missing tax class or manufacturer is a
/// 400 — and a validator can only ever produce the latter.
/// </summary>
public class ProductUpdateValidator : ProductBaseValidator<ProductUpdateCommand>
{
    public ProductUpdateValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");

        RuleFor(p => p.Id)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
