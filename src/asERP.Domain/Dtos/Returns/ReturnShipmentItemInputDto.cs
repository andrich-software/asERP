using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Returns;

public class ReturnShipmentItemInputDto
{
    /// <summary>A shipped order line (SalesItem with ShippingId set).</summary>
    public Guid SalesItemId { get; set; }

    /// <summary>Quantity to return; must not exceed the line's shipped quantity minus already returned.</summary>
    public double Quantity { get; set; }

    public ReturnReason Reason { get; set; } = ReturnReason.Unspecified;

    public string? ReasonText { get; set; }
}
