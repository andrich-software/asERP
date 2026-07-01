using asToolkit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace asToolkit.SalesChannels.Repositories;

/// <summary>
/// Helpers for keeping the sync run's shared, scoped <see cref="DbContext"/> consistent when a single
/// item import fails. Every import repository in a run reuses one context, so a failed SaveChanges leaves
/// half-applied Added/Modified entries in the change tracker that are re-flushed (and re-fail) on the next
/// item — turning one bad row into a run-wide cascade. Reverting just the pending changes after a failure
/// isolates it to the offending item without disturbing rows already committed earlier in the run.
/// </summary>
internal static class ImportChangeTrackerExtensions
{
    /// <summary>
    /// Rolls the change tracker back to the last persisted state: Added entries are detached, Modified and
    /// Deleted entries are reset to their original database values and marked Unchanged. Entries that are
    /// already Unchanged (work committed by an earlier SaveChanges in this run, e.g. an on-the-fly TaxClass,
    /// or the dispatcher's run row it closes at the end) are deliberately left tracked.
    /// </summary>
    public static void DiscardPendingChanges(this DbContext context)
    {
        // Detaching an Added principal while its Added dependents are still tracked severs a required
        // relationship; with the default Immediate timing EF runs the fixup right away and throws
        // ("The association ... has been severed ...") before the loop reaches those dependents — e.g. a
        // new Product detached ahead of its ProductVariantOption rows. Defer the fixup so the whole
        // Added graph can be detached entry-by-entry regardless of iteration order; we never SaveChanges
        // here, so the deferred cascade never has to run. Restored afterwards to leave the shared
        // context's timing as we found it.
        var cascadeDeleteTiming = context.ChangeTracker.CascadeDeleteTiming;
        var deleteOrphansTiming = context.ChangeTracker.DeleteOrphansTiming;
        context.ChangeTracker.CascadeDeleteTiming = CascadeTiming.Never;
        context.ChangeTracker.DeleteOrphansTiming = CascadeTiming.Never;

        try
        {
            foreach (var entry in context.ChangeTracker.Entries().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
        finally
        {
            context.ChangeTracker.CascadeDeleteTiming = cascadeDeleteTiming;
            context.ChangeTracker.DeleteOrphansTiming = deleteOrphansTiming;
        }
    }

    /// <summary>
    /// Detaches all committed (Unchanged) entries after an item's SaveChanges so the tracker stays small
    /// over a long import run. Without this, every imported order/customer/product graph stays tracked and
    /// DetectChanges scans an ever-growing set — per-item cost rises linearly until a 15-minute run spends
    /// most of its time in change tracking. The dispatcher's <see cref="ChannelSyncRun"/> row and the
    /// <see cref="SalesChannel"/> entity are exempt: both carry mid-run state (progress counts, backfill
    /// cursors) that later SaveChanges calls in the same run must still flush. Pending (Added/Modified/
    /// Deleted) entries are left alone — trimming runs on the success path where none should exist, and a
    /// dirty channel cursor between checkpoints must survive.
    /// </summary>
    public static void TrimCommittedEntries(this DbContext context)
    {
        // Same deferred-fixup guard as DiscardPendingChanges: detaching a principal while its dependents
        // are still tracked must not trigger an immediate severed-relationship cascade mid-loop.
        var cascadeDeleteTiming = context.ChangeTracker.CascadeDeleteTiming;
        var deleteOrphansTiming = context.ChangeTracker.DeleteOrphansTiming;
        context.ChangeTracker.CascadeDeleteTiming = CascadeTiming.Never;
        context.ChangeTracker.DeleteOrphansTiming = CascadeTiming.Never;

        try
        {
            foreach (var entry in context.ChangeTracker.Entries().ToList())
            {
                if (entry.State != EntityState.Unchanged)
                {
                    continue;
                }

                if (entry.Entity is ChannelSyncRun or SalesChannel)
                {
                    continue;
                }

                entry.State = EntityState.Detached;
            }
        }
        finally
        {
            context.ChangeTracker.CascadeDeleteTiming = cascadeDeleteTiming;
            context.ChangeTracker.DeleteOrphansTiming = deleteOrphansTiming;
        }
    }
}