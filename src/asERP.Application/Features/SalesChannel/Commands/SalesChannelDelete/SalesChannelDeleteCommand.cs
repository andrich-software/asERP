using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelDelete;

public class SalesChannelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
