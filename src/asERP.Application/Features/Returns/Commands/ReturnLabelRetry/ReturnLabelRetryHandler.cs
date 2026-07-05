using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnLabelRetry;

public class ReturnLabelRetryHandler : IRequestHandler<ReturnLabelRetryCommand, Result<Guid>>
{
    private readonly IAppLogger<ReturnLabelRetryHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IReturnCarrierService _returnCarrierService;

    public ReturnLabelRetryHandler(
        IAppLogger<ReturnLabelRetryHandler> logger,
        IReturnShipmentRepository returnShipmentRepository,
        IReturnCarrierService returnCarrierService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _returnCarrierService = returnCarrierService ?? throw new ArgumentNullException(nameof(returnCarrierService));
    }

    public async Task<Result<Guid>> Handle(ReturnLabelRetryCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrying return-label creation for return {Id}", request.Id);

        var result = new Result<Guid>();

        var existsGlobally = await _returnShipmentRepository.ExistsGloballyAsync(request.Id);
        if (!existsGlobally)
        {
            _logger.LogWarning("Return not found: {Id}", request.Id);
            throw new NotFoundException("ReturnShipment", request.Id);
        }

        var returnShipment = await _returnShipmentRepository.GetByIdAsync(request.Id, asNoTracking: true);
        if (returnShipment == null)
        {
            _logger.LogWarning("Cross-tenant access attempt for return {Id}", request.Id);
            throw new NotFoundException("ReturnShipment", request.Id);
        }

        if (returnShipment.LabelData is { Length: > 0 })
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.Add("The return already has a label.");
            return result;
        }

        var labelResult = await _returnCarrierService.CreateReturnLabelAsync(request.Id, cancellationToken);

        result.Succeeded = labelResult.Succeeded;
        result.StatusCode = labelResult.Succeeded ? ResultStatusCode.Ok : labelResult.StatusCode;
        result.Messages.AddRange(labelResult.Messages);
        result.Data = request.Id;

        return result;
    }
}
