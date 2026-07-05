using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Customers;
using asERP.Client.Features.Returns.Services;
using asERP.Client.Features.Saless.Services;
using asERP.Client.Features.Shippings;
using asERP.Client.Features.Shippings.Services;
using asERP.Domain.Dtos.Sales;

namespace asERP.Client.Features.Saless.Models;

/// <summary>
/// Model for sales detail page using MVUX pattern.
/// Receives sales ID from navigation data.
/// </summary>
public partial record SalesDetailModel
{
    private readonly ISalesService _salesService;
    private readonly IShippingService _shippingService;
    private readonly IReturnService _returnService;
    private readonly INavigator _navigator;
    private readonly INotificationService _notifications;
    private readonly IStringLocalizer _localizer;
    private readonly Guid _salesId;

    public SalesDetailModel(
        ISalesService salesService,
        IShippingService shippingService,
        IReturnService returnService,
        INavigator navigator,
        INotificationService notifications,
        IStringLocalizer localizer,
        SalesDetailData data)
    {
        _salesService = salesService;
        _shippingService = shippingService;
        _returnService = returnService;
        _navigator = navigator;
        _notifications = notifications;
        _localizer = localizer;
        _salesId = data.salesId;
    }

    /// <summary>
    /// Feed that loads the sales details.
    /// </summary>
    public IFeed<SalesDetailDto> Sales => Feed.Async(async ct =>
    {
        var sales = await _salesService.GetSalesAsync(_salesId, ct);
        return sales ?? throw new InvalidOperationException($"Sales {_salesId} not found");
    });

    /// <summary>
    /// Navigate back to sales list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }

    /// <summary>
    /// Navigate to edit sales page.
    /// </summary>
    public async Task EditSales()
    {
        await _navigator.NavigateDataAsync(this, new SalesEditData(_salesId));
    }

    /// <summary>
    /// Navigate to the detail page of the customer who placed this sale.
    /// </summary>
    public async Task NavigateToCustomer(Guid customerId)
    {
        if (customerId == Guid.Empty)
        {
            return;
        }

        await _navigator.NavigateDataAsync(this, new CustomerDetailData(customerId));
    }

    /// <summary>
    /// Navigate to the detail page of a shipment of this order.
    /// </summary>
    public async Task NavigateToShipping(Guid shippingId)
    {
        if (shippingId == Guid.Empty)
        {
            return;
        }

        await _navigator.NavigateDataAsync(this, new ShippingDetailData(shippingId));
    }

    /// <summary>
    /// Cancels the order on the server (status guard and carrier voids run server-side).
    /// Returns true on success so the view can refresh its feed.
    /// </summary>
    public async Task<bool> CancelSales()
    {
        try
        {
            await _shippingService.CancelSalesAsync(_salesId);
            _notifications.Show(_localizer["SalesDetailPage.CancelSalesSuccess"].Value, NotificationSeverity.Success);
            return true;
        }
        catch (ApiException ex)
        {
            _notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
            return false;
        }
    }

    /// <summary>
    /// Cancels a single shipment of this order (carrier void, item release). Returns true
    /// on success so the view can refresh its feed.
    /// </summary>
    public async Task<bool> CancelShipment(Guid shippingId)
    {
        try
        {
            await _shippingService.CancelShippingAsync(shippingId);
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
    /// Cancels a return of this order before receipt (carrier void runs server-side, best
    /// effort). Returns true on success so the view can refresh its feed.
    /// </summary>
    public async Task<bool> CancelReturn(Guid returnId)
    {
        try
        {
            await _returnService.CancelReturnAsync(returnId);
            _notifications.Show(_localizer["SalesDetailPage.CancelReturnSuccess"].Value, NotificationSeverity.Success);
            return true;
        }
        catch (ApiException ex)
        {
            _notifications.Show(ex.CombinedMessage, NotificationSeverity.Error);
            return false;
        }
    }
}
