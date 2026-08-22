using System.Collections.Immutable;
using asERP.Client.Core.Exceptions;
using asERP.Client.Features.SalesChannels.Services;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;

namespace asERP.Client.Features.SalesChannels.Models;

/// <summary>
/// Navigation data for SalesChannelDetailModel.
/// </summary>
public record SalesChannelDetailData(Guid SalesChannelId);

/// <summary>
/// Model for sales channel detail page using MVUX pattern.
/// Receives sales channel ID from navigation data.
/// </summary>
public partial record SalesChannelDetailModel
{
    private readonly ISalesChannelService _salesChannelService;
    private readonly INavigator _navigator;
    private readonly IStringLocalizer _localizer;
    private readonly Guid _salesChannelId;

    public SalesChannelDetailModel(
        ISalesChannelService salesChannelService,
        INavigator navigator,
        IStringLocalizer localizer,
        SalesChannelDetailData data)
    {
        _salesChannelService = salesChannelService;
        _navigator = navigator;
        _localizer = localizer;
        _salesChannelId = data.SalesChannelId;
    }

    /// <summary>
    /// Feed that loads the sales channel details.
    /// </summary>
    public IFeed<SalesChannelDetailDto> SalesChannel => Feed.Async(async ct =>
    {
        var salesChannel = await _salesChannelService.GetSalesChannelAsync(_salesChannelId, ct);
        return salesChannel ?? throw new InvalidOperationException($"Sales channel {_salesChannelId} not found");
    });

    /// <summary>Recent sync-run audit history.</summary>
    public IListFeed<ChannelSyncRunDto> SyncRuns => ListFeed.Async<ChannelSyncRunDto>(async ct =>
    {
        var runs = await _salesChannelService.GetSyncRunsAsync(_salesChannelId, take: 25, offset: 0, ct);
        return runs.ToImmutableList();
    });

    /// <summary>Outbox rows currently in DeadLetter — surfaced for manual retry.</summary>
    public IListFeed<ChannelExportOutboxDto> DeadLetterRows => ListFeed.Async<ChannelExportOutboxDto>(async ct =>
    {
        var rows = await _salesChannelService.GetDeadLetterAsync(_salesChannelId, ct);
        return rows.ToImmutableList();
    });

    /// <summary>Set true when the Log tab is first selected, unlocking the log query.</summary>
    public IState<bool> LogsRequested => State<bool>.Value(this, () => false);

    /// <summary>Minimum severity for the log tab (empty = all levels including Debug).</summary>
    public IState<string> LogLevelFilter => State<string>.Value(this, () => string.Empty);

    /// <summary>Free-text filter over the log message.</summary>
    public IState<string> LogSearch => State<string>.Value(this, () => string.Empty);

    /// <summary>Current log page (0-based).</summary>
    public IState<int> LogPage => State<int>.Value(this, () => 0);

    /// <summary>Log entries per page.</summary>
    public IState<int> LogPageSize => State<int>.Value(this, () => 50);

    /// <summary>Pagination info from the last log query.</summary>
    public IState<SyncLogPaginationInfo> LogPagination => State<SyncLogPaginationInfo>.Value(this, () => new SyncLogPaginationInfo(_localizer));

    /// <summary>
    /// Synchronization log lines (full history, newest first). Re-queries when the level filter,
    /// search text, page, or page size changes; idle until the Log tab is first selected.
    /// </summary>
    public IListFeed<ChannelSyncLogDto> SyncLogs => Feed
        .Combine(LogsRequested, LogLevelFilter, LogSearch, Feed.Combine(LogPage, LogPageSize))
        .SelectAsync(async (combined, ct) =>
        {
            var (requested, minLevel, search, paging) = combined;
            if (!requested)
            {
                return ImmutableList<ChannelSyncLogDto>.Empty;
            }

            var (page, pageSize) = paging;
            var response = await _salesChannelService.GetSyncLogsAsync(
                _salesChannelId,
                pageNumber: page,
                pageSize: pageSize,
                minLevel: string.IsNullOrEmpty(minLevel) ? null : minLevel,
                search: string.IsNullOrWhiteSpace(search) ? null : search,
                sinceHours: null,
                ct);

            await LogPagination.UpdateAsync(_ => new SyncLogPaginationInfo(
                response.CurrentPage,
                response.TotalPages,
                response.TotalCount,
                response.PageSize,
                response.HasPreviousPage,
                response.HasNextPage,
                _localizer), ct);

            return response.Data.ToImmutableList();
        })
        .AsListFeed();

    /// <summary>Called by the page when the Log tab is selected the first time.</summary>
    public async Task ActivateLogTab() => await LogsRequested.SetAsync(true);

    /// <summary>Sets the minimum severity ("" | "Information" | "Warning" | "Error") and resets to page 0.</summary>
    public async Task SetLogLevel(string minLevel)
    {
        await LogPage.UpdateAsync(_ => 0);
        await LogLevelFilter.SetAsync(minLevel);
    }

    /// <summary>Sets the message search text and resets to page 0.</summary>
    public async Task SetLogSearch(string search)
    {
        await LogPage.UpdateAsync(_ => 0);
        await LogSearch.SetAsync(search);
    }

    /// <summary>Sets the page size and resets to page 0.</summary>
    public async Task SetLogPageSize(int pageSize)
    {
        await LogPage.UpdateAsync(_ => 0);
        await LogPageSize.SetAsync(pageSize);
    }

    public async Task GoToPreviousLogPage(CancellationToken ct = default)
    {
        var pagination = await LogPagination.Value(ct);
        if (pagination?.HasPreviousPage == true)
        {
            await LogPage.UpdateAsync(p => Math.Max(0, p - 1), ct);
        }
    }

    public async Task GoToNextLogPage(CancellationToken ct = default)
    {
        var pagination = await LogPagination.Value(ct);
        if (pagination?.HasNextPage == true)
        {
            await LogPage.UpdateAsync(p => p + 1, ct);
        }
    }

    /// <summary>User-facing status line for the most recent orchestration action.</summary>
    public IState<string> StatusMessage => State<string>.Value(this, () => string.Empty);

    /// <summary>Set true while an orchestration action is in flight, so XAML can disable buttons.</summary>
    public IState<bool> IsBusy => State<bool>.Value(this, () => false);

    public Task TriggerSyncProducts() => RunAsync("Products import", ct => _salesChannelService.TriggerSyncAsync(_salesChannelId, "products", ct));
    public Task TriggerSyncSaless() => RunAsync("Saless import", ct => _salesChannelService.TriggerSyncAsync(_salesChannelId, "saless", ct));
    public Task TriggerSyncCustomers() => RunAsync("Customers import", ct => _salesChannelService.TriggerSyncAsync(_salesChannelId, "customers", ct));

    public async Task TestConnection()
    {
        await IsBusy.SetAsync(true);
        try
        {
            var result = await _salesChannelService.TestConnectionAsync(_salesChannelId);
            var ok = result?.Success == true;
            var message = ok ? "Connected." : (result?.Message ?? "Test failed.");
            await StatusMessage.SetAsync($"Test connection: {(ok ? "OK" : "FAIL")} — {message}");
        }
        catch (ApiException ex)
        {
            await StatusMessage.SetAsync($"Test connection failed: {ex.CombinedMessage}");
        }
        finally
        {
            await IsBusy.SetAsync(false);
        }
    }

    public async Task RetryDeadLetter(ChannelExportOutboxDto row)
    {
        await IsBusy.SetAsync(true);
        try
        {
            await _salesChannelService.RetryDeadLetterAsync(_salesChannelId, row.Id);
            await StatusMessage.SetAsync($"Re-queued {row.Operation} ({row.AggregateId:N}).");
        }
        catch (ApiException ex)
        {
            await StatusMessage.SetAsync($"Retry failed: {ex.CombinedMessage}");
        }
        finally
        {
            await IsBusy.SetAsync(false);
        }
    }

    /// <summary>
    /// Navigate to edit sales channel page.
    /// </summary>
    public async Task EditSalesChannel()
    {
        await _navigator.NavigateDataAsync(this, new SalesChannelEditData(_salesChannelId));
    }

    /// <summary>
    /// Navigate back to sales channel list.
    /// </summary>
    public async Task GoBack()
    {
        await _navigator.NavigateBackAsync(this);
    }

    private async Task RunAsync(string label, Func<CancellationToken, Task<SalesChannelSyncResultDto?>> action)
    {
        await IsBusy.SetAsync(true);
        try
        {
            // The server enqueues the run (202 + runId) and the orchestrator picks it up within ~10s —
            // the request no longer waits for the import itself. Progress shows up in the runs/logs
            // feeds and the dashboard's sync-status tab.
            var result = await action(CancellationToken.None);
            var summary = result is null
                ? "no result"
                : result.Status == ChannelSyncRunStatus.Queued
                    ? "queued — starts within a few seconds"
                    : $"{result.Status} — processed {result.ItemsProcessed}, failed {result.ItemsFailed}";
            await StatusMessage.SetAsync($"{label}: {summary}");
        }
        catch (ApiException ex)
        {
            await StatusMessage.SetAsync($"{label} failed: {ex.CombinedMessage}");
        }
        finally
        {
            await IsBusy.SetAsync(false);
        }
    }
}

/// <summary>x:Bind visual functions for the sync-log table rows (kept static for testability).</summary>
public static class SyncLogRowVisuals
{
    /// <summary>UTC timestamp → local short date + time (e.g. "22.08.2026 10:33").</summary>
    public static string FormatTimestamp(DateTime value) =>
        value.ToLocalTime().ToString("g");
}

/// <summary>
/// Holds pagination state information for the sync-log table.
/// </summary>
public record SyncLogPaginationInfo
{
    private readonly IStringLocalizer? _localizer;

    public SyncLogPaginationInfo()
    {
    }

    /// <summary>Initial state before the first load: no counts yet, but the localizer, so the
    /// placeholder texts ("No results", count label) are localized instead of English fallbacks.</summary>
    public SyncLogPaginationInfo(IStringLocalizer localizer) => _localizer = localizer;

    public SyncLogPaginationInfo(
        int currentPage,
        int totalPages,
        int totalCount,
        int pageSize,
        bool hasPreviousPage,
        bool hasNextPage,
        IStringLocalizer localizer)
    {
        CurrentPage = currentPage;
        TotalPages = totalPages;
        TotalCount = totalCount;
        PageSize = pageSize;
        HasPreviousPage = hasPreviousPage;
        HasNextPage = hasNextPage;
        _localizer = localizer;
    }

    public int CurrentPage { get; init; }
    public int TotalPages { get; init; }
    public int TotalCount { get; init; }
    public int PageSize { get; init; }
    public bool HasPreviousPage { get; init; }
    public bool HasNextPage { get; init; }

    /// <summary>
    /// Display text for current page info (e.g., "Page 1 of 5").
    /// </summary>
    public string PageInfo
    {
        get
        {
            if (TotalPages <= 0)
            {
                return _localizer?["Pagination.NoResults"] ?? "No results";
            }

            var format = _localizer?["Pagination.PageInfo"] ?? "Page {0} of {1}";
            return string.Format(format, CurrentPage + 1, TotalPages);
        }
    }

    /// <summary>
    /// Display text for total count info (e.g., "120 log entries").
    /// </summary>
    public string CountInfo
    {
        get
        {
            if (TotalCount == 1)
            {
                return _localizer?["Pagination.SyncLogsSingular"] ?? "1 log entry";
            }

            var format = _localizer?["Pagination.SyncLogsPlural"] ?? "{0} log entries";
            return string.Format(format, TotalCount);
        }
    }
}
