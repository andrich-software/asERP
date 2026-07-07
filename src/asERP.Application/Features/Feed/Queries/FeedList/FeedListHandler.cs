using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedList;

public class FeedListHandler : IRequestHandler<FeedListQuery, PaginatedResult<FeedListDto>>
{
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Feed.Id),
        nameof(Domain.Entities.Feed.Name),
        nameof(Domain.Entities.Feed.Template),
        nameof(Domain.Entities.Feed.Currency),
        nameof(Domain.Entities.Feed.IsEnabled),
        nameof(Domain.Entities.Feed.DateCreated),
    };

    private readonly IAppLogger<FeedListHandler> _logger;
    private readonly IFeedRepository _feedRepository;

    public FeedListHandler(IAppLogger<FeedListHandler> logger, IFeedRepository feedRepository)
    {
        _logger = logger;
        _feedRepository = feedRepository;
    }

    public async Task<PaginatedResult<FeedListDto>> Handle(FeedListQuery request, CancellationToken cancellationToken)
    {
        var spec = new FeedFilterSpecification(request.SearchString);

        return await _feedRepository.Entities
            .Specify(spec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(f => new FeedListDto
            {
                Id = f.Id,
                Name = f.Name,
                Template = f.Template,
                Currency = f.Currency,
                IsEnabled = f.IsEnabled,
                SalesChannelName = f.SalesChannel != null ? f.SalesChannel.Name : null,
                LastAccessedAt = f.FeedLogs
                    .OrderByDescending(l => l.DateCreated)
                    .Select(l => (DateTime?)l.DateCreated)
                    .FirstOrDefault(),
                DateCreated = f.DateCreated,
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
