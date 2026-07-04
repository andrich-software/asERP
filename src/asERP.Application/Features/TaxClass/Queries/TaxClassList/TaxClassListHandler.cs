using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.TaxClass.Queries.TaxClassList;

public class TaxClassListHandler : IRequestHandler<TaxClassListQuery, PaginatedResult<TaxClassListDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await _taxClassRepository.Entities
               .Specify(taxClassFilterSpec)
               .Select(t => new TaxClassListDto
               {
                   Id = t.Id,
                   TaxRate = t.TaxRate
               })
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }

        var salesing = string.Join(",", request.SalesBy);

        return await _taxClassRepository.Entities
            .Specify(taxClassFilterSpec)
            .OrderBy(salesing)
            .Select(t => new TaxClassListDto
            {
                Id = t.Id,
                TaxRate = t.TaxRate
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}