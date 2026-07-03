using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Mediator;
using asToolkit.Application.Notifications;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Services;

public class ShippingStatusUpdater : IShippingStatusUpdater
{
    private static readonly ShippingStatus[] TerminalStatuses =
    [
        ShippingStatus.Delivered,
        ShippingStatus.Cancelled,
        ShippingStatus.ReturnedToSender,
        ShippingStatus.Lost
    ];

    private readonly IAppLogger<ShippingStatusUpdater> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IMediator _mediator;

    public ShippingStatusUpdater(
        IAppLogger<ShippingStatusUpdater> logger,
        IShippingRepository shippingRepository,
        ISalesRepository salesRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result> ApplyStatusAsync(
        Guid shippingId,
        ShippingStatus newStatus,
        string? rawCarrierStatus = null,
        DateTime? eventTimeUtc = null,
        bool isSystemGenerated = true,
        Guid? userId = null,
        CancellationToken cancellationToken = default)
    {
        var shipping = await _shippingRepository.GetByIdAsync(shippingId);
        if (shipping == null)
        {
            return new Result { Succeeded = false, StatusCode = ResultStatusCode.NotFound, Messages = [$"Shipping {shippingId} not found."] };
        }

        var oldStatus = shipping.Status;

        if (isSystemGenerated)
        {
            // Every poll attempt stamps LastTrackedAt so broken tracking numbers cannot hot-loop.
            shipping.LastTrackedAt = DateTime.UtcNow;
            if (rawCarrierStatus != null)
            {
                shipping.LastCarrierStatusRaw = rawCarrierStatus;
            }
        }

        // Carrier polls never move a shipment out of a terminal state (no Delivered -> InTransit
        // downgrades from stale tracking data). Manual changes are gated by the update validator.
        if (oldStatus == newStatus || (isSystemGenerated && TerminalStatuses.Contains(oldStatus)))
        {
            await _shippingRepository.UpdateAsync(shipping);
            return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
        }

        shipping.Status = newStatus;

        var eventTime = eventTimeUtc ?? DateTime.UtcNow;
        if (shipping.ShippedAt == null && newStatus is ShippingStatus.Shipped or ShippingStatus.InTransit
                or ShippingStatus.OutForDelivery or ShippingStatus.Delivered)
        {
            shipping.ShippedAt = eventTime;
        }

        if (newStatus == ShippingStatus.Delivered)
        {
            shipping.DeliveredAt = eventTime;
        }

        await _shippingRepository.UpdateAsync(shipping);

        await _salesRepository.AddSalesHistoryAsync(new SalesHistory
        {
            SalesId = shipping.SalesId,
            UserId = userId ?? Guid.Empty,
            TenantId = shipping.TenantId,
            ShippingStatusOld = oldStatus.ToString(),
            ShippingStatusNew = newStatus.ToString(),
            Description = rawCarrierStatus ?? string.Empty,
            IsSystemGenerated = isSystemGenerated
        });

        _logger.LogInformation("Shipping {ShippingId} status changed {Old} -> {New}", shippingId, oldStatus, newStatus);

        await _mediator.Publish(
            new SalesChangedNotification(shipping.SalesId, shipping.TenantId, SalesChangeKind.StatusChanged),
            cancellationToken);

        return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
    }
}
