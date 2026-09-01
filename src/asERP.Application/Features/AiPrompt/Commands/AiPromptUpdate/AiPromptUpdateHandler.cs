using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptUpdate;

public class AiPromptUpdateHandler : IRequestHandler<AiPromptUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<AiPromptUpdateHandler> _logger;
    private readonly IAiPromptRepository _aIPromptRepository;
    private readonly IAiModelRepository _aiModelRepository;
    private readonly ITenantContext _tenantContext;

    public AiPromptUpdateHandler(
        IAppLogger<AiPromptUpdateHandler> logger,
        IAiPromptRepository aIPromptRepository,
        IAiModelRepository aiModelRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aIPromptRepository = aIPromptRepository ?? throw new ArgumentNullException(nameof(aIPromptRepository));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<Guid>> Handle(AiPromptUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating AI prompt with ID: {Id} and identifier: {Identifier}", request.Id, request.Identifier);

        var result = new Result<Guid>();

        // Load existing AI prompt from database
        var aIPromptToUpdate = await _aIPromptRepository.GetByIdAsync(request.Id);

        if (aIPromptToUpdate == null)
        {
            _logger.LogWarning("AI prompt with ID {Id} not found for update", request.Id);
            result.Fail(ErrorType.NotFound, ErrorCodes.AiPrompt.NotFound, "AI prompt not found.");
            return result;
        }

        // Update properties
        aIPromptToUpdate.AiModelId = request.AiModelId;
        aIPromptToUpdate.Identifier = request.Identifier;
        aIPromptToUpdate.PromptText = request.PromptText;

        // Save changes (entity is already tracked, so just save)
        await _aIPromptRepository.SaveChangesAsync();

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = aIPromptToUpdate.Id;

        _logger.LogInformation("Successfully updated AI prompt with ID: {Id}", aIPromptToUpdate.Id);

        return result;
    }
}
