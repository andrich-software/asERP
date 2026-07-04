using asERP.Application.Mediator;
using asERP.Domain.Dtos.TenantEmailSettings;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantEmailSettings.Queries.TenantEmailSettingsDetail;

/// <summary>
/// Returns the email configuration for the current tenant. Returns 404 when no override exists.
/// </summary>
public class TenantEmailSettingsDetailQuery : IRequest<Result<TenantEmailSettingsDetailDto>>
{
}
