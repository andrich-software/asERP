using FluentValidation;

namespace asERP.Application.Features.Product.Commands.ProductVariantGenerate;

public class ProductVariantGenerateValidator : AbstractValidator<ProductVariantGenerateCommand>
{
    public ProductVariantGenerateValidator()
    {
        RuleFor(p => p.ParentProductId)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");

        RuleFor(p => p.Axes)
            .NotEmpty().WithMessage("At least one axis with values is required.");

        RuleForEach(p => p.Axes)
            .ChildRules(axis =>
            {
                axis.RuleFor(a => a.ProductAttributeId)
                    .NotEqual(Guid.Empty).WithMessage("Axis attribute id cannot be empty.");

                axis.RuleFor(a => a.ValueIds)
                    .NotEmpty().WithMessage("Each axis requires at least one value.");
            });
    }
}
