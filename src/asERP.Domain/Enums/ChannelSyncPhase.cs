namespace asERP.Domain.Enums;

/// <summary>
/// Lifecycle phase of one (channel, operation) import. <see cref="Initial"/> = the first full walk of
/// the remote data set is still in progress (resumable, time-boxed chunks); <see cref="Incremental"/> =
/// the walk completed once and the operation now pulls deltas on an adaptive interval.
/// </summary>
public enum ChannelSyncPhase
{
    /// <summary>Row exists but was never initialized — the dispatcher seeds it from legacy state on first use.</summary>
    Unknown = 0,
    Initial = 1,
    Incremental = 2,
}
