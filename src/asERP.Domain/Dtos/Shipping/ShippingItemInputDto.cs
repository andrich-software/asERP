namespace asERP.Domain.Dtos.Shipping;

/// <summary>Order line to pack with an explicit quantity — enables partial-quantity shipments.</summary>
public class ShippingItemInputDto
{
    public Guid SalesItemId { get; set; }

    /// <summary>Quantity to ship; less than the line's open quantity splits the line.</summary>
    public double Quantity { get; set; }
}
