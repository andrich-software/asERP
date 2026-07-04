using System.Collections.Immutable;
using System.Globalization;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Enums;
using Microsoft.Extensions.Localization;

namespace asERP.Client.Features.SalesChannelDashboards.Models;

/// <summary>
/// View-friendly projection of <see cref="SalesChannelSyncStatusDto"/> for the Sync-Status tab.
/// All strings are pre-formatted (German-localized) in <see cref="SyncStatusViewMapper"/> so the XAML
/// stays declarative — mirrors how <c>RevenueKpiData</c> / <c>RecentSalesItem</c> are shaped.
/// </summary>
public record SyncStatusViewData
{
    public bool IsEnabled { get; init; }
    public string EnabledText { get; init; } = string.Empty;
    public string IntervalText { get; init; } = string.Empty;
    public string BackfillText { get; init; } = string.Empty;

    public int DeadLetterCount { get; init; }
    public bool HasDeadLetters { get; init; }
    public string DeadLetterText { get; init; } = string.Empty;

    /// <summary>Export queue depth + oldest waiting age — the stock-push latency health signal.</summary>
    public string OutboxText { get; init; } = string.Empty;
    public bool HasOutboxBacklog { get; init; }

    /// <summary>Ledger activity (movements last 24h).</summary>
    public string StockMovementsText { get; init; } = string.Empty;

    /// <summary>"Sold without mirrored stock" alarm.</summary>
    public bool HasNegativeStock { get; init; }
    public string NegativeStockText { get; init; } = string.Empty;

    // Rendered as four fixed cards (explicit grid, mirroring the Web-Statistics tab).
    public SyncOperationCardData Products { get; init; } = new();
    public SyncOperationCardData Customers { get; init; } = new();
    public SyncOperationCardData Saless { get; init; } = new();
    public SyncOperationCardData Stock { get; init; } = new();
}

/// <summary>Status of one import operation, pre-formatted for a status card.</summary>
public record SyncOperationCardData
{
    /// <summary>"products" | "customers" | "saless" — sent to the manual-sync trigger.</summary>
    public string OperationToken { get; init; } = string.Empty;

    public string OperationName { get; init; } = string.Empty;
    public bool IsImportEnabled { get; init; }

    /// <summary>Raw status for the badge colour converter; null when there has never been a run.</summary>
    public ChannelSyncRunStatus? LastStatus { get; init; }
    public bool IsRunning { get; init; }

    public string StatusText { get; init; } = string.Empty;
    public string LastRunText { get; init; } = string.Empty;
    public string LastRunTooltip { get; init; } = string.Empty;
    public string ItemsText { get; init; } = string.Empty;
    public string DurationText { get; init; } = string.Empty;
    public string NextRunText { get; init; } = string.Empty;
    public string TriggerText { get; init; } = string.Empty;

    public bool HasError { get; init; }
    public string ErrorSummary { get; init; } = string.Empty;
}

/// <summary>One synchronization log line, pre-formatted for the log panel.</summary>
public record SyncLogLineViewData
{
    public DateTime Timestamp { get; init; }
    public string TimestampText { get; init; } = string.Empty;
    public ChannelSyncLogLevel Level { get; init; }
    public string LevelText { get; init; } = string.Empty;
    public string OperationText { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public bool HasException { get; init; }
    public string Exception { get; init; } = string.Empty;

    /// <summary>The full line as it appears when the user copies the log.</summary>
    public string RawLine { get; init; } = string.Empty;
}

/// <summary>Maps the wire DTOs to the pre-formatted view records, applying German localization.</summary>
public static class SyncStatusViewMapper
{
    public static SyncStatusViewData ToViewData(SalesChannelSyncStatusDto dto, IStringLocalizer l, DateTime nowUtc)
    {
        return new SyncStatusViewData
        {
            IsEnabled = dto.IsEnabled,
            EnabledText = dto.IsEnabled ? l["SyncStatus.Active"] : l["SyncStatus.Paused"],
            IntervalText = string.Format(Culture, l["SyncStatus.IntervalFormat"], dto.SyncIntervalSeconds),
            BackfillText = FormatBackfill(dto, l),
            DeadLetterCount = dto.DeadLetterCount,
            HasDeadLetters = dto.DeadLetterCount > 0,
            DeadLetterText = string.Format(Culture, l["SyncStatus.DeadLetterFormat"], dto.DeadLetterCount),
            OutboxText = FormatOutbox(dto, l),
            HasOutboxBacklog = dto.OutboxPendingCount + dto.OutboxInFlightCount > 0,
            StockMovementsText = string.Format(Culture, l["SyncStatus.StockMovementsFormat"], dto.StockMovementsLast24h),
            HasNegativeStock = dto.NegativeStockCount > 0,
            NegativeStockText = dto.NegativeStockCount > 0
                ? string.Format(Culture, l["SyncStatus.NegativeStockFormat"], dto.NegativeStockCount)
                : string.Empty,
            Products = ToCard(dto.Products, "products", l["SyncStatus.OpProducts"], dto.IsEnabled, nowUtc, l),
            Customers = ToCard(dto.Customers, "customers", l["SyncStatus.OpCustomers"], dto.IsEnabled, nowUtc, l),
            Saless = ToCard(dto.Saless, "saless", l["SyncStatus.OpOrders"], dto.IsEnabled, nowUtc, l),
            Stock = ToCard(dto.Stock, "stock", l["SyncStatus.OpStock"], dto.IsEnabled, nowUtc, l),
        };
    }

    private static string FormatOutbox(SalesChannelSyncStatusDto dto, IStringLocalizer l)
    {
        var backlog = dto.OutboxPendingCount + dto.OutboxInFlightCount;
        if (backlog == 0)
        {
            return l["SyncStatus.OutboxEmpty"];
        }

        var text = string.Format(Culture, l["SyncStatus.OutboxFormat"], dto.OutboxPendingCount, dto.OutboxInFlightCount);
        if (dto.OldestPendingOutboxAgeSeconds is { } age)
        {
            text += " · " + string.Format(Culture, l["SyncStatus.OutboxOldestFormat"], FormatSpan(TimeSpan.FromSeconds(age)));
        }

        return text;
    }

    public static SyncLogLineViewData ToLogLine(ChannelSyncLogDto dto, IStringLocalizer l)
    {
        var local = dto.Timestamp.ToLocalTime();
        var op = OperationName(dto.Operation, l);
        var level = LevelText(dto.Level);
        var timestamp = local.ToString("dd.MM. HH:mm:ss", Culture);

        return new SyncLogLineViewData
        {
            Timestamp = dto.Timestamp,
            TimestampText = timestamp,
            Level = dto.Level,
            LevelText = level,
            OperationText = op,
            Message = dto.Message,
            HasException = !string.IsNullOrWhiteSpace(dto.Exception),
            Exception = dto.Exception ?? string.Empty,
            RawLine = string.IsNullOrWhiteSpace(dto.Exception)
                ? $"{timestamp} [{level}] {op}: {dto.Message}"
                : $"{timestamp} [{level}] {op}: {dto.Message}\n{dto.Exception}",
        };
    }

    private static SyncOperationCardData ToCard(
        SyncOperationStatusDto op,
        string token,
        string name,
        bool channelEnabled,
        DateTime nowUtc,
        IStringLocalizer l)
    {
        var neverRun = op.LastStatus is null;

        return new SyncOperationCardData
        {
            OperationToken = token,
            OperationName = name,
            IsImportEnabled = op.IsImportEnabled,
            LastStatus = op.LastStatus,
            IsRunning = op.IsRunning,
            StatusText = StatusText(op, l),
            LastRunText = neverRun ? l["SyncStatus.NeverRun"] : FormatPast(op.LastStartedAt, nowUtc, l),
            LastRunTooltip = op.LastStartedAt?.ToLocalTime().ToString("F", Culture) ?? string.Empty,
            ItemsText = FormatItems(op, neverRun, nowUtc, l),
            DurationText = FormatDuration(op, nowUtc, l),
            NextRunText = FormatNextRun(op, channelEnabled, nowUtc, l),
            TriggerText = neverRun ? string.Empty : string.Format(Culture, l["SyncStatus.TriggerFormat"], TriggerText(op.LastTriggerSource, l)),
            HasError = !string.IsNullOrWhiteSpace(op.LastErrorSummary),
            ErrorSummary = op.LastErrorSummary ?? string.Empty,
        };
    }

    private static string StatusText(SyncOperationStatusDto op, IStringLocalizer l) => op.LastStatus switch
    {
        null => l["SyncStatus.NeverRun"],
        ChannelSyncRunStatus.Running => l["SyncStatus.Running"],
        ChannelSyncRunStatus.Queued => l["SyncStatus.Queued"],
        ChannelSyncRunStatus.Success => l["SyncStatus.Success"],
        ChannelSyncRunStatus.PartialFailure => l["SyncStatus.PartialFailure"],
        ChannelSyncRunStatus.Failed => l["SyncStatus.Failed"],
        _ => op.LastStatus.ToString() ?? string.Empty,
    };

    /// <summary>
    /// "processed / failed", extended with the remote total and percentage when the run reported one,
    /// and with a live items/s rate while a run is walking — the "is it actually moving?" signal.
    /// </summary>
    private static string FormatItems(SyncOperationStatusDto op, bool neverRun, DateTime nowUtc, IStringLocalizer l)
    {
        if (neverRun)
        {
            return "—";
        }

        var text = string.Format(Culture, l["SyncStatus.ItemsFormat"], op.LastItemsProcessed, op.LastItemsFailed);

        if (op.LastItemsTotal is { } total && total > 0)
        {
            var percent = Math.Clamp(op.LastItemsProcessed * 100.0 / total, 0, 100);
            text += string.Format(Culture, l["SyncStatus.ItemsTotalFormat"], total, percent);
        }

        var end = op.IsRunning ? nowUtc : op.LastFinishedAt;
        if (op.LastStartedAt is { } started && end is { } until && until > started)
        {
            var perSecond = op.LastItemsProcessed / Math.Max(1, (until - started).TotalSeconds);
            if (perSecond >= 0.1)
            {
                text += string.Format(Culture, l["SyncStatus.ItemsRateFormat"], perSecond);
            }
        }

        return text;
    }

    private static string FormatDuration(SyncOperationStatusDto op, DateTime nowUtc, IStringLocalizer l)
    {
        if (op.IsRunning && op.LastStartedAt is DateTime started)
        {
            return string.Format(Culture, l["SyncStatus.RunningSinceFormat"], FormatSpan(nowUtc - started));
        }

        if (op.LastStartedAt is DateTime s && op.LastFinishedAt is DateTime f && f >= s)
        {
            return string.Format(Culture, l["SyncStatus.DurationFormat"], FormatSpan(f - s));
        }

        return "—";
    }

    private static string FormatNextRun(SyncOperationStatusDto op, bool channelEnabled, DateTime nowUtc, IStringLocalizer l)
    {
        if (!op.IsImportEnabled) return l["SyncStatus.ImportOff"];
        if (!channelEnabled) return l["SyncStatus.Paused"];

        if (op.WillRunOnSchedule && op.NextRunAt is DateTime next)
        {
            return string.Format(Culture, l["SyncStatus.NextRunFormat"], FormatFuture(next, nowUtc, l));
        }

        return op.InitialImportCompleted ? l["SyncStatus.ManualOnly"] : "—";
    }

    private static string FormatBackfill(SalesChannelSyncStatusDto dto, IStringLocalizer l)
    {
        if (!dto.Saless.IsImportEnabled) return l["SyncStatus.ImportOff"];
        if (dto.InitialSalesImportCompleted) return l["SyncStatus.BackfillDone"];
        if (dto.SalesImportBackfillCursor is DateTime cursor)
        {
            return string.Format(Culture, l["SyncStatus.BackfillRunningFormat"], cursor.ToLocalTime().ToString("dd.MM.yyyy", Culture));
        }

        return l["SyncStatus.BackfillNotStarted"];
    }

    private static string FormatPast(DateTime? utc, DateTime nowUtc, IStringLocalizer l)
    {
        if (utc is not DateTime ts) return "—";
        var delta = nowUtc - ts;
        if (delta < TimeSpan.Zero) delta = TimeSpan.Zero;

        if (delta.TotalSeconds < 10) return l["SyncStatus.JustNow"];
        if (delta.TotalMinutes < 1) return string.Format(Culture, l["SyncStatus.AgoSecFormat"], (int)delta.TotalSeconds);
        if (delta.TotalHours < 1) return string.Format(Culture, l["SyncStatus.AgoMinFormat"], (int)delta.TotalMinutes);
        if (delta.TotalDays < 1) return string.Format(Culture, l["SyncStatus.AgoHourFormat"], (int)delta.TotalHours);
        return ts.ToLocalTime().ToString("dd.MM.yyyy HH:mm", Culture);
    }

    private static string FormatFuture(DateTime utc, DateTime nowUtc, IStringLocalizer l)
    {
        var delta = utc - nowUtc;
        if (delta <= TimeSpan.Zero) return l["SyncStatus.DueNow"];
        if (delta.TotalSeconds < 60) return string.Format(Culture, l["SyncStatus.InSecFormat"], (int)delta.TotalSeconds);
        if (delta.TotalHours < 1) return string.Format(Culture, l["SyncStatus.InMinFormat"], (int)delta.TotalMinutes);
        return utc.ToLocalTime().ToString("dd.MM. HH:mm", Culture);
    }

    private static string FormatSpan(TimeSpan span) =>
        span.TotalHours >= 1
            ? $"{(int)span.TotalHours:00}:{span.Minutes:00}:{span.Seconds:00}"
            : $"{span.Minutes:00}:{span.Seconds:00}";

    private static string OperationName(ChannelSyncOperation op, IStringLocalizer l) => op switch
    {
        ChannelSyncOperation.ImportProducts => l["SyncStatus.OpProducts"],
        ChannelSyncOperation.ImportCustomers => l["SyncStatus.OpCustomers"],
        ChannelSyncOperation.ImportSaless => l["SyncStatus.OpOrders"],
        ChannelSyncOperation.ImportStock => l["SyncStatus.OpStock"],
        _ => op.ToString(),
    };

    private static string LevelText(ChannelSyncLogLevel level) => level switch
    {
        ChannelSyncLogLevel.Debug => "DEBUG",
        ChannelSyncLogLevel.Information => "INFO",
        ChannelSyncLogLevel.Warning => "WARN",
        ChannelSyncLogLevel.Error => "ERROR",
        ChannelSyncLogLevel.Critical => "CRIT",
        _ => level.ToString().ToUpperInvariant(),
    };

    private static string TriggerText(ChannelSyncTriggerSource? source, IStringLocalizer l) => source switch
    {
        ChannelSyncTriggerSource.Manual => l["SyncStatus.TriggerManual"],
        ChannelSyncTriggerSource.Event => l["SyncStatus.TriggerEvent"],
        _ => l["SyncStatus.TriggerScheduler"],
    };

    private static CultureInfo Culture => CultureInfo.CurrentCulture;
}
