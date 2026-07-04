using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelDelete;

public class SalesChannelDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}