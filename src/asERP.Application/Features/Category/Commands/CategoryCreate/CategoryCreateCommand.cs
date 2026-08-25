using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryCreate;

/// <summary>
/// Command for creating a new category. Inherits from CategoryInputDto to get all category
/// properties and implements IRequest to work with the mediator, returning the ID of the newly
/// created category wrapped in a Result.
/// </summary>
public class CategoryCreateCommand : CategoryInputDto, IRequest<Result<Guid>>
{
}
