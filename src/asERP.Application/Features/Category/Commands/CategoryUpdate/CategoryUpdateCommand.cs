using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryUpdate;

/// <summary>
/// Command for updating an existing category (rename, reparent, reorder). Inherits from
/// CategoryInputDto and returns the updated category's ID wrapped in a Result.
/// </summary>
public class CategoryUpdateCommand : CategoryInputDto, IRequest<Result<Guid>>
{
}
