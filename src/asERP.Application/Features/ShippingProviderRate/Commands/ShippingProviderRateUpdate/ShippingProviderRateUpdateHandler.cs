using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateUpdate;

public class ShippingProviderRateUpdateHandler : IRequestHandler<ShippingProviderRateUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderRateUpdateHandler> _logger;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;
    private readonly ICountryRepository _countryRepository;

    public ShippingProviderRateUpdateHandler(
        IAppLogger<ShippingProviderRateUpdateHandler> logger,
        IShippingProviderRateRepository shippingProviderRateRepository,
        ICountryRepository countryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
        _countryRepository = countryRepository ?? throw new ArgumentNullException(nameof(countryRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderRateUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating shipping option with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            var existsGlobally = await _shippingProviderRateRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipping option not found: {Id}", request.Id);
                throw new NotFoundException("ShippingProviderRate", request.Id);
            }

            var rateToUpdate = await _shippingProviderRateRepository.GetByIdAsync(request.Id);
            if (rateToUpdate == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipping option {Id}", request.Id);
                throw new NotFoundException("ShippingProviderRate", request.Id);
            }

            // A shipping option cannot move to another carrier — its shipments were booked against this one.
            if (rateToUpdate.ShippingProviderId != request.ShippingProviderId)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.ShippingProviderRate.Invalid, "The shipping provider of an option cannot be changed. Create a new option instead.");
                return result;
            }

            rateToUpdate.Name = request.Name;
            rateToUpdate.Description = string.IsNullOrWhiteSpace(request.Description) ? null : request.Description.Trim();
            rateToUpdate.IsActive = request.IsActive;
            rateToUpdate.SortOrder = request.SortOrder;
            rateToUpdate.CarrierProduct = ShippingProviderRateCreate.ShippingProviderRateCreateHandler.NormalizeCode(request.CarrierProduct);
            rateToUpdate.CarrierProcedure = ShippingProviderRateCreate.ShippingProviderRateCreateHandler.NormalizeCode(request.CarrierProcedure);
            rateToUpdate.CarrierParticipation = ShippingProviderRateCreate.ShippingProviderRateCreateHandler.NormalizeCode(request.CarrierParticipation);
            rateToUpdate.MaxLength = request.MaxLength;
            rateToUpdate.MaxWidth = request.MaxWidth;
            rateToUpdate.MaxHeight = request.MaxHeight;
            rateToUpdate.MaxWeight = request.MaxWeight;
            rateToUpdate.Price = request.Price;

            await _shippingProviderRateRepository.UpdateAsync(rateToUpdate);
            await _shippingProviderRateRepository.ReplaceAllowedCountriesAsync(rateToUpdate.Id, request.AllowedCountryIds);

            result.Succeeded = true;
            result.Status = ResultStatus.Ok;
            result.Data = rateToUpdate.Id;

            _logger.LogInformation("Successfully updated shipping option with ID: {Id}", rateToUpdate.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }

        return result;
    }
}
