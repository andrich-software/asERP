using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Mediator;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.ShippingProvider;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProvider.Queries.ShippingProviderList;

public class ShippingProviderListHandler : IRequestHandler<ShippingProviderListQuery, PaginatedResult<ShippingProviderListDto>>
{
    private readonly IAppLogger<ShippingProviderListHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;

    public ShippingProviderListHandler(
        IAppLogger<ShippingProviderListHandler> logger,
        IShippingProviderRepository shippingProviderRepository)
    {
        _logger = logger;
        _shippingProviderRepository = shippingProviderRepository;
    }

    public async Task<PaginatedResult<ShippingProviderListDto>> Handle(ShippingProviderListQuery request, CancellationToken cancellationToken)
    {
        var filterSpec = new ShippingProviderFilterSpecification(request.SearchString);

        _logger.LogInformation("ShippingProviderListHandler.Handle: Retrieving shipping providers.");

        var query = _shippingProviderRepository.Entities
            .Specify(filterSpec);

        if (request.SalesBy.Any())
        {
            query = query.OrderBy(string.Join(",", request.SalesBy));
        }

        return await query
            .Select(p => new ShippingProviderListDto
            {
                Id = p.Id,
                Name = p.Name,
                Type = p.Type,
                IsEnabled = p.IsEnabled,
                UseSandbox = p.UseSandbox,
                RateCount = p.ShippingRates!.Count
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
