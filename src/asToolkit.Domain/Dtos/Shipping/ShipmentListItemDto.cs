using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Dtos.Shipping;

/// <summary>
/// Row of the tenant-wide paginated shipment list.
/// </summary>
public class ShipmentListItemDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }

    /// <summary>Sequential tenant-scoped order number (Sales.SalesId).</summary>
    public int SalesNumber { get; set; }

    /// <summary>Delivery company name, or first + last name when no company is set.</summary>
    public string RecipientName { get; set; } = string.Empty;

    public string ProviderName { get; set; } = string.Empty;
    public string RateName { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public ShippingStatus Status { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public bool HasLabel { get; set; }

    /// <summary>Problem flag: lost/returned/delivery-failed, in transit for more than four days,
    /// or a dead-lettered label-outbox row. Filterable and sortable.</summary>
    public bool IsProblem { get; set; }

    public DateTime DateCreated { get; set; }
}
