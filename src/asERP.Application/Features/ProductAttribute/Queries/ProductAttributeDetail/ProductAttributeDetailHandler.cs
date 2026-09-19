using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;

public class ProductAttributeDetailHandler : IRequestHandler<ProductAttributeDetailQuery, Result<ProductAttributeDetailDto>>
{
    private readonly IAppLogger<ProductAttributeDetailHandler> _logger;
    private readonly IProductAttributeRepository _productAttributeRepository;

    public ProductAttributeDetailHandler(
        IAppLogger<ProductAttributeDetailHandler> logger,
        IProductAttributeRepository productAttributeRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productAttributeRepository = productAttributeRepository ?? throw new ArgumentNullException(nameof(productAttributeRepository));
    }

    public async Task<Result<ProductAttributeDetailDto>> Handle(ProductAttributeDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving product attribute details for ID: {Id}", request.Id);

        var attribute = await _productAttributeRepository.GetWithValuesAsync(request.Id);

        if (attribute == null)
        {
            _logger.LogWarning("Product attribute with ID {Id} not found", request.Id);
            return Result<ProductAttributeDetailDto>.NotFound(ErrorCodes.ProductAttribute.NotFound, $"Product attribute with ID {request.Id} not found");
        }

        // Manual mapping from entity to DTO
        var data = new ProductAttributeDetailDto
        {
            Id = attribute.Id,
            Name = attribute.Name,
            SortOrder = attribute.SortOrder,
            Values = attribute.Values.Select(v => new ProductAttributeValueDto
            {
                Id = v.Id,
                Value = v.Value,
                SortOrder = v.SortOrder
            }).ToList()
        };

        _logger.LogInformation("Product attribute with ID {Id} retrieved successfully", request.Id);

        return Result<ProductAttributeDetailDto>.Ok(data);
    }
}
