using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Queries.SettingList;

public class SettingListQuery : IRequest<PaginatedResult<SettingListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public SettingListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
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
