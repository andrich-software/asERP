using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsDelete;

/// <summary>
/// Removes the tenant-level email override so the tenant falls back to the server defaults.
/// </summary>
public class TenantEmailSettingsDeleteCommand : IRequest<Result<Guid>>
{
}
