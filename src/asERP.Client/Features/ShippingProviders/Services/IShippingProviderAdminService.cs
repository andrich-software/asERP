using asERP.Domain.Dtos.ShippingProvider;
using asERP.Domain.Dtos.ShippingProviderRate;

namespace asERP.Client.Features.ShippingProviders.Services;

/// <summary>
/// Full management access to the tenant's carriers (shipping providers) and their shipping
/// options ("Versandarten"). The read-only <c>IShippingProviderService</c> in the Shippings
/// feature stays untouched — it only feeds the create-shipment dialog.
/// </summary>
public interface IShippingProviderAdminService
{
    Task<List<ShippingProviderListDto>> GetProvidersAsync(CancellationToken ct = default);

    Task<ShippingProviderDetailDto?> GetProviderAsync(Guid id, CancellationToken ct = default);

    Task<Guid> CreateProviderAsync(ShippingProviderCreateDto input, CancellationToken ct = default);

    Task UpdateProviderAsync(Guid id, ShippingProviderUpdateDto input, CancellationToken ct = default);

    Task DeleteProviderAsync(Guid id, CancellationToken ct = default);

    Task<ShippingProviderRateDetailDto?> GetRateAsync(Guid providerId, Guid id, CancellationToken ct = default);

    Task<Guid> CreateRateAsync(Guid providerId, ShippingProviderRateCreateDto input, CancellationToken ct = default);

    Task UpdateRateAsync(Guid providerId, Guid id, ShippingProviderRateUpdateDto input, CancellationToken ct = default);

    Task DeleteRateAsync(Guid providerId, Guid id, CancellationToken ct = default);
}
