namespace asERP.Domain.Dtos.Shipping;

/// <summary>Result of a successful carrier label creation, returned by IShippingCarrierService.</summary>
public class ShipmentLabelResult
{
    public string CarrierShipmentId { get; set; } = string.Empty;
    public string TrackingNumber { get; set; } = string.Empty;
    public string? TrackingUrl { get; set; }
    public byte[] LabelData { get; set; } = Array.Empty<byte>();
    public string LabelFormat { get; set; } = "application/pdf";
}
