using System.Collections.Concurrent;
using System.Threading;

namespace asERP.SalesChannels.Logging;

/// <inheritdoc />
public sealed class SalesChannelSyncLogBuffer : ISalesChannelSyncLogBuffer
{
    // Cap protects memory if the drainer falls behind or stalls. Sync volume is low, so 10k is ample;
    // anything beyond that is dropped (and counted) rather than risking unbounded growth.
    private const int Capacity = 10_000;

    private readonly ConcurrentQueue<SyncLogRecord> _queue = new();
    private int _count;
    private long _dropped;

    public long DroppedCount => Interlocked.Read(ref _dropped);

    public void Enqueue(SyncLogRecord record)
    {
        if (Interlocked.Increment(ref _count) > Capacity)
        {
            Interlocked.Decrement(ref _count);
            Interlocked.Increment(ref _dropped);
            return;
        }

        _queue.Enqueue(record);
    }

    public int Drain(List<SyncLogRecord> destination, int max)
    {
        var moved = 0;
        while (moved < max && _queue.TryDequeue(out var record))
        {
            Interlocked.Decrement(ref _count);
            destination.Add(record);
            moved++;
        }

        return moved;
    }
}
