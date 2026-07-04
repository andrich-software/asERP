using FluentValidation;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Validators;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateValidator : ProductAttributeBaseValidator<ProductAttributeUpdateCommand>
{
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeUpdateValidator(IProductAttributeRepository productAttributeRepository)
    {
        _productAttributeRepository = productAttributeRepository;

        RuleFor(p => p.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} cannot be empty.");

        RuleFor(q => q)
            .MustAsync(IsUniqueAsync).WithMessage("ProductAttribute with the same name already exists.")
            .Must(HaveDistinctValues).WithMessage("Attribute values must be unique.");

        RuleForEach(q => q.Values)
            .ChildRules(v =>
            {
                v.RuleFor(x => x.Value)
                    .NotEmpty().WithMessage("Value is required.")
                    .MaximumLength(255).WithMessage("Value must be less than 255 characters.");
            });
    }

    private async Task<bool> IsUniqueAsync(ProductAttributeUpdateCommand command, CancellationToken cancellationToken)
    {
        var attribute = new Domain.Entities.ProductAttribute
        {
            Name = command.Name
        };

        return await _productAttributeRepository.IsUniqueAsync(attribute, command.Id);
    }

    private static bool HaveDistinctValues(ProductAttributeUpdateCommand command)
    {
        return command.Values.Select(v => v.Value).Distinct().Count() == command.Values.Count;
    }
}
