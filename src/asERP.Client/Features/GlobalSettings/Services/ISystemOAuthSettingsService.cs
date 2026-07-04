using asERP.Domain.Dtos.SystemOAuthSettings;

namespace asERP.Client.Features.GlobalSettings.Services;

public interface ISystemOAuthSettingsService
{
    Task<SystemOAuthSettingsDto?> GetAsync(string provider, CancellationToken ct = default);
    Task UpsertAsync(string provider, SystemOAuthSettingsInputDto input, CancellationToken ct = default);
}
