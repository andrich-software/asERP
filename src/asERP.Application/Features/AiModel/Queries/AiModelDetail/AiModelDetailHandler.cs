using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Queries.AiModelDetail;

/// <summary>
/// Handler for processing AI model detail queries.
/// Implements IRequestHandler from the custom mediator to handle AiModelDetailQuery requests
/// and return detailed AI model information wrapped in a Result.
/// </summary>
public class AiModelDetailHandler : IRequestHandler<AiModelDetailQuery, Result<AiModelDetailDto>>
{
    private readonly IAppLogger<AiModelDetailHandler> _logger;
    private readonly IAiModelRepository _aiModelRepository;

    public AiModelDetailHandler(
        IAppLogger<AiModelDetailHandler> logger,
        IAiModelRepository aiModelRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aiModelRepository = aiModelRepository ?? throw new ArgumentNullException(nameof(aiModelRepository));
    }

    public async Task<Result<AiModelDetailDto>> Handle(AiModelDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving AI model details for ID: {Id}", request.Id);

        // Retrieve AI model with all related details from the repository
        var aiModel = await _aiModelRepository.GetByIdAsync(request.Id, true);

        // If AI model not found, return a not found result
        if (aiModel == null)
        {
            _logger.LogWarning("AI model with ID {Id} not found", request.Id);
            return Result<AiModelDetailDto>.NotFound(ErrorCodes.AiModel.NotFound, $"AI model with ID {request.Id} not found");
        }

        // Manual mapping instead of using AutoMapper
        var data = new AiModelDetailDto
        {
            Id = aiModel.Id,
            AiModelType = aiModel.AiModelType,
            Name = aiModel.Name,
            ApiUsername = aiModel.ApiUsername,
            // Secrets are write-only on the wire: expose only whether one is set, never the value.
            ApiPassword = string.Empty,
            ApiKey = string.Empty,
            HasApiPassword = !string.IsNullOrEmpty(aiModel.ApiPassword),
            HasApiKey = !string.IsNullOrEmpty(aiModel.ApiKey),
            NCtx = aiModel.NCtx
        };

        _logger.LogInformation("AI model with ID {Id} retrieved successfully", request.Id);

        return Result<AiModelDetailDto>.Ok(data);
    }
}
