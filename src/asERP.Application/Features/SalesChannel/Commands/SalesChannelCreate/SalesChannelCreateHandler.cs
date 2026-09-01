using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelCreate;

/// <summary>
/// Handler for processing sales channel creation commands.
/// Implements IRequestHandler from the custom mediator to handle SalesChannelCreateCommand requests
/// and return the ID of the newly created sales channel wrapped in a Result.
/// </summary>
public class SalesChannelCreateHandler : IRequestHandler<SalesChannelCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesChannelCreateHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IShippingProviderRepository _shippingProviderRepository;

    public SalesChannelCreateHandler(
        IAppLogger<SalesChannelCreateHandler> logger,
        ISalesChannelRepository salesChannelRepository,
        IWarehouseRepository warehouseRepository,
        IShippingProviderRepository shippingProviderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
    }

    public async Task<Result<Guid>> Handle(SalesChannelCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new sales channel with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Carrier mappings must only ever reference the caller's own shipping providers: the id
        // travels in the request body and the database FK is tenant-blind, so an unchecked id
        // would let a channel resolve imported shipments onto another tenant's carrier (and its
        // credentials). GetByIdAsync applies the tenant query filter, so a foreign id reads as
        // missing.
        var unknownProviderIds = new List<Guid>();
        foreach (var providerId in request.CarrierMappings
                     .Select(m => m.ShippingProviderId)
                     .Where(id => id != Guid.Empty)
                     .Distinct())
        {
            if (await _shippingProviderRepository.GetByIdAsync(providerId, asNoTracking: true) is null)
            {
                unknownProviderIds.Add(providerId);
            }
        }

        if (unknownProviderIds.Count > 0)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.SalesChannel.Invalid, $"The following shipping provider IDs do not exist: {string.Join(", ", unknownProviderIds)}");
            return result;
        }

        // Map request to domain entity
        var salesChannelToCreate = MapToEntity(request);

        // Link the requested warehouses. The validator guarantees the ids exist, but load
        // tracked entities so EF inserts only the join rows alongside the new channel.
        var warehouses = new List<Domain.Entities.Warehouse>();
        foreach (var warehouseId in request.WarehouseIds)
        {
            var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
            if (warehouse == null)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.SalesChannel.Invalid, $"The following warehouse IDs do not exist: {warehouseId}");
                return result;
            }

            warehouses.Add(warehouse);
        }
        salesChannelToCreate.Warehouses = warehouses;

        // Add the new sales channel to the database
        await _salesChannelRepository.CreateAsync(salesChannelToCreate);

        // Set successful result with the new sales channel ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = salesChannelToCreate.Id;

        _logger.LogInformation("Successfully created sales channel with ID: {Id}", salesChannelToCreate.Id);

        return result;
    }

    /// <summary>
    /// Maps a sales channel command to a domain entity
    /// </summary>
    /// <param name="command">The sales channel creation command</param>
    /// <returns>A new sales channel entity with properties from the command</returns>
    private Domain.Entities.SalesChannel MapToEntity(SalesChannelCreateCommand command)
    {
        // asShop is the built-in storefront on the ERP's own data: every sync direction is
        // implicitly always on, the client hides the toggles, and the connector's empty
        // capability set keeps the orchestrator/outbox from acting on the flags.
        var syncAlwaysOn = command.SalesChannelType == Domain.Enums.SalesChannelType.AsShop;

        return new Domain.Entities.SalesChannel
        {
            Type = command.SalesChannelType,
            Name = command.Name,
            Url = command.Url,
            Username = command.Username,
            Password = command.Password,
            AdditionalConfigJson = command.AdditionalConfigJson,
            ImportProducts = syncAlwaysOn || command.ImportProducts,
            ImportCustomers = syncAlwaysOn || command.ImportCustomers,
            ImportSaless = syncAlwaysOn || command.ImportSaless,
            ExportProducts = syncAlwaysOn || command.ExportProducts,
            ExportCustomers = syncAlwaysOn || command.ExportCustomers,
            ExportSaless = syncAlwaysOn || command.ExportSaless,
            ExportStock = syncAlwaysOn || command.ExportStock,
            PushSalesCancellations = syncAlwaysOn || command.PushSalesCancellations,
            ImportStock = syncAlwaysOn || command.ImportStock,
            ImportCategories = syncAlwaysOn || command.ImportCategories,
            ExportCategories = syncAlwaysOn || command.ExportCategories,
            // Not forced on for asShop: the storefront reads the ERP's shipments directly, so there
            // is nothing to exchange in either direction.
            ShipmentTrackingMode = syncAlwaysOn ? Domain.Enums.ShipmentTrackingMode.None : command.ShipmentTrackingMode,
            CarrierMappings = command.CarrierMappings
                .Where(m => !string.IsNullOrWhiteSpace(m.RemoteCarrierCode) && m.ShippingProviderId != Guid.Empty)
                .GroupBy(m => m.RemoteCarrierCode.Trim().ToLowerInvariant())
                .Select(g => new Domain.Entities.SalesChannelCarrierMapping
                {
                    Id = Guid.NewGuid(),
                    RemoteCarrierCode = g.Key,
                    ShippingProviderId = g.Last().ShippingProviderId,
                })
                .ToList(),
            // asShop tracking is built-in (no plugin/token needed, cookieless by design), so new shop
            // channels start with analytics on; DELETE /tracking turns it off. Plugin-served channel
            // types stay off until a token is rotated.
            TrackingEnabled = command.SalesChannelType == Domain.Enums.SalesChannelType.AsShop,
            // Every channel owns a 1:1 sync-state row (import cursors, completion flags). Created here so it
            // is inserted with the channel; the sync machinery mutates it thereafter (never the channel row).
            SyncState = new Domain.Entities.SalesChannelSyncState(),
        };
    }
}
