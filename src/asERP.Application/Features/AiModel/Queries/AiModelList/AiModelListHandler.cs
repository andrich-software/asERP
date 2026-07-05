using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.AiModel;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.AiModel.Queries.AiModelList;

// ReSharper disable once UnusedType.Global
public class AiModelListHandler : IRequestHandler<AiModelListQuery, PaginatedResult<AiModelListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    // Secret columns (ApiKey, ApiPassword, ApiUsername, ApiUrl) are deliberately excluded.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.AiModel.Id),
        nameof(Domain.Entities.AiModel.AiModelType),
        nameof(Domain.Entities.AiModel.Name),
        nameof(Domain.Entities.AiModel.NCtx)
    };

    private readonly IAppLogger<AiModelListHandler> _logger;
    private readonly IAiModelRepository _aiModelRepository;

    public AiModelListHandler(
        IAppLogger<AiModelListHandler> logger,
        IAiModelRepository aiModelRepository)
    {
        _logger = logger;
        _aiModelRepository = aiModelRepository;
    }

    public async Task<PaginatedResult<AiModelListDto>> Handle(AiModelListQuery request, CancellationToken cancellationToken)
    {
        var aiModelFilterSpec = new AiModelFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle AiModelListQuery: {0}", request);

        return await _aiModelRepository.Entities
            .Specify(aiModelFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(a => new AiModelListDto
            {
                Id = a.Id,
                AiModelType = (int)a.AiModelType,
                Name = a.Name,
                NCtx = a.NCtx
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
