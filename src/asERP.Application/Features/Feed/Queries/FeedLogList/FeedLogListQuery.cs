using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedLogList;

public class FeedLogListQuery : IRequest<PaginatedResult<FeedLogDto>>
{
    public Guid FeedId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public FeedLogListQuery(Guid feedId, int pageNumber = 0, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        FeedId = feedId;
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        SortBy = string.IsNullOrWhiteSpace(sortBy) ? Array.Empty<string>() : sortBy.Split(',');
    }
}
