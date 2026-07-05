using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Returns.Queries.ReturnLabel;

public class ReturnLabelHandler : IRequestHandler<ReturnLabelQuery, Result<ShippingLabelDto>>
{
    private readonly IAppLogger<ReturnLabelHandler> _logger;
    private readonly IReturnShipmentRepository _returnShipmentRepository;

    public ReturnLabelHandler(
        IAppLogger<ReturnLabelHandler> logger,
        IReturnShipmentRepository returnShipmentRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _returnShipmentRepository = returnShipmentRepository ?? throw new ArgumentNullException(nameof(returnShipmentRepository));
    }

    public async Task<Result<ShippingLabelDto>> Handle(ReturnLabelQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving label for return {Id}", request.Id);

        var returnShipment = await _returnShipmentRepository.GetByIdAsync(request.Id, asNoTracking: true);
        if (returnShipment == null)
        {
            _logger.LogWarning("Return not found: {Id}", request.Id);
            throw new NotFoundException("ReturnShipment", request.Id);
        }

        if (returnShipment.LabelData is not { Length: > 0 })
        {
            return Result<ShippingLabelDto>.Fail(ResultStatusCode.NotFound, "No label has been created for this return yet.");
        }

        var extension = returnShipment.LabelFormat switch
        {
            "application/pdf" or null => "pdf",
            "image/gif" => "gif",
            "image/png" => "png",
            _ => "bin"
        };

        var fileNamePart = string.IsNullOrEmpty(returnShipment.TrackingNumber)
            ? returnShipment.Id.ToString("N")
            : returnShipment.TrackingNumber;

        var data = new ShippingLabelDto
        {
            Data = returnShipment.LabelData,
            ContentType = returnShipment.LabelFormat ?? "application/pdf",
            FileName = $"return-label-{fileNamePart}.{extension}"
        };

        return Result<ShippingLabelDto>.Success(data);
    }
}
