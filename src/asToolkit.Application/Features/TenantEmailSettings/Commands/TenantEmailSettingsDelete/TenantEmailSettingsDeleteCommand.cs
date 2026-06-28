using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.TenantEmailSettings.Commands.TenantEmailSettingsDelete;

/// <summary>
/// Removes the tenant-level email override so the tenant falls back to the server defaults.
/// </summary>
public class TenantEmailSettingsDeleteCommand : IRequest<Result<Guid>>
{
}
