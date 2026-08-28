using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Sales;

public class SalesHistoryDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SalesId { get; set; }
    public Guid? ShippingId { get; set; }
    public SalesStatus? SalesStatusOld { get; set; }
    public SalesStatus? SalesStatusNew { get; set; }
    public PaymentStatus? PaymentStatusOld { get; set; }
    public PaymentStatus? PaymentStatusNew { get; set; }
    public string? ShippingStatusOld { get; set; }
    public string? ShippingStatusNew { get; set; }
    /// <summary>English audit text; the client's fallback when <see cref="MessageKey"/> is null.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Resource key the client renders instead of <see cref="Description"/>.</summary>
    public string? MessageKey { get; set; }

    /// <summary>Arguments for <see cref="MessageKey"/>; each is itself resolved as a resource key
    /// (with the literal value as fallback) so enum tokens localize too.</summary>
    public List<string> MessageArgs { get; set; } = new();

    public bool IsSystemGenerated { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
