using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Services;

/// <summary>
/// Enqueues a return-label-creation retry. One active row per return (idempotency key
/// "return-label:{ReturnShipmentId:N}"); re-enqueueing a Done/DeadLetter row resets it to Pending.
/// </summary>
public sealed class ReturnLabelOutboxEnqueuer
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ReturnLabelOutboxEnqueuer> _logger;

    public ReturnLabelOutboxEnqueuer(ApplicationDbContext context, ILogger<ReturnLabelOutboxEnqueuer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public static string IdempotencyKeyFor(Guid returnShipmentId) => $"return-label:{returnShipmentId:N}";

    public async Task EnqueueAsync(Guid returnShipmentId, Guid shippingProviderId, Guid? tenantId, string? lastError,
        CancellationToken cancellationToken = default)
    {
        var key = IdempotencyKeyFor(returnShipmentId);

        var existing = await _context.ReturnLabelOutbox
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(o => o.ReturnShipmentId == returnShipmentId && o.IdempotencyKey == key, cancellationToken);

        if (existing is null)
        {
            _context.ReturnLabelOutbox.Add(new ReturnLabelOutbox
            {
                ReturnShipmentId = returnShipmentId,
                ShippingProviderId = shippingProviderId,
                TenantId = tenantId,
                IdempotencyKey = key,
                Status = ShippingOutboxStatus.Pending,
                AttemptCount = 0,
                NextAttemptAt = DateTime.UtcNow,
                LastError = lastError
            });
        }
        else if (existing.Status is ShippingOutboxStatus.Done or ShippingOutboxStatus.DeadLetter)
        {
            existing.Status = ShippingOutboxStatus.Pending;
            existing.AttemptCount = 0;
            existing.NextAttemptAt = DateTime.UtcNow;
            existing.LastError = lastError;
            existing.CompletedAt = null;
        }
        else
        {
            // Pending/InFlight — already queued; just record the latest error.
            existing.LastError = lastError ?? existing.LastError;
        }

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Queued return-label creation for return {ReturnShipmentId} (provider {ProviderId})",
            returnShipmentId, shippingProviderId);
    }
}
