using asToolkit.Domain.Enums;

namespace asToolkit.Shipping.Abstractions;

/// <summary>
/// One implementation per carrier (DHL, DPD, GLS, UPS). Connectors are stateless — everything
/// call-specific arrives via <see cref="ShippingCarrierContext"/>.
/// </summary>
public interface IShippingCarrierConnector
{
    ShippingProviderType Type { get; }

    Task<CarrierConnectionTestResult> TestConnectionAsync(ShippingCarrierContext context);

    Task<CarrierLabelResult> CreateLabelAsync(ShippingCarrierContext context, ShipmentLabelRequest request);

    Task<CarrierTrackingResult> GetTrackingStatusAsync(ShippingCarrierContext context, string trackingNumber);

    Task<CarrierCancelResult> CancelShipmentAsync(ShippingCarrierContext context, string carrierShipmentId);
}
