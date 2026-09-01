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

        var rateToCreate = new Domain.Entities.ShippingProviderRate
        {
            ShippingProviderId = request.ShippingProviderId,
            Name = request.Name,
            Description = string.IsNullOrWhiteSpace(request.Description) ? null : request.Description.Trim(),
            IsActive = request.IsActive,
            SortOrder = request.SortOrder,
            CarrierProduct = NormalizeCode(request.CarrierProduct),
            CarrierProcedure = NormalizeCode(request.CarrierProcedure),
            CarrierParticipation = NormalizeCode(request.CarrierParticipation),
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
        result.Status = ResultStatus.Created;
        return result;
    }

    /// <summary>Carrier codes are exact identifiers — trim whitespace, treat blank as "not set".</summary>
    internal static string? NormalizeCode(string? code)
        => string.IsNullOrWhiteSpace(code) ? null : code.Trim();
}
