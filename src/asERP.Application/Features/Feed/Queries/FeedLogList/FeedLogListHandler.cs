using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedLogList;

public class FeedLogListHandler : IRequestHandler<FeedLogListQuery, PaginatedResult<FeedLogDto>>
{
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(FeedLog.DateCreated),
        nameof(FeedLog.IpAddress),
        nameof(FeedLog.UserAgent),
        nameof(FeedLog.Id),
    };

    private readonly IAppLogger<FeedLogListHandler> _logger;
    private readonly IGenericRepository<FeedLog> _feedLogRepository;

    public FeedLogListHandler(IAppLogger<FeedLogListHandler> logger, IGenericRepository<FeedLog> feedLogRepository)
    {
        _logger = logger;
        _feedLogRepository = feedLogRepository;
    }

    public async Task<PaginatedResult<FeedLogDto>> Handle(FeedLogListQuery request, CancellationToken cancellationToken)
    {
        var query = _feedLogRepository.Entities.Where(l => l.FeedId == request.FeedId);

        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var search = request.SearchString;
            query = query.Where(l =>
                (l.IpAddress != null && l.IpAddress.Contains(search)) ||
                (l.UserAgent != null && l.UserAgent.Contains(search)));
        }

        // Newest-first by default; a client-supplied sort overrides this.
        query = query.OrderByDescending(l => l.DateCreated);

        return await query
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(l => new FeedLogDto
            {
                Id = l.Id,
                IpAddress = l.IpAddress,
                UserAgent = l.UserAgent,
                DateCreated = l.DateCreated,
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
