using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Returns;

public class ReturnShipmentDetailDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }

    /// <summary>Sequential tenant-scoped order number (Sales.SalesId).</summary>
    public int SalesNumber { get; set; }

    public Guid? OriginalShippingId { get; set; }

    public Guid? ShippingProviderId { get; set; }
    public string ProviderName { get; set; } = string.Empty;

    public ReturnShipmentStatus Status { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public string? CarrierShipmentId { get; set; }

    /// <summary>Label bytes are only served via the label endpoint.</summary>
    public bool HasLabel { get; set; }

    public string? LabelFormat { get; set; }

    public decimal? RefundAmount { get; set; }
    public string? Note { get; set; }
    public DateTime? ReceivedAt { get; set; }

    /// <summary>State of the return-label fallback queue, if a row exists for this return.</summary>
    public ShippingOutboxStatus? LabelQueueStatus { get; set; }
    public string? LabelQueueLastError { get; set; }

    public List<ReturnShipmentItemDto> Items { get; set; } = new();

    public DateTime DateCreated { get; set; }
}
