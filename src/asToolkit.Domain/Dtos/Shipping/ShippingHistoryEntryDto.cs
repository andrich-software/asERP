namespace asToolkit.Domain.Dtos.Shipping;

/// <summary>
/// A single tracking-timeline entry of a shipment, sourced from the sales history rows
/// stamped with the shipment's id.
/// </summary>
public class ShippingHistoryEntryDto
{
    public Guid Id { get; set; }
    public string? ShippingStatusOld { get; set; }
    public string? ShippingStatusNew { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsSystemGenerated { get; set; }
    public Guid UserId { get; set; }
    public DateTime DateCreated { get; set; }
}
