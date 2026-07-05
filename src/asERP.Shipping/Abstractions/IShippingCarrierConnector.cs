using asERP.Domain.Enums;

namespace asERP.Shipping.Abstractions;

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

    /// <summary>
    /// Return labels are separate carrier API products — opt-in per connector. Connectors
    /// without support report a clean permanent failure from <see cref="CreateReturnLabelAsync"/>.
    /// </summary>
    bool SupportsReturnLabels { get; }

    Task<CarrierLabelResult> CreateReturnLabelAsync(ShippingCarrierContext context, ReturnLabelRequest request);
}
