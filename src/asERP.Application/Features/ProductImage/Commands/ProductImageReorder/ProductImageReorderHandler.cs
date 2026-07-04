using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductImage.Commands.ProductImageReorder;

public class ProductImageReorderHandler : IRequestHandler<ProductImageReorderCommand, Result<Guid>>
{
    private readonly IAppLogger<ProductImageReorderHandler> _logger;
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageReorderHandler(
        IAppLogger<ProductImageReorderHandler> logger,
        IProductImageRepository productImageRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
    }

    public async Task<Result<Guid>> Handle(ProductImageReorderCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Reordering images of product {ProductId}", request.ProductId);

        var images = await _productImageRepository.GetByProductIdAsync(request.ProductId);
        if (images.Count == 0)
        {
            return Result<Guid>.Fail(ResultStatusCode.NotFound, "Product has no images to reorder");
        }

        // The requested ids must be exactly the product's image ids — no extras, none missing.
        var requestedIds = request.OrderedImageIds;
        var existingIds = images.Select(i => i.Id).ToHashSet();
        if (requestedIds.Count != existingIds.Count
            || requestedIds.Distinct().Count() != requestedIds.Count
            || !requestedIds.All(existingIds.Contains))
        {
            return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                "The provided image ids must match exactly the product's images.");
        }

        var byId = images.ToDictionary(i => i.Id);
        for (var index = 0; index < requestedIds.Count; index++)
        {
            byId[requestedIds[index]].SortOrder = index;
        }

        await _productImageRepository.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(request.ProductId);
    }
}
