using maERP.Client.Features.Dashboard.Models;
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
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly ILogger<SalesChannelDashboardModel> _logger;
    private readonly Guid _salesChannelId;

    public string Title { get; }

    public SalesChannelDashboardModel(
        ISalesChannelStatisticsService statisticsService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<SalesChannelDashboardModel> logger,
        SalesChannelDashboardData? data = null)
    {
        _statisticsService = statisticsService;
        _navigator = navigator;
        _localizer = localizer;
        _logger = logger;
        _salesChannelId = data?.SalesChannelId ?? Guid.Empty;
        Title = data?.SalesChannelName ?? string.Empty;
    }

    // Tab 1: Dashboard KPIs
    public IFeed<RevenueKpiData> RevenueData => Feed.Async(LoadRevenueDataAsync);
    public IFeed<SalessKpiData> SalessData => Feed.Async(LoadSalessDataAsync);

    /// <summary>
    /// Navigates to the SalesChannel detail/settings page for the connector configuration.
    /// </summary>
    public async ValueTask OpenSettings()
    {
        await _navigator.NavigateDataAsync(this, new SalesChannelDetailData(_salesChannelId));
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
}
