using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptDelete;

public class AiPromptDeleteHandler : IRequestHandler<AiPromptDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<AiPromptDeleteHandler> _logger;
    private readonly IAiPromptRepository _aIPromptRepository;

    public AiPromptDeleteHandler(
        IAppLogger<AiPromptDeleteHandler> logger,
        IAiPromptRepository aIPromptRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aIPromptRepository = aIPromptRepository ?? throw new ArgumentNullException(nameof(aIPromptRepository));
    }

    public async Task<Result<Guid>> Handle(AiPromptDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting AI prompt with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            // Get entity from database first
            var aIPromptToDelete = await _aIPromptRepository.GetByIdAsync(request.Id);

            if (aIPromptToDelete == null)
            {
                _logger.LogWarning("AI prompt with ID: {Id} not found for deletion", request.Id);
                result.Fail(ErrorType.NotFound, ErrorCodes.AiPrompt.NotFound, "AI prompt not found");
                return result;
            }

            // Delete from database
            await _aIPromptRepository.DeleteAsync(aIPromptToDelete);

            result.Succeeded = true;
            result.Status = ResultStatus.NoContent;
            result.Data = aIPromptToDelete.Id;

            _logger.LogInformation("Successfully deleted AI prompt with ID: {Id}", aIPromptToDelete.Id);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - prompt was already deleted by another request
            _logger.LogWarning("AI prompt with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);

            result.Fail(ErrorType.NotFound, ErrorCodes.AiPrompt.NotFound, "AI prompt not found");
        }
        catch (InvalidOperationException ex)
        {
            // Repository signals entity was already removed (e.g. concurrent delete)
            _logger.LogWarning(
                "AI prompt with ID: {Id} not found for deletion. Reason: {Reason}",
                request.Id,
                ex.Message);

            result.Fail(ErrorType.NotFound, ErrorCodes.AiPrompt.NotFound, "AI prompt not found");
        }

        return result;
    }
}
