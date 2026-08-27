using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Orchestration;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Pins when a one-shot sweep (products/categories) counts as structurally complete, i.e. when the
/// dispatcher may flip its Initial*Completed flag: clean runs and runs with only per-item failures
/// do; an aborted walk (run-level ErrorSummary) and hard failures never do — flipping the flag on an
/// aborted partial would permanently stop the initial import halfway through the catalogue.
/// </summary>
public class StructuralCompletionTests
{
    private static ChannelSyncRun Run(ChannelSyncRunStatus status, string? errorSummary = null) => new()
    {
        Status = status,
        ErrorSummary = errorSummary,
    };

    [Fact]
    public void Success_IsComplete()
        => Assert.True(SyncDispatcher.IsStructurallyComplete(Run(ChannelSyncRunStatus.Success)));

    [Fact]
    public void PartialFailure_WithOnlyItemFailures_IsComplete()
        => Assert.True(SyncDispatcher.IsStructurallyComplete(Run(ChannelSyncRunStatus.PartialFailure)));

    [Fact]
    public void PartialFailure_FromAbortedWalk_IsNotComplete()
        => Assert.False(SyncDispatcher.IsStructurallyComplete(
            Run(ChannelSyncRunStatus.PartialFailure, "connection reset mid-catalogue")));

    [Fact]
    public void Failed_IsNotComplete()
        => Assert.False(SyncDispatcher.IsStructurallyComplete(
            Run(ChannelSyncRunStatus.Failed, "boom")));

    [Fact]
    public void RunningAndQueued_AreNotComplete()
    {
        Assert.False(SyncDispatcher.IsStructurallyComplete(Run(ChannelSyncRunStatus.Running)));
        Assert.False(SyncDispatcher.IsStructurallyComplete(Run(ChannelSyncRunStatus.Queued)));
    }
}
