using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Persistence.DatabaseContext;
using asToolkit.Shipping.Abstractions;
using asToolkit.Shipping.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asToolkit.Shipping.Services;

/// <summary>
/// Implements the Application-facing carrier contract. Label creation is hybrid: a synchronous
/// attempt (Polly already retries transient errors) with an outbox fallback when the carrier is
/// unreachable. The outbox drainer reuses <see cref="TryCreateLabelCoreAsync"/> so both paths
/// share one code path.
/// </summary>
public sealed class ShippingCarrierService : IShippingCarrierService
{
    private readonly ApplicationDbContext _context;
    private readonly IShippingCarrierConnectorRegistry _registry;
    private readonly ShippingCarrierContextFactory _contextFactory;
    private readonly ShippingLabelOutboxEnqueuer _enqueuer;
    private readonly IShippingStatusUpdater _statusUpdater;
    private readonly ITenantContext _tenantContext;
    private readonly ILogger<ShippingCarrierService> _logger;

    public ShippingCarrierService(
        ApplicationDbContext context,
        IShippingCarrierConnectorRegistry registry,
        ShippingCarrierContextFactory contextFactory,
        ShippingLabelOutboxEnqueuer enqueuer,
        IShippingStatusUpdater statusUpdater,
        ITenantContext tenantContext,
        ILogger<ShippingCarrierService> logger)
    {
        _context = context;
        _registry = registry;
        _contextFactory = contextFactory;
        _enqueuer = enqueuer;
        _statusUpdater = statusUpdater;
        _tenantContext = tenantContext;
        _logger = logger;
    }

    public async Task<Result<ShipmentLabelResult>> CreateLabelAsync(Guid shippingId, CancellationToken cancellationToken = default)
    {
        var core = await TryCreateLabelCoreAsync(shippingId, cancellationToken);

        if (core.Result.Success)
        {
            var data = new ShipmentLabelResult
            {
                CarrierShipmentId = core.Result.CarrierShipmentId ?? string.Empty,
                TrackingNumber = core.Result.TrackingNumber ?? string.Empty,
                TrackingUrl = core.Result.TrackingUrl,
                LabelData = core.Result.LabelData ?? Array.Empty<byte>(),
                LabelFormat = core.Result.LabelFormat
            };

            return Result<ShipmentLabelResult>.Success(data);
        }

        if (core.Result.IsPermanentFailure || core.Shipping is null)
        {
            return Result<ShipmentLabelResult>.Fail(ResultStatusCode.BadRequest,
                core.Result.ErrorMessage ?? "Label creation failed.");
        }

        // Transient failure — queue for background retry. The request itself is accepted, so this
        // reports success with an explanatory message rather than an error status.
        await _enqueuer.EnqueueAsync(core.Shipping.Id, core.Shipping.ShippingProviderId, core.Shipping.TenantId,
            core.Result.ErrorMessage, cancellationToken);

        return Result<ShipmentLabelResult>.Success(new ShipmentLabelResult(),
            $"The carrier could not be reached — label creation was queued for retry. ({core.Result.ErrorMessage})");
    }

    /// <summary>
    /// Single label-creation code path shared by the synchronous request and the outbox drainer.
    /// Persists label data and advances the status on success; never enqueues.
    /// </summary>
    internal async Task<(CarrierLabelResult Result, Domain.Entities.Shipping? Shipping)> TryCreateLabelCoreAsync(
        Guid shippingId, CancellationToken cancellationToken)
    {
        var shipping = await _context.Shipping
            .IgnoreQueryFilters()
            .Include(s => s.Sales)
            .FirstOrDefaultAsync(s => s.Id == shippingId, cancellationToken);

        if (shipping is null)
        {
            return (CarrierLabelResult.Permanent($"Shipping {shippingId} not found."), null);
        }

        // Background scopes have no ambient tenant — adopt the shipment's so downstream
        // repository calls (status updater) see the row.
        _tenantContext.SetCurrentTenantId(shipping.TenantId);

        var provider = await _context.ShippingProvider
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == shipping.ShippingProviderId, cancellationToken);

        if (provider is null)
        {
            return (CarrierLabelResult.Permanent("The shipping provider of this shipment no longer exists."), shipping);
        }

        if (!provider.IsEnabled)
        {
            return (CarrierLabelResult.Permanent($"The shipping provider '{provider.Name}' is disabled."), shipping);
        }

        var connector = _registry.Resolve(provider.Type);
        if (connector is null)
        {
            return (CarrierLabelResult.Permanent($"No connector is available for carrier {provider.Type}."), shipping);
        }

        ShipmentLabelRequest request;
        try
        {
            request = await BuildLabelRequestAsync(shipping, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return (CarrierLabelResult.Permanent(ex.Message), shipping);
        }

        var carrierContext = _contextFactory.Create(provider, cancellationToken);
        var result = await connector.CreateLabelAsync(carrierContext, request);

        if (!result.Success)
        {
            _logger.LogWarning("Label creation for shipping {ShippingId} via {Carrier} failed ({Kind}): {Error}",
                shippingId, provider.Type, result.IsPermanentFailure ? "permanent" : "transient", result.ErrorMessage);
            return (result, shipping);
        }

        shipping.TrackingNumber = result.TrackingNumber ?? string.Empty;
        shipping.CarrierShipmentId = result.CarrierShipmentId;
        shipping.TrackingUrl = result.TrackingUrl;
        shipping.LabelData = result.LabelData;
        shipping.LabelFormat = result.LabelFormat;
        await _context.SaveChangesAsync(cancellationToken);

        await _statusUpdater.ApplyStatusAsync(shipping.Id, ShippingStatus.LabelCreated,
            rawCarrierStatus: "Label created", isSystemGenerated: true, cancellationToken: cancellationToken);

        _logger.LogInformation("Created {Carrier} label for shipping {ShippingId}: tracking {TrackingNumber}",
            provider.Type, shippingId, result.TrackingNumber);

        return (result, shipping);
    }

    public async Task<Result> CancelShipmentAsync(Guid shippingId, CancellationToken cancellationToken = default)
    {
        var (shipping, provider, connector, error) = await LoadForCarrierCallAsync(shippingId, cancellationToken);
        if (error != null || shipping is null || provider is null || connector is null)
        {
            return new Result { Succeeded = false, StatusCode = ResultStatusCode.BadRequest, Messages = [error ?? "Carrier call not possible."] };
        }

        if (string.IsNullOrEmpty(shipping.CarrierShipmentId))
        {
            return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
        }

        var carrierContext = _contextFactory.Create(provider, cancellationToken);
        var result = await connector.CancelShipmentAsync(carrierContext, shipping.CarrierShipmentId);

        if (!result.Success)
        {
            return new Result
            {
                Succeeded = false,
                StatusCode = ResultStatusCode.BadRequest,
                Messages = [$"Carrier-side cancellation failed: {result.ErrorMessage}"]
            };
        }

        return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
    }

    public async Task<Result<ShipmentTrackingResult>> GetTrackingStatusAsync(Guid shippingId, CancellationToken cancellationToken = default)
    {
        var (shipping, provider, connector, error) = await LoadForCarrierCallAsync(shippingId, cancellationToken);
        if (error != null || shipping is null || provider is null || connector is null)
        {
            return Result<ShipmentTrackingResult>.Fail(ResultStatusCode.BadRequest, error ?? "Carrier call not possible.");
        }

        if (string.IsNullOrEmpty(shipping.TrackingNumber))
        {
            return Result<ShipmentTrackingResult>.Fail(ResultStatusCode.BadRequest, "The shipment has no tracking number yet.");
        }

        var carrierContext = _contextFactory.Create(provider, cancellationToken);
        var result = await connector.GetTrackingStatusAsync(carrierContext, shipping.TrackingNumber);

        if (!result.Success)
        {
            return Result<ShipmentTrackingResult>.Fail(ResultStatusCode.BadRequest,
                result.ErrorMessage ?? "Tracking request failed.");
        }

        var mapped = TrackingStatusMapper.Map(result.Status);

        return Result<ShipmentTrackingResult>.Success(new ShipmentTrackingResult
        {
            Status = mapped ?? shipping.Status,
            RawCarrierStatus = result.StatusDescription,
            EventTimeUtc = result.EventTimestampUtc
        });
    }

    private async Task<(Domain.Entities.Shipping? Shipping, Domain.Entities.ShippingProvider? Provider, IShippingCarrierConnector? Connector, string? Error)>
        LoadForCarrierCallAsync(Guid shippingId, CancellationToken cancellationToken)
    {
        var shipping = await _context.Shipping
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(s => s.Id == shippingId, cancellationToken);

        if (shipping is null)
        {
            return (null, null, null, $"Shipping {shippingId} not found.");
        }

        _tenantContext.SetCurrentTenantId(shipping.TenantId);

        var provider = await _context.ShippingProvider
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == shipping.ShippingProviderId, cancellationToken);

        if (provider is null)
        {
            return (shipping, null, null, "The shipping provider of this shipment no longer exists.");
        }

        var connector = _registry.Resolve(provider.Type);
        if (connector is null)
        {
            return (shipping, provider, null, $"No connector is available for carrier {provider.Type}.");
        }

        return (shipping, provider, connector, null);
    }

    /// <summary>Builds the carrier-agnostic request from the order's delivery address.</summary>
    private async Task<ShipmentLabelRequest> BuildLabelRequestAsync(Domain.Entities.Shipping shipping, CancellationToken cancellationToken)
    {
        var sales = shipping.Sales;

        var countryString = sales.DeliveryAddressCountry;
        if (string.IsNullOrWhiteSpace(countryString))
        {
            throw new InvalidOperationException("The sales order has no delivery country.");
        }

        // Country rows are tenant-agnostic seed data — resolve the order's free-text country
        // to its ISO code (case-insensitive on code or name).
        var lowerCountry = countryString.ToLower();
        var country = await _context.Country
            .FirstOrDefaultAsync(c => c.CountryCode.ToLower() == lowerCountry || c.Name.ToLower() == lowerCountry,
                cancellationToken);

        if (country is null)
        {
            throw new InvalidOperationException(
                $"The delivery country '{countryString}' could not be resolved to a known country.");
        }

        var recipientName = $"{sales.DeliveryAddressFirstName} {sales.DeliveryAddressLastName}".Trim();
        if (string.IsNullOrWhiteSpace(recipientName))
        {
            recipientName = sales.DeliveryAddressCompanyName;
        }

        if (string.IsNullOrWhiteSpace(recipientName) || string.IsNullOrWhiteSpace(sales.DeliveryAddressStreet)
            || string.IsNullOrWhiteSpace(sales.DeliveryAddressZip) || string.IsNullOrWhiteSpace(sales.DeliveryAddressCity))
        {
            throw new InvalidOperationException("The sales order's delivery address is incomplete.");
        }

        return new ShipmentLabelRequest
        {
            ShippingId = shipping.Id,
            Reference = sales.SalesId.ToString(),
            RecipientName = recipientName,
            RecipientCompany = string.IsNullOrWhiteSpace(sales.DeliveryAddressCompanyName) ? null : sales.DeliveryAddressCompanyName,
            RecipientPhone = string.IsNullOrWhiteSpace(sales.DeliveryAddressPhone) ? null : sales.DeliveryAddressPhone,
            Street = sales.DeliveryAddressStreet,
            City = sales.DeliveryAddressCity,
            Zip = sales.DeliveryAddressZip,
            CountryIsoCode = country.CountryCode.ToUpperInvariant(),
            WeightKg = shipping.WeightKg ?? 1m,
            LengthCm = shipping.LengthCm,
            WidthCm = shipping.WidthCm,
            HeightCm = shipping.HeightCm
        };
    }
}
