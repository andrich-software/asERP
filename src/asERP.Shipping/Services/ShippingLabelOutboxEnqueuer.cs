using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Services;

/// <summary>
/// Enqueues a label-creation retry. One active row per shipment (idempotency key
/// "label:{ShippingId:N}"); re-enqueueing a Done/DeadLetter row resets it to Pending.
/// </summary>
public sealed class ShippingLabelOutboxEnqueuer
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ShippingLabelOutboxEnqueuer> _logger;

    public ShippingLabelOutboxEnqueuer(ApplicationDbContext context, ILogger<ShippingLabelOutboxEnqueuer> logger)
    {
        _context = context;
        _logger = logger;
    }

    public static string IdempotencyKeyFor(Guid shippingId) => $"label:{shippingId:N}";

    public async Task EnqueueAsync(Guid shippingId, Guid shippingProviderId, Guid? tenantId, string? lastError,
        CancellationToken cancellationToken = default)
    {
        var key = IdempotencyKeyFor(shippingId);

        var existing = await _context.ShippingLabelOutbox
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(o => o.ShippingId == shippingId && o.IdempotencyKey == key, cancellationToken);

        if (existing is null)
        {
            _context.ShippingLabelOutbox.Add(new ShippingLabelOutbox
            {
                ShippingId = shippingId,
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

        _logger.LogInformation("Queued label creation for shipping {ShippingId} (provider {ProviderId})",
            shippingId, shippingProviderId);
    }
}
