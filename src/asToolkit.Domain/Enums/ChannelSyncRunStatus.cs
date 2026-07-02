namespace asToolkit.Domain.Enums;

public enum ChannelSyncRunStatus
{
    Running = 0,
    Success = 1,
    PartialFailure = 2,
    Failed = 3,

    /// <summary>
    /// Created by a manual trigger and waiting for the orchestrator to pick it up. Queued rows form a
    /// durable work queue: they survive restarts and are dispatched oldest-first on the next tick.
    /// </summary>
    Queued = 4,
}
