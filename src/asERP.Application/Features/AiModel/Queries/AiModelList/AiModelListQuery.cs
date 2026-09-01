using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Queries.AiModelList;

public class AiModelListQuery : IRequest<PaginatedResult<AiModelListDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string SearchString { get; set; }
    public string[] SortBy { get; set; }

    public AiModelListQuery(int pageNumber = 1, int pageSize = 10, string searchString = "", string sortBy = "")
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
