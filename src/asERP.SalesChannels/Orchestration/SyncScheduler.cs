using asERP.Domain.Entities;
using asERP.Domain.Enums;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Pure scheduling policy: given a finished run, mutates the operation-state's adaptive fields
/// (interval, failure count) and returns the next due time. No I/O, fully unit-testable — the
/// dispatcher persists whatever this computes.
/// </summary>
internal static class SyncScheduler
{
    /// <summary>
    /// Computes when the operation should run next.
    /// Policy, in order:
    /// 1. Failed or aborted run (a PartialFailure carrying a run-level ErrorSummary aborted mid-walk)
    ///    → exponential backoff (base · 2^(failures-1), capped) so a broken shop is not hammered
    ///    every few seconds; the counter resets on the next clean run.
    /// 2. Initial walk still incomplete (a clean time-boxed chunk ended mid-walk) → chain the next
    ///    chunk almost immediately: the pacing of an initial import is its time box, not the interval.
    /// 3. Incremental with activity → snap to the effective minimum interval
    ///    (max of the operation-class floor and the channel's own SyncIntervalSeconds).
    /// 4. Incremental and idle → stretch the current interval by the idle factor, up to the maximum.
    /// </summary>
    public static DateTime ComputeNextDue(
        SalesChannelOperationState state,
        ChannelSyncRun run,
        SalesChannelSyncOptions options,
        int channelIntervalSeconds,
        bool initialWalkIncomplete,
        DateTime now)
    {
        var opClass = options.For(state.Operation);
        var effectiveMin = Math.Max(opClass.MinIntervalSeconds, Math.Max(1, channelIntervalSeconds));

        // An abort (page fetch died, connection dropped) carries the exception as the run-level
        // ErrorSummary regardless of how many items landed first. Chaining an aborted initial chunk
        // at the 5s cadence would hammer a persistently failing shop — aborts back off like failures.
        var aborted = !string.IsNullOrEmpty(run.ErrorSummary);
        if (run.Status == ChannelSyncRunStatus.Failed || aborted)
        {
            state.ConsecutiveFailures++;
            var backoff = ComputeBackoffSeconds(state.ConsecutiveFailures, options.FailureBackoff);
            // Keep the current interval untouched — one outage must not erase the adaptive state.
            return now.AddSeconds(backoff);
        }

        state.ConsecutiveFailures = 0;

        if (run.Status == ChannelSyncRunStatus.Success)
        {
            state.LastSuccessAt = now;
        }

        // Chain only fully clean chunks. A PartialFailure with item failures may sit on a frozen
        // cursor (the sales backfill deliberately freezes on a failed order) — chaining it at the
        // 5s cadence would re-walk the same page in a tight loop; the adaptive interval below gives
        // those a moderate retry pace instead.
        if (initialWalkIncomplete && run.Status == ChannelSyncRunStatus.Success)
        {
            return now.AddSeconds(options.InitialChainDelaySeconds);
        }

        if (run.ItemsProcessed > 0)
        {
            state.CurrentIntervalSeconds = effectiveMin;
        }
        else
        {
            var current = state.CurrentIntervalSeconds > 0 ? state.CurrentIntervalSeconds : effectiveMin;
            var stretched = (int)Math.Min(
                opClass.MaxIntervalSeconds,
                Math.Max(effectiveMin, current * opClass.IdleStretchFactor));
            state.CurrentIntervalSeconds = stretched;
        }

        return now.AddSeconds(state.CurrentIntervalSeconds);
    }

    internal static int ComputeBackoffSeconds(int consecutiveFailures, FailureBackoffOptions backoff)
    {
        var exponent = Math.Clamp(consecutiveFailures - 1, 0, 10);
        var delay = (long)backoff.BaseSeconds << exponent;
        return (int)Math.Min(backoff.MaxSeconds, delay);
    }
}
