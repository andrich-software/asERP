using System.Collections.Immutable;
using System.Globalization;
using asToolkit.Domain.Dtos.SalesChannel;
using asToolkit.Domain.Enums;
using Microsoft.Extensions.Localization;

namespace asToolkit.Client.Features.SalesChannelDashboards.Models;

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

    /// <summary>Products, Customers, Orders — rendered as cards.</summary>
    public IImmutableList<SyncOperationCardData> Operations { get; init; } = ImmutableList<SyncOperationCardData>.Empty;
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
        var operations = ImmutableList.Create(
            ToCard(dto.Products, "products", l["SyncStatus.OpProducts"], dto.IsEnabled, nowUtc, l),
            ToCard(dto.Customers, "customers", l["SyncStatus.OpCustomers"], dto.IsEnabled, nowUtc, l),
            ToCard(dto.Saless, "saless", l["SyncStatus.OpOrders"], dto.IsEnabled, nowUtc, l, ordersDto: dto));

        return new SyncStatusViewData
        {
            IsEnabled = dto.IsEnabled,
            EnabledText = dto.IsEnabled ? l["SyncStatus.Active"] : l["SyncStatus.Paused"],
            IntervalText = string.Format(Culture, l["SyncStatus.IntervalFormat"], dto.SyncIntervalSeconds),
            BackfillText = FormatBackfill(dto, l),
            DeadLetterCount = dto.DeadLetterCount,
            HasDeadLetters = dto.DeadLetterCount > 0,
            DeadLetterText = string.Format(Culture, l["SyncStatus.DeadLetterFormat"], dto.DeadLetterCount),
            Operations = operations,
        };
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
        IStringLocalizer l,
        SalesChannelSyncStatusDto? ordersDto = null)
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
            ItemsText = neverRun
                ? "—"
                : string.Format(Culture, l["SyncStatus.ItemsFormat"], op.LastItemsProcessed, op.LastItemsFailed),
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
        ChannelSyncRunStatus.Success => l["SyncStatus.Success"],
        ChannelSyncRunStatus.PartialFailure => l["SyncStatus.PartialFailure"],
        ChannelSyncRunStatus.Failed => l["SyncStatus.Failed"],
        _ => op.LastStatus.ToString() ?? string.Empty,
    };

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
