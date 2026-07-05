using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderDelete;

public class ShippingProviderDeleteHandler : IRequestHandler<ShippingProviderDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderDeleteHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;
    private readonly IShippingProviderRateRepository _shippingProviderRateRepository;

    public ShippingProviderDeleteHandler(
        IAppLogger<ShippingProviderDeleteHandler> logger,
        IShippingProviderRepository shippingProviderRepository,
        IShippingProviderRateRepository shippingProviderRateRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
        _shippingProviderRateRepository = shippingProviderRateRepository ?? throw new ArgumentNullException(nameof(shippingProviderRateRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting shipping provider with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        try
        {
            var existsGlobally = await _shippingProviderRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipping provider not found: {Id}", request.Id);
                throw new NotFoundException("ShippingProvider", request.Id);
            }

            var providerToDelete = await _shippingProviderRepository.GetByIdAsync(request.Id);
            if (providerToDelete == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipping provider {Id}", request.Id);
                throw new NotFoundException("ShippingProvider", request.Id);
            }

            // Shipments are order history — never orphan them by deleting their provider.
            if (await _shippingProviderRepository.HasShipmentsAsync(request.Id))
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("The shipping provider cannot be deleted because shipments reference it. Disable it instead.");
                return result;
            }

            // Cascade explicitly (repo rule: no EF cascade deletes): country joins, then rates, then provider.
            var rates = await _shippingProviderRateRepository.GetByProviderAsync(request.Id);
            foreach (var rate in rates)
            {
                await _shippingProviderRateRepository.ReplaceAllowedCountriesAsync(rate.Id, Array.Empty<Guid>());
                await _shippingProviderRateRepository.DeleteAsync(rate);
            }

            await _shippingProviderRepository.DeleteAsync(providerToDelete);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.NoContent;
            result.Data = request.Id;

            _logger.LogInformation("Successfully deleted shipping provider with ID: {Id}", request.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while deleting the shipping provider.",
                "Error deleting shipping provider {Id}.", request.Id);
        }

        return result;
    }
}
