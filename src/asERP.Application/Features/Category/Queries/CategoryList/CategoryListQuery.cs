using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Queries.CategoryList;

/// <summary>
/// Returns the tenant's complete category list (deliberately unpaginated — the tree view always
/// needs the full set; per-tenant category counts are small). Ordering/indentation is derived
/// client-side via <c>CategoryTreeBuilder</c>.
/// </summary>
public class CategoryListQuery : IRequest<Result<List<CategoryListDto>>>
{
}
