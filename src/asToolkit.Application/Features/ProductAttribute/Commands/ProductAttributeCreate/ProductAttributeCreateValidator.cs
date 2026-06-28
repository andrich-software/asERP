using FluentValidation;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Domain.Validators;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeCreate;

public class ProductAttributeCreateValidator : ProductAttributeBaseValidator<ProductAttributeCreateCommand>
{
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeCreateValidator(IProductAttributeRepository productAttributeRepository)
    {
        _productAttributeRepository = productAttributeRepository;

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

    private async Task<bool> IsUniqueAsync(ProductAttributeCreateCommand command, CancellationToken cancellationToken)
    {
        var attributeToCreate = new Domain.Entities.ProductAttribute
        {
            Name = command.Name
        };

        return await _productAttributeRepository.IsUniqueAsync(attributeToCreate);
    }

    private static bool HaveDistinctValues(ProductAttributeCreateCommand command)
    {
        return command.Values.Select(v => v.Value).Distinct().Count() == command.Values.Count;
    }
}
