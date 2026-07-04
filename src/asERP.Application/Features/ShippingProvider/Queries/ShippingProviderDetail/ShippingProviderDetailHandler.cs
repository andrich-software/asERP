using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Queries.ShippingProviderDetail;

public class ShippingProviderDetailHandler : IRequestHandler<ShippingProviderDetailQuery, Result<ShippingProviderDetailDto>>
{
    private readonly IAppLogger<ShippingProviderDetailHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;

    public ShippingProviderDetailHandler(
        IAppLogger<ShippingProviderDetailHandler> logger,
        IShippingProviderRepository shippingProviderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
    }

    public async Task<Result<ShippingProviderDetailDto>> Handle(ShippingProviderDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipping provider details for ID: {Id}", request.Id);

        var provider = await _shippingProviderRepository.GetWithRatesAsync(request.Id);
        if (provider == null)
        {
            _logger.LogWarning("Shipping provider not found: {Id}", request.Id);
            throw new NotFoundException("ShippingProvider", request.Id);
        }

        var data = new ShippingProviderDetailDto
        {
            Id = provider.Id,
            Name = provider.Name,
            Type = provider.Type,
            IsEnabled = provider.IsEnabled,
            UseSandbox = provider.UseSandbox,
            Username = provider.Username,
            AccountNumber = provider.AccountNumber,
            AdditionalConfigJson = provider.AdditionalConfigJson,
            TrackingPollIntervalSeconds = provider.TrackingPollIntervalSeconds,
            HasPassword = !string.IsNullOrEmpty(provider.Password),
            HasApiKey = !string.IsNullOrEmpty(provider.ApiKey),
            HasApiSecret = !string.IsNullOrEmpty(provider.ApiSecret),
            Rates = provider.ShippingRates?.Select(r => new ShippingProviderRateListDto
            {
                Id = r.Id,
                ShippingProviderId = r.ShippingProviderId,
                Name = r.Name,
                MaxLength = r.MaxLength,
                MaxWidth = r.MaxWidth,
                MaxHeight = r.MaxHeight,
                MaxWeight = r.MaxWeight,
                Price = r.Price,
                AllowedCountryCount = r.AllowedCountries.Count
            }).OrderBy(r => r.Name).ToList() ?? new List<ShippingProviderRateListDto>()
        };

        return Result<ShippingProviderDetailDto>.Success(data);
    }
}
