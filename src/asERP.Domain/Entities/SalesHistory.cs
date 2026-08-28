using System.ComponentModel.DataAnnotations;
using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

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
    /// <summary>English audit text. Also the client's fallback when <see cref="MessageKey"/> is
    /// null (entries written before localization) or its resource is missing.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Resource key the client renders instead of <see cref="Description"/>.
    /// See <see cref="SalesHistoryMessage"/>.</summary>
    public string? MessageKey { get; set; }

    /// <summary>JSON-encoded arguments for <see cref="MessageKey"/>.</summary>
    public string? MessageArgs { get; set; }

    public bool IsSystemGenerated { get; set; }
}
