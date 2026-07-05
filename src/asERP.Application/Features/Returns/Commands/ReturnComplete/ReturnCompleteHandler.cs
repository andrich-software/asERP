using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Commands.ReturnComplete;

public class ReturnCompleteHandler : IRequestHandler<ReturnCompleteCommand, Result<Guid>>
{
    private readonly IAppLogger<ReturnCompleteHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;
    private readonly IReturnStatusUpdater _returnStatusUpdater;

    public ReturnCompleteHandler(
        IAppLogger<ReturnCompleteHandler> logger,
        IReturnShipmentRepository returnShipmentRepository,
        IReturnStatusUpdater returnStatusUpdater)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
        _returnStatusUpdater = returnStatusUpdater ?? throw new ArgumentNullException(nameof(returnStatusUpdater));
    }

    public async Task<Result<Guid>> Handle(ReturnCompleteCommand request, CancellationToken cancellationToken)
    {
        var targetStatus = request.Reject ? ReturnShipmentStatus.Rejected : ReturnShipmentStatus.Completed;
        _logger.LogInformation("Closing return {Id} as {Status}", request.Id, targetStatus);

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

        if (returnShipment.Status != ReturnShipmentStatus.Received)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.Add($"Only a received return can be closed; this one is {returnShipment.Status}.");
            return result;
        }

        var statusResult = await _returnStatusUpdater.ApplyStatusAsync(
            returnShipment.Id, targetStatus, cancellationToken: cancellationToken);

        result.Succeeded = statusResult.Succeeded;
        result.StatusCode = statusResult.Succeeded ? ResultStatusCode.Ok : statusResult.StatusCode;
        result.Messages.AddRange(statusResult.Messages);
        result.Data = request.Id;

        return result;
    }
}
