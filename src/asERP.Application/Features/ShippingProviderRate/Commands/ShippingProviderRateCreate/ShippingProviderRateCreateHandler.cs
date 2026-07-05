using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateCreate;

public class ShippingProviderRateCreateHandler : IRequestHandler<ShippingProviderRateCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderRateCreateHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;
    private readonly ICountryRepository _countryRepository;

    public ShippingProviderRateCreateHandler(
        IAppLogger<ShippingProviderRateCreateHandler> logger,
        IShippingProviderRepository shippingProviderRepository,
        IShippingProviderRateRepository shippingProviderRateRepository,
        ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderRateCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating shipping option {Name} for provider {ProviderId}",
            request.Name, request.ShippingProviderId);

        var validator = new ShippingProviderRateCreateValidator(
            _shippingProviderRepository, _shippingProviderRateRepository, _countryRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ShippingProviderRateCreateCommand), validationErrors);

            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            var rateToCreate = new Domain.Entities.ShippingProviderRate
            {
                ShippingProviderId = request.ShippingProviderId,
                Name = request.Name,
                MaxLength = request.MaxLength,
                MaxWidth = request.MaxWidth,
                MaxHeight = request.MaxHeight,
                MaxWeight = request.MaxWeight,
                Price = request.Price
            };

            await _shippingProviderRateRepository.CreateAsync(rateToCreate);
            await _shippingProviderRateRepository.ReplaceAllowedCountriesAsync(rateToCreate.Id, request.AllowedCountryIds);

            _logger.LogInformation("Successfully created shipping option with ID: {Id}", rateToCreate.Id);

            var result = Result<Guid>.Success(rateToCreate.Id);
            result.StatusCode = ResultStatusCode.Created;
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating shipping option");

            return Result<Guid>.Fail(ResultStatusCode.InternalServerError,
                "An error occurred while creating the shipping option.");
        }
    }
}
