namespace asERP.Application.Contracts.Services;

/// <summary>
/// Derives the order status from its shipment assignment: all items assigned → Completed,
/// some assigned → PartiallyDelivered, none assigned → revert an automation-set status.
/// Call after every change to SalesItem.ShippingId (shipment create/cancel/delete).
/// </summary>
public interface ISalesShippingStatusService
{
    Task RecomputeAsync(Guid salesId, CancellationToken cancellationToken = default);
}
