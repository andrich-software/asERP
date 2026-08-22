using asERP.Domain.Dtos.ShopDomain;

namespace asERP.Client.Features.SalesChannels.Services;

/// <summary>
/// Manages the inbound host bindings (domains) of asShop sales channels.
/// </summary>
public interface IShopDomainService
{
    Task<List<ShopDomainListDto>> GetShopDomainsAsync(Guid salesChannelId, CancellationToken ct = default);

    Task<Guid> CreateShopDomainAsync(ShopDomainInputDto input, CancellationToken ct = default);

    Task DeleteShopDomainAsync(Guid id, CancellationToken ct = default);
}
