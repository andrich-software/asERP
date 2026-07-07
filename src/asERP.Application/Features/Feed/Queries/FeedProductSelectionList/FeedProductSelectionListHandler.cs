using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedProductSelectionList;

public class FeedProductSelectionListHandler : IRequestHandler<FeedProductSelectionListQuery, PaginatedResult<FeedProductSelectionDto>>
{
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Product.Id),
        nameof(Domain.Entities.Product.Sku),
        nameof(Domain.Entities.Product.Name),
        nameof(Domain.Entities.Product.Price),
        nameof(Domain.Entities.Product.DateCreated),
    };

    private readonly IAppLogger<FeedProductSelectionListHandler> _logger;
    private readonly IProductRepository _productRepository;

    public FeedProductSelectionListHandler(IAppLogger<FeedProductSelectionListHandler> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    public async Task<PaginatedResult<FeedProductSelectionDto>> Handle(FeedProductSelectionListQuery request, CancellationToken cancellationToken)
    {
        var feedId = request.FeedId;

        // Same DbContext, tenant-filtered; used as a correlated EXISTS subquery for the IsActive flag.
        var feedProducts = _productRepository.GetContext<FeedProduct>();

        var query = _productRepository.Entities;

        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var lower = request.SearchString.ToLower();
            query = query.Where(p => p.Sku.ToLower().Contains(lower) || p.Name.ToLower().Contains(lower));
        }

        return await query
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(p => new FeedProductSelectionDto
            {
                ProductId = p.Id,
                Sku = p.Sku,
                Name = p.Name,
                Price = p.Price,
                PrimaryImageId = p.Images.OrderBy(i => i.SortOrder).Select(i => (Guid?)i.Id).FirstOrDefault(),
                // Included by default unless an exclusion row (IsActive == false) exists for this feed.
                IsActive = !feedProducts.Any(fp => fp.FeedId == feedId && fp.ProductId == p.Id && !fp.IsActive),
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
