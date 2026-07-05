namespace asERP.Domain.Dtos.Sales;

/// <summary>
/// Projection of a sales order line for the detail view. Deliberately does not embed the
/// <c>SalesItem</c> entity so tenant/navigation data (TenantId, SerialNumbers, …) is never
/// serialized to the client.
/// </summary>
public class SalesItemDto
{
    public Guid Id { get; set; }
    public Guid SalesId { get; set; }
    public Guid ProductId { get; set; }
    public double Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public double TaxRate { get; set; }
    public string MissingProductSku { get; set; } = string.Empty;
    public string MissingProductEan { get; set; } = string.Empty;

    /// <summary>The parcel this line was packed into; null while unassigned.</summary>
    public Guid? ShippingId { get; set; }
}
