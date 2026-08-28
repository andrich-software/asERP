using asERP.Domain.Entities;
using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

public interface IShipmentImportRepository
{
    /// <summary>
    /// Creates the shipments a shop reported for its orders, skipping everything already known.
    /// Returns per-batch counters for the sync run.
    /// </summary>
    Task<ShipmentImportOutcome> ImportShipmentsAsync(
        SalesChannel salesChannel,
        IReadOnlyList<SalesChannelImportShipment> shipments,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Result of one import batch. <paramref name="UnmappedCarrierCodes"/> lists the distinct carrier
/// codes that had no mapping — surfaced in the sync log so the operator knows exactly which rows to
/// add on the channel form.
/// </summary>
public sealed record ShipmentImportOutcome(
    int Created,
    int Skipped,
    IReadOnlyCollection<string> UnmappedCarrierCodes,
    IReadOnlyCollection<string> UnknownRemoteSalesIds);
