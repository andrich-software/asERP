using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Contracts.Services;

/// <summary>
/// The single path for shipment status transitions — used by manual update/cancel handlers
/// AND the background tracking poller, so every change lands in SalesHistory.
/// </summary>
public interface IShippingStatusUpdater
{
    /// <summary>
    /// Applies a status change: no-op when unchanged, never downgrades a delivered shipment,
    /// stamps ShippedAt/DeliveredAt, writes a SalesHistory entry and raises SalesChangedNotification.
    /// </summary>
    Task<Result> ApplyStatusAsync(
        Guid shippingId,
        ShippingStatus newStatus,
        string? rawCarrierStatus = null,
        DateTime? eventTimeUtc = null,
        bool isSystemGenerated = true,
        Guid? userId = null,
        CancellationToken cancellationToken = default);
}
