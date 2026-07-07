using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// A product feed exposed to an external platform (Google Products, idealo, Pinterest, ...). The feed is
/// served anonymously at <c>/feed/{Id}</c>; the random <see cref="BaseEntity.Id"/> guid is the only access
/// guard. Products are included by default — a <see cref="FeedProduct"/> row with <c>IsActive = false</c>
/// excludes a single product (opt-out model).
/// </summary>
public class Feed : BaseEntity, IBaseEntity, IConcurrencyStamped
{
    /// <summary>Optimistic-concurrency token; refreshed on every insert/update in SaveChangesAsync.</summary>
    public Guid ConcurrencyToken { get; set; }

    /// <summary>Human-friendly label shown in the management UI.</summary>
    public string Name { get; set; } = string.Empty;

    public FeedTemplate Template { get; set; }

    /// <summary>ISO 4217 currency code emitted for every product price (e.g. "EUR").</summary>
    public string Currency { get; set; } = "EUR";

    /// <summary>
    /// Optional link to a Shopware6/WooCommerce <see cref="SalesChannel"/>. Its <see cref="SalesChannel.Url"/>
    /// plus the product's per-channel <c>RemoteProductId</c> build the required product deep-link. Null means
    /// products are exported without a link.
    /// </summary>
    public Guid? SalesChannelId { get; set; }
    public SalesChannel? SalesChannel { get; set; }

    /// <summary>Kill-switch — a disabled feed answers the public endpoint with 404.</summary>
    public bool IsEnabled { get; set; } = true;

    /// <summary>idealo requires a delivery time per offer (e.g. "1-3 Tage"). Used only by the idealo renderer.</summary>
    public string? DefaultDeliveryTime { get; set; }

    /// <summary>idealo requires at least one delivery cost per offer. Used only by the idealo renderer.</summary>
    public decimal? DefaultShippingCost { get; set; }

    public ICollection<FeedProduct> FeedProducts { get; set; } = null!;
    public ICollection<FeedLog> FeedLogs { get; set; } = null!;
}
