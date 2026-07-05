using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.TaxClass.Queries.TaxClassList;

public class TaxClassListHandler : IRequestHandler<TaxClassListQuery, PaginatedResult<TaxClassListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.TaxClass.Id),
        nameof(Domain.Entities.TaxClass.TaxRate)
    };

    private readonly IAppLogger<TaxClassListHandler> _logger;
    private readonly ITaxClassRepository _taxClassRepository;

    public TaxClassListHandler(
        IAppLogger<TaxClassListHandler> logger,
        ITaxClassRepository taxClassRepository)
    {
        _logger = logger;
        _taxClassRepository = taxClassRepository;
    }

    public async Task<PaginatedResult<TaxClassListDto>> Handle(TaxClassListQuery request, CancellationToken cancellationToken)
    {
        var taxClassFilterSpec = new TaxClassFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle TaxClassListQuery: {0}", request);

        return await _taxClassRepository.Entities
            .Specify(taxClassFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(t => new TaxClassListDto
            {
                Id = t.Id,
                TaxRate = t.TaxRate
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
