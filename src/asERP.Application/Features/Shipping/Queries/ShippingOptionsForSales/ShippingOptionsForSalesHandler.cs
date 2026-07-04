using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Shipping.Queries.ShippingOptionsForSales;

public class ShippingOptionsForSalesHandler : IRequestHandler<ShippingOptionsForSalesQuery, Result<List<ApplicableShippingRateDto>>>
{
    private readonly IAppLogger<ShippingOptionsForSalesHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;
    private readonly IShippingDestinationResolver _destinationResolver;

    public ShippingOptionsForSalesHandler(
        IAppLogger<ShippingOptionsForSalesHandler> logger,
        ISalesRepository salesRepository,
        IShippingProviderRateRepository shippingProviderRateRepository,
        IShippingDestinationResolver destinationResolver)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
        _destinationResolver = destinationResolver ?? throw new ArgumentNullException(nameof(destinationResolver));
    }

    public async Task<Result<List<ApplicableShippingRateDto>>> Handle(ShippingOptionsForSalesQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipping options for sales {Id}", request.Id);

        var result = new Result<List<ApplicableShippingRateDto>>();

        var sales = await _salesRepository.GetByIdAsync(request.Id, asNoTracking: true);
        if (sales == null)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"Sales with ID {request.Id} not found");

            _logger.LogWarning("Sales with ID {Id} not found", request.Id);
            return result;
        }

        var destination = await _destinationResolver.ResolveAsync(sales);
        if (destination.Error != null)
        {
            // The dialog shows WHY no option is available — a GET must not fail on data issues.
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = new List<ApplicableShippingRateDto>();
            result.Messages.Add(destination.Error);
            return result;
        }

        var countryId = destination.Country!.Id;

        var rates = await _shippingProviderRateRepository.Entities
            .Where(r => r.ShippingProvider.IsEnabled)
            .Where(r => r.AllowedCountries.Any(c => c.CountryId == countryId))
            .OrderBy(r => r.Price)
            .Select(r => new ApplicableShippingRateDto
            {
                RateId = r.Id,
                RateName = r.Name,
                ProviderId = r.ShippingProviderId,
                ProviderName = r.ShippingProvider.Name,
                ProviderType = r.ShippingProvider.Type,
                Price = r.Price,
                MaxWeight = r.MaxWeight,
                MaxLength = r.MaxLength,
                MaxWidth = r.MaxWidth,
                MaxHeight = r.MaxHeight
            })
            .ToListAsync(cancellationToken);

        result.Succeeded = true;
        result.StatusCode = ResultStatusCode.Ok;
        result.Data = rates;

        return result;
    }
}
