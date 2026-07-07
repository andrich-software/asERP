using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Feed.Commands.FeedDelete;

public class FeedDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
