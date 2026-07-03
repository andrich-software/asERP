using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Entities;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingCreate;

public class ShippingCreateHandler : IRequestHandler<ShippingCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingCreateHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly IShippingRepository _shippingRepository;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IShippingCarrierService _shippingCarrierService;

    public ShippingCreateHandler(
        IAppLogger<ShippingCreateHandler> logger,
        ISalesRepository salesRepository,
        IShippingRepository shippingRepository,
        IShippingProviderRateRepository shippingProviderRateRepository,
        ICountryRepository countryRepository,
        IShippingCarrierService shippingCarrierService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
        _shippingCarrierService = shippingCarrierService ?? throw new ArgumentNullException(nameof(shippingCarrierService));
    }

    public async Task<Result<Guid>> Handle(ShippingCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating shipment for sales {SalesId} with rate {RateId}",
            request.SalesId, request.ShippingProviderRateId);

        var result = new Result<Guid>();

        var validator = new ShippingCreateValidator(_salesRepository, _shippingProviderRateRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ShippingCreateCommand), validationErrors);

            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            var rate = await _shippingProviderRateRepository.GetWithCountriesAsync(request.ShippingProviderRateId);
            if (rate == null)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, "The shipping option does not exist.");
            }

            if (!rate.ShippingProvider.IsEnabled)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                    $"The shipping provider '{rate.ShippingProvider.Name}' is disabled.");
            }

            var sales = await _salesRepository.GetWithDetailsAsync(request.SalesId);
            if (sales == null)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, "The sales order does not exist.");
            }

            var destinationCheck = await ValidateDestinationCountryAsync(sales, rate);
            if (destinationCheck != null)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, destinationCheck);
            }

            var limitError = ValidateRateLimits(request, rate);
            if (limitError != null)
            {
                return Result<Guid>.Fail(ResultStatusCode.BadRequest, limitError);
            }

            var salesItems = new List<SalesItem>();
            foreach (var itemId in request.SalesItemIds.Distinct())
            {
                var item = sales.SalesItems.FirstOrDefault(i => i.Id == itemId);
                if (item == null)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {itemId} does not belong to this sales order.");
                }

                if (item.ShippingId != null)
                {
                    return Result<Guid>.Fail(ResultStatusCode.BadRequest,
                        $"Sales item {itemId} is already assigned to another shipment.");
                }

                salesItems.Add(item);
            }

            var shippingToCreate = new Domain.Entities.Shipping
            {
                SalesId = sales.Id,
                ShippingProviderId = rate.ShippingProviderId,
                ShippingProviderRateId = rate.Id,
                Status = ShippingStatus.Open,
                TrackingNumber = request.TrackingNumber ?? string.Empty,
                ShippingCost = request.ShippingCost ?? rate.Price,
                TaxRate = request.TaxRate,
                WeightKg = request.WeightKg,
                LengthCm = request.LengthCm,
                WidthCm = request.WidthCm,
                HeightCm = request.HeightCm,
                TenantId = sales.TenantId
            };

            await _shippingRepository.CreateAsync(shippingToCreate);

            // The sales aggregate is loaded untracked — stamp the items via a tracked update.
            await _shippingRepository.AssignSalesItemsAsync(
                shippingToCreate.Id,
                salesItems.Select(i => i.Id).ToList());

            await _salesRepository.AddSalesHistoryAsync(new SalesHistory
            {
                SalesId = sales.Id,
                UserId = Guid.Empty,
                TenantId = sales.TenantId,
                ShippingStatusOld = null,
                ShippingStatusNew = ShippingStatus.Open.ToString(),
                Description = $"Shipment created ({rate.ShippingProvider.Name} / {rate.Name})",
                IsSystemGenerated = false
            });

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Created;
            result.Data = shippingToCreate.Id;

            if (request.RequestLabel)
            {
                // The carrier service persists tracking number, label bytes and status itself;
                // on transient failure it queues a background retry. Label problems never fail
                // the shipment creation.
                var labelResult = await _shippingCarrierService.CreateLabelAsync(shippingToCreate.Id, cancellationToken);
                if (!labelResult.Succeeded)
                {
                    result.Messages.AddRange(labelResult.Messages);
                }
            }

            _logger.LogInformation("Successfully created shipment with ID: {Id}", shippingToCreate.Id);
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add($"An error occurred while creating the shipment: {ex.Message}");

            _logger.LogError("Error creating shipment: {Message}", ex.Message);
        }

        return result;
    }

    /// <summary>Resolves the order's free-text delivery country against the seeded country list and checks the rate allows it.</summary>
    private async Task<string?> ValidateDestinationCountryAsync(Domain.Entities.Sales sales, Domain.Entities.ShippingProviderRate rate)
    {
        var countryString = sales.DeliveryAddressCountry;
        if (string.IsNullOrWhiteSpace(countryString))
        {
            return "The sales order has no delivery country.";
        }

        var country = await _countryRepository.GetCountryByString(countryString);
        if (country == null)
        {
            return $"The delivery country '{countryString}' could not be resolved to a known country.";
        }

        if (rate.AllowedCountries.All(c => c.CountryId != country.Id))
        {
            return $"The shipping option '{rate.Name}' does not ship to '{country.Name}'.";
        }

        return null;
    }

    private static string? ValidateRateLimits(ShippingCreateCommand request, Domain.Entities.ShippingProviderRate rate)
    {
        if (request.WeightKg.HasValue && request.WeightKg.Value > rate.MaxWeight)
        {
            return $"The parcel weight ({request.WeightKg} kg) exceeds the option's maximum of {rate.MaxWeight} kg.";
        }

        if (request.LengthCm.HasValue && request.LengthCm.Value > rate.MaxLength)
        {
            return $"The parcel length ({request.LengthCm} cm) exceeds the option's maximum of {rate.MaxLength} cm.";
        }

        if (request.WidthCm.HasValue && request.WidthCm.Value > rate.MaxWidth)
        {
            return $"The parcel width ({request.WidthCm} cm) exceeds the option's maximum of {rate.MaxWidth} cm.";
        }

        if (request.HeightCm.HasValue && request.HeightCm.Value > rate.MaxHeight)
        {
            return $"The parcel height ({request.HeightCm} cm) exceeds the option's maximum of {rate.MaxHeight} cm.";
        }

        return null;
    }
}
