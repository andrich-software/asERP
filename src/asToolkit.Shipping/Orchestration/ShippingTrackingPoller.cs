using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Enums;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.Shipping.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.Shipping.Orchestration;

/// <summary>
/// One polling pass: for every enabled provider, fetch the tracking status of its active
/// (non-terminal, tracked) shipments whose <c>LastTrackedAt</c> is older than the provider's
/// poll interval, and apply status changes through the shared status updater.
/// </summary>
public sealed class ShippingTrackingPoller
{
    /// <summary>Statuses the poller keeps watching. Terminal and pre-label states are never polled.</summary>
    internal static readonly ShippingStatus[] ActiveStatuses =
    [
        ShippingStatus.LabelCreated,
        ShippingStatus.Shipped,
        ShippingStatus.InTransit,
        ShippingStatus.OutForDelivery,
        ShippingStatus.DeliveryFailed
    ];

    private const int MaxShipmentsPerProviderPerPass = 50;
    private static readonly TimeSpan StaleShipmentWarningAge = TimeSpan.FromDays(60);

    private readonly ApplicationDbContext _context;
    private readonly IShippingCarrierConnectorRegistry _registry;
    private readonly ShippingCarrierContextFactory _contextFactory;
    private readonly IShippingStatusUpdater _statusUpdater;
    private readonly ITenantContext _tenantContext;
    private readonly ILogger<ShippingTrackingPoller> _logger;

    public ShippingTrackingPoller(
        ApplicationDbContext context,
        IShippingCarrierConnectorRegistry registry,
        ShippingCarrierContextFactory contextFactory,
        IShippingStatusUpdater statusUpdater,
        ITenantContext tenantContext,
        ILogger<ShippingTrackingPoller> logger)
    {
        _context = context;
        _registry = registry;
        _contextFactory = contextFactory;
        _statusUpdater = statusUpdater;
        _tenantContext = tenantContext;
        _logger = logger;
    }

    public async Task<int> PollOnceAsync(CancellationToken cancellationToken)
    {
        var providers = await _context.ShippingProvider
            .IgnoreQueryFilters()
            .Where(p => p.IsEnabled)
            .ToListAsync(cancellationToken);

        var polled = 0;

        foreach (var provider in providers)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var connector = _registry.Resolve(provider.Type);
            if (connector is null)
            {
                continue;
            }

            // Time gating happens in memory — DateDiff functions are provider-specific SQL.
            var candidates = await _context.Shipping
                .IgnoreQueryFilters()
                .Where(s => s.ShippingProviderId == provider.Id
                            && ActiveStatuses.Contains(s.Status)
                            && s.TrackingNumber != string.Empty)
                .OrderBy(s => s.LastTrackedAt)
                .Take(200)
                .ToListAsync(cancellationToken);

            var now = DateTime.UtcNow;
            var interval = TimeSpan.FromSeconds(Math.Max(60, provider.TrackingPollIntervalSeconds));
            var due = candidates
                .Where(s => s.LastTrackedAt is null || now - s.LastTrackedAt.Value >= interval)
                .Take(MaxShipmentsPerProviderPerPass)
                .ToList();

            if (due.Count == 0)
            {
                continue;
            }

            provider.LastTrackingPollStartedAt = now;
            await _context.SaveChangesAsync(cancellationToken);

            var carrierContext = _contextFactory.Create(provider, cancellationToken);

            // Sequential per provider — natural rate limiting; Polly handles 429s.
            foreach (var shipping in due)
            {
                cancellationToken.ThrowIfCancellationRequested();

                _tenantContext.SetCurrentTenantId(shipping.TenantId);

                // Stamp every attempt (success or failure) so a broken tracking number
                // cannot hot-loop the poller.
                shipping.LastTrackedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync(cancellationToken);

                var result = await connector.GetTrackingStatusAsync(carrierContext, shipping.TrackingNumber);
                polled++;

                if (!result.Success)
                {
                    _logger.LogWarning("Tracking poll failed for shipping {ShippingId} ({Carrier}, {TrackingNumber}): {Error}",
                        shipping.Id, provider.Type, shipping.TrackingNumber, result.ErrorMessage);
                    continue;
                }

                var mapped = TrackingStatusMapper.Map(result.Status);
                if (mapped is null || !TrackingStatusMapper.IsUpgrade(shipping.Status, mapped.Value))
                {
                    if (result.StatusDescription != null)
                    {
                        shipping.LastCarrierStatusRaw = result.StatusDescription;
                        await _context.SaveChangesAsync(cancellationToken);
                    }

                    continue;
                }

                await _statusUpdater.ApplyStatusAsync(shipping.Id, mapped.Value,
                    rawCarrierStatus: result.StatusDescription,
                    eventTimeUtc: result.EventTimestampUtc,
                    isSystemGenerated: true,
                    cancellationToken: cancellationToken);

                // The status updater changed the row through its own repository — refresh our copy.
                await _context.Entry(shipping).ReloadAsync(cancellationToken);
            }

            // Surface shipments stuck non-terminal for a long time — candidates for a manual "Lost".
            var staleThreshold = now - StaleShipmentWarningAge;
            foreach (var stale in due.Where(s => s.DateCreated < staleThreshold))
            {
                _logger.LogWarning(
                    "Shipping {ShippingId} ({TrackingNumber}) has been non-terminal for over {Days} days — consider marking it Lost",
                    stale.Id, stale.TrackingNumber, StaleShipmentWarningAge.TotalDays);
            }
        }

        return polled;
    }
}
