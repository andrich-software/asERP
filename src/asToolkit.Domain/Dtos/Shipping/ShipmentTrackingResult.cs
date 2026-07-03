using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Dtos.Shipping;

/// <summary>Normalized carrier tracking state, returned by IShippingCarrierService.</summary>
public class ShipmentTrackingResult
{
    public ShippingStatus Status { get; set; }

    /// <summary>Verbatim carrier status text — stored in Shipping.LastCarrierStatusRaw.</summary>
    public string? RawCarrierStatus { get; set; }

    public DateTime? EventTimeUtc { get; set; }
}
