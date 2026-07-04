using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannelOAuth.Commands.OAuthDisconnect;

public class OAuthDisconnectCommand : IRequest<Result<int>>
{
    public Guid SalesChannelId { get; set; }
}
