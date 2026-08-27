using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Orchestration;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Pure-policy tests for <see cref="SyncScheduler.ComputeNextDue"/>: failure backoff, initial-walk
/// chunk chaining, activity snap-back, idle stretching, and the channel interval acting as the floor.
/// </summary>
public class SyncSchedulerTests
{
    private static readonly DateTime Now = new(2026, 08, 27, 12, 0, 0, DateTimeKind.Utc);

    private static SalesChannelOperationState State(ChannelSyncOperation op = ChannelSyncOperation.ImportSaless) => new()
    {
        Operation = op,
        Phase = ChannelSyncPhase.Incremental,
    };

    private static ChannelSyncRun Run(ChannelSyncRunStatus status, int processed = 0) => new()
    {
        Status = status,
        ItemsProcessed = processed,
    };

    [Fact]
    public void FailedRuns_BackOffExponentially_UpToCap()
    {
        var options = new SalesChannelSyncOptions();
        var state = State();

        var first = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Failed), options, 60, false, Now);
        var second = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Failed), options, 60, false, Now);
        var third = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Failed), options, 60, false, Now);

        Assert.Equal(Now.AddSeconds(60), first);
        Assert.Equal(Now.AddSeconds(120), second);
        Assert.Equal(Now.AddSeconds(240), third);
        Assert.Equal(3, state.ConsecutiveFailures);

        state.ConsecutiveFailures = 40;   // deep failure history must clamp at the cap, not overflow
        var capped = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Failed), options, 60, false, Now);
        Assert.Equal(Now.AddSeconds(options.FailureBackoff.MaxSeconds), capped);
    }

    [Fact]
    public void SuccessfulRun_ResetsFailureCounter()
    {
        var state = State();
        state.ConsecutiveFailures = 5;

        SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Success, processed: 1), new SalesChannelSyncOptions(), 60, false, Now);

        Assert.Equal(0, state.ConsecutiveFailures);
        Assert.Equal(Now, state.LastSuccessAt);
    }

    [Fact]
    public void IncompleteInitialWalk_ChainsNextChunkAlmostImmediately()
    {
        // The pacing of an initial import is its time box: a 66k-customer walk must not wait a full
        // sync interval between its 15-minute chunks.
        var options = new SalesChannelSyncOptions();
        var next = SyncScheduler.ComputeNextDue(
            State(ChannelSyncOperation.ImportCustomers), Run(ChannelSyncRunStatus.Success, processed: 10_000),
            options, 60, initialWalkIncomplete: true, Now);

        Assert.Equal(Now.AddSeconds(options.InitialChainDelaySeconds), next);
    }

    [Fact]
    public void Activity_SnapsIntervalToEffectiveMinimum()
    {
        var options = new SalesChannelSyncOptions();   // ImportSaless min 60
        var state = State();
        state.CurrentIntervalSeconds = 600;            // previously stretched

        // Channel interval (120) is above the op-class floor (60) → it is the effective minimum.
        var next = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Success, processed: 3), options, 120, false, Now);

        Assert.Equal(120, state.CurrentIntervalSeconds);
        Assert.Equal(Now.AddSeconds(120), next);
    }

    [Fact]
    public void IdleRuns_StretchInterval_UpToMaximum()
    {
        var options = new SalesChannelSyncOptions();   // ImportSaless: min 60, max 900, factor 1.5
        var state = State();

        var first = SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Success), options, 60, false, Now);
        Assert.Equal(90, state.CurrentIntervalSeconds);          // 60 × 1.5
        Assert.Equal(Now.AddSeconds(90), first);

        SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Success), options, 60, false, Now);
        Assert.Equal(135, state.CurrentIntervalSeconds);         // 90 × 1.5

        state.CurrentIntervalSeconds = 899;
        SyncScheduler.ComputeNextDue(state, Run(ChannelSyncRunStatus.Success), options, 60, false, Now);
        Assert.Equal(900, state.CurrentIntervalSeconds);         // capped at the op-class maximum
    }
}
