using asERP.Client.Core.Models;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;

namespace asERP.Client.Features.Shippings.Services;

/// <summary>
/// Service interface for shipment-related API operations.
/// </summary>
public interface IShippingService
{
    /// <summary>
    /// Gets the tenant-wide paginated shipment list with full pagination metadata.
    /// </summary>
    /// <param name="parameters">Paging, search and sort parameters.</param>
    /// <param name="status">Optional status filter (sent as int).</param>
    /// <param name="problemsOnly">When true, only problem shipments are returned.</param>
    /// <param name="salesId">Optional filter to the shipments of a single order.</param>
    Task<PaginatedResponse<ShipmentListItemDto>> GetShippingsAsync(
        QueryParameters parameters,
        ShippingStatus? status = null,
        bool problemsOnly = false,
        Guid? salesId = null,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single shipment (incl. its tracking timeline) by ID.
    /// </summary>
    Task<ShippingDetailDto?> GetShippingAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Cancels a shipment (carrier void, item release) on the server.
    /// </summary>
    Task CancelShippingAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Re-queues the label creation of a shipment whose label-outbox row dead-lettered.
    /// </summary>
    Task RetryLabelAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Gets the order lines of a sales order that are still open for shipping.
    /// </summary>
    Task<List<ShippableSalesItemDto>> GetShippableItemsAsync(Guid salesId, CancellationToken ct = default);

    /// <summary>
    /// Gets the paginated batch-shipping candidates: orders in a shippable status with at
    /// least one line not yet assigned to a shipment.
    /// </summary>
    Task<PaginatedResponse<SalesReadyToShipListDto>> GetReadyToShipSalesAsync(
        int pageNumber, int pageSize, CancellationToken ct = default);

    /// <summary>
    /// Gets the shipping options applicable to a sales order, sorted by price ascending.
    /// An empty list with populated <see cref="ApiResponse{T}.Messages"/> explains why no
    /// option applies (e.g. destination country not resolvable).
    /// </summary>
    Task<ApiResponse<List<ApplicableShippingRateDto>>> GetShippingOptionsAsync(Guid salesId, CancellationToken ct = default);

    /// <summary>
    /// Creates a shipment for a sales order and returns the new shipment id.
    /// </summary>
    Task<Guid> CreateShippingAsync(ShippingInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Cancels a sales order (status guard and carrier voids run server-side).
    /// </summary>
    Task CancelSalesAsync(Guid salesId, CancellationToken ct = default);
}
