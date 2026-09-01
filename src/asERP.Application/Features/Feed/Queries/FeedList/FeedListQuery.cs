using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedList;

public class FeedListQuery : IRequest<PaginatedResult<FeedListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public FeedListQuery(int pageNumber = 0, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        SortBy = string.IsNullOrWhiteSpace(sortBy) ? Array.Empty<string>() : sortBy.Split(',');
    }
}
