namespace asERP.Domain.Dtos.Shipping;

/// <summary>
/// A single tracking-timeline entry of a shipment, sourced from the sales history rows
/// stamped with the shipment's id.
/// </summary>
public class ShippingHistoryEntryDto
{
    public Guid Id { get; set; }
    public string? ShippingStatusOld { get; set; }
    public string? ShippingStatusNew { get; set; }
    /// <summary>English audit text; the client's fallback when <see cref="MessageKey"/> is null.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Resource key the client renders instead of <see cref="Description"/>.</summary>
    public string? MessageKey { get; set; }

    /// <summary>Arguments for <see cref="MessageKey"/>; each is itself resolved as a resource key.</summary>
    public List<string> MessageArgs { get; set; } = new();

    public bool IsSystemGenerated { get; set; }
    public Guid UserId { get; set; }
    public DateTime DateCreated { get; set; }
}
