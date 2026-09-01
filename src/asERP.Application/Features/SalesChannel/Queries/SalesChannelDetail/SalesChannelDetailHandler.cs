using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.SalesChannel;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.SalesChannel.Queries.SalesChannelDetail;

/// <summary>
/// Handler for processing sales channel detail queries.
/// Implements IRequestHandler from the custom mediator to handle SalesChannelDetailQuery requests
/// and return detailed sales channel information wrapped in a Result.
/// </summary>
public class SalesChannelDetailHandler : IRequestHandler<SalesChannelDetailQuery, Result<SalesChannelDetailDto>>
{
    private readonly IAppLogger<SalesChannelDetailHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IShopDomainRepository _shopDomainRepository;

    public SalesChannelDetailHandler(
        IAppLogger<SalesChannelDetailHandler> logger,
        ISalesChannelRepository salesChannelRepository,
        IShopDomainRepository shopDomainRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _shopDomainRepository = shopDomainRepository ?? throw new ArgumentNullException(nameof(shopDomainRepository));
    }

    public async Task<Result<SalesChannelDetailDto>> Handle(SalesChannelDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving sales channel details for ID: {Id}", request.Id);

        var result = new Result<SalesChannelDetailDto>();

        try
        {
            // Retrieve sales channel with all related details from the repository
            var salesChannel = await _salesChannelRepository.GetDetails(request.Id);

            // Note: GetDetails method throws NotFoundException if not found, so no null check needed here

            // Map entity to DTO using the mapping method
            var data = MapToDetailDto(salesChannel);

            // asShop channels carry their host bindings on the detail view (same shape and
            // ordering as the dedicated shop-domains list endpoint). Other types have none.
            if (salesChannel.Type == Domain.Enums.SalesChannelType.AsShop)
            {
                data.ShopDomains = await _shopDomainRepository.Entities
                    .Where(d => d.SalesChannelId == salesChannel.Id)
                    .OrderByDescending(d => d.IsPrimary)
                    .ThenBy(d => d.Host)
                    .ThenBy(d => d.Port)
                    .Select(d => new ShopDomainListDto
                    {
                        Id = d.Id,
                        SalesChannelId = d.SalesChannelId,
                        Host = d.Host,
                        Port = d.Port,
                        IsPrimary = d.IsPrimary,
                        RedirectToPrimary = d.RedirectToPrimary
                    })
                    .ToListAsync(cancellationToken);
            }

            // Set successful result with the sales channel details
            result.Succeeded = true;
            result.Status = ResultStatus.Ok;
            result.Data = data;

            _logger.LogInformation("Sales channel with ID {Id} retrieved successfully", request.Id);
        }
        catch (Application.Exceptions.NotFoundException)
        {
            // Handle not found exceptions specifically
            result.Fail(ErrorType.NotFound, ErrorCodes.SalesChannel.NotFound, $"Sales channel with ID {request.Id} not found");

            _logger.LogWarning("Sales channel with ID {Id} not found", request.Id);
        }

        return result;
    }

    /// <summary>
    /// Maps a sales channel entity to a detail DTO
    /// </summary>
    /// <param name="entity">The sales channel entity to map</param>
    /// <returns>A sales channel detail DTO with properties from the entity</returns>
    private SalesChannelDetailDto MapToDetailDto(Domain.Entities.SalesChannel entity)
    {
        return new SalesChannelDetailDto
        {
            Id = entity.Id,
            SalesChannelType = entity.Type,
            Name = entity.Name,
            Url = entity.Url,
            Username = entity.Username,
            // Password is intentionally never returned in detail DTOs (write-only on the wire).
            Password = string.Empty,
            AdditionalConfigJson = entity.AdditionalConfigJson,
            HasRefreshToken = !string.IsNullOrEmpty(entity.RefreshToken),
            TokenExpiresAt = entity.TokenExpiresAt,
            ImportProducts = entity.ImportProducts,
            ImportCustomers = entity.ImportCustomers,
            ImportSaless = entity.ImportSaless,
            ExportProducts = entity.ExportProducts,
            ExportCustomers = entity.ExportCustomers,
            ExportSaless = entity.ExportSaless,
            ExportStock = entity.ExportStock,
            PushSalesCancellations = entity.PushSalesCancellations,
            ImportStock = entity.ImportStock,
            ImportCategories = entity.ImportCategories,
            ExportCategories = entity.ExportCategories,
            ShipmentTrackingMode = entity.ShipmentTrackingMode,
            CarrierMappings = entity.CarrierMappings?
                .OrderBy(m => m.RemoteCarrierCode, StringComparer.Ordinal)
                .Select(m => new SalesChannelCarrierMappingDto
                {
                    Id = m.Id,
                    RemoteCarrierCode = m.RemoteCarrierCode,
                    ShippingProviderId = m.ShippingProviderId,
                    ShippingProviderName = m.ShippingProvider?.Name ?? string.Empty,
                }).ToList() ?? new List<SalesChannelCarrierMappingDto>(),
            HasWebhookSecret = !string.IsNullOrEmpty(entity.WebhookSecret),
            Warehouses = entity.Warehouses?.Select(w => new WarehouseDetailDto
            {
                Id = w.Id,
                Name = w.Name
            }).ToList() ?? new List<WarehouseDetailDto>()
        };
    }
}
