using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;

namespace asToolkit.Application.Features.Shipping.Services;

public class ShippingDestinationResolver : IShippingDestinationResolver
{
    private readonly ICountryRepository _countryRepository;

    public ShippingDestinationResolver(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<ShippingDestinationResult> ResolveAsync(Domain.Entities.Sales sales)
    {
        var countryString = sales.DeliveryAddressCountry;
        if (string.IsNullOrWhiteSpace(countryString))
        {
            return new ShippingDestinationResult { Error = "The sales order has no delivery country." };
        }

        var country = await _countryRepository.GetCountryByString(countryString);
        if (country == null)
        {
            return new ShippingDestinationResult
            {
                Error = $"The delivery country '{countryString}' could not be resolved to a known country."
            };
        }

        return new ShippingDestinationResult { Country = country };
    }
}
