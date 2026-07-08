using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Per-channel synchronization bookkeeping: import cursors, initial-import completion flags and the last
/// poll time. Deliberately split off <see cref="SalesChannel"/> into its own 1:1 row.
///
/// <para>
/// <see cref="SalesChannel"/> carries an optimistic-concurrency token (<see cref="IConcurrencyStamped"/>)
/// to protect user-facing admin edits from lost updates. The sync machinery, however, writes these
/// progress columns from several operations of the SAME channel that run concurrently on separate
/// DbContexts (e.g. the order backfill advances <see cref="SalesImportBackfillCursor"/> while the customer
/// import advances <see cref="CustomerImportPageCursor"/>). A concurrency token guards the whole row, so
/// those independent per-column updates collided on the channel's token and surfaced as spurious
/// <c>DbUpdateConcurrencyException</c>s that failed otherwise-valid backfill orders. Holding the volatile
/// columns on this token-free entity gives them last-writer-wins-per-column semantics, which is exactly
/// what independent progress bookkeeping wants.
/// </para>
/// </summary>
public class SalesChannelSyncState : BaseEntity, IBaseEntity
{
    /// <summary>Owning channel (1:1). Unique FK; cascade-deleted with the channel.</summary>
    public Guid SalesChannelId { get; set; }

    public SalesChannel SalesChannel { get; set; } = null!;

    public bool InitialProductImportCompleted { get; set; }

    public bool InitialProductExportCompleted { get; set; }

    public bool InitialCustomerImportCompleted { get; set; }

    /// <summary>
    /// True once the resumable, oldest-first order backfill has walked the whole remote history. Until then,
    /// scheduled sales imports run in backfill mode; afterwards they switch to the lighter incremental
    /// (modified_after) mode. Clear this to force a fresh full backfill.
    /// </summary>
    public bool InitialSalesImportCompleted { get; set; }

    /// <summary>
    /// Resume point for the order backfill: the UTC <c>date_created</c> of the furthest order imported so far.
    /// The next backfill run continues from here (WooCommerce <c>after=</c>) instead of restarting, so an
    /// interrupted sweep never loses ground. Null means "start from the beginning of history".
    /// </summary>
    public DateTime? SalesImportBackfillCursor { get; set; }

    /// <summary>
    /// Resume point for the customer import: the last fully imported page (1-based, id-ordered). A time-boxed
    /// run persists its progress here so the next run continues from the following page instead of re-walking
    /// from the start. Reset to 0 once the whole customer base is in (and <see cref="InitialCustomerImportCompleted"/>
    /// flips). 0 means "start from the first page".
    /// </summary>
    public int CustomerImportPageCursor { get; set; }

    /// <summary>UTC time of the last sync attempt — orchestrator schedules the next dispatch from this.</summary>
    public DateTime? LastSyncStartedAt { get; set; }
}
