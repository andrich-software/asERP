using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShippingProvider.Commands.ShippingProviderCreate;

public class ShippingProviderCreateHandler : IRequestHandler<ShippingProviderCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingProviderCreateHandler> _logger;
    private readonly IShippingProviderRepository _shippingProviderRepository;

    public ShippingProviderCreateHandler(
        IAppLogger<ShippingProviderCreateHandler> logger,
        IShippingProviderRepository shippingProviderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingProviderRepository = shippingProviderRepository ?? throw new ArgumentNullException(nameof(shippingProviderRepository));
    }

    public async Task<Result<Guid>> Handle(ShippingProviderCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating shipping provider {Name} ({Type})", request.Name, request.Type);

        var validator = new ShippingProviderCreateValidator(_shippingProviderRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var validationErrors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in create request for {0}: {1}",
                nameof(ShippingProviderCreateCommand), validationErrors);

            return Result<Guid>.Fail(ResultStatusCode.BadRequest, validationErrors);
        }

        try
        {
            var providerToCreate = new Domain.Entities.ShippingProvider
            {
                Name = request.Name,
                Type = request.Type,
                IsEnabled = request.IsEnabled,
                UseSandbox = request.UseSandbox,
                Username = request.Username,
                Password = request.Password,
                ApiKey = request.ApiKey,
                ApiSecret = request.ApiSecret,
                AccountNumber = request.AccountNumber,
                AdditionalConfigJson = request.AdditionalConfigJson,
                TrackingPollIntervalSeconds = request.TrackingPollIntervalSeconds
            };

            await _shippingProviderRepository.CreateAsync(providerToCreate);

            _logger.LogInformation("Successfully created shipping provider with ID: {Id}", providerToCreate.Id);

            var result = Result<Guid>.Success(providerToCreate.Id);
            result.StatusCode = ResultStatusCode.Created;
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error creating shipping provider: {Message}", ex.Message);

            return Result<Guid>.Fail(ResultStatusCode.InternalServerError,
                $"An error occurred while creating the shipping provider: {ex.Message}");
        }
    }
}
