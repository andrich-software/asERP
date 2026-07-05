using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Commands.AiModelUpdate;

public class AiModelUpdateHandler : IRequestHandler<AiModelUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<AiModelUpdateHandler> _logger;
    private readonly IAiModelRepository _aiModelRepository;


    public AiModelUpdateHandler(
        IAppLogger<AiModelUpdateHandler> logger,
        IAiModelRepository aiModelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
    }

    public async Task<Result<Guid>> Handle(AiModelUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating AI model with ID: {Id} and name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new AiModelUpdateValidator(_aiModelRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(AiModelUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Load the tracked entity and mutate it, so the persistence layer keeps
            // TenantId/DateCreated intact instead of nulling them on a detached update.
            var aiModelToUpdate = await _aiModelRepository.GetByIdAsync(request.Id);
            if (aiModelToUpdate == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add("AI model not found.");
                _logger.LogWarning("AI model with ID {Id} not found for update", request.Id);
                return result;
            }

            aiModelToUpdate.Name = request.Name;
            aiModelToUpdate.AiModelType = request.AiModelType;
            aiModelToUpdate.ApiUrl = request.ApiUrl;
            aiModelToUpdate.ApiUsername = request.ApiUsername;
            aiModelToUpdate.NCtx = request.NCtx;

            // Secrets are write-only on the wire: an empty input means "keep the stored value"
            // so the client never has to resend the credential to change other fields.
            if (!string.IsNullOrEmpty(request.ApiPassword))
            {
                aiModelToUpdate.ApiPassword = request.ApiPassword;
            }

            if (!string.IsNullOrEmpty(request.ApiKey))
            {
                aiModelToUpdate.ApiKey = request.ApiKey;
            }

            // Save changes (entity is already tracked, so just save)
            await _aiModelRepository.SaveChangesAsync();

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = aiModelToUpdate.Id;

            _logger.LogInformation("Successfully updated AI model with ID: {Id}", aiModelToUpdate.Id);
        }
        catch (Exception ex)
        {
            // Never leak the raw exception text.
            result.FromException(_logger, ex,
                "An error occurred while updating the AI model.",
                "Error updating AI model.");
        }

        return result;
    }
}
