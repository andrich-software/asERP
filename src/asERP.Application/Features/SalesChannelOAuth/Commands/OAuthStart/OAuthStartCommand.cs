using asERP.Application.Mediator;
using asERP.Domain.Dtos.SalesChannelOAuth;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannelOAuth.Commands.OAuthStart;

public class OAuthStartCommand : IRequest<Result<OAuthStartResponseDto>>
{
    public Guid SalesChannelId { get; set; }
    public SalesChannelType Provider { get; set; }
    public string? UserId { get; set; }
}
