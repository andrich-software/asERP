namespace asERP.Domain.Dtos.Returns;

/// <summary>
/// A shipped order line that can (still) be returned, enriched with what the
/// create-return dialog needs. Shipped lines are parcel-scoped after the outbound split.
/// </summary>
public class ReturnableSalesItemDto
{
    public Guid SalesItemId { get; set; }
    public Guid ShippingId { get; set; }

    /// <summary>Tracking number of the outbound parcel the line was shipped in.</summary>
    public string TrackingNumber { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;

    public double ShippedQuantity { get; set; }
    public double AlreadyReturnedQuantity { get; set; }
    public double ReturnableQuantity { get; set; }

    /// <summary>Serialized lines can only be returned as a whole line.</summary>
    public bool HasSerialNumbers { get; set; }

    /// <summary>Serial numbers of the line — offered for selection at goods receipt.</summary>
    public List<string> SerialNumbers { get; set; } = new();
}
