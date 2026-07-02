using System.Collections.Concurrent;

namespace asToolkit.SalesChannels.Repositories;

/// <summary>
/// Process-wide allocator for the human-facing per-tenant sequence numbers (CustomerId, SalesId) handed
/// out during imports. Each import run used to seed its own MAX+1 counter — safe only while all imports
/// of a channel ran strictly sequentially. Now that a channel's sales and customer imports run
/// concurrently (each on its own DbContext), two run-local counters would seed from the same MAX and
/// hand out identical ids. A single shared counter per (tenant, kind) — seeded from the DB once, then
/// advanced with <see cref="Interlocked"/> — makes allocations unique across all concurrent runs in this
/// process. Single-process deployment (one server container) is a stated assumption of the orchestrator.
/// </summary>
public sealed class ImportIdAllocator
{
    private sealed class Counter
    {
        public int Value;
    }

    private readonly ConcurrentDictionary<(Guid? TenantId, string Kind), Lazy<Task<Counter>>> _counters = new();

    /// <summary>
    /// Returns the next id for the given tenant/kind, seeding from <paramref name="currentMaxAsync"/> on
    /// first use. A failed seed is evicted so the next caller retries instead of poisoning the key forever.
    /// </summary>
    public async Task<int> NextAsync(Guid? tenantId, string kind, Func<Task<int>> currentMaxAsync)
    {
        var key = (tenantId, kind);
        var lazy = _counters.GetOrAdd(key, _ => new Lazy<Task<Counter>>(async () => new Counter
        {
            Value = await currentMaxAsync(),
        }));

        Counter counter;
        try
        {
            counter = await lazy.Value;
        }
        catch
        {
            _counters.TryRemove(key, out _);
            throw;
        }

        return Interlocked.Increment(ref counter.Value);
    }

    public const string CustomerKind = "customer";
    public const string SalesKind = "sales";
}
