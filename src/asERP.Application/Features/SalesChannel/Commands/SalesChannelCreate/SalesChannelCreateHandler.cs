using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.SalesChannel.Commands.SalesChannelCreate;

/// <summary>
/// Handler for processing sales channel creation commands.
/// Implements IRequestHandler from MediatR to handle SalesChannelCreateCommand requests
/// and return the ID of the newly created sales channel wrapped in a Result.
/// </summary>
public class SalesChannelCreateHandler : IRequestHandler<SalesChannelCreateCommand, Result<Guid>>
{
    /// <summary>
    /// Logger for recording handler operations
    /// </summary>
    private readonly IAppLogger<SalesChannelCreateHandler> _logger;

    /// <summary>
    /// Repository for sales channel data operations
    /// </summary>
    private readonly ISalesChannelRepository _salesChannelRepository;

    /// <summary>
    /// Repository for warehouse data operations
    /// </summary>
    private readonly IWarehouseRepository _warehouseRepository;

    /// <summary>
    /// Repository for shipping provider data operations
    /// </summary>
    private readonly IShippingProviderRepository _shippingProviderRepository;

    /// <summary>
    /// Constructor that initializes the handler with required dependencies
    /// </summary>
    /// <param name="logger">Logger for recording operations</param>
    /// <param name="salesChannelRepository">Repository for sales channel data access</param>
    /// <param name="warehouseRepository">Repository for warehouse data access</param>
    /// <param name="shippingProviderRepository">Repository for shipping provider data access</param>
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

    /// <summary>
    /// Handles the sales channel creation request
    /// </summary>
    /// <param name="request">The sales channel creation command with sales channel details</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Result containing the ID of the newly created sales channel if successful</returns>
    public async Task<Result<Guid>> Handle(SalesChannelCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new sales channel with name: {Name}", request.Name);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SalesChannelCreateValidator(_salesChannelRepository, _warehouseRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        // If validation fails, return a bad request result with validation error messages
        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(SalesChannelCreateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
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
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add($"The following shipping provider IDs do not exist: {string.Join(", ", unknownProviderIds)}");
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
                    result.Succeeded = false;
                    result.StatusCode = ResultStatusCode.BadRequest;
                    result.Messages.Add($"The following warehouse IDs do not exist: {warehouseId}");
                    return result;
                }

                warehouses.Add(warehouse);
            }
            salesChannelToCreate.Warehouses = warehouses;

            // Add the new sales channel to the database
            await _salesChannelRepository.CreateAsync(salesChannelToCreate);

            // Set successful result with the new sales channel ID
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = salesChannelToCreate.Id;

            _logger.LogInformation("Successfully created sales channel with ID: {Id}", salesChannelToCreate.Id);
        }
        catch (Exception ex)
        {
            // Handle any exceptions during sales channel creation
            result.FromException(_logger, ex,
                "An error occurred while creating the sales channel.",
                "Error creating sales channel {Name}.", request.Name);
        }

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
