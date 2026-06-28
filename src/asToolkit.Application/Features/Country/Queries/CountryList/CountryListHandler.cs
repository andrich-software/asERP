using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Domain.Dtos.Country;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asToolkit.Application.Features.Country.Queries.CountryList;

public class CountryListHandler : IRequestHandler<CountryListQuery, PaginatedResult<CountryListDto>>
{
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

        // Apply salesing
        if (request.SalesBy.Any())
        {
            var salesing = string.Join(",", request.SalesBy);
            query = query.OrderBy(salesing);
        }
        else
        {
            query = query.OrderBy(c => c.Name);
        }

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
