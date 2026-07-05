using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Country.Queries.CountryList;

public class CountryListHandler : IRequestHandler<CountryListQuery, PaginatedResult<CountryListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Country.Id),
        nameof(Domain.Entities.Country.Name),
        nameof(Domain.Entities.Country.CountryCode)
    };

    private readonly IAppLogger<CountryListHandler> _logger;
    private readonly ICountryRepository _countryRepository;

    public CountryListHandler(
        IAppLogger<CountryListHandler> logger,
        ICountryRepository countryRepository)
    {
        _logger = logger;
        _countryRepository = countryRepository;
    }

    public async Task<PaginatedResult<CountryListDto>> Handle(CountryListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle CountryListQuery: {0}", request);

        var query = _countryRepository.Entities.AsNoTracking();

        // Apply search filter if provided
        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var searchLower = request.SearchString.ToLower();
            query = query.Where(c =>
                c.Name.ToLower().Contains(searchLower) ||
                c.CountryCode.ToLower().Contains(searchLower));
        }

        // Apply salesing; fall back to the default Name ordering when the client provided none.
        query = request.SalesBy.Any()
            ? query.ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            : query.OrderBy(c => c.Name);

        return await query
            .Select(c => new CountryListDto
            {
                Id = c.Id,
                Name = c.Name,
                CountryCode = c.CountryCode
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
