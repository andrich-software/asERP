using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.SalesChannelOAuth;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.SalesChannelOAuth.Commands.OAuthStart;

public class OAuthStartCommand : IRequest<Result<OAuthStartResponseDto>>
{
    public Guid SalesChannelId { get; set; }
    public SalesChannelType Provider { get; set; }
    public string? UserId { get; set; }
}
