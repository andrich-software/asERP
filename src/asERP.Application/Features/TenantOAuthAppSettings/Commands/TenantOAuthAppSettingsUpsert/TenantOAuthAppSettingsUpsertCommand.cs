using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TenantOAuthAppSettings.Commands.TenantOAuthAppSettingsUpsert;

public class TenantOAuthAppSettingsUpsertCommand : IRequest<Result<Guid>>
{
    public SalesChannelType Provider { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ClientId { get; set; }

    /// <summary>
    /// <c>null</c> means "keep existing"; non-null means "replace stored value with this".
    /// </summary>
    public string? ClientSecret { get; set; }

    public string? RedirectUri { get; set; }
    public string? RuName { get; set; }
    public string? Scopes { get; set; }
    public bool? UseSandbox { get; set; }
}
