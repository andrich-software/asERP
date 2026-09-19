using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProviderRate.Commands.ShippingProviderRateDelete;

public class ShippingProviderRateDeleteHandler : IRequestHandler<ShippingProviderRateDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderRateDeleteHandler> _logger;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;

    public ShippingProviderRateDeleteHandler(
        IAppLogger<ShippingProviderRateDeleteHandler> logger,
        IShippingProviderRateRepository shippingProviderRateRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderRateDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting shipping option with ID: {Id}", request.Id);

        try
        {
            var existsGlobally = await _shippingProviderRateRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipping option not found: {Id}", request.Id);
                throw new NotFoundException("ShippingProviderRate", request.Id);
            }

            var rateToDelete = await _shippingProviderRateRepository.GetByIdAsync(request.Id);
            if (rateToDelete == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipping option {Id}", request.Id);
                throw new NotFoundException("ShippingProviderRate", request.Id);
            }

            if (await _shippingProviderRateRepository.HasShipmentsAsync(request.Id))
            {
                return Result<Guid>.Invalid(ErrorCodes.ShippingProviderRate.Invalid, "The shipping option cannot be deleted because shipments reference it.");
            }

            // Cascade explicitly (repo rule: no EF cascade deletes): country joins, then the rate.
            await _shippingProviderRateRepository.ReplaceAllowedCountriesAsync(request.Id, Array.Empty<Guid>());
            await _shippingProviderRateRepository.DeleteAsync(rateToDelete);

            _logger.LogInformation("Successfully deleted shipping option with ID: {Id}", request.Id);
            return Result<Guid>.NoContent(request.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }

    }
}
