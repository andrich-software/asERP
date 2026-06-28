namespace asToolkit.SalesChannels.Logging;

/// <summary>
/// Bounded, thread-safe hand-off buffer for captured sync log lines. The Serilog sink enqueues on
/// arbitrary logging threads; the orchestrator's <c>SyncLogDrainer</c> drains and persists them.
/// Registered as a singleton so producer and consumer share one instance.
/// </summary>
public interface ISalesChannelSyncLogBuffer
{
    /// <summary>Adds a record. Non-blocking; silently drops (counting it) when the buffer is full.</summary>
    void Enqueue(SyncLogRecord record);

    /// <summary>Moves up to <paramref name="max"/> records into <paramref name="destination"/>; returns the count moved.</summary>
    int Drain(List<SyncLogRecord> destination, int max);

    /// <summary>Total records dropped due to overflow since startup (for diagnostics).</summary>
    long DroppedCount { get; }
}
