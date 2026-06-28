using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Features.ProductImage.Shared;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Queries.ProductImageList;

public class ProductImageListHandler : IRequestHandler<ProductImageListQuery, Result<List<ProductImageDto>>>
{
    private readonly IAppLogger<ProductImageListHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageListHandler(
        IAppLogger<ProductImageListHandler> logger,
        IProductRepository productRepository,
        IProductImageRepository productImageRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
    }

    public async Task<Result<List<ProductImageDto>>> Handle(ProductImageListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Listing images for product {ProductId}", request.ProductId);

        // Tenant-filtered existence check so a foreign/unknown product yields NotFound.
        var product = await _productRepository.GetByIdAsync(request.ProductId, asNoTracking: true);
        if (product == null)
        {
            return Result<List<ProductImageDto>>.Fail(ResultStatusCode.NotFound, "Product not found");
        }

        var images = await _productImageRepository.GetByProductIdAsync(request.ProductId);
        var data = images.Select(ProductImageMapping.ToDto).ToList();

        return Result<List<ProductImageDto>>.Success(data);
    }
}
