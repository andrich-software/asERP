using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingCreate;

/// <summary>
/// Handler for processing setting creation commands.
/// Implements IRequestHandler from MediatR to handle SettingCreateCommand requests
/// and return the ID of the newly created setting wrapped in a Result.
/// </summary>
public class SettingCreateHandler : IRequestHandler<SettingCreateCommand, Result<Guid>>
{
    /// <summary>
    /// Logger for recording handler operations
    /// </summary>
    private readonly IAppLogger<SettingCreateHandler> _logger;

    /// <summary>
    /// Repository for setting data operations
    /// </summary>
    private readonly ISettingRepository _settingRepository;

    /// <summary>
    /// Constructor that initializes the handler with required dependencies
    /// </summary>
    /// <param name="logger">Logger for recording operations</param>
    /// <param name="settingRepository">Repository for setting data access</param>
    public SettingCreateHandler(
        IAppLogger<SettingCreateHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    /// <summary>
    /// Handles the setting creation request
    /// </summary>
    /// <param name="request">The setting creation command with setting details</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result containing the ID of the newly created setting if successful</returns>
    public async Task<Result<Guid>> Handle(SettingCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new setting with name: {Name}", request.Key);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SettingCreateValidator(_settingRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // If validation fails, return a bad request result with validation error messages
        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(SettingCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Map request to domain entity
            var settingToCreate = MapToEntity(request);

            // Add the new setting to the database
            await _settingRepository.CreateAsync(settingToCreate);

            // Set successful result with the new setting ID
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = settingToCreate.Id;

            _logger.LogInformation("Successfully created setting with ID: {Id}", settingToCreate.Id);
        }
        catch (Exception ex)
        {
            // Handle any exceptions during setting creation
            result.FromException(_logger, ex,
                "An error occurred while creating the setting.",
                "Error creating setting.");
        }

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
