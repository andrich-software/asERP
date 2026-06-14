using maERP.Client.Core.Models;
using maERP.Client.Features.Dashboard.Models;
using maERP.Client.Features.Saless;
using maERP.Client.Features.Saless.Models;
using maERP.Client.Features.Saless.Services;
using maERP.Client.Features.SalesChannelDashboards.Services;
using maERP.Client.Features.SalesChannels.Models;
using Microsoft.Extensions.Logging;

namespace maERP.Client.Features.SalesChannelDashboards.Models;

/// <summary>
/// Generic dashboard model for SalesChannel types without a specialized dashboard
/// (Shopware6, WooCommerce, eBay, Amazon). Provides revenue/saless KPIs and a
/// shortcut to the channel's settings/detail page.
/// </summary>
public partial record SalesChannelDashboardModel
{
    private readonly ISalesChannelStatisticsService _statisticsService;
    private readonly ISalesService _salesService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly ILogger<SalesChannelDashboardModel> _logger;
    private readonly Guid _salesChannelId;

    public string Title { get; }

    public SalesChannelDashboardModel(
        ISalesChannelStatisticsService statisticsService,
        ISalesService salesService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<SalesChannelDashboardModel> logger,
        SalesChannelDashboardData? data = null)
    {
        _statisticsService = statisticsService;
        _salesService = salesService;
        _navigator = navigator;
        _localizer = localizer;
        _logger = logger;
        _salesChannelId = data?.SalesChannelId ?? Guid.Empty;
        Title = data?.SalesChannelName ?? string.Empty;
    }

    /// <summary>
    /// Auto-refresh signal. Bumping this value re-evaluates all data feeds.
    /// </summary>
    public IState<int> RefreshTick => State<int>.Value(this, () => 0);

    // Tab 1: Dashboard KPIs
    public IFeed<RevenueKpiData> RevenueData => RefreshTick.SelectAsync((_, ct) => LoadRevenueDataAsync(ct));
    public IFeed<SalessKpiData> SalessData => RefreshTick.SelectAsync((_, ct) => LoadSalessDataAsync(ct));

    // Tab 2: Recent Sales (paginated, filtered by this SalesChannel)
    public IState<int> CurrentPage => State<int>.Value(this, () => 0);
    public IState<int> PageSize => State<int>.Value(this, () => 10);
    public IState<SalesPaginationInfo> Pagination => State<SalesPaginationInfo>.Value(this, () => new SalesPaginationInfo());

    public IListFeed<RecentSalesItem> RecentSaless => Feed
        .Combine(CurrentPage, PageSize, RefreshTick)
        .SelectAsync(LoadRecentSalessAsync)
        .AsListFeed();

    /// <summary>
    /// Triggers a reload of all dashboard data (KPIs and recent sales for the current page).
    /// Called periodically by the view's auto-refresh timer.
    /// </summary>
    public async ValueTask RefreshAsync(CancellationToken ct = default)
    {
        await RefreshTick.UpdateAsync(t => t + 1, ct);
    }

    /// <summary>
    /// Navigates to the SalesChannel detail/settings page for the connector configuration.
    /// </summary>
    public async ValueTask OpenSettings()
    {
        await _navigator.NavigateDataAsync(this, new SalesChannelDetailData(_salesChannelId));
    }

    /// <summary>
    /// Navigates to the detail page of the selected recent sales.
    /// </summary>
    public async ValueTask ViewSales(RecentSalesItem sales)
    {
        await _navigator.NavigateDataAsync(this, new SalesDetailData(sales.Id));
    }

    /// <summary>
    /// Go to the next page of recent sales.
    /// </summary>
    public async ValueTask GoToNextPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await CurrentPage.UpdateAsync(p => p + 1, ct);
        }
    }

    /// <summary>
    /// Go to the previous page of recent sales.
    /// </summary>
    public async ValueTask GoToPreviousPage(CancellationToken ct = default)
    {
        var pagination = await Pagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await CurrentPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    private async ValueTask<RevenueKpiData> LoadRevenueDataAsync(CancellationToken ct)
    {
        try
        {
            var data = await _statisticsService.GetSalesTodayAsync(_salesChannelId, ct);
            if (data == null) return new RevenueKpiData();

            return new RevenueKpiData
            {
                RevenueToday = data.RevenueToday,
                RevenueThisWeek = data.RevenueThisWeek,
                RevenueThisMonth = data.RevenueThisMonth,
                RevenueChange = data.RevenueChangePercent
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading revenue KPI data for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    private async ValueTask<SalessKpiData> LoadSalessDataAsync(CancellationToken ct)
    {
        try
        {
            var data = await _statisticsService.GetSalessTodayAsync(_salesChannelId, ct);
            if (data == null) return new SalessKpiData();

            return new SalessKpiData
            {
                SalessToday = data.SalessToday,
                SalessPending = data.SalessPending,
                SalessThisWeek = data.SalessThisWeek,
                SalessChange = data.SalessChangePercent
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading saless KPI data for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    private async ValueTask<IImmutableList<RecentSalesItem>> LoadRecentSalessAsync((int page, int size, int tick) paging, CancellationToken ct)
    {
        var (page, size, _) = paging;
        try
        {
            var parameters = new QueryParameters
            {
                PageNumber = page,
                PageSize = size,
                SalesChannelId = _salesChannelId,
                SalesBy = "DateSalesed Descending"
            };

            var response = await _salesService.GetSalessAsync(parameters, ct);

            await Pagination.UpdateAsync(_ => new SalesPaginationInfo(
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount,
                response.PageSize,
                response.HasPreviousPage,
                response.HasNextPage,
                _localizer), ct);

            return response.Data
                .Select(o => new RecentSalesItem
                {
                    Id = o.Id,
                    SalesNumber = o.SalesId.ToString(),
                    CustomerName = o.FullName,
                    Amount = o.Total,
                    Status = o.Status,
                    SalesDate = o.DateSalesed
                })
                .ToImmutableList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading recent saless for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }
}
