using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantOAuthAppSettings.Commands.TenantOAuthAppSettingsDelete;

public class TenantOAuthAppSettingsDeleteCommand : IRequest<Result<int>>
{
    public SalesChannelType Provider { get; set; }
}
