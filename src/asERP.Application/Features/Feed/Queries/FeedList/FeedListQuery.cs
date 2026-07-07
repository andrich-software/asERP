using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedList;

public class FeedListQuery : IRequest<PaginatedResult<FeedListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public FeedListQuery(int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        SalesBy = string.IsNullOrWhiteSpace(salesBy) ? Array.Empty<string>() : salesBy.Split(',');
    }
}
