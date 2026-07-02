using asToolkit.Domain.Entities.Common;
using asToolkit.Domain.Enums;

namespace asToolkit.Domain.Entities;

/// <summary>
/// Audit row recorded by the orchestrator for each sync dispatch (import or export). Lets the
/// admin UI show "last X sync runs for channel Y" and supports cross-channel SLO reporting.
/// </summary>
public class ChannelSyncRun : BaseEntity, IBaseEntity
{
    public Guid SalesChannelId { get; set; }
    public SalesChannel? SalesChannel { get; set; }

    public ChannelSyncOperation Operation { get; set; }
    public ChannelSyncTriggerSource TriggerSource { get; set; }
    public ChannelSyncRunStatus Status { get; set; }

    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public int ItemsProcessed { get; set; }
    public int ItemsFailed { get; set; }

    /// <summary>
    /// Total items the run expects to process, when the remote reports it (e.g. WooCommerce's
    /// <c>X-WP-Total</c> header). Null when unknown — the dashboard then shows counts without a percentage.
    /// </summary>
    public int? ItemsTotal { get; set; }

    /// <summary>Truncated, single-line error summary. Detailed errors live in app logs.</summary>
    public string? ErrorSummary { get; set; }

    /// <summary>Correlation id used to tie related log entries together (Serilog scope).</summary>
    public Guid CorrelationId { get; set; }
}
