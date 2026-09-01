using asERP.Application.Mediator;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Queries.SalesChannelList;

public class SalesChannelListQuery : IRequest<PaginatedResult<SalesChannelListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public SalesChannelListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        SearchString = searchString;

        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            SortBy = sortBy.Split(',');
        }
        else SortBy = new string[] { };
    }
}
