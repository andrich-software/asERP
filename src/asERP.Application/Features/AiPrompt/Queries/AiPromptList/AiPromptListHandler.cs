using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiPrompt.Queries.AiPromptList;

// ReSharper disable once UnusedType.Global
public class AiPromptListHandler : IRequestHandler<AiPromptListQuery, PaginatedResult<AiPromptListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.AiPrompt.Id),
        nameof(Domain.Entities.AiPrompt.Identifier),
        nameof(Domain.Entities.AiPrompt.PromptText),
        nameof(Domain.Entities.AiPrompt.DateCreated),
        nameof(Domain.Entities.AiPrompt.DateModified)
    };

    private readonly IAppLogger<AiPromptListHandler> _logger;
    private readonly IAiPromptRepository _aiPromptRepository;

    public AiPromptListHandler(
        IAppLogger<AiPromptListHandler> logger,
        IAiPromptRepository aiPromptRepository)
    {
        _logger = logger;
        _aiPromptRepository = aiPromptRepository;
    }
    public async Task<PaginatedResult<AiPromptListDto>> Handle(AiPromptListQuery request, CancellationToken cancellationToken)
    {
        var aiPromptFilterSpec = new AiPromptFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle AiPromptListQuery: {0}", request);

        return await _aiPromptRepository.Entities
            .Specify(aiPromptFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(a => new AiPromptListDto
            {
                Id = a.Id,
                Identifier = a.Identifier,
                PromptText = a.PromptText,
                DateCreated = a.DateCreated,
                DateModified = a.DateModified
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
