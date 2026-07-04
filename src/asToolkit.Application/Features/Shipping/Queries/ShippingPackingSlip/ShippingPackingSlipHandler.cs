using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingPackingSlip;

public class ShippingPackingSlipHandler : IRequestHandler<ShippingPackingSlipQuery, Result<ShippingLabelDto>>
{
    private readonly IAppLogger<ShippingPackingSlipHandler> _logger;
    private readonly IShippingDocumentDataService _documentDataService;
    private readonly IPdfService _pdfService;

    public ShippingPackingSlipHandler(
        IAppLogger<ShippingPackingSlipHandler> logger,
        IShippingDocumentDataService documentDataService,
        IPdfService pdfService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _documentDataService = documentDataService ?? throw new ArgumentNullException(nameof(documentDataService));
        _pdfService = pdfService ?? throw new ArgumentNullException(nameof(pdfService));
    }

    public async Task<Result<ShippingLabelDto>> Handle(ShippingPackingSlipQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Generating packing slip for shipment {Id}", request.Id);

        var data = await _documentDataService.GetPackingSlipDataAsync(request.Id, cancellationToken);
        if (data == null)
        {
            _logger.LogWarning("Shipment not found: {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        var pdfBytes = _pdfService.GeneratePackingSlip(data);

        var fileNamePart = string.IsNullOrEmpty(data.TrackingNumber)
            ? request.Id.ToString("N")
            : data.TrackingNumber;

        var dto = new ShippingLabelDto
        {
            Data = pdfBytes,
            ContentType = "application/pdf",
            FileName = $"packliste-{data.SalesNumber}-{fileNamePart}.pdf"
        };

        return Result<ShippingLabelDto>.Success(dto);
    }
}
