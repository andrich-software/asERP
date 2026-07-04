using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IShippingProviderRepository : IGenericRepository<ShippingProvider>
{
    Task<ShippingProvider?> GetWithRatesAsync(Guid id);
    Task<bool> IsNameUniqueAsync(string name, Guid? excludeId = null);
    Task<bool> HasShipmentsAsync(Guid providerId);
}
