using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateDetail;

public class ShippingProviderRateDetailHandler : IRequestHandler<ShippingProviderRateDetailQuery, Result<ShippingProviderRateDetailDto>>
{
    private readonly IAppLogger<ShippingProviderRateDetailHandler> _logger;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;

    public ShippingProviderRateDetailHandler(
        IAppLogger<ShippingProviderRateDetailHandler> logger,
        IShippingProviderRateRepository shippingProviderRateRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
    }

    public async Task<Result<ShippingProviderRateDetailDto>> Handle(ShippingProviderRateDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipping option details for ID: {Id}", request.Id);

        var rate = await _shippingProviderRateRepository.GetWithCountriesAsync(request.Id);
        if (rate == null)
        {
            _logger.LogWarning("Shipping option not found: {Id}", request.Id);
            throw new NotFoundException("ShippingProviderRate", request.Id);
        }

        var data = new ShippingProviderRateDetailDto
        {
            Id = rate.Id,
            ShippingProviderId = rate.ShippingProviderId,
            ProviderName = rate.ShippingProvider.Name,
            Name = rate.Name,
            MaxLength = rate.MaxLength,
            MaxWidth = rate.MaxWidth,
            MaxHeight = rate.MaxHeight,
            MaxWeight = rate.MaxWeight,
            Price = rate.Price,
            AllowedCountries = rate.AllowedCountries
                .Select(c => new ShippingRateCountryDto
                {
                    CountryId = c.CountryId,
                    Name = c.Country.Name,
                    CountryCode = c.Country.CountryCode
                })
                .OrderBy(c => c.Name)
                .ToList()
        };

        return Result<ShippingProviderRateDetailDto>.Success(data);
    }
}
