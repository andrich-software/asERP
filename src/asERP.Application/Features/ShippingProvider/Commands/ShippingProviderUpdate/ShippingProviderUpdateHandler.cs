using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderUpdate;

public class ShippingProviderUpdateHandler : IRequestHandler<ShippingProviderUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderUpdateHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;

    public ShippingProviderUpdateHandler(
        IAppLogger<ShippingProviderUpdateHandler> logger,
        IShippingProviderRepository shippingProviderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating shipping provider with ID: {Id}", request.Id);

        try
        {
            var existsGlobally = await _shippingProviderRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                _logger.LogWarning("Shipping provider not found: {Id}", request.Id);
                throw new NotFoundException("ShippingProvider", request.Id);
            }

            var providerToUpdate = await _shippingProviderRepository.GetByIdAsync(request.Id);
            if (providerToUpdate == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for shipping provider {Id}", request.Id);
                throw new NotFoundException("ShippingProvider", request.Id);
            }

            // The carrier is part of the provider's identity — shipments and labels were created
            // against it. A different carrier means a new provider.
            if (providerToUpdate.Type != request.Type)
            {
                return Result<Guid>.Invalid(ErrorCodes.ShippingProvider.Invalid, "The provider type cannot be changed. Create a new shipping provider instead.");
            }

            providerToUpdate.Name = request.Name;
            providerToUpdate.IsEnabled = request.IsEnabled;
            providerToUpdate.UseSandbox = request.UseSandbox;
            providerToUpdate.Username = request.Username;
            providerToUpdate.AccountNumber = request.AccountNumber;
            providerToUpdate.AdditionalConfigJson = request.AdditionalConfigJson;
            providerToUpdate.TrackingPollIntervalSeconds = request.TrackingPollIntervalSeconds;

            // Secrets are never round-tripped to the client — empty means "keep the stored value".
            if (!string.IsNullOrEmpty(request.Password))
            {
                providerToUpdate.Password = request.Password;
            }

            if (!string.IsNullOrEmpty(request.ApiKey))
            {
                providerToUpdate.ApiKey = request.ApiKey;
            }

            if (!string.IsNullOrEmpty(request.ApiSecret))
            {
                providerToUpdate.ApiSecret = request.ApiSecret;
            }

            await _shippingProviderRepository.UpdateAsync(providerToUpdate);

            _logger.LogInformation("Successfully updated shipping provider with ID: {Id}", providerToUpdate.Id);
            return Result<Guid>.Ok(providerToUpdate.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }

    }
}
