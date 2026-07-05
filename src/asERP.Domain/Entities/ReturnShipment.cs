using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// A customer return (RMA) for an order. Deliberately a separate entity from
/// <see cref="Shipping"/> — the lifecycles differ too much (no rates, manual receipt,
/// per-item condition). One order can have many returns.
/// </summary>
public class ReturnShipment : BaseEntity, IBaseEntity
{
    public Guid SalesId { get; set; }

    // Not auto-initialized — see the phantom-entity note on ProductSalesChannel.
    public Sales Sales { get; set; } = null!;

    /// <summary>The outbound parcel the return relates to, when known. Informational link only.</summary>
    public Guid? OriginalShippingId { get; set; }
    public Shipping? OriginalShipping { get; set; }

    /// <summary>Carrier used for the return label; null when the customer ships themselves.</summary>
    public Guid? ShippingProviderId { get; set; }
    public ShippingProvider? ShippingProvider { get; set; }

    public ReturnShipmentStatus Status { get; set; } = ReturnShipmentStatus.Requested;

    /// <summary>Return-parcel tracking number — from the carrier label or entered manually.</summary>
    public string TrackingNumber { get; set; } = string.Empty;

    public string? TrackingUrl { get; set; }

    /// <summary>Carrier-side shipment identifier — needed to void/cancel the return label at the carrier.</summary>
    public string? CarrierShipmentId { get; set; }

    /// <summary>Return-label document bytes as returned (or converted) by the connector.</summary>
    public byte[]? LabelData { get; set; }

    /// <summary>MIME type of <see cref="LabelData"/>, e.g. "application/pdf".</summary>
    public string? LabelFormat { get; set; }

    /// <summary>Intended refund. Informational in v1 — no payment integration.</summary>
    public decimal? RefundAmount { get; set; }

    public string? Note { get; set; }

    /// <summary>UTC time the returned goods were physically received.</summary>
    public DateTime? ReceivedAt { get; set; }

    /// <summary>UTC time of the last tracking poll attempt. Unused in v1 — returns are not polled yet.</summary>
    public DateTime? LastTrackedAt { get; set; }

    /// <summary>Verbatim status text from the carrier's last tracking response. Unused in v1.</summary>
    public string? LastCarrierStatusRaw { get; set; }

    public ICollection<ReturnShipmentItem> Items { get; set; } = new List<ReturnShipmentItem>();
}
