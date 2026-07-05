using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Orchestration;

/// <summary>
/// Fan-out helper used by notification handlers: takes a domain change and enqueues one
/// ChannelExportOutbox row per (SalesChannel × aggregate) tuple that needs to know about it.
///
/// IdempotencyKey is stable per (Operation, AggregateType, AggregateId, SalesChannelId) — so
/// rapid-fire updates to the same aggregate coalesce into a single Pending row instead of
/// piling up in the queue. The drainer (PR 12) hydrates the payload from the current DB state
/// at dispatch time, so a coalesced row always carries the latest data.
/// </summary>
public sealed class ChannelExportOutboxEnqueuer
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ChannelExportOutboxEnqueuer> _logger;

    public ChannelExportOutboxEnqueuer(ApplicationDbContext context, ILogger<ChannelExportOutboxEnqueuer> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>Enqueue one outbox row per channel that should receive this change.</summary>
    public async Task EnqueueAsync(
        IReadOnlyList<Guid> salesChannelIds,
        ChannelSyncOperation operation,
        ChannelOutboxAggregateType aggregateType,
        Guid aggregateId,
        Guid? tenantId,
        CancellationToken cancellationToken = default)
    {
        if (salesChannelIds.Count == 0)
        {
            return;
        }

        var now = DateTime.UtcNow;

        foreach (var salesChannelId in salesChannelIds)
        {
            var key = BuildIdempotencyKey(operation, aggregateType, aggregateId, salesChannelId);

            var existing = await _context.ChannelExportOutbox
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(o => o.SalesChannelId == salesChannelId && o.IdempotencyKey == key, cancellationToken);

            if (existing is null)
            {
                _context.ChannelExportOutbox.Add(new ChannelExportOutbox
                {
                    Id = Guid.NewGuid(),
                    TenantId = tenantId,
                    SalesChannelId = salesChannelId,
                    Operation = operation,
                    AggregateType = aggregateType,
                    AggregateId = aggregateId,
                    PayloadJson = string.Empty, // Drainer hydrates from current DB state.
                    IdempotencyKey = key,
                    AttemptCount = 0,
                    NextAttemptAt = now,
                    Status = ChannelOutboxStatus.Pending,
                });
                continue;
            }

            switch (existing.Status)
            {
                case ChannelOutboxStatus.Pending:
                    existing.NextAttemptAt = now;
                    break;

                case ChannelOutboxStatus.InFlight:
                    // Drainer is mid-flight; it'll re-read state. Nothing to do.
                    break;

                case ChannelOutboxStatus.Done:
                case ChannelOutboxStatus.DeadLetter:
                    existing.Status = ChannelOutboxStatus.Pending;
                    existing.AttemptCount = 0;
                    existing.NextAttemptAt = now;
                    existing.LastError = null;
                    existing.CompletedAt = null;
                    break;
            }
        }

        await SaveEnqueuedAsync(operation, aggregateType, aggregateId, cancellationToken);
    }

    /// <summary>
    /// Enqueue one outbox row per channel, each carrying a captured payload snapshot. Used when the
    /// aggregate is gone by drain time (e.g. delist after a product delete), so the drainer cannot
    /// hydrate from live DB state and must use the snapshot instead.
    /// </summary>
    public async Task EnqueueWithPayloadAsync(
        ChannelSyncOperation operation,
        ChannelOutboxAggregateType aggregateType,
        Guid aggregateId,
        Guid? tenantId,
        IReadOnlyList<(Guid SalesChannelId, string PayloadJson)> perChannel,
        CancellationToken cancellationToken = default)
    {
        if (perChannel.Count == 0)
        {
            return;
        }

        var now = DateTime.UtcNow;

        foreach (var (salesChannelId, payloadJson) in perChannel)
        {
            var key = BuildIdempotencyKey(operation, aggregateType, aggregateId, salesChannelId);

            var existing = await _context.ChannelExportOutbox
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(o => o.SalesChannelId == salesChannelId && o.IdempotencyKey == key, cancellationToken);

            if (existing is null)
            {
                _context.ChannelExportOutbox.Add(new ChannelExportOutbox
                {
                    Id = Guid.NewGuid(),
                    TenantId = tenantId,
                    SalesChannelId = salesChannelId,
                    Operation = operation,
                    AggregateType = aggregateType,
                    AggregateId = aggregateId,
                    PayloadJson = payloadJson,
                    IdempotencyKey = key,
                    AttemptCount = 0,
                    NextAttemptAt = now,
                    Status = ChannelOutboxStatus.Pending,
                });
                continue;
            }

            existing.PayloadJson = payloadJson;
            existing.Status = ChannelOutboxStatus.Pending;
            existing.AttemptCount = 0;
            existing.NextAttemptAt = now;
            existing.LastError = null;
            existing.CompletedAt = null;
        }

        await SaveEnqueuedAsync(operation, aggregateType, aggregateId, cancellationToken);
    }

    /// <summary>
    /// Saves the enqueued rows, treating ONLY a unique-constraint violation on the idempotency index as a
    /// benign enqueue race (a concurrent notification path produced the same key — the existing row already
    /// carries the change). Any other <see cref="DbUpdateException"/> (FK violation, truncation, ...) is a
    /// real failure: it is logged at Warning and rethrown rather than silently dropping the export. Either
    /// way the failed <c>Added</c> rows are detached first so they do not linger in this shared scoped
    /// context and poison a later save in the same scope.
    /// </summary>
    private async Task SaveEnqueuedAsync(
        ChannelSyncOperation operation,
        ChannelOutboxAggregateType aggregateType,
        Guid aggregateId,
        CancellationToken cancellationToken)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            DetachAddedOutboxRows();

            if (IsIdempotencyRace(ex))
            {
                // Concurrent enqueue from another notification path produced the same key —
                // safe to swallow; the existing row already represents the change we wanted.
                _logger.LogDebug(ex,
                    "Outbox enqueue race for op={Op} agg={Type}:{Id} — existing row will carry the change.",
                    operation, aggregateType, aggregateId);
                return;
            }

            _logger.LogWarning(ex,
                "Outbox enqueue failed for op={Op} agg={Type}:{Id} — not an idempotency race.",
                operation, aggregateType, aggregateId);
            throw;
        }
    }

    /// <summary>
    /// Detaches the outbox rows this enqueue call added but failed to persist, so the shared scoped
    /// <see cref="ApplicationDbContext"/> is not left tracking phantom Added entries that would be
    /// re-attempted (and re-fail) on the next unrelated SaveChanges in the same scope.
    /// </summary>
    private void DetachAddedOutboxRows()
    {
        var added = _context.ChangeTracker
            .Entries<ChannelExportOutbox>()
            .Where(e => e.State == EntityState.Added)
            .ToList();

        foreach (EntityEntry<ChannelExportOutbox> entry in added)
        {
            entry.State = EntityState.Detached;
        }
    }

    // Provider-agnostic detection of a unique-constraint violation on the idempotency index. The
    // SalesChannels project does not reference the concrete provider packages (SqlException / Npgsql /
    // Sqlite), so the inner-exception message is inspected for the well-known unique-violation markers
    // of the three supported providers. This keeps a genuine FK/truncation DbUpdateException from being
    // misclassified as a benign enqueue race.
    private static bool IsIdempotencyRace(DbUpdateException ex)
    {
        for (Exception? inner = ex.InnerException; inner is not null; inner = inner.InnerException)
        {
            var message = inner.Message;
            if (string.IsNullOrEmpty(message))
            {
                continue;
            }

            // SQLite: "UNIQUE constraint failed: ChannelExportOutbox.SalesChannelId, ..."
            // PostgreSQL (Npgsql): "23505: duplicate key value violates unique constraint ..."
            // SQL Server: "Cannot insert duplicate key row ..." / error 2601/2627.
            if (message.Contains("UNIQUE constraint failed", StringComparison.OrdinalIgnoreCase)
                || message.Contains("duplicate key value violates unique constraint", StringComparison.OrdinalIgnoreCase)
                || message.Contains("Cannot insert duplicate key", StringComparison.OrdinalIgnoreCase)
                || message.Contains("Violation of UNIQUE KEY constraint", StringComparison.OrdinalIgnoreCase)
                || message.Contains("23505", StringComparison.Ordinal))
            {
                return true;
            }
        }

        return false;
    }

    public static string BuildIdempotencyKey(
        ChannelSyncOperation operation,
        ChannelOutboxAggregateType aggregateType,
        Guid aggregateId,
        Guid salesChannelId)
        => $"{(int)operation}:{(int)aggregateType}:{aggregateId:N}:{salesChannelId:N}";
}
