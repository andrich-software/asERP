using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingLabel;

public class ShippingLabelHandler : IRequestHandler<ShippingLabelQuery, Result<ShippingLabelDto>>
{
    private readonly IAppLogger<ShippingLabelHandler> _logger;
    private readonly IShippingRepository _shippingRepository;

    public ShippingLabelHandler(
        IAppLogger<ShippingLabelHandler> logger,
        IShippingRepository shippingRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
    }

    public async Task<Result<ShippingLabelDto>> Handle(ShippingLabelQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving label for shipment {Id}", request.Id);

        var shipping = await _shippingRepository.GetByIdAsync(request.Id, asNoTracking: true);
        if (shipping == null)
        {
            _logger.LogWarning("Shipment not found: {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        if (shipping.LabelData is not { Length: > 0 })
        {
            return Result<ShippingLabelDto>.Fail(ResultStatusCode.NotFound, "No label has been created for this shipment yet.");
        }

        var extension = shipping.LabelFormat switch
        {
            "application/pdf" or null => "pdf",
            "image/gif" => "gif",
            "image/png" => "png",
            _ => "bin"
        };

        var fileNamePart = string.IsNullOrEmpty(shipping.TrackingNumber)
            ? shipping.Id.ToString("N")
            : shipping.TrackingNumber;

        var data = new ShippingLabelDto
        {
            Data = shipping.LabelData,
            ContentType = shipping.LabelFormat ?? "application/pdf",
            FileName = $"label-{fileNamePart}.{extension}"
        };

        return Result<ShippingLabelDto>.Success(data);
    }
}
