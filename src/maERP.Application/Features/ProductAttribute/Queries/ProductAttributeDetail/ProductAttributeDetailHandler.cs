using maERP.Application.Contracts.Logging;
using maERP.Application.Contracts.Persistence;
using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;

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

        var result = new Result<ProductAttributeDetailDto>();

        try
        {
            var attribute = await _productAttributeRepository.GetWithValuesAsync(request.Id);

            if (attribute == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Product attribute with ID {request.Id} not found");

                _logger.LogWarning("Product attribute with ID {Id} not found", request.Id);
                return result;
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

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = data;

            _logger.LogInformation("Product attribute with ID {Id} retrieved successfully", request.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while retrieving the product attribute: {ex.Message}");

            _logger.LogError("Error retrieving product attribute: {Message}", ex.Message);
        }

        return result;
    }
}
