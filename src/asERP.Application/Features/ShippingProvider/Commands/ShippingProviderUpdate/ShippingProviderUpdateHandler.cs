using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
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

        var result = new Result<Guid>();

        var validator = new ShippingProviderUpdateValidator(_shippingProviderRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(ShippingProviderUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

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
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("The provider type cannot be changed. Create a new shipping provider instead.");
                return result;
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

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = providerToUpdate.Id;

            _logger.LogInformation("Successfully updated shipping provider with ID: {Id}", providerToUpdate.Id);
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while updating the shipping provider.",
                "Error updating shipping provider {Id}.", request.Id);
        }

        return result;
    }
}
