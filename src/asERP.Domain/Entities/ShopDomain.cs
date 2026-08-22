using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// One inbound host binding of an asShop sales channel. Incoming requests are matched by
/// Host header (+ optional port) against these rows to resolve the owning channel and tenant.
/// A hostname belongs to exactly one channel across ALL tenants — the unique (Host, Port)
/// index deliberately has no TenantId component because the host IS the tenant-resolution
/// security boundary.
/// </summary>
public class ShopDomain : BaseEntity, IBaseEntity
{
    public Guid SalesChannelId { get; set; }
    public SalesChannel? SalesChannel { get; set; }

    /// <summary>
    /// Normalized host: lowercase, ASCII/punycode (IDN), no scheme, no port, no trailing dot.
    /// Normalization happens on write AND on lookup so comparisons are exact string matches.
    /// </summary>
    public string Host { get; set; } = string.Empty;

    /// <summary>
    /// 0 = match any port (the normal case behind Cloudflare/reverse proxies). Non-zero = exact
    /// public-port match, tried before the 0 row. A sentinel instead of null so the unique
    /// (Host, Port) index behaves identically across all three database providers.
    /// </summary>
    public int Port { get; set; }

    /// <summary>Canonical domain of the shop — redirect target and base for absolute URL generation.</summary>
    public bool IsPrimary { get; set; }

    /// <summary>301/308 requests on this host to the channel's primary host (www→apex etc.). Ignored on the primary row.</summary>
    public bool RedirectToPrimary { get; set; } = true;
}
