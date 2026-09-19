using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeCreate;

public class ProductAttributeCreateHandler : IRequestHandler<ProductAttributeCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductAttributeCreateHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeCreateHandler(
        IAppLogger<ProductAttributeCreateHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
    }

    public async Task<Result<Guid>> Handle(ProductAttributeCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new product attribute with name: {Name}", request.Name);

        // Manual mapping to domain entity
        var attributeToCreate = new Domain.Entities.ProductAttribute
        {
            Name = request.Name,
            SortOrder = request.SortOrder,
            Values = request.Values.Select(v => new Domain.Entities.ProductAttributeValue
            {
                Value = v.Value,
                SortOrder = v.SortOrder
            }).ToList()
        };

        await _productAttributeRepository.CreateAsync(attributeToCreate);

        _logger.LogInformation("Successfully created product attribute with ID: {Id}", attributeToCreate.Id);

        return Result<Guid>.Created(attributeToCreate.Id);
    }
}
