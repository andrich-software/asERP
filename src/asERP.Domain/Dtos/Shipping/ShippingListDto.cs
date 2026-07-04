using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Shipping;

public class ShippingListDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }
    public string ProviderName { get; set; } = string.Empty;
    public string RateName { get; set; } = string.Empty;
    public ShippingStatus Status { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public decimal ShippingCost { get; set; }
    public bool HasLabel { get; set; }
    public DateTime? ShippedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime DateCreated { get; set; }
}
