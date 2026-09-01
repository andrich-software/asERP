using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
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

        // Load the tracked entity and mutate it, so the persistence layer keeps
        // TenantId/DateCreated intact instead of nulling them on a detached update.
        var aiModelToUpdate = await _aiModelRepository.GetByIdAsync(request.Id);
        if (aiModelToUpdate == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.AiModel.NotFound, "AI model not found.");
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
        result.Status = ResultStatus.Ok;
        result.Data = aiModelToUpdate.Id;

        _logger.LogInformation("Successfully updated AI model with ID: {Id}", aiModelToUpdate.Id);

        return result;
    }
}
