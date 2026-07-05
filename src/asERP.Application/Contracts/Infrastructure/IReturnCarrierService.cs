using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Contracts.Infrastructure;

/// <summary>
/// Carrier orchestration for return labels — implemented in asERP.Shipping.
/// </summary>
public interface IReturnCarrierService
{
    /// <summary>
    /// Requests a return label from the carrier configured on the return and persists tracking
    /// number, carrier shipment id and label bytes on the return. On transient failure the
    /// request is queued for background retry (result message says so). Carriers without
    /// return-label support fail permanently.
    /// </summary>
    Task<Result<ShipmentLabelResult>> CreateReturnLabelAsync(Guid returnShipmentId, CancellationToken cancellationToken = default);

    /// <summary>Voids/cancels the carrier-side return shipment (best effort).</summary>
    Task<Result> CancelReturnLabelAsync(Guid returnShipmentId, CancellationToken cancellationToken = default);
}
