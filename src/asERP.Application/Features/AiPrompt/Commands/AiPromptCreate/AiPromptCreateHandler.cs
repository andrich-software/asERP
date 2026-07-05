using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Commands.AiPromptCreate;

public class AiPromptCreateHandler : IRequestHandler<AiPromptCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<AiPromptCreateHandler> _logger;
    private readonly IAiPromptRepository _aIPromptRepository;
    private readonly IAiModelRepository _aiModelRepository;
    private readonly ITenantContext _tenantContext;

    public AiPromptCreateHandler(
        IAppLogger<AiPromptCreateHandler> logger,
        IAiPromptRepository aIPromptRepository,
        IAiModelRepository aiModelRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aIPromptRepository = aIPromptRepository ?? throw new ArgumentNullException(nameof(aIPromptRepository));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<Guid>> Handle(AiPromptCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new AI prompt with identifier: {Identifier}", request.Identifier);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new AiPromptCreateValidator(_aIPromptRepository, _aiModelRepository, _tenantContext);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(AiPromptCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // Manuelles Mapping statt AutoMapper
            var aIPromptToCreate = new Domain.Entities.AiPrompt
            {
                AiModelId = request.AiModelId,
                Identifier = request.Identifier,
                PromptText = request.PromptText
            };

            // add to database
            await _aIPromptRepository.CreateAsync(aIPromptToCreate);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = aIPromptToCreate.Id;

            _logger.LogInformation("Successfully created AI prompt with ID: {Id}", aIPromptToCreate.Id);
        }
        catch (Exception ex)
        {
            // Never leak the raw exception text.
            result.FromException(_logger, ex,
                "An error occurred while creating the AI prompt.",
                "Error creating AI prompt.");
        }

        return result;
    }
}
