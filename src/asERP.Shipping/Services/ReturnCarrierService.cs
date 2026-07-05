using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Services;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Persistence.DatabaseContext;
using asERP.Shipping.Abstractions;
using asERP.Shipping.Orchestration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Shipping.Services;

/// <summary>
/// Implements the Application-facing return-label contract. Structural mirror of
/// <see cref="ShippingCarrierService"/>: a synchronous attempt with an outbox fallback on
/// transient failure; the outbox drainer reuses <see cref="TryCreateReturnLabelCoreAsync"/>.
/// </summary>
public sealed class ReturnCarrierService : IReturnCarrierService
{
    private static readonly ReturnShipmentStatus[] TerminalStatuses =
    [
        ReturnShipmentStatus.Completed,
        ReturnShipmentStatus.Rejected,
        ReturnShipmentStatus.Cancelled
    ];

    private readonly ApplicationDbContext _context;
    private readonly IShippingCarrierConnectorRegistry _registry;
    private readonly ShippingCarrierContextFactory _contextFactory;
    private readonly ReturnLabelOutboxEnqueuer _enqueuer;
    private readonly IReturnStatusUpdater _statusUpdater;
    private readonly ITenantContext _tenantContext;
    private readonly ILogger<ReturnCarrierService> _logger;

    public ReturnCarrierService(
        ApplicationDbContext context,
        IShippingCarrierConnectorRegistry registry,
        ShippingCarrierContextFactory contextFactory,
        ReturnLabelOutboxEnqueuer enqueuer,
        IReturnStatusUpdater statusUpdater,
        ITenantContext tenantContext,
        ILogger<ReturnCarrierService> logger)
    {
        _context = context;
        _registry = registry;
        _contextFactory = contextFactory;
        _enqueuer = enqueuer;
        _statusUpdater = statusUpdater;
        _tenantContext = tenantContext;
        _logger = logger;
    }

    public async Task<Result<ShipmentLabelResult>> CreateReturnLabelAsync(Guid returnShipmentId, CancellationToken cancellationToken = default)
    {
        var core = await TryCreateReturnLabelCoreAsync(returnShipmentId, cancellationToken);

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

        if (core.Result.IsPermanentFailure || core.ReturnShipment is null || core.ReturnShipment.ShippingProviderId is null)
        {
            return Result<ShipmentLabelResult>.Fail(ResultStatusCode.BadRequest,
                core.Result.ErrorMessage ?? "Return-label creation failed.");
        }

        // Transient failure — queue for background retry. The request itself is accepted, so this
        // reports success with an explanatory message rather than an error status.
        await _enqueuer.EnqueueAsync(core.ReturnShipment.Id, core.ReturnShipment.ShippingProviderId.Value,
            core.ReturnShipment.TenantId, core.Result.ErrorMessage, cancellationToken);

        return Result<ShipmentLabelResult>.Success(new ShipmentLabelResult(),
            $"The carrier could not be reached — return-label creation was queued for retry. ({core.Result.ErrorMessage})");
    }

    /// <summary>
    /// Single return-label code path shared by the synchronous request and the outbox drainer.
    /// Persists label data and advances the status on success; never enqueues.
    /// </summary>
    internal async Task<(CarrierLabelResult Result, Domain.Entities.ReturnShipment? ReturnShipment)> TryCreateReturnLabelCoreAsync(
        Guid returnShipmentId, CancellationToken cancellationToken)
    {
        var returnShipment = await _context.ReturnShipment
            .IgnoreQueryFilters()
            .Include(r => r.Sales)
            .FirstOrDefaultAsync(r => r.Id == returnShipmentId, cancellationToken);

        if (returnShipment is null)
        {
            return (CarrierLabelResult.Permanent($"Return {returnShipmentId} not found."), null);
        }

        // Background scopes have no ambient tenant — adopt the return's so downstream
        // repository calls (status updater) see the row.
        _tenantContext.SetCurrentTenantId(returnShipment.TenantId);

        if (TerminalStatuses.Contains(returnShipment.Status))
        {
            return (CarrierLabelResult.Permanent($"The return is {returnShipment.Status} — no label will be created."), returnShipment);
        }

        if (returnShipment.ShippingProviderId is null)
        {
            return (CarrierLabelResult.Permanent("The return has no shipping provider — the customer ships themselves."), returnShipment);
        }

        var provider = await _context.ShippingProvider
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == returnShipment.ShippingProviderId, cancellationToken);

        if (provider is null)
        {
            return (CarrierLabelResult.Permanent("The shipping provider of this return no longer exists."), returnShipment);
        }

        if (!provider.IsEnabled)
        {
            return (CarrierLabelResult.Permanent($"The shipping provider '{provider.Name}' is disabled."), returnShipment);
        }

        var connector = _registry.Resolve(provider.Type);
        if (connector is null)
        {
            return (CarrierLabelResult.Permanent($"No connector is available for carrier {provider.Type}."), returnShipment);
        }

        if (!connector.SupportsReturnLabels)
        {
            return (CarrierLabelResult.Permanent($"Carrier {provider.Type} does not support return labels."), returnShipment);
        }

        ReturnLabelRequest request;
        try
        {
            request = await BuildReturnLabelRequestAsync(returnShipment, cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            return (CarrierLabelResult.Permanent(ex.Message), returnShipment);
        }

        var carrierContext = _contextFactory.Create(provider, cancellationToken);
        var result = await connector.CreateReturnLabelAsync(carrierContext, request);

        if (!result.Success)
        {
            _logger.LogWarning("Return-label creation for return {ReturnId} via {Carrier} failed ({Kind}): {Error}",
                returnShipmentId, provider.Type, result.IsPermanentFailure ? "permanent" : "transient", result.ErrorMessage);
            return (result, returnShipment);
        }

        returnShipment.TrackingNumber = result.TrackingNumber ?? string.Empty;
        returnShipment.CarrierShipmentId = result.CarrierShipmentId;
        returnShipment.TrackingUrl = result.TrackingUrl;
        returnShipment.LabelData = result.LabelData;
        returnShipment.LabelFormat = result.LabelFormat;
        await _context.SaveChangesAsync(cancellationToken);

        await _statusUpdater.ApplyStatusAsync(returnShipment.Id, ReturnShipmentStatus.LabelCreated,
            description: "Return label created", cancellationToken: cancellationToken);

        _logger.LogInformation("Created {Carrier} return label for return {ReturnId}: tracking {TrackingNumber}",
            provider.Type, returnShipmentId, result.TrackingNumber);

        return (result, returnShipment);
    }

    public async Task<Result> CancelReturnLabelAsync(Guid returnShipmentId, CancellationToken cancellationToken = default)
    {
        var returnShipment = await _context.ReturnShipment
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(r => r.Id == returnShipmentId, cancellationToken);

        if (returnShipment is null)
        {
            return new Result { Succeeded = false, StatusCode = ResultStatusCode.BadRequest, Messages = [$"Return {returnShipmentId} not found."] };
        }

        _tenantContext.SetCurrentTenantId(returnShipment.TenantId);

        if (string.IsNullOrEmpty(returnShipment.CarrierShipmentId) || returnShipment.ShippingProviderId is null)
        {
            return new Result { Succeeded = true, StatusCode = ResultStatusCode.Ok };
        }

        var provider = await _context.ShippingProvider
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(p => p.Id == returnShipment.ShippingProviderId, cancellationToken);

        if (provider is null)
        {
            return new Result { Succeeded = false, StatusCode = ResultStatusCode.BadRequest, Messages = ["The shipping provider of this return no longer exists."] };
        }

        var connector = _registry.Resolve(provider.Type);
        if (connector is null)
        {
            return new Result { Succeeded = false, StatusCode = ResultStatusCode.BadRequest, Messages = [$"No connector is available for carrier {provider.Type}."] };
        }

        var carrierContext = _contextFactory.Create(provider, cancellationToken);
        var result = await connector.CancelShipmentAsync(carrierContext, returnShipment.CarrierShipmentId);

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

    /// <summary>Builds the carrier-agnostic request — the customer's delivery address is the return sender.</summary>
    private async Task<ReturnLabelRequest> BuildReturnLabelRequestAsync(
        Domain.Entities.ReturnShipment returnShipment, CancellationToken cancellationToken)
    {
        var sales = returnShipment.Sales;

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

        var customerName = $"{sales.DeliveryAddressFirstName} {sales.DeliveryAddressLastName}".Trim();
        if (string.IsNullOrWhiteSpace(customerName))
        {
            customerName = sales.DeliveryAddressCompanyName;
        }

        if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(sales.DeliveryAddressStreet)
            || string.IsNullOrWhiteSpace(sales.DeliveryAddressZip) || string.IsNullOrWhiteSpace(sales.DeliveryAddressCity))
        {
            throw new InvalidOperationException("The sales order's delivery address is incomplete.");
        }

        return new ReturnLabelRequest
        {
            ReturnShipmentId = returnShipment.Id,
            Reference = sales.SalesId.ToString(),
            CustomerName = customerName,
            CustomerCompany = string.IsNullOrWhiteSpace(sales.DeliveryAddressCompanyName) ? null : sales.DeliveryAddressCompanyName,
            CustomerPhone = string.IsNullOrWhiteSpace(sales.DeliveryAddressPhone) ? null : sales.DeliveryAddressPhone,
            Street = sales.DeliveryAddressStreet,
            City = sales.DeliveryAddressCity,
            Zip = sales.DeliveryAddressZip,
            CountryIsoCode = country.CountryCode.ToUpperInvariant(),
            WeightKg = 1m
        };
    }
}
