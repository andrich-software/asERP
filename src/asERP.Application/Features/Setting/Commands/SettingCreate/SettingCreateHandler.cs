using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingCreate;

/// <summary>
/// Handler for processing setting creation commands.
/// Implements IRequestHandler from the custom mediator to handle SettingCreateCommand requests
/// and return the ID of the newly created setting wrapped in a Result.
/// </summary>
public class SettingCreateHandler : IRequestHandler<SettingCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<SettingCreateHandler> _logger;
    private readonly ISettingRepository _settingRepository;

    public SettingCreateHandler(
        IAppLogger<SettingCreateHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public async Task<Result<Guid>> Handle(SettingCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new setting with name: {Name}", request.Key);

        var result = new Result<Guid>();

        // Map request to domain entity
        var settingToCreate = MapToEntity(request);

        // Add the new setting to the database
        await _settingRepository.CreateAsync(settingToCreate);

        // Set successful result with the new setting ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = settingToCreate.Id;

        _logger.LogInformation("Successfully created setting with ID: {Id}", settingToCreate.Id);

        return result;
    }

    private static asERP.Domain.Entities.Setting MapToEntity(SettingCreateCommand request)
    {
        return new Domain.Entities.Setting
        {
            Key = request.Key,
            Value = request.Value
        };
    }
}
