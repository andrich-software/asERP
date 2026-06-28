using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.TenantEmailSettings;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantEmailSettings.Queries.TenantEmailSettingsDetail;

/// <summary>
/// Returns the email configuration for the current tenant. Returns 404 when no override exists.
/// </summary>
public class TenantEmailSettingsDetailQuery : IRequest<Result<TenantEmailSettingsDetailDto>>
{
}
