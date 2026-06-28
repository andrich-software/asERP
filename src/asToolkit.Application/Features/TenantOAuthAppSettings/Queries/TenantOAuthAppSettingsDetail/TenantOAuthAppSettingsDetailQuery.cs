using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.TenantOAuthAppSettings;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantOAuthAppSettings.Queries.TenantOAuthAppSettingsDetail;

public class TenantOAuthAppSettingsDetailQuery : IRequest<Result<TenantOAuthAppSettingsDetailDto>>
{
    public SalesChannelType Provider { get; set; }
}
