namespace asERP.Application.Models.Email;

/// <summary>
/// Template input for the customer shipping/delivery notification emails.
/// All string values are raw (unencoded) — the template service HTML-encodes them.
/// </summary>
public class ShippingNotificationEmailData
{
    /// <summary>Order number shown to the customer (<c>Sales.SalesId</c>).</summary>
    public int SalesNumber { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CarrierName { get; set; } = string.Empty;

    /// <summary>Booked rate ("Versandoption"); null when the rate was deleted.</summary>
    public string? RateName { get; set; }

    public string TrackingNumber { get; set; } = string.Empty;

    /// <summary>Carrier tracking link; when null/empty the template renders the plain number.</summary>
    public string? TrackingUrl { get; set; }

    /// <summary>True when the order has items outside this parcel — renders the partial-shipment hint.</summary>
    public bool IsPartialShipment { get; set; }

    public List<ShippingNotificationEmailItem> Items { get; set; } = new();
}

public class ShippingNotificationEmailItem
{
    public double Quantity { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Sku { get; set; } = string.Empty;
}
