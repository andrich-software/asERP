using asERP.Application.Mediator;
using asERP.Domain.Dtos.Feed;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedUpdate;

public class FeedUpdateCommand : FeedInputDto, IRequest<Result<Guid>>
{
}
