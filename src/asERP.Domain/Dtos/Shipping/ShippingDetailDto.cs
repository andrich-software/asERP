using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Shipping;

public class ShippingDetailDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }

    /// <summary>Sequential tenant-scoped order number (Sales.SalesId).</summary>
    public int SalesNumber { get; set; }

    public Guid ShippingProviderId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public ShippingProviderType ProviderType { get; set; }
    public Guid? ShippingProviderRateId { get; set; }
    public string RateName { get; set; } = string.Empty;

    public ShippingStatus Status { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public decimal ShippingCost { get; set; }
    public double TaxRate { get; set; }

    public decimal? WeightKg { get; set; }
    public decimal? LengthCm { get; set; }
    public decimal? WidthCm { get; set; }
    public decimal? HeightCm { get; set; }

    public string? CarrierShipmentId { get; set; }

    /// <summary>Label bytes are only served via the label endpoint.</summary>
    public bool HasLabel { get; set; }

    public string? LabelFormat { get; set; }

    public DateTime? LastTrackedAt { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string? LastCarrierStatusRaw { get; set; }

    /// <summary>State of the label-creation fallback queue, if a row exists for this shipment.</summary>
    public ShippingOutboxStatus? LabelQueueStatus { get; set; }
    public string? LabelQueueLastError { get; set; }

    public List<Guid> SalesItemIds { get; set; } = new();

    /// <summary>Tracking timeline of this shipment, newest first.</summary>
    public List<ShippingHistoryEntryDto> History { get; set; } = new();

    public DateTime DateCreated { get; set; }
}
