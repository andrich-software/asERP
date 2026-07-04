using asERP.Domain.Dtos.Shipping;

namespace asERP.Application.Contracts.Services;

/// <summary>
/// Collects the data for shipment documents (packing slip, pick list). Kept separate from the
/// PDF rendering so the aggregation is testable at DTO level and reusable by the batch-shipping
/// pick list (multiple shipment ids).
/// </summary>
public interface IShippingDocumentDataService
{
    /// <summary>Null when the shipment does not exist (tenant-filtered).</summary>
    Task<PackingSlipData?> GetPackingSlipDataAsync(Guid shippingId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Combined, location-sorted pick list over one or more shipments. Unknown ids are skipped;
    /// null when none of the given shipments exist (tenant-filtered).
    /// </summary>
    Task<PickListData?> GetPickListDataAsync(IReadOnlyCollection<Guid> shippingIds, CancellationToken cancellationToken = default);
}
