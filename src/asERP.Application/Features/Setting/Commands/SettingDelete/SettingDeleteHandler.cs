using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Setting.Commands.SettingDelete;

public class SettingDeleteHandler : IRequestHandler<SettingDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<SettingDeleteHandler> _logger;
    private readonly ISettingRepository _settingRepository;

    public SettingDeleteHandler(
        IAppLogger<SettingDeleteHandler> logger,
        ISettingRepository settingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _settingRepository = settingRepository ?? throw new ArgumentNullException(nameof(settingRepository));
    }

    public async Task<Result<Guid>> Handle(SettingDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting setting with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SettingDeleteValidator(_settingRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;

            // Check if the validation error is about setting not found
            var settingNotFoundError = validationResult.Errors
                .FirstOrDefault(e => e.ErrorMessage.Contains("Setting not found"));

            if (settingNotFoundError != null)
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.Setting.NotFound, "Setting not found.");
            }
            else
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Setting.Invalid);
                result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));
            }

            _logger.LogWarning("Validation errors in delete request for {0}: {1}",
                nameof(SettingDeleteCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        // Create entity to delete
        var settingToDelete = new Domain.Entities.Setting()
        {
            Id = request.Id
        };

        // Delete from database
        await _settingRepository.DeleteAsync(settingToDelete);

        result.Succeeded = true;
        result.Status = ResultStatus.NoContent;
        result.Data = settingToDelete.Id;

        _logger.LogInformation("Successfully deleted setting with ID: {Id}", settingToDelete.Id);

        return result;
    }
}
