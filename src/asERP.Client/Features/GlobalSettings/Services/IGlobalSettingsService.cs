using asERP.Domain.Dtos.GlobalSettings;

namespace asERP.Client.Features.GlobalSettings.Services;

public interface IGlobalSettingsService
{
    Task<List<GlobalSettingDto>?> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(GlobalSettingsUpdateInputDto input, CancellationToken ct = default);
}
