using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Queries.FeedProductSelectionList;

/// <summary>
/// Paged product list for a feed, each row annotated with whether it is currently included
/// (<see cref="FeedProductSelectionDto.IsActive"/>). Powers the read-only "Products" detail tab and the
/// editable checkbox list.
/// </summary>
public class FeedProductSelectionListQuery : IRequest<PaginatedResult<FeedProductSelectionDto>>
{
    public Guid FeedId { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SalesBy { get; set; }

    public FeedProductSelectionListQuery(Guid feedId, int pageNumber = 0, int pageSize = 10, string searchString = "", string salesBy = "")
    {
        FeedId = feedId;
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;
        SalesBy = string.IsNullOrWhiteSpace(salesBy) ? Array.Empty<string>() : salesBy.Split(',');
    }
}
