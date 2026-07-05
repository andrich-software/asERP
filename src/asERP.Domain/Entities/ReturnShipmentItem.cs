using asERP.Domain.Entities.Common;
using asERP.Domain.Enums;

namespace asERP.Domain.Entities;

/// <summary>
/// One returned position. References a shipped <see cref="SalesItem"/> row directly —
/// after the outbound split every shipped row is parcel-scoped, so partial returns are
/// pure quantity arithmetic (quantity ≤ row quantity − already returned) and never split rows.
/// </summary>
public class ReturnShipmentItem : BaseEntity, IBaseEntity
{
    public Guid ReturnShipmentId { get; set; }
    public ReturnShipment ReturnShipment { get; set; } = null!;

    public Guid SalesItemId { get; set; }
    public SalesItem SalesItem { get; set; } = null!;

    public double Quantity { get; set; }

    public ReturnReason Reason { get; set; } = ReturnReason.Unspecified;

    /// <summary>Free-text detail complementing <see cref="Reason"/>.</summary>
    public string? ReasonText { get; set; }

    /// <summary>Recorded at goods receipt; stays <see cref="ReturnItemCondition.Unknown"/> until then.</summary>
    public ReturnItemCondition Condition { get; set; } = ReturnItemCondition.Unknown;

    public ICollection<ReturnShipmentItemSerialNumber> SerialNumbers { get; set; } = new List<ReturnShipmentItemSerialNumber>();
}
