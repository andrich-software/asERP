using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Queries.ShippingProviderList;

public class ShippingProviderListHandler : IRequestHandler<ShippingProviderListQuery, PaginatedResult<ShippingProviderListDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.ShippingProvider.Id),
        nameof(Domain.Entities.ShippingProvider.Name),
        nameof(Domain.Entities.ShippingProvider.Type),
        nameof(Domain.Entities.ShippingProvider.IsEnabled),
        nameof(Domain.Entities.ShippingProvider.UseSandbox)
    };

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
            .Specify(filterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields);

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
