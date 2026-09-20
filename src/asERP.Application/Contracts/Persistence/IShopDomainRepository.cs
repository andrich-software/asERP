using asERP.Domain.Dtos.Shop;
using asERP.Domain.Entities;

namespace asERP.Application.Contracts.Persistence;

public interface IShopDomainRepository : IGenericRepository<ShopDomain>
{
    /// <summary>
    /// Loads the host bindings of all enabled AsShop channels, ACROSS tenants. The storefront
    /// request path is anonymous (no tenant context yet — the binding is what resolves it), so
    /// this deliberately bypasses the global tenant query filter. Returns no secrets — only
    /// hosts + the owning tenant/channel ids, with each binding's primary host resolved.
    /// </summary>
    Task<List<ShopHostBindingRef>> GetActiveBindingsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// True when <paramref name="salesChannelId"/> may claim the normalized host on the given port,
    /// checked ACROSS tenants — a hostname belongs to exactly one channel globally. Any row of
    /// another channel on that host blocks it regardless of its port (port 0 and exact-port rows
    /// resolve to the same host), while the owning channel may add further ports of its own host.
    /// Pass <paramref name="id"/> on update to exclude the row being edited.
    /// </summary>
    Task<bool> HostIsUniqueAsync(string host, int port, Guid salesChannelId, Guid? id = null);
}
