using asToolkit.Client.Core.Exceptions;
using asToolkit.Client.Core.Models;
using asToolkit.Client.Features.Dashboard.Models;
using asToolkit.Client.Features.SalesChannelDashboards.Services;
using asToolkit.Client.Features.SalesChannels.Models;
using asToolkit.Client.Features.SalesChannels.Services;
using asToolkit.Client.Features.Saless;
using asToolkit.Client.Features.Saless.Models;
using asToolkit.Client.Features.Saless.Services;
using asToolkit.Domain.Dtos.WebAnalytics;
using asToolkit.Domain.Enums;
using Microsoft.Extensions.Logging;

namespace asToolkit.Client.Features.SalesChannelDashboards.Models;

/// <summary>
/// Generic dashboard model for SalesChannel types without a specialized dashboard
/// (Shopware6, WooCommerce, eBay, Amazon). Provides revenue/saless KPIs and a
/// shortcut to the channel's settings/detail page.
/// </summary>
public partial record SalesChannelDashboardModel
{
    private readonly ISalesChannelStatisticsService _statisticsService;
    private readonly ISalesService _salesService;
    private readonly ISalesChannelService _salesChannelService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly ILogger<SalesChannelDashboardModel> _logger;
    private readonly Guid _salesChannelId;
    private readonly SalesChannelType _salesChannelType;

    public string Title { get; }

    /// <summary>
    /// Web analytics is only offered for the channel types that ship a tracking plugin (WooCommerce,
    /// Shopware 6). Used to show/hide the "Web-Statistiken" tab.
    /// </summary>
    public bool ShowWebStatistics => _salesChannelType is SalesChannelType.WooCommerce or SalesChannelType.Shopware6;

    public SalesChannelDashboardModel(
        ISalesChannelStatisticsService statisticsService,
        ISalesService salesService,
        ISalesChannelService salesChannelService,
        INavigator navigator,
        IStringLocalizer localizer,
        ILogger<SalesChannelDashboardModel> logger,
        SalesChannelDashboardData? data = null)
    {
        _statisticsService = statisticsService;
        _salesService = salesService;
        _salesChannelService = salesChannelService;
        _navigator = navigator;
        _localizer = localizer;
        _logger = logger;
        _salesChannelId = data?.SalesChannelId ?? Guid.Empty;
        _salesChannelType = data?.SalesChannelType ?? default;
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

    // Tab: Web statistics (visitor analytics; only for WooCommerce / Shopware 6)
    public IFeed<WebSessionsSummaryDto> WebSessions => RefreshTick.SelectAsync((_, ct) => LoadWebSessionsAsync(ct));
    public IListFeed<WebTopProductDto> WebTopProducts => RefreshTick.SelectAsync((_, ct) => LoadWebTopProductsAsync(ct)).AsListFeed();

    // Tab: Sync status (per-operation last/next run + scrollable 24h log)
    public IFeed<SyncStatusViewData> SyncStatus => RefreshTick.SelectAsync((_, ct) => LoadSyncStatusAsync(ct));

    /// <summary>Minimum log level shown: 0 = Information (all), 1 = Warning, 2 = Error. Bound to the filter ComboBox.</summary>
    public IState<int> LogLevelFilterIndex => State<int>.Value(this, () => 0);

    public IListFeed<SyncLogLineViewData> SyncLog => Feed
        .Combine(LogLevelFilterIndex, RefreshTick)
        .SelectAsync(LoadSyncLogAsync)
        .AsListFeed();

    /// <summary>True while a manual sync / retry request is in flight — disables the action buttons.</summary>
    public IState<bool> IsSyncBusy => State<bool>.Value(this, () => false);

    /// <summary>Last sync-action error (RFC 7807 messages), surfaced under the action buttons.</summary>
    public IState<string?> SyncError => State<string?>.Value(this, () => null);

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

    private async ValueTask<WebSessionsSummaryDto> LoadWebSessionsAsync(CancellationToken ct)
    {
        try
        {
            var data = await _statisticsService.GetWebSessionsAsync(_salesChannelId, ct);
            return data ?? new WebSessionsSummaryDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading web sessions for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    private async ValueTask<IImmutableList<WebTopProductDto>> LoadWebTopProductsAsync(CancellationToken ct)
    {
        try
        {
            // Most-visited products over the last 30 days.
            var end = DateTime.UtcNow.Date;
            var start = end.AddDays(-29);
            var data = await _statisticsService.GetWebTopProductsAsync(_salesChannelId, start, end, 10, ct);
            return (data?.Products ?? new List<WebTopProductDto>()).ToImmutableList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading web top products for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    private async ValueTask<SyncStatusViewData> LoadSyncStatusAsync(CancellationToken ct)
    {
        try
        {
            var dto = await _salesChannelService.GetSyncStatusAsync(_salesChannelId, ct);
            if (dto is null) return new SyncStatusViewData();

            return SyncStatusViewMapper.ToViewData(dto, _localizer, DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading sync status for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    private async ValueTask<IImmutableList<SyncLogLineViewData>> LoadSyncLogAsync((int levelIndex, int tick) input, CancellationToken ct)
    {
        var (levelIndex, _) = input;
        try
        {
            var minLevel = levelIndex switch
            {
                1 => "Warning",
                2 => "Error",
                _ => "Information",
            };

            var logs = await _salesChannelService.GetSyncLogsAsync(_salesChannelId, take: 500, offset: 0, minLevel: minLevel, ct: ct);
            return logs.Select(l => SyncStatusViewMapper.ToLogLine(l, _localizer)).ToImmutableList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading sync log for SalesChannel {SalesChannelId}", _salesChannelId);
            throw;
        }
    }

    /// <summary>
    /// Triggers a manual import for one operation ("products" | "customers" | "saless"). The server
    /// enqueues the run (202) and the orchestrator starts it within ~10s; the refreshed sync-status
    /// feed then shows it as Queued/Running with live progress checkpoints.
    /// </summary>
    public async ValueTask TriggerSync(string operation, CancellationToken ct = default)
    {
        await IsSyncBusy.UpdateAsync(_ => true, ct);
        await SyncError.UpdateAsync(_ => null, ct);
        try
        {
            await _salesChannelService.TriggerSyncAsync(_salesChannelId, operation, ct);
        }
        catch (ApiException ex)
        {
            await SyncError.UpdateAsync(_ => ex.CombinedMessage, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Manual sync '{Operation}' failed for SalesChannel {SalesChannelId}", operation, _salesChannelId);
            await SyncError.UpdateAsync(_ => ex.Message, ct);
        }
        finally
        {
            await IsSyncBusy.UpdateAsync(_ => false, ct);
            await RefreshAsync(ct);
        }
    }

    /// <summary>Resets every DeadLetter export row for this channel back to Pending so the drainer retries them.</summary>
    public async ValueTask RetryDeadLetters(CancellationToken ct = default)
    {
        await IsSyncBusy.UpdateAsync(_ => true, ct);
        await SyncError.UpdateAsync(_ => null, ct);
        try
        {
            var rows = await _salesChannelService.GetDeadLetterAsync(_salesChannelId, ct);
            foreach (var row in rows)
            {
                await _salesChannelService.RetryDeadLetterAsync(_salesChannelId, row.Id, ct);
            }
        }
        catch (ApiException ex)
        {
            await SyncError.UpdateAsync(_ => ex.CombinedMessage, ct);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Dead-letter retry failed for SalesChannel {SalesChannelId}", _salesChannelId);
            await SyncError.UpdateAsync(_ => ex.Message, ct);
        }
        finally
        {
            await IsSyncBusy.UpdateAsync(_ => false, ct);
            await RefreshAsync(ct);
        }
    }

    /// <summary>Builds the full visible log as plain text for the "Copy log" button (uses the current level filter).</summary>
    public async Task<string> BuildLogClipboardTextAsync(CancellationToken ct = default)
    {
        var levelIndex = await LogLevelFilterIndex.Value(ct);
        var lines = await LoadSyncLogAsync((levelIndex, 0), ct);
        return string.Join(Environment.NewLine, lines.Select(l => l.RawLine));
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
