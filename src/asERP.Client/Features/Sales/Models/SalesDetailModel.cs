using System.Collections.Immutable;
using System.Linq;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Notifications;
using asERP.Client.Features.Customers;
using asERP.Client.Features.Products.Services;
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
    private readonly IProductService _productService;
    private readonly INavigator _navigator;
    private readonly INotificationService _notifications;
    private readonly IStringLocalizer _localizer;
    private readonly Guid _salesId;

    public SalesDetailModel(
        ISalesService salesService,
        IShippingService shippingService,
        IReturnService returnService,
        IProductService productService,
        INavigator navigator,
        INotificationService notifications,
        IStringLocalizer localizer,
        SalesDetailData data)
    {
        _salesService = salesService;
        _shippingService = shippingService;
        _returnService = returnService;
        _productService = productService;
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
    /// Gate for the lazy items feed; flipped once when the items tab is first selected.
    /// </summary>
    public IState<bool> ItemsTabRequested => State<bool>.Value(this, () => false);

    /// <summary>
    /// Order lines with their product thumbnails. Depends on the sales feed for the lines and
    /// stays dormant until <see cref="RequestItemsTab"/> flips the gate (lazy per-tab feed),
    /// so opening an order does not pull images the user may never look at.
    /// </summary>
    public IListFeed<SalesItemRow> Items => Feed.Combine(Sales, ItemsTabRequested)
        .Where(t => t.Item2)
        .SelectAsync(async (t, ct) =>
        {
            var rows = t.Item1.SalesItems
                .Select(item => new SalesItemRow
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Sku = item.MissingProductSku,
                    Quantity = item.Quantity,
                    Price = item.Price,
                    PrimaryImageId = item.PrimaryImageId
                })
                .ToList();

            await Task.WhenAll(rows
                .Where(row => row.PrimaryImageId.HasValue)
                .Select(row => LoadThumbnailAsync(row, ct)));

            return (IImmutableList<SalesItemRow>)rows.ToImmutableList();
        })
        .AsListFeed();

    /// <summary>
    /// Start loading the items feed; called from the page when the items tab is first selected.
    /// </summary>
    public async ValueTask RequestItemsTab(CancellationToken ct = default)
        => await ItemsTabRequested.UpdateAsync(_ => true, ct);

    private async Task LoadThumbnailAsync(SalesItemRow row, CancellationToken ct)
    {
        try
        {
            row.ThumbnailBytes = await _productService.GetProductImageBytesAsync(
                row.ProductId, row.PrimaryImageId!.Value, thumbnail: true, ct);
        }
        catch
        {
            // Thumbnail is non-essential; a missing preview must not break the items table.
        }
    }

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
