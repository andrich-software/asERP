using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Returns;

/// <summary>Row of the paginated returns list.</summary>
public class ReturnShipmentListItemDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }

    /// <summary>Sequential tenant-scoped order number (Sales.SalesId).</summary>
    public int SalesNumber { get; set; }

    public ReturnShipmentStatus Status { get; set; }
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public int ItemCount { get; set; }
    public bool HasLabel { get; set; }
    public DateTime? ReceivedAt { get; set; }
    public DateTime DateCreated { get; set; }
}
