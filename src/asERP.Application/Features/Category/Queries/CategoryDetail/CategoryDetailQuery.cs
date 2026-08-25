using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Queries.CategoryDetail;

public class CategoryDetailQuery : IRequest<Result<CategoryDetailDto>>
{
    public CategoryDetailQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}
