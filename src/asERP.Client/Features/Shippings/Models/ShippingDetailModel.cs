using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Saless;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Shipping;

namespace asERP.Client.Features.Shippings.Models;

/// <summary>
/// Model for the shipment detail page using the MVUX pattern.
/// Receives the shipment ID from navigation data.
/// </summary>
public partial record ShippingDetailModel
{
    private readonly IShippingService _shippingService;
    private readonly INavigator _navigator;
    private readonly INotificationService _notifications;
    private readonly IStringLocalizer _localizer;
    private readonly Guid _shippingId;

    public ShippingDetailModel(
        IShippingService shippingService,
        INavigator navigator,
        INotificationService notifications,
        IStringLocalizer localizer,
        ShippingDetailData data)
    {
        _shippingService = shippingService;
        _navigator = navigator;
        _notifications = notifications;
        _localizer = localizer;
        _shippingId = data.shippingId;
    }

    /// <summary>
    /// Feed that loads the shipment details (incl. the tracking timeline).
    /// </summary>
    public IFeed<ShippingDetailDto> Shipping => Feed.Async(async ct =>
    {
        var shipping = await _shippingService.GetShippingAsync(_shippingId, ct);
        return shipping ?? throw new InvalidOperationException($"Shipping {_shippingId} not found");
    });

    /// <summary>
    /// Navigate back to the shipment list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }

    /// <summary>
    /// Navigate to the detail page of the order this shipment belongs to.
    /// </summary>
    public async Task NavigateToSales(Guid salesId)
    {
        if (salesId == Guid.Empty)
        {
            return;
        }

        await _navigator.NavigateDataAsync(this, new SalesDetailData(salesId));
    }

    /// <summary>
    /// Cancels the shipment on the server. Returns true on success so the view can
    /// refresh its feed.
    /// </summary>
    public async Task<bool> CancelShipment()
    {
        try
        {
            await _shippingService.CancelShippingAsync(_shippingId);
            _notifications.Show(_localizer["ShippingDetailPage.CancelSuccess"].Value, NotificationSeverity.Success);
            return true;
        }
        catch (ApiException ex)
        {
            _notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
            return false;
        }
    }

    /// <summary>
    /// Re-queues the label creation after a dead-lettered outbox row. Returns true on
    /// success so the view can refresh its feed.
    /// </summary>
    public async Task<bool> RetryLabel()
    {
        try
        {
            await _shippingService.RetryLabelAsync(_shippingId);
            _notifications.Show(_localizer["ShippingDetailPage.RetrySuccess"].Value, NotificationSeverity.Success);
            return true;
        }
        catch (ApiException ex)
        {
            _notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
            return false;
        }
    }
}
