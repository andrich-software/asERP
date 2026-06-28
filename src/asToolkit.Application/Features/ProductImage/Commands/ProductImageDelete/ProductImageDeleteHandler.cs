using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Commands.ProductImageDelete;

public class ProductImageDeleteHandler : IRequestHandler<ProductImageDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductImageDeleteHandler> _logger;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductImageStorage _productImageStorage;

    public ProductImageDeleteHandler(
        IAppLogger<ProductImageDeleteHandler> logger,
        IProductImageRepository productImageRepository,
        IProductImageStorage productImageStorage)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
        _productImageStorage = productImageStorage ?? throw new ArgumentNullException(nameof(productImageStorage));
    }

    public async Task<Result<Guid>> Handle(ProductImageDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting image {ImageId} of product {ProductId}", request.ImageId, request.ProductId);

        // Tenant-filtered lookup; a foreign image resolves to null and yields NotFound.
        var image = await _productImageRepository.GetByIdAsync(request.ImageId);
        if (image == null || image.ProductId != request.ProductId)
        {
            _logger.LogWarning("Image {ImageId} not found for product {ProductId}", request.ImageId, request.ProductId);
            return Result<Guid>.Fail(ResultStatusCode.NotFound, "Image not found");
        }

        var relativePath = image.RelativePath;
        var thumbnailPath = image.ThumbnailPath;

        try
        {
            await _productImageRepository.DeleteAsync(image);

            // Re-normalize the remaining images to a contiguous 0..n-1 ordering.
            var remaining = await _productImageRepository.GetByProductIdAsync(request.ProductId);
            var reindexed = false;
            for (var i = 0; i < remaining.Count; i++)
            {
                if (remaining[i].SortOrder != i)
                {
                    remaining[i].SortOrder = i;
                    reindexed = true;
                }
            }

            if (reindexed)
            {
                await _productImageRepository.SaveChangesAsync(cancellationToken);
            }

            // Best-effort file cleanup after the database is consistent.
            await _productImageStorage.DeleteAsync(relativePath, thumbnailPath, cancellationToken);

            var result = Result<Guid>.Success(request.ImageId);
            result.StatusCode = ResultStatusCode.NoContent;
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error deleting product image: {Message}", ex.Message);
            return Result<Guid>.Fail(ResultStatusCode.InternalServerError,
                $"An error occurred while deleting the image: {ex.Message}");
        }
    }
}
