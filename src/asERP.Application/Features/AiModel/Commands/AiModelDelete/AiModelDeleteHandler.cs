using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Commands.AiModelDelete;

public class AiModelDeleteHandler : IRequestHandler<AiModelDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<AiModelDeleteHandler> _logger;
    private readonly IAiModelRepository _aiModelRepository;

    public AiModelDeleteHandler(
        IAppLogger<AiModelDeleteHandler> logger,
        IAiModelRepository aiModelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
    }

    public async Task<Result<Guid>> Handle(AiModelDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting AI model with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Create entity to delete
        var aiModelToDelete = new Domain.Entities.AiModel
        {
            Id = request.Id
        };

        try
        {
            await _aiModelRepository.DeleteAsync(aiModelToDelete);
        }
        catch (Exception ex) when (ex is InvalidOperationException or UnauthorizedAccessException)
        {
            // This DELETE is idempotent — AIModelsController answers 204 whatever comes back — so
            // "row already gone" (InvalidOperationException) and "row belongs to another tenant"
            // (UnauthorizedAccessException) must not surface as an error. Deliberately narrow: a
            // real infrastructure failure still bubbles up to the GlobalExceptionHandler.
            _logger.LogWarning("AI model {Id} was not deletable in this context: {Message}", request.Id, ex.Message);

            result.Fail(ErrorType.NotFound, ErrorCodes.AiModel.NotFound, "AI model not found");
            return result;
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = aiModelToDelete.Id;

        _logger.LogInformation("Successfully deleted AI model with ID: {Id}", aiModelToDelete.Id);

        return result;
    }
}
