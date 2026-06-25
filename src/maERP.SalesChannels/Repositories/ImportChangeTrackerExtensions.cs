using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace maERP.SalesChannels.Repositories;

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
}
