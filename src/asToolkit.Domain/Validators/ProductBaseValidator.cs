using FluentValidation;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Interfaces;

namespace asToolkit.Domain.Validators;

/// <summary>
/// Basis-Validator für Product - enthält feldbasierte Validierungsregeln.
/// WICHTIG: Dieser Validator wird von Client (asToolkit.Client) und Server (asToolkit.Application) verwendet.
///
/// Client: ProductClientValidator erbt von dieser Klasse und fügt UI-spezifische Regeln hinzu.
/// Server: ProductCreateValidator/ProductUpdateValidator erben von dieser Klasse und fügen DB-Validierungen hinzu.
///
/// Änderungen an diesem Validator wirken sich auf Client UND Server aus!
/// Enthält nur feldbasierte Validierungen ohne externe Dependencies (keine DB-Zugriffe, keine Repositories).
/// </summary>
public class ProductBaseValidator<T> : AbstractValidator<T> where T : IProductInputModel
{
    public ProductBaseValidator()
    {
        RuleFor(p => p.Sku)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(3).WithMessage("{PropertyName} must be more than {MinLength} characters.")
            .MaximumLength(255).WithMessage("{PropertyName} must be less than {MaxLength} characters.");

        RuleFor(p => p.Name)
            .NotNull().WithMessage("{PropertyName} is required.")
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(255).WithMessage("{PropertyName} must be less than {MaxLength} characters.");

        // Variant parents act as non-sellable containers (e.g. imported WooCommerce
        // variable products carry no own price), so price 0 is allowed for them.
        RuleFor(p => p.Price)
            .NotNull().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.")
            .When(p => p.ProductType != ProductType.VariantParent);

        RuleFor(p => p.Price)
            .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater or equal than {ComparisonValue}.")
            .When(p => p.ProductType == ProductType.VariantParent);

        RuleFor(p => p.TaxClassId)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(p => p.ParentProductId)
            .NotNull().WithMessage("A variant requires a parent product.")
            .When(p => p.ProductType == ProductType.Variant);

        RuleFor(p => p.ParentProductId)
            .Null().WithMessage("Only variants may reference a parent product.")
            .When(p => p.ProductType != ProductType.Variant);
    }
}
