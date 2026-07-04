using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IShippingProviderRateRepository : IGenericRepository<ShippingProviderRate>
{
    Task<ShippingProviderRate?> GetWithCountriesAsync(Guid id);
    Task<List<ShippingProviderRate>> GetByProviderAsync(Guid providerId);
    Task<bool> IsNameUniqueForProviderAsync(Guid providerId, string name, Guid? excludeId = null);
    Task<bool> HasShipmentsAsync(Guid rateId);

    /// <summary>Replaces the rate's allowed-country join rows with the given set.</summary>
    Task ReplaceAllowedCountriesAsync(Guid rateId, ICollection<Guid> countryIds);
}
