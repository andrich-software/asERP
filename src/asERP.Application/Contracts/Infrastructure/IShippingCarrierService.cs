using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Contracts.Infrastructure;

/// <summary>
/// Carrier-facing operations for a shipment. Implemented in asERP.Shipping, which resolves
/// the connector from the shipment's provider and handles the label-outbox fallback on
/// transient carrier failures.
/// </summary>
public interface IShippingCarrierService
{
    /// <summary>
    /// Requests a label from the carrier configured on the shipment's provider and persists
    /// tracking number, carrier shipment id and label bytes on the shipment. On transient
    /// failure the request is queued for background retry (result message says so).
    /// </summary>
    Task<Result<ShipmentLabelResult>> CreateLabelAsync(Guid shippingId, CancellationToken cancellationToken = default);

    /// <summary>Voids/cancels the carrier-side shipment (best effort).</summary>
    Task<Result> CancelShipmentAsync(Guid shippingId, CancellationToken cancellationToken = default);

    /// <summary>Fetches the current carrier tracking state for one shipment.</summary>
    Task<Result<ShipmentTrackingResult>> GetTrackingStatusAsync(Guid shippingId, CancellationToken cancellationToken = default);
}
