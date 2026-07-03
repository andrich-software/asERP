using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Commands.ShippingLabelRetry;

public class ShippingLabelRetryHandler : IRequestHandler<ShippingLabelRetryCommand, Result<Guid>>
{
    private readonly IAppLogger<ShippingLabelRetryHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly IShippingCarrierService _shippingCarrierService;

    public ShippingLabelRetryHandler(
        IAppLogger<ShippingLabelRetryHandler> logger,
        IShippingRepository shippingRepository,
        IShippingCarrierService shippingCarrierService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _shippingCarrierService = shippingCarrierService ?? throw new ArgumentNullException(nameof(shippingCarrierService));
    }

    public async Task<Result<Guid>> Handle(ShippingLabelRetryCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrying label creation for shipment {Id}", request.Id);

        var result = new Result<Guid>();

        var existsGlobally = await _shippingRepository.ExistsGloballyAsync(request.Id);
        if (!existsGlobally)
        {
            _logger.LogWarning("Shipment not found: {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        var shipping = await _shippingRepository.GetByIdAsync(request.Id, asNoTracking: true);
        if (shipping == null)
        {
            _logger.LogWarning("Cross-tenant access attempt for shipment {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        if (shipping.LabelData is { Length: > 0 })
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.Add("The shipment already has a label.");
            return result;
        }

        var labelResult = await _shippingCarrierService.CreateLabelAsync(request.Id, cancellationToken);

        result.Succeeded = labelResult.Succeeded;
        result.StatusCode = labelResult.Succeeded ? ResultStatusCode.Ok : labelResult.StatusCode;
        result.Messages.AddRange(labelResult.Messages);
        result.Data = request.Id;

        return result;
    }
}
