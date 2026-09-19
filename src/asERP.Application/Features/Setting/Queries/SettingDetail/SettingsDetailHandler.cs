using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Setting;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Queries.SettingDetail;

/// <summary>
/// Handler for processing setting detail queries.
/// Implements IRequestHandler from the custom mediator to handle SettingDetailQuery requests
/// and return detailed setting information wrapped in a Result.
/// </summary>
public class SettingDetailHandler : IRequestHandler<SettingDetailQuery, Result<SettingDetailDto>>
{
    private readonly IAppLogger<SettingDetailHandler> _logger;
    private readonly ISettingRepository _settingRepository;

    public SettingDetailHandler(
        IAppLogger<SettingDetailHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public async Task<Result<SettingDetailDto>> Handle(SettingDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving setting details for ID: {Id}", request.Id);

        // Retrieve setting with all related details from the repository
        var setting = await _settingRepository.GetByIdAsync(request.Id, true);

        // If setting not found, return a not found result
        if (setting == null)
        {
            _logger.LogWarning("Setting with ID {Id} not found", request.Id);
            return Result<SettingDetailDto>.NotFound(ErrorCodes.Setting.NotFound, $"Setting with ID {request.Id} not found");
        }

        // Map entity to DTO using the mapping method
        var data = MapToDetailDto(setting);

        _logger.LogInformation("Setting with ID {Id} retrieved successfully", request.Id);

        return Result<SettingDetailDto>.Ok(data);
    }

    /// <summary>
    /// Maps a setting entity to a detail DTO
    /// </summary>
    /// <param name="entity">The setting entity to map</param>
    /// <returns>A setting detail DTO with properties from the entity</returns>
    private SettingDetailDto MapToDetailDto(Domain.Entities.Setting entity)
    {
        return new SettingDetailDto()
        {
            Id = entity.Id,
            Key = entity.Key,
            Value = entity.Value
        };
    }
}
