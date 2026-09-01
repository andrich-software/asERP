using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.AiPrompt.Queries.AiPromptDetail;

public class AiPromptDetailHandler : IRequestHandler<AiPromptDetailQuery, Result<AiPromptDetailDto>>
{
    private readonly IAppLogger<AiPromptDetailHandler> _logger;
    private readonly IAiPromptRepository _aiPromptRepository;

    public AiPromptDetailHandler(
        IAppLogger<AiPromptDetailHandler> logger,
        IAiPromptRepository aiPromptRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _aiPromptRepository = aiPromptRepository ?? throw new ArgumentNullException(nameof(aiPromptRepository));
    }

    public async Task<Result<AiPromptDetailDto>> Handle(AiPromptDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving AI prompt details for ID: {Id}", request.Id);

        var result = new Result<AiPromptDetailDto>();

        var aiPrompt = await _aiPromptRepository.GetByIdAsync(request.Id, true);

        if (aiPrompt == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.AiPrompt.NotFound, $"AI prompt with ID {request.Id} not found");

            _logger.LogWarning("AI prompt with ID {Id} not found", request.Id);
            return result;
        }

        // Manuelles Mapping statt AutoMapper
        var data = new AiPromptDetailDto
        {
            Id = aiPrompt.Id,
            AiModelId = aiPrompt.AiModelId,
            Identifier = aiPrompt.Identifier,
            PromptText = aiPrompt.PromptText
        };

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = data;

        _logger.LogInformation("AI prompt with ID {Id} retrieved successfully", request.Id);

        return result;
    }
}
