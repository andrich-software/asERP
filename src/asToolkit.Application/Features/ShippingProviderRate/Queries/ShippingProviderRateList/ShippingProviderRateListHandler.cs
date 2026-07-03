using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.ShippingProviderRate;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ShippingProviderRate.Queries.ShippingProviderRateList;

public class ShippingProviderRateListHandler : IRequestHandler<ShippingProviderRateListQuery, Result<List<ShippingProviderRateListDto>>>
{
    private readonly IAppLogger<ShippingProviderRateListHandler> _logger;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;

    public ShippingProviderRateListHandler(
        IAppLogger<ShippingProviderRateListHandler> logger,
        IShippingProviderRateRepository shippingProviderRateRepository)
    {
        _logger = logger;
        _shippingProviderRateRepository = shippingProviderRateRepository;
    }

    public async Task<Result<List<ShippingProviderRateListDto>>> Handle(ShippingProviderRateListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving shipping options for provider {ProviderId}", request.ShippingProviderId);

        var rates = await _shippingProviderRateRepository.GetByProviderAsync(request.ShippingProviderId);

        var data = rates.Select(r => new ShippingProviderRateListDto
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
        }).ToList();

        return Result<List<ShippingProviderRateListDto>>.Success(data);
    }
}
