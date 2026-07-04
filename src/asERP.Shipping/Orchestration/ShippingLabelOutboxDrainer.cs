using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.Shipping.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Orchestration;

/// <summary>
/// One drainer pass over the label-creation fallback queue: pick up to <see cref="BatchSize"/>
/// Pending rows that are due, set them InFlight, retry the label via the shared core path,
/// then mark Done or schedule the next retry with exponential backoff. After 10 failed attempts
/// (or on the first permanent failure) a row lands in <see cref="ShippingOutboxStatus.DeadLetter"/>.
/// </summary>
public sealed class ShippingLabelOutboxDrainer
{
    private const int BatchSize = 100;
    private const int MaxAttempts = 10;

    private readonly ApplicationDbContext _context;
    private readonly ShippingCarrierService _carrierService;
    private readonly ILogger<ShippingLabelOutboxDrainer> _logger;

    public ShippingLabelOutboxDrainer(
        ApplicationDbContext context,
        ShippingCarrierService carrierService,
        ILogger<ShippingLabelOutboxDrainer> logger)
    {
        _context = context;
        _carrierService = carrierService;
        _logger = logger;
    }

    public async Task<int> DrainOnceAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var due = await _context.ShippingLabelOutbox
            .IgnoreQueryFilters()
            .Where(o => o.Status == ShippingOutboxStatus.Pending && o.NextAttemptAt <= now)
            .OrderBy(o => o.NextAttemptAt)
            .Take(BatchSize)
            .ToListAsync(cancellationToken);

        if (due.Count == 0)
        {
            return 0;
        }

        var processed = 0;

        foreach (var outbox in due)
        {
            cancellationToken.ThrowIfCancellationRequested();

            outbox.Status = ShippingOutboxStatus.InFlight;
            outbox.AttemptCount++;
            await _context.SaveChangesAsync(cancellationToken);

            var (result, _) = await _carrierService.TryCreateLabelCoreAsync(outbox.ShippingId, cancellationToken);

            if (result.Success)
            {
                outbox.Status = ShippingOutboxStatus.Done;
                outbox.CompletedAt = DateTime.UtcNow;
                outbox.LastError = null;
            }
            else
            {
                var error = result.ErrorMessage ?? "unknown";
                outbox.LastError = error.Length > 2000 ? error[..2000] : error;

                if (result.IsPermanentFailure || outbox.AttemptCount >= MaxAttempts)
                {
                    outbox.Status = ShippingOutboxStatus.DeadLetter;
                    _logger.LogWarning(
                        "Label outbox row {Id} for shipping {ShippingId} moved to DeadLetter ({Reason}): {Error}",
                        outbox.Id, outbox.ShippingId,
                        result.IsPermanentFailure ? "permanent failure" : "max attempts reached", error);
                }
                else
                {
                    outbox.Status = ShippingOutboxStatus.Pending;
                    outbox.NextAttemptAt = ScheduleRetry(outbox.AttemptCount);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            processed++;
        }

        return processed;
    }

    private static DateTime ScheduleRetry(int attemptCount)
    {
        // Exponential backoff capped at 1h: 30s, 60s, 120s, 240s, ..., max 3600s.
        var seconds = Math.Min(3600d, 30d * Math.Pow(2, attemptCount - 1));
        return DateTime.UtcNow.AddSeconds(seconds);
    }
}
