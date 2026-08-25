using asERP.Application.Mediator;
using asERP.Domain.Dtos.Category;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Category.Commands.CategoryChannelActivationUpdate;

/// <summary>
/// Batch of per-channel activation changes from the category matrix. Returns the number of cells
/// that actually changed state (after the ancestor/descendant expansion).
/// </summary>
public class CategoryChannelActivationUpdateCommand : IRequest<Result<int>>
{
    public List<CategoryChannelActivationChange> Changes { get; set; } = new();
}
