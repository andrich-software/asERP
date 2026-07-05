using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Services;

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

        // Consume the customer-notification slots in the same save as the status change so a
        // racing second transition can never publish a duplicate "due" event. Stamped regardless
        // of the tenant opt-in — the handler decides whether a mail actually goes out.
        ShippingCustomerNotificationKind? customerNotificationDue = null;
        if (newStatus == ShippingStatus.Delivered && shipping.CustomerDeliveryNotifiedAt == null)
        {
            // Skip-ahead (e.g. poller jumps LabelCreated -> Delivered) consumes the shipped slot
            // too: a late "on the way" mail after delivery would be noise.
            shipping.CustomerNotifiedAt ??= eventTime;
            shipping.CustomerDeliveryNotifiedAt = eventTime;
            customerNotificationDue = ShippingCustomerNotificationKind.Delivered;
        }
        else if (shipping.CustomerNotifiedAt == null && newStatus is ShippingStatus.Shipped
                     or ShippingStatus.InTransit or ShippingStatus.OutForDelivery)
        {
            shipping.CustomerNotifiedAt = eventTime;
            customerNotificationDue = ShippingCustomerNotificationKind.Shipped;
        }

        await _shippingRepository.UpdateAsync(shipping);

        await _salesRepository.AddSalesHistoryAsync(new SalesHistory
        {
            SalesId = shipping.SalesId,
            ShippingId = shipping.Id,
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

        if (customerNotificationDue is { } notificationKind)
        {
            await _mediator.Publish(
                new ShippingCustomerNotificationDue(shipping.Id, shipping.SalesId, shipping.TenantId, notificationKind),
                cancellationToken);
        }

        return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
    }
}
