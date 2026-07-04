using System.ComponentModel.DataAnnotations;
using asToolkit.Domain.Entities.Common;
using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Entities;

public class SalesHistory : BaseEntity, IBaseEntity
{
    public Guid UserId { get; set; }
    public Guid SalesId { get; set; }

    /// <summary>Set when the entry belongs to a specific shipment; null for order-level entries.
    /// No navigation/FK on purpose — shipments may be deleted while their audit trail stays.</summary>
    public Guid? ShippingId { get; set; }
    public SalesStatus? SalesStatusOld { get; set; }
    public SalesStatus? SalesStatusNew { get; set; }
    public PaymentStatus? PaymentStatusOld { get; set; }
    public PaymentStatus? PaymentStatusNew { get; set; }
    public string? ShippingStatusOld { get; set; }
    public string? ShippingStatusNew { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsSystemGenerated { get; set; }
}