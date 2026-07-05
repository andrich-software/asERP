using System.Collections.Concurrent;

namespace asERP.SalesChannels.Repositories;

/// <summary>
/// Process-wide allocator for the human-facing per-tenant sequence numbers (CustomerId, SalesId) handed
/// out during imports. Each import run used to seed its own MAX+1 counter — safe only while all imports
/// of a channel ran strictly sequentially. Now that a channel's sales and customer imports run
/// concurrently (each on its own DbContext), two run-local counters would seed from the same MAX and
/// hand out identical ids. A single shared counter per (tenant, kind) — seeded from the DB once, then
/// advanced under a per-counter lock — makes allocations unique across all concurrent runs in this
/// process. Single-process deployment (one server container) is a stated assumption of the orchestrator.
///
/// The counter alone still diverges from the manual API creation path (which does a fresh <c>MAX+1</c>
/// per insert): if a user manually creates a customer/sale after the counter was seeded, the DB overtakes
/// the in-memory counter and the next import would hand out an already-used number (unique-constraint
/// failure). To stay collision-safe, every allocation re-reads the current DB max and returns
/// <c>MAX(counter, dbMax) + 1</c>, folding any external inserts back into the counter. The DB read is the
/// same query the manual path already performs, so this converges the two paths rather than adding cost
/// on top of a cheaper design.
/// </summary>
public sealed class ImportIdAllocator
{
    private sealed class Counter
    {
        public int Value;
        public readonly SemaphoreSlim Gate = new(1, 1);
    }

    private readonly ConcurrentDictionary<(Guid? TenantId, string Kind), Counter> _counters = new();

    /// <summary>
    /// Returns the next id for the given tenant/kind as <c>MAX(in-memory counter, DB max) + 1</c>.
    /// <paramref name="currentMaxAsync"/> supplies the current DB maximum (the same query the manual
    /// creation path uses); folding it in on every call keeps the counter from ever handing out a number
    /// a concurrent manual insert already claimed. Allocations for one (tenant, kind) are serialized by a
    /// per-counter gate so the read-max-then-advance step is atomic.
    /// </summary>
    public async Task<int> NextAsync(Guid? tenantId, string kind, Func<Task<int>> currentMaxAsync)
    {
        var counter = _counters.GetOrAdd((tenantId, kind), _ => new Counter());

        await counter.Gate.WaitAsync();
        try
        {
            var dbMax = await currentMaxAsync();
            var next = Math.Max(counter.Value, dbMax) + 1;
            counter.Value = next;
            return next;
        }
        finally
        {
            counter.Gate.Release();
        }
    }

    public const string CustomerKind = "customer";
    public const string SalesKind = "sales";
}
