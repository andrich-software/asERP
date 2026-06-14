using FluentValidation;

namespace maERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteValidator : AbstractValidator<ProductAttributeDeleteCommand>
{
    public ProductAttributeDeleteValidator()
    {
        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");
    }
}
