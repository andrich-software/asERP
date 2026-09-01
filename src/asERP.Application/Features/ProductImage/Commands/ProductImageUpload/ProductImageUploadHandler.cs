using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.ProductImage.Shared;
using asERP.Application.Mediator;
using asERP.Application.Models.Storage;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using Microsoft.Extensions.Options;

namespace asERP.Application.Features.ProductImage.Commands.ProductImageUpload;

public class ProductImageUploadHandler : IRequestHandler<ProductImageUploadCommand, Result<ProductImageDto>>
{
    private readonly IAppLogger<ProductImageUploadHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductImageStorage _productImageStorage;
    private readonly ITenantContext _tenantContext;
    private readonly FileStorageOptions _options;

    public ProductImageUploadHandler(
        IAppLogger<ProductImageUploadHandler> logger,
        IProductRepository productRepository,
        IProductImageRepository productImageRepository,
        IProductImageStorage productImageStorage,
        ITenantContext tenantContext,
        IOptions<FileStorageOptions> options)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
        _productImageStorage = productImageStorage ?? throw new ArgumentNullException(nameof(productImageStorage));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
        _options = options.Value;
    }

    public async Task<Result<ProductImageDto>> Handle(ProductImageUploadCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Uploading image for product ID: {ProductId}", request.ProductId);

        // Content type guard. Storage re-encodes to PNG, but we only accept image formats we expect.
        var contentType = request.File.ContentType?.Split(';')[0].Trim().ToLowerInvariant() ?? string.Empty;
        if (!_options.AllowedContentTypes.Contains(contentType, StringComparer.OrdinalIgnoreCase))
        {
            return Result<ProductImageDto>.Invalid(ErrorCodes.ProductImage.Invalid,
                $"Unsupported content type '{request.File.ContentType}'. Allowed: {string.Join(", ", _options.AllowedContentTypes)}");
        }

        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue)
        {
            return Result<ProductImageDto>.Invalid(ErrorCodes.ProductImage.Invalid,
                "Tenant context is not set. Cannot upload image without tenant information.");
        }

        // Tenant-filtered existence check — a product from another tenant resolves to null (NotFound).
        var product = await _productRepository.GetByIdAsync(request.ProductId, asNoTracking: true);
        if (product == null)
        {
            _logger.LogWarning("Product with ID {ProductId} not found for image upload", request.ProductId);
            return Result<ProductImageDto>.NotFound(ErrorCodes.ProductImage.NotFound, "Product not found");
        }

        StoredImage stored;
        await using (var stream = request.File.OpenReadStream())
        {
            stored = await _productImageStorage.SaveAsync(stream, cancellationToken);
        }

        var nextSortOrder = await _productImageRepository.GetMaxSortOrderAsync(request.ProductId) + 1;

        var image = new Domain.Entities.ProductImage
        {
            ProductId = request.ProductId,
            FileName = stored.FileName,
            RelativePath = stored.RelativePath,
            ThumbnailPath = stored.ThumbnailPath,
            OriginalFileName = request.File.FileName,
            Width = stored.Width,
            Height = stored.Height,
            FileSizeBytes = stored.FileSizeBytes,
            SortOrder = nextSortOrder,
            TenantId = currentTenantId.Value
        };

        await _productImageRepository.CreateAsync(image);

        _logger.LogInformation("Created image {ImageId} for product {ProductId}", image.Id, request.ProductId);

        var result = Result<ProductImageDto>.Success(ProductImageMapping.ToDto(image));
        result.Status = ResultStatus.Created;
        return result;
    }
}
