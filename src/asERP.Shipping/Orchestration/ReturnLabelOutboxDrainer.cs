using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.Shipping.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Orchestration;

/// <summary>
/// One drainer pass over the return-label fallback queue — mirror of
/// <see cref="ShippingLabelOutboxDrainer"/>. Terminal returns fail permanently inside the shared
/// core path, so their rows dead-letter instead of retrying forever.
/// </summary>
public sealed class ReturnLabelOutboxDrainer
{
    private const int BatchSize = 100;
    private const int MaxAttempts = 10;

    private readonly ApplicationDbContext _context;
    private readonly ReturnCarrierService _carrierService;
    private readonly ILogger<ReturnLabelOutboxDrainer> _logger;

    public ReturnLabelOutboxDrainer(
        ApplicationDbContext context,
        ReturnCarrierService carrierService,
        ILogger<ReturnLabelOutboxDrainer> logger)
    {
        _context = context;
        _carrierService = carrierService;
        _logger = logger;
    }

    public async Task<int> DrainOnceAsync(CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var due = await _context.ReturnLabelOutbox
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

            var (result, _) = await _carrierService.TryCreateReturnLabelCoreAsync(outbox.ReturnShipmentId, cancellationToken);

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
                        "Return-label outbox row {Id} for return {ReturnShipmentId} moved to DeadLetter ({Reason}): {Error}",
                        outbox.Id, outbox.ReturnShipmentId,
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
