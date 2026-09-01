using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
// using ValidationException = asERP.Application.Exceptions.ValidationException;

namespace asERP.Application.Features.AiModel.Commands.AiModelCreate;

/// <summary>
/// Handler for processing AI model creation commands.
/// Implements IRequestHandler from the custom mediator to handle AiModelCreateCommand requests
/// and return the ID of the newly created AI model wrapped in a Result.
/// </summary>
public class AiModelCreateHandler : IRequestHandler<AiModelCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<AiModelCreateHandler> _logger;
    private readonly IAiModelRepository _aiModelRepository;

    public AiModelCreateHandler(
        IAppLogger<AiModelCreateHandler> logger,
        IAiModelRepository aiModelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
    }

    public async Task<Result<Guid>> Handle(AiModelCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new AI model with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Validate that the AI model type is a valid enum value
        if (!Enum.IsDefined(typeof(AiModelType), request.AiModelType))
        {
            result.Fail(ErrorType.Validation, ErrorCodes.AiModel.Invalid, $"Invalid AiModelType value: {request.AiModelType}");

            _logger.LogWarning("Invalid AiModelType value in create request: {0}", request.AiModelType);

            return result;
        }

        // Direct manual mapping without helper class
        var aiModelToCreate = new Domain.Entities.AiModel
        {
            Name = request.Name,
            AiModelType = request.AiModelType,
            ApiUsername = request.ApiUsername,
            ApiPassword = request.ApiPassword,
            ApiKey = request.ApiKey,
            NCtx = request.NCtx
        };

        // Add the new AI model to the database
        await _aiModelRepository.CreateAsync(aiModelToCreate);

        // Set successful result with the new AI model ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = aiModelToCreate.Id;

        _logger.LogInformation("Successfully created AI model with ID: {Id}", aiModelToCreate.Id);

        return result;
    }
}
