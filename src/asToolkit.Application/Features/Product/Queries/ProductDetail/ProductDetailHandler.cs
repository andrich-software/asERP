using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Features.ProductImage.Shared;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Product.Queries.ProductDetail;

/// <summary>
/// Handler for processing product detail queries.
/// Implements IRequestHandler from MediatR to handle ProductDetailQuery requests
/// and return detailed product information wrapped in a Result.
/// </summary>
public class ProductDetailHandler : IRequestHandler<ProductDetailQuery, Result<ProductDetailDto>>
{
    /// <summary>
    /// Logger for recording handler operations
    /// </summary>
    private readonly IAppLogger<ProductDetailHandler> _logger;

    /// <summary>
    /// Repository for product data operations
    /// </summary>
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Constructor that initializes the handler with required dependencies
    /// </summary>
    /// <param name="logger">Logger for recording operations</param>
    /// <param name="productRepository">Repository for product data access</param>
    public ProductDetailHandler(
        IAppLogger<ProductDetailHandler> logger,
        IProductRepository productRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    /// <summary>
    /// Handles the product detail query request
    /// </summary>
    /// <param name="request">The query containing the product ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result containing detailed product information if successful</returns>
    public async Task<Result<ProductDetailDto>> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving product details for ID: {Id}", request.Id);

        try
        {
            // Retrieve product with all related details from the repository
            var product = await _productRepository.GetWithDetailsAsync(request.Id);

            // If product not found, return a not found result
            if (product == null)
            {
                _logger.LogWarning("Product with ID {Id} not found", request.Id);
                return Result<ProductDetailDto>.Fail(ResultStatusCode.NotFound,
                    $"Product with ID {request.Id} not found");
            }

            // Manual mapping instead of using AutoMapper
            var data = new ProductDetailDto
            {
                Id = product.Id,
                Sku = product.Sku,
                Name = product.Name,
                NameOptimized = product.NameOptimized,
                Ean = product.Ean,
                Asin = product.Asin,
                Description = product.Description,
                DescriptionOptimized = product.DescriptionOptimized,
                UseOptimized = product.UseOptimized,
                Price = product.Price,
                Msrp = product.Msrp,
                Weight = product.Weight,
                Width = product.Width,
                Height = product.Height,
                Depth = product.Depth,
                TaxClassId = product.TaxClassId,
                Manufacturer = product.Manufacturer != null ? new ManufacturerDetailDto
                {
                    Id = product.Manufacturer.Id,
                    Name = product.Manufacturer.Name,
                    Street = product.Manufacturer.Street,
                    City = product.Manufacturer.City,
                    State = product.Manufacturer.State,
                    Country = product.Manufacturer.Country,
                    ZipCode = product.Manufacturer.ZipCode,
                    Phone = product.Manufacturer.Phone,
                    Email = product.Manufacturer.Email,
                    Website = product.Manufacturer.Website,
                    Logo = product.Manufacturer.Logo
                } : null,
                ProductType = product.ProductType,
                ParentProductId = product.ParentProductId,
                VariantSortOrder = product.VariantSortOrder,
                VariantAxes = product.VariantAxes
                    .OrderBy(a => a.SortOrder)
                    .Select(a => new ProductVariantAxisDto
                    {
                        ProductAttributeId = a.ProductAttributeId,
                        AttributeName = a.ProductAttribute?.Name ?? string.Empty,
                        SortOrder = a.SortOrder,
                        AvailableValues = (a.ProductAttribute?.Values ?? [])
                            .OrderBy(v => v.SortOrder).ThenBy(v => v.Value)
                            .Select(v => new Domain.Dtos.ProductAttribute.ProductAttributeValueDto
                            {
                                Id = v.Id,
                                Value = v.Value,
                                SortOrder = v.SortOrder
                            }).ToList()
                    }).ToList(),
                Variants = product.Variants
                    .OrderBy(v => v.VariantSortOrder).ThenBy(v => v.Sku)
                    .Select(v => new ProductVariantListDto
                    {
                        Id = v.Id,
                        Sku = v.Sku,
                        Name = v.Name,
                        Ean = v.Ean,
                        Price = v.Price,
                        VariantSortOrder = v.VariantSortOrder,
                        Options = MapOptions(v.VariantOptions)
                    }).ToList(),
                Options = MapOptions(product.VariantOptions),
                // Map related sales channels and stocks
                ProductSalesChannel = product.ProductSalesChannels?.Select(psc => psc.Id).ToList() ?? new List<Guid>(),
                ProductStocks = product.ProductStocks.Select(ps => ps.Id).ToList(),
                Images = product.Images
                    .OrderBy(i => i.SortOrder)
                    .Select(ProductImageMapping.ToDto)
                    .ToList()
            };

            _logger.LogInformation("Product with ID {Id} retrieved successfully", request.Id);

            return Result<ProductDetailDto>.Success(data);
        }
        catch (Exception ex)
        {
            // Handle any exceptions during product retrieval
            _logger.LogError("Error retrieving product: {Message}", ex.Message);

            return Result<ProductDetailDto>.Fail(ResultStatusCode.InternalServerError,
                $"An error occurred while retrieving the product: {ex.Message}");
        }
    }

    private static List<ProductVariantOptionDto> MapOptions(IEnumerable<Domain.Entities.ProductVariantOption> options)
    {
        return options
            .Select(o => new ProductVariantOptionDto
            {
                ProductAttributeId = o.ProductAttributeValue?.ProductAttributeId ?? Guid.Empty,
                AttributeName = o.ProductAttributeValue?.ProductAttribute?.Name ?? string.Empty,
                ProductAttributeValueId = o.ProductAttributeValueId,
                Value = o.ProductAttributeValue?.Value ?? string.Empty
            })
            .OrderBy(o => o.AttributeName)
            .ToList();
    }
}
