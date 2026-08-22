using asERP.Domain.Dtos.Shop;

namespace asERP.Shop.Hosting;

public interface IShopHostResolver
{
    /// <summary>
    /// Resolves a normalized host + effective public port to its shop binding. Exact-port rows
    /// win over the port-0 ("any port") row. Returns null for unbound hosts.
    /// </summary>
    Task<ShopHostBindingRef?> ResolveAsync(string normalizedHost, int port, CancellationToken cancellationToken = default);

    /// <summary>Resolves a channel id to one of its bindings (the primary). Used by circuit initialization.</summary>
    Task<ShopHostBindingRef?> ResolveByChannelAsync(Guid salesChannelId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Drops the cached host map so the next request reloads it — called when domain bindings
    /// change. The 30s TTL alone already bounds staleness; this makes changes immediate.
    /// </summary>
    void Invalidate();
}
