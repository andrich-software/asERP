using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Sales.Queries.SalesDetail;

/// <summary>
/// Handler for processing sales detail queries.
/// Implements IRequestHandler from MediatR to handle SalesDetailQuery requests
/// and return detailed sales information wrapped in a Result.
/// </summary>
public class SalesDetailHandler : IRequestHandler<SalesDetailQuery, Result<SalesDetailDto>>
{
    /// <summary>
    /// Logger for recording handler operations
    /// </summary>
    private readonly IAppLogger<SalesDetailHandler> _logger;

    /// <summary>
    /// Repository for sales data operations
    /// </summary>
    private readonly ISalesRepository _salesRepository;

    /// <summary>
    /// Repository for the shipments of the sales order
    /// </summary>
    private readonly IShippingRepository _shippingRepository;

    /// <summary>
    /// Repository for the customer returns of the sales order
    /// </summary>
    private readonly IReturnShipmentRepository _returnShipmentRepository;

    /// <summary>
    /// Repository for the images of the ordered products
    /// </summary>
    private readonly IProductImageRepository _productImageRepository;

    /// <summary>
    /// Constructor that initializes the handler with required dependencies
    /// </summary>
    /// <param name="logger">Logger for recording operations</param>
    /// <param name="salesRepository">Repository for sales data access</param>
    /// <param name="shippingRepository">Repository for shipment data access</param>
    /// <param name="returnShipmentRepository">Repository for return shipment data access</param>
    /// <param name="productImageRepository">Repository for product image data access</param>
    public SalesDetailHandler(
        IAppLogger<SalesDetailHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IReturnShipmentRepository returnShipmentRepository,
        IProductImageRepository productImageRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _productImageRepository = productImageRepository ?? throw new ArgumentNullException(nameof(productImageRepository));
    }

    /// <summary>
    /// Handles the sales detail query request
    /// </summary>
    /// <param name="request">The query containing the sales ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result containing detailed sales information if successful</returns>
    public async Task<Result<SalesDetailDto>> Handle(SalesDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving sales details for ID: {Id}", request.Id);

        var result = new Result<SalesDetailDto>();

        try
        {
            // Retrieve sales with all related details from the repository
            var sales = await _salesRepository.GetWithDetailsAsync(request.Id);

            // If sales not found, return a not found result
            if (sales == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.NotFound;
                result.Messages.Add($"Sales with ID {request.Id} not found");

                _logger.LogWarning("Sales with ID {Id} not found", request.Id);
                return result;
            }

            // Retrieve the order history.
            var salesHistory = await _salesRepository.GetSalesHistoryAsync(request.Id);

            var shippings = await _shippingRepository.GetBySalesIdAsync(sales.Id);
            // Legacy single-shipment fields are fed from the newest non-cancelled shipment.
            var latestShipping = shippings.FirstOrDefault(s => s.Status != ShippingStatus.Cancelled);

            var returns = await _returnShipmentRepository.GetBySalesIdAsync(sales.Id);

            var primaryImageByProduct = await GetPrimaryImagesAsync(sales.SalesItems, cancellationToken);

            // Manual mapping from entity to DTO
            var data = new SalesDetailDto
            {
                Id = sales.Id,
                SalesId = sales.SalesId,
                SalesChannelId = sales.SalesChannelId,
                RemoteSalesId = sales.RemoteSalesId,
                CustomerId = sales.Customer.CustomerId,
                CustomerGuid = sales.Customer.Id,
                Status = sales.Status,
                SalesItems = sales.SalesItems.Select(i => new SalesItemDto
                {
                    Id = i.Id,
                    SalesId = i.SalesId,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Name = i.Name,
                    Price = i.Price,
                    TaxRate = i.TaxRate,
                    MissingProductSku = i.MissingProductSku,
                    MissingProductEan = i.MissingProductEan,
                    ShippingId = i.ShippingId,
                    PrimaryImageId = primaryImageByProduct.TryGetValue(i.ProductId, out var imageId) ? imageId : null
                }).ToList(),
                SalesHistory = MapSalesHistoryToDto(salesHistory),
                PaymentMethod = sales.PaymentMethod,
                PaymentStatus = sales.PaymentStatus,
                PaymentProvider = sales.PaymentProvider,
                PaymentTransactionId = sales.PaymentTransactionId,
                ShippingMethod = latestShipping?.ShippingProviderRate?.Name ?? string.Empty,
                ShippingStatus = latestShipping?.Status.ToString() ?? string.Empty,
                ShippingProvider = latestShipping?.ShippingProvider.Name ?? string.Empty,
                ShippingTrackingId = latestShipping?.TrackingNumber ?? string.Empty,
                Shippings = shippings.Select(s => new ShippingListDto
                {
                    Id = s.Id,
                    SalesId = s.SalesId,
                    ProviderName = s.ShippingProvider.Name,
                    RateName = s.ShippingProviderRate?.Name ?? string.Empty,
                    Status = s.Status,
                    TrackingNumber = s.TrackingNumber,
                    TrackingUrl = s.TrackingUrl,
                    ShippingCost = s.ShippingCost,
                    HasLabel = s.LabelData != null && s.LabelData.Length > 0,
                    ShippedAt = s.ShippedAt,
                    DeliveredAt = s.DeliveredAt,
                    DateCreated = s.DateCreated
                }).ToList(),
                Returns = returns.Select(r => new ReturnShipmentListItemDto
                {
                    Id = r.Id,
                    SalesId = r.SalesId,
                    SalesNumber = sales.SalesId,
                    Status = r.Status,
                    TrackingNumber = r.TrackingNumber,
                    TrackingUrl = r.TrackingUrl,
                    ItemCount = r.Items.Count,
                    HasLabel = r.LabelData != null && r.LabelData.Length > 0,
                    ReceivedAt = r.ReceivedAt,
                    DateCreated = r.DateCreated
                }).ToList(),
                Subtotal = sales.Subtotal,
                ShippingCost = sales.ShippingCost,
                TotalTax = sales.TotalTax,
                Total = sales.Total,
                Note = sales.CustomerNote,
                // Delivery address details
                DeliveryAddressFirstName = sales.DeliveryAddressFirstName,
                DeliveryAddressLastName = sales.DeliveryAddressLastName,
                DeliveryAddressCompanyName = sales.DeliveryAddressCompanyName,
                DeliveryAddressPhone = sales.DeliveryAddressPhone,
                DeliveryAddressStreet = sales.DeliveryAddressStreet,
                DeliveryAddressCity = sales.DeliveryAddressCity,
                DeliveryAddressZip = sales.DeliveryAddressZip,
                DeliveryAddressCountry = sales.DeliveryAddressCountry,
                // Invoice address details
                InvoiceAddressFirstName = sales.InvoiceAddressFirstName,
                InvoiceAddressLastName = sales.InvoiceAddressLastName,
                InvoiceAddressCompanyName = sales.InvoiceAddressCompanyName,
                InvoiceAddressPhone = sales.InvoiceAddressPhone,
                InvoiceAddressStreet = sales.InvoiceAddressStreet,
                InvoiceAddressCity = sales.InvoiceAddressCity,
                InvoiceAddressZip = sales.InvoiceAddressZip,
                InvoiceAddressCountry = sales.InvoiceAddressCountry,
                DateSalesed = sales.DateSalesed
            };

            // Set successful result with the sales details
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = data;

            _logger.LogInformation("Sales with ID {Id} retrieved successfully", request.Id);
        }
        catch (Exception ex)
        {
            // Handle any exceptions during sales retrieval; never leak the raw exception text.
            result.FromException(_logger, ex,
                "An error occurred while retrieving the sales.",
                "Error retrieving sales with ID: {Id}", request.Id);
        }

        return result;
    }

    /// <summary>
    /// Resolves the primary image (lowest SortOrder) of every ordered product in one query,
    /// so the client can render a thumbnail per order line.
    /// </summary>
    private async Task<Dictionary<Guid, Guid>> GetPrimaryImagesAsync(
        IEnumerable<Domain.Entities.SalesItem> salesItems,
        CancellationToken cancellationToken)
    {
        var productIds = salesItems
            .Select(i => i.ProductId)
            .Where(id => id != Guid.Empty)
            .Distinct()
            .ToList();

        if (productIds.Count == 0)
        {
            return new Dictionary<Guid, Guid>();
        }

        var images = await _productImageRepository.Entities
            .AsNoTracking()
            .Where(img => productIds.Contains(img.ProductId))
            .Select(img => new { img.Id, img.ProductId, img.SortOrder })
            .ToListAsync(cancellationToken);

        return images
            .GroupBy(img => img.ProductId)
            .ToDictionary(
                g => g.Key,
                g => g.OrderBy(img => img.SortOrder).ThenBy(img => img.Id).First().Id);
    }

    /// <summary>
    /// Maps SalesHistory entities to SalesHistoryDto objects.
    /// </summary>
    /// <param name="salesHistories">List of SalesHistory entities.</param>
    /// <returns>List of SalesHistoryDto objects.</returns>
    private List<SalesHistoryDto> MapSalesHistoryToDto(List<Domain.Entities.SalesHistory> salesHistories)
    {
        return salesHistories.Select(history => new SalesHistoryDto
        {
            Id = history.Id,
            UserId = history.UserId,
            SalesId = history.SalesId,
            ShippingId = history.ShippingId,
            SalesStatusOld = history.SalesStatusOld,
            SalesStatusNew = history.SalesStatusNew,
            PaymentStatusOld = history.PaymentStatusOld,
            PaymentStatusNew = history.PaymentStatusNew,
            ShippingStatusOld = history.ShippingStatusOld,
            ShippingStatusNew = history.ShippingStatusNew,
            Description = history.Description,
            MessageKey = history.MessageKey,
            MessageArgs = Domain.Entities.SalesHistoryMessage.DecodeArgs(history.MessageArgs),
            IsSystemGenerated = history.IsSystemGenerated,
            DateCreated = history.DateCreated,
            DateUpdated = history.DateModified
        }).ToList();
    }
}
