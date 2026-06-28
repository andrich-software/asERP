using asToolkit.Application.Mediator;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantOAuthAppSettings.Commands.TenantOAuthAppSettingsDelete;

public class TenantOAuthAppSettingsDeleteCommand : IRequest<Result<int>>
{
    public SalesChannelType Provider { get; set; }
}
