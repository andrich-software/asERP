using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingUpdate;

public class SettingUpdateQuery : IRequestHandler<SettingUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<SettingUpdateQuery> _logger;
    private readonly ISettingRepository _settingRepository;

    public SettingUpdateQuery(
        IAppLogger<SettingUpdateQuery> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public async Task<Result<Guid>> Handle(SettingUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating setting with ID: {Id} and name: {Name}", request.Id, request.Key);

        // Get the existing entity to preserve fields we don't want to overwrite
        var existingSetting = await _settingRepository.GetByIdAsync(request.Id);
        if (existingSetting == null)
        {
            return Result<Guid>.NotFound(ErrorCodes.Setting.NotFound, "Setting not found");
        }

        // Update only the fields that should be modified
        existingSetting.Key = request.Key;
        existingSetting.Value = request.Value;
        existingSetting.DateModified = DateTime.UtcNow;

        // Update in database
        await _settingRepository.UpdateAsync(existingSetting);

        _logger.LogInformation("Successfully updated setting with ID: {Id}", existingSetting.Id);

        return Result<Guid>.Ok(existingSetting.Id);
    }

}
