using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// A single parcel of an order. One <see cref="Sales"/> can have many shipments
/// (partial deliveries); each carries its own tracking number and label.
/// </summary>
public class Shipping : BaseEntity, IBaseEntity
{
    public Guid SalesId { get; set; }

    // Not auto-initialized — see the phantom-entity note on ProductSalesChannel.
    public Sales Sales { get; set; } = null!;

    public Guid ShippingProviderId { get; set; }
    public ShippingProvider ShippingProvider { get; set; } = null!;

    /// <summary>The rate ("Versandoption") the shipment was booked with. Nullable so a rate can be deleted without orphaning history.</summary>
    public Guid? ShippingProviderRateId { get; set; }
    public ShippingProviderRate? ShippingProviderRate { get; set; }

    public ShippingStatus Status { get; set; } = ShippingStatus.Open;

    public string TrackingNumber { get; set; } = string.Empty;

    public string? TrackingUrl { get; set; }

    public decimal ShippingCost { get; set; }

    public double TaxRate { get; set; }

    public decimal? WeightKg { get; set; }
    public decimal? LengthCm { get; set; }
    public decimal? WidthCm { get; set; }
    public decimal? HeightCm { get; set; }

    /// <summary>Carrier-side shipment identifier — needed to void/cancel the shipment at the carrier.</summary>
    public string? CarrierShipmentId { get; set; }

    /// <summary>Label document bytes as returned (or converted) by the connector.</summary>
    public byte[]? LabelData { get; set; }

    /// <summary>MIME type of <see cref="LabelData"/>, e.g. "application/pdf".</summary>
    public string? LabelFormat { get; set; }

    /// <summary>UTC time of the last tracking poll attempt (success or failure) — gates the poller.</summary>
    public DateTime? LastTrackedAt { get; set; }

    /// <summary>UTC time the carrier first reported the parcel as accepted/in transit.</summary>
    public DateTime? ShippedAt { get; set; }

    public DateTime? DeliveredAt { get; set; }

    /// <summary>Verbatim status text from the carrier's last tracking response.</summary>
    public string? LastCarrierStatusRaw { get; set; }

    /// <summary>
    /// UTC time the "on the way" customer-notification slot was consumed (first transition to
    /// Shipped/InTransit/OutForDelivery, or Delivered on skip-ahead). Stamped even when the tenant
    /// toggle is off or the send fails, so enabling the toggle later never mails in-flight shipments.
    /// </summary>
    public DateTime? CustomerNotifiedAt { get; set; }

    /// <summary>UTC time the delivered customer-notification slot was consumed — same semantics as <see cref="CustomerNotifiedAt"/>.</summary>
    public DateTime? CustomerDeliveryNotifiedAt { get; set; }
}
