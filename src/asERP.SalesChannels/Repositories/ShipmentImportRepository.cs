using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using asERP.SalesChannels.Contracts;
using asERP.SalesChannels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.SalesChannels.Repositories;

/// <summary>
/// Writes the tracking numbers a shop reported into local <see cref="Shipping"/> rows.
/// <para>
/// Import-only semantics: an imported shipment documents what the shop did. It carries no label and
/// no carrier shipment id, so it can never be cancelled or re-printed locally — only its carrier
/// status can still be polled, and only when the mapped provider is configured and enabled.
/// </para>
/// </summary>
public class ShipmentImportRepository : IShipmentImportRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ShipmentImportRepository> _logger;

    public ShipmentImportRepository(ApplicationDbContext dbContext, ILogger<ShipmentImportRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<ShipmentImportOutcome> ImportShipmentsAsync(
        SalesChannel salesChannel,
        IReadOnlyList<SalesChannelImportShipment> shipments,
        CancellationToken cancellationToken = default)
    {
        var candidates = shipments
            .Where(s => !string.IsNullOrWhiteSpace(s.TrackingNumber) && !string.IsNullOrWhiteSpace(s.RemoteSalesId))
            .ToList();

        if (candidates.Count == 0)
        {
            return new ShipmentImportOutcome(0, shipments.Count, [], []);
        }

        // Background scopes carry no ambient tenant (see asERP.Shipping/CLAUDE.md) — every query here
        // is addressed by the channel and therefore ignores the global filter deliberately.
        var carrierMappings = await _dbContext.SalesChannelCarrierMapping
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(m => m.SalesChannelId == salesChannel.Id)
            .Select(m => new { m.RemoteCarrierCode, m.ShippingProviderId })
            .ToListAsync(cancellationToken);

        var providerByCode = carrierMappings
            .GroupBy(m => NormalizeCode(m.RemoteCarrierCode))
            .ToDictionary(g => g.Key, g => g.First().ShippingProviderId, StringComparer.Ordinal);

        var remoteSalesIds = candidates.Select(c => c.RemoteSalesId).Distinct().ToList();

        var sales = await _dbContext.Sales
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(o => o.SalesChannelId == salesChannel.Id && remoteSalesIds.Contains(o.RemoteSalesId))
            .Select(o => new { o.Id, o.RemoteSalesId, o.TenantId })
            .ToListAsync(cancellationToken);

        var salesByRemoteId = sales
            .GroupBy(o => o.RemoteSalesId)
            .ToDictionary(g => g.Key, g => g.First(), StringComparer.Ordinal);

        var salesIds = sales.Select(o => o.Id).ToList();

        // One query for the whole batch instead of an existence check per shipment. The tracking
        // number is the natural key: re-importing an order must not duplicate its parcels.
        var existingTracking = await _dbContext.Shipping
            .IgnoreQueryFilters()
            .AsNoTracking()
            .Where(s => salesIds.Contains(s.SalesId))
            .Select(s => new { s.SalesId, s.TrackingNumber })
            .ToListAsync(cancellationToken);

        var known = new HashSet<(Guid SalesId, string Tracking)>(
            existingTracking.Select(e => (e.SalesId, e.TrackingNumber.Trim())));

        var unmappedCarriers = new HashSet<string>(StringComparer.Ordinal);
        var unknownSales = new HashSet<string>(StringComparer.Ordinal);
        var created = 0;
        var skipped = shipments.Count - candidates.Count;

        foreach (var shipment in candidates)
        {
            if (!salesByRemoteId.TryGetValue(shipment.RemoteSalesId, out var order))
            {
                // The order import runs on its own cadence; a shipment for a not-yet-imported order
                // is picked up by a later run rather than being an error.
                unknownSales.Add(shipment.RemoteSalesId);
                skipped++;
                continue;
            }

            var trackingNumber = shipment.TrackingNumber.Trim();
            if (!known.Add((order.Id, trackingNumber)))
            {
                skipped++;
                continue;
            }

            var code = NormalizeCode(shipment.RemoteCarrierCode);
            if (!providerByCode.TryGetValue(code, out var providerId))
            {
                // Shipping.ShippingProviderId is not nullable and guessing a carrier would attach the
                // parcel to the wrong one — skip and report the code so the operator can map it.
                unmappedCarriers.Add(code);
                known.Remove((order.Id, trackingNumber));
                skipped++;
                continue;
            }

            _dbContext.Shipping.Add(new Shipping
            {
                Id = Guid.NewGuid(),
                TenantId = order.TenantId,
                SalesId = order.Id,
                ShippingProviderId = providerId,
                Status = ShippingStatus.Shipped,
                TrackingNumber = trackingNumber,
                ShippedAt = shipment.ShippedAt,
            });
            created++;
        }

        if (created > 0)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        if (unmappedCarriers.Count > 0)
        {
            _logger.LogWarning(
                "Channel {Channel}: {Count} shipment(s) skipped — no carrier mapping for {Codes}",
                salesChannel.Name, unmappedCarriers.Count, string.Join(", ", unmappedCarriers));
        }

        return new ShipmentImportOutcome(created, skipped, unmappedCarriers, unknownSales);
    }

    private static string NormalizeCode(string? code)
        => (code ?? string.Empty).Trim().ToLowerInvariant();
}
