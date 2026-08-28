using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Maps a channel-side carrier identifier onto a local <see cref="ShippingProvider"/>. Required
/// because <see cref="Shipping.ShippingProviderId"/> is not nullable while a shop only reports a
/// free-text carrier or shipping-method id — the operator configures the translation per channel
/// instead of the connector guessing it.
/// <para>
/// Used in both directions: shipment import resolves <see cref="RemoteCarrierCode"/> to a provider,
/// the tracking push resolves the provider back to a code. An unmapped code is skipped (and logged
/// with the code) rather than silently attached to an arbitrary provider.
/// </para>
/// </summary>
public class SalesChannelCarrierMapping : BaseEntity, IBaseEntity
{
    public Guid SalesChannelId { get; set; }
    public SalesChannel? SalesChannel { get; set; }

    /// <summary>
    /// Carrier identifier as reported by the shop. For WooCommerce this is the shipping method id of
    /// the order's shipping line (e.g. <c>dhl_home_delivery</c>, <c>flat_rate</c>) — the only carrier
    /// signal WooCommerce carries on an order. Compared case-insensitively.
    /// </summary>
    public string RemoteCarrierCode { get; set; } = string.Empty;

    public Guid ShippingProviderId { get; set; }
    public ShippingProvider? ShippingProvider { get; set; }
}
