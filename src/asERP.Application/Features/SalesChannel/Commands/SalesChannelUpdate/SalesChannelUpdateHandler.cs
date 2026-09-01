using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Application.Notifications;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelUpdate;

public class SalesChannelUpdateHandler : IRequestHandler<SalesChannelUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesChannelUpdateHandler> _logger;
    private readonly ISalesChannelRepository _salesChannelRepository;
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly IShippingProviderRepository _shippingProviderRepository;
    private readonly IMediator _mediator;

    public SalesChannelUpdateHandler(
        IAppLogger<SalesChannelUpdateHandler> logger,
        ISalesChannelRepository salesChannelRepository,
        IWarehouseRepository warehouseRepository,
        IShippingProviderRepository shippingProviderRepository,
        IMediator mediator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesChannelRepository = salesChannelRepository ?? throw new ArgumentNullException(nameof(salesChannelRepository));
        _warehouseRepository = warehouseRepository ?? throw new ArgumentNullException(nameof(warehouseRepository));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public async Task<Result<Guid>> Handle(SalesChannelUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating sales channel with ID: {Id} and name: {Name}", request.Id, request.Name);

        var result = new Result<Guid>();

        // Get existing sales channel with warehouses
        Domain.Entities.SalesChannel existingSalesChannel;
        try
        {
            existingSalesChannel = await _salesChannelRepository.GetDetails(request.Id);
        }
        catch (NotFoundException)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.SalesChannel.NotFound, $"Sales channel with ID {request.Id} not found");
            return result;
        }

        // Snapshot the stock-relevant state before any mutation: the exported stock is the sum over
        // the channel's linked warehouses, so a changed warehouse set (or ExportStock switching on)
        // must trigger a stock re-push for every listed product after the update is persisted.
        var previousWarehouseIds = existingSalesChannel.Warehouses?.Select(w => w.Id).ToHashSet() ?? new HashSet<Guid>();
        var previousExportStock = existingSalesChannel.ExportStock;

        // Update properties from request
        existingSalesChannel.Type = request.SalesChannelType;
        existingSalesChannel.Name = request.Name;
        existingSalesChannel.Url = request.Url;
        existingSalesChannel.Username = request.Username;
        // The password/secret is write-only: it is never returned to the client, so the edit
        // form submits it empty unless the user deliberately enters a new value. Treat an empty
        // password as "keep the stored secret" instead of wiping it.
        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            existingSalesChannel.Password = request.Password;
        }
        // Null means "keep the stored connector config" (older clients don't send the field);
        // an empty string deliberately clears it.
        if (request.AdditionalConfigJson is not null)
        {
            existingSalesChannel.AdditionalConfigJson =
                string.IsNullOrWhiteSpace(request.AdditionalConfigJson) ? null : request.AdditionalConfigJson;
        }
        // asShop channels keep every sync direction always on (the client hides the toggles);
        // forcing here also heals channels created before that rule existed. The connector's
        // empty capability set keeps the orchestrator/outbox from acting on the flags.
        var syncAlwaysOn = request.SalesChannelType == Domain.Enums.SalesChannelType.AsShop;
        existingSalesChannel.ImportProducts = syncAlwaysOn || request.ImportProducts;
        existingSalesChannel.ImportCustomers = syncAlwaysOn || request.ImportCustomers;
        existingSalesChannel.ImportSaless = syncAlwaysOn || request.ImportSaless;
        existingSalesChannel.ExportProducts = syncAlwaysOn || request.ExportProducts;
        existingSalesChannel.ExportCustomers = syncAlwaysOn || request.ExportCustomers;
        existingSalesChannel.ExportSaless = syncAlwaysOn || request.ExportSaless;
        existingSalesChannel.ExportStock = syncAlwaysOn || request.ExportStock;
        existingSalesChannel.PushSalesCancellations = syncAlwaysOn || request.PushSalesCancellations;
        existingSalesChannel.ImportStock = syncAlwaysOn || request.ImportStock;
        existingSalesChannel.ImportCategories = syncAlwaysOn || request.ImportCategories;
        existingSalesChannel.ExportCategories = syncAlwaysOn || request.ExportCategories;
        // Not forced on for asShop: the storefront reads the ERP's shipments directly.
        existingSalesChannel.ShipmentTrackingMode =
            syncAlwaysOn ? Domain.Enums.ShipmentTrackingMode.None : request.ShipmentTrackingMode;


        // Update warehouse relationships
        var warehouses = new List<Domain.Entities.Warehouse>();
        if (request.WarehouseIds != null && request.WarehouseIds.Any())
        {
            var invalidWarehouseIds = new List<Guid>();

            foreach (var warehouseId in request.WarehouseIds)
            {
                var warehouse = await _warehouseRepository.GetByIdAsync(warehouseId);
                if (warehouse != null)
                {
                    warehouses.Add(warehouse);
                }
                else
                {
                    invalidWarehouseIds.Add(warehouseId);
                }
            }

            // Return error if any warehouse IDs are invalid
            if (invalidWarehouseIds.Any())
            {
                result.Fail(ErrorType.Validation, ErrorCodes.SalesChannel.Invalid, $"The following warehouse IDs do not exist: {string.Join(", ", invalidWarehouseIds)}");
                return result;
            }
        }
        existingSalesChannel.Warehouses = warehouses;

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

        // Update in database
        await _salesChannelRepository.UpdateAsync(existingSalesChannel);

        // Separate call on purpose: assigning the navigation on the tracked entity would hit the
        // same identity-resolution trap the warehouse snapshot above works around.
        await _salesChannelRepository.ReplaceCarrierMappingsAsync(
            existingSalesChannel.Id, request.CarrierMappings);

        // A changed warehouse set (or freshly enabled ExportStock) shifts the effective stock of
        // every listed product — kick off a stock re-push for all of them via the export outbox.
        var newWarehouseIds = warehouses.Select(w => w.Id).ToHashSet();
        if (existingSalesChannel.ExportStock && (!previousExportStock || !newWarehouseIds.SetEquals(previousWarehouseIds)))
        {
            await _mediator.Publish(
                new SalesChannelStockScopeChangedNotification(existingSalesChannel.Id, existingSalesChannel.TenantId),
                cancellationToken);
        }

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = existingSalesChannel.Id;

        _logger.LogInformation("Successfully updated sales channel with ID: {Id}", existingSalesChannel.Id);

        return result;
    }
}
