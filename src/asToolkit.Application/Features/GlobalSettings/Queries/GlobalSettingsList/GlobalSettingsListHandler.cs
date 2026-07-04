using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.GlobalSettings;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.GlobalSettings.Queries.GlobalSettingsList;

public class GlobalSettingsListHandler
    : IRequestHandler<GlobalSettingsListQuery, Result<List<GlobalSettingDto>>>
{
    private readonly IAppLogger<GlobalSettingsListHandler> _logger;
    private readonly ISettingRepository _settingRepository;

    public GlobalSettingsListHandler(
        IAppLogger<GlobalSettingsListHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger;
        _settingRepository = settingRepository;
    }

    public Task<Result<List<GlobalSettingDto>>> Handle(
        GlobalSettingsListQuery request, CancellationToken cancellationToken)
    {
        var dtos = _settingRepository.Entities
            .AsEnumerable()
            .Where(s => !GlobalSettingsRules.IsHidden(s.Key))
            .OrderBy(s => s.Key, StringComparer.OrdinalIgnoreCase)
            .Select(s =>
            {
                var isSecret = GlobalSettingsRules.IsSecret(s.Key, s.IsEncrypted);
                return new GlobalSettingDto
                {
                    Key = s.Key,
                    // Secrets are write-only: the ciphertext (or legacy plaintext) never leaves
                    // the server; the client only learns whether something is stored.
                    Value = isSecret ? string.Empty : s.Value,
                    IsSecret = isSecret,
                    HasValue = !string.IsNullOrEmpty(s.Value),
                };
            })
            .ToList();

        _logger.LogInformation("Listed {Count} global settings", dtos.Count);
        return Task.FromResult(Result<List<GlobalSettingDto>>.Success(dtos));
    }
}
