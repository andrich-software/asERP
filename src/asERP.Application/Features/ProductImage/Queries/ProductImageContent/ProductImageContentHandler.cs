using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductImage.Queries.ProductImageContent;

public class ProductImageContentHandler : IRequestHandler<ProductImageContentQuery, Result<ProductImageFile>>
{
    private readonly IAppLogger<ProductImageContentHandler> _logger;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductImageStorage _productImageStorage;

    public ProductImageContentHandler(
        IAppLogger<ProductImageContentHandler> logger,
        IProductImageRepository productImageRepository,
        IProductImageStorage productImageStorage)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
        _productImageStorage = productImageStorage ?? throw new ArgumentNullException(nameof(productImageStorage));
    }

    public async Task<Result<ProductImageFile>> Handle(ProductImageContentQuery request, CancellationToken cancellationToken)
    {
        // Tenant-filtered lookup; a foreign image resolves to null (NotFound).
        var image = await _productImageRepository.GetByIdAsync(request.ImageId, asNoTracking: true);
        if (image == null || image.ProductId != request.ProductId)
        {
            return Result<ProductImageFile>.Fail(ResultStatusCode.NotFound, "Image not found");
        }

        var relativePath = request.Thumbnail ? image.ThumbnailPath : image.RelativePath;
        var stream = await _productImageStorage.OpenReadAsync(relativePath, cancellationToken);
        if (stream == null)
        {
            _logger.LogWarning("Image file missing on disk: {Path}", relativePath);
            return Result<ProductImageFile>.Fail(ResultStatusCode.NotFound, "Image file not found");
        }

        return Result<ProductImageFile>.Success(
            new ProductImageFile(stream, ContentTypeFor(image.FileName), image.FileName));
    }

    /// <summary>
    /// Derives the response content type from the stored file's extension, so images written in
    /// any historical format (legacy PNG, current WebP, …) are served with the correct MIME type.
    /// </summary>
    private static string ContentTypeFor(string fileName) =>
        Path.GetExtension(fileName).ToLowerInvariant() switch
        {
            ".webp" => "image/webp",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            _ => "application/octet-stream",
        };
}
