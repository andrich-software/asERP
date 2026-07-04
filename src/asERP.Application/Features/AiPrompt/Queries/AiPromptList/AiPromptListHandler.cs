using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.AiPrompt;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.AiPrompt.Queries.AiPromptList;

// ReSharper disable once UnusedType.Global
public class AiPromptListHandler : IRequestHandler<AiPromptListQuery, PaginatedResult<AiPromptListDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await _aiPromptRepository.Entities
               .Specify(aiPromptFilterSpec)
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

        var salesing = string.Join(",", request.SalesBy);

        return await _aiPromptRepository.Entities
            .Specify(aiPromptFilterSpec)
            .OrderBy(salesing)
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