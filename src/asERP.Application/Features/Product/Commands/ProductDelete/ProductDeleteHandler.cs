using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductDelete;

public class ProductDeleteHandler : IRequestHandler<ProductDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductDeleteHandler> _logger;
    private readonly IProductRepository _productRepository;
    private readonly IProductImageRepository _productImageRepository;
    private readonly IProductImageStorage _productImageStorage;

    public ProductDeleteHandler(
        IAppLogger<ProductDeleteHandler> logger,
        IProductRepository productRepository,
        IProductImageRepository productImageRepository,
        IProductImageStorage productImageStorage)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
        _productImageStorage = productImageStorage ?? throw new ArgumentNullException(nameof(productImageStorage));
    }

    public async Task<Result<Guid>> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting product with ID: {Id}", request.Id);

        // Validate incoming data
        var validator = new ProductDeleteValidator(_productRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(ProductDeleteCommand), validationErrors);

            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            // Get entity from database first
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);

            if (productToDelete == null)
            {
                _logger.LogWarning("Product with ID: {Id} not found for deletion", request.Id);
                return Result<Guid>.Fail(ResultStatusCode.NotFound, "Product not found");
            }

            // Collect image file paths (this product plus any variant children) before the DB
            // cascade removes the rows. File cleanup happens after the DB delete succeeds.
            var imagesToDelete = new List<Domain.Entities.ProductImage>(
                await _productImageRepository.GetByProductIdAsync(productToDelete.Id));

            foreach (var variant in await _productRepository.GetVariantsAsync(productToDelete.Id))
            {
                imagesToDelete.AddRange(await _productImageRepository.GetByProductIdAsync(variant.Id));
            }

            // Delete from database incl. dependents (variants, options, axes, channel links, stocks, images)
            await _productRepository.DeleteWithDependentsAsync(productToDelete);

            // Best-effort file cleanup; the database is already consistent at this point.
            foreach (var image in imagesToDelete)
            {
                try
                {
                    await _productImageStorage.DeleteAsync(image.RelativePath, image.ThumbnailPath, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning("Failed to delete image file {Path}: {Message}", image.RelativePath, ex.Message);
                }
            }

            _logger.LogInformation("Successfully deleted product with ID: {Id}", productToDelete.Id);

            var result = Result<Guid>.Success(productToDelete.Id);
            result.StatusCode = ResultStatusCode.NoContent;
            return result;
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - product was already deleted by another request
            _logger.LogWarning("Product with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);

            return Result<Guid>.Fail(ResultStatusCode.NotFound, "Product not found");
        }
        catch (Exception ex)
        {
            _logger.LogError("Error deleting product: {Message}", ex.Message);

            return Result<Guid>.Fail(ResultStatusCode.InternalServerError,
                $"An error occurred while deleting the product: {ex.Message}");
        }
    }
}
