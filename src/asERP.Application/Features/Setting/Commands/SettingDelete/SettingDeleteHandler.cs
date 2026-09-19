using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

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

        // Create entity to delete
        var settingToDelete = new Domain.Entities.Setting()
        {
            Id = request.Id
        };

        try
        {
            await _settingRepository.DeleteAsync(settingToDelete);
        }
        catch (Exception ex) when (ex is InvalidOperationException or UnauthorizedAccessException or DbUpdateConcurrencyException)
        {
            // Existence is decided here, not by the validator, so a missing setting answers 404
            // rather than a validation message. Letting the delete itself report it also covers the
            // race between two concurrent deletes, which a prior check-then-delete would not —
            // SettingRepository does not pre-check, so a vanished row surfaces as a concurrency
            // exception rather than an InvalidOperationException.
            _logger.LogWarning("Setting {Id} was not deletable in this context: {Message}", request.Id, ex.Message);

            return Result<Guid>.NotFound(ErrorCodes.Setting.NotFound, "Setting not found.");
        }

        _logger.LogInformation("Successfully deleted setting with ID: {Id}", settingToDelete.Id);

        return Result<Guid>.NoContent(settingToDelete.Id);
    }
}
