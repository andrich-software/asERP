using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedCreate;

/// <summary>
/// Command for creating a new feed. Inherits <see cref="FeedInputDto"/> and returns the new feed's id.
/// </summary>
public class FeedCreateCommand : FeedInputDto, IRequest<Result<Guid>>
{
}
