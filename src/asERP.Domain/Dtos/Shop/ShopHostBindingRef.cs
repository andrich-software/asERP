namespace asERP.Domain.Dtos.Shop;

/// <summary>
/// The minimal identity a shop host binding resolves to. Loaded cross-tenant (the storefront
/// request path is anonymous) and used to bind the request to the owning tenant + channel
/// before any tenant-scoped query runs. Carries no secrets.
/// </summary>
public sealed class ShopHostBindingRef
{
    public Guid SalesChannelId { get; init; }

    /// <summary>Owning tenant — set on the tenant context so the whole request is tenant-bound.</summary>
    public Guid TenantId { get; init; }

    /// <summary>Normalized host (lowercase, punycode, no port) this binding matches.</summary>
    public string Host { get; init; } = string.Empty;

    /// <summary>0 = any port; non-zero rows win over the 0 row for that exact port.</summary>
    public int Port { get; init; }

    public bool IsPrimary { get; init; }

    public bool RedirectToPrimary { get; init; }

    /// <summary>
    /// Whether the channel's built-in web-analytics tracking is on. asShop needs no plugin/token —
    /// the storefront embeds the tracker and the collector resolves the channel from this binding.
    /// </summary>
    public bool TrackingEnabled { get; init; }

    /// <summary>Resolved primary host of the same channel — the redirect target for non-primary rows.</summary>
    public string PrimaryHost { get; init; } = string.Empty;
}
