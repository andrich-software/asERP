using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Exceptions;
using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Shipping.Queries.ShippingPickList;

public class ShippingPickListHandler : IRequestHandler<ShippingPickListQuery, Result<ShippingLabelDto>>
{
    private readonly IAppLogger<ShippingPickListHandler> _logger;
    private readonly IShippingDocumentDataService _documentDataService;
    private readonly IPdfService _pdfService;

    public ShippingPickListHandler(
        IAppLogger<ShippingPickListHandler> logger,
        IShippingDocumentDataService documentDataService,
        IPdfService pdfService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _documentDataService = documentDataService ?? throw new ArgumentNullException(nameof(documentDataService));
        _pdfService = pdfService ?? throw new ArgumentNullException(nameof(pdfService));
    }

    public async Task<Result<ShippingLabelDto>> Handle(ShippingPickListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Generating pick list for shipment {Id}", request.Id);

        var data = await _documentDataService.GetPickListDataAsync(new[] { request.Id }, cancellationToken);
        if (data == null)
        {
            _logger.LogWarning("Shipment not found: {Id}", request.Id);
            throw new NotFoundException("Shipping", request.Id);
        }

        var pdfBytes = _pdfService.GeneratePickList(data);

        var salesNumberPart = data.SalesNumbers.Count > 0
            ? data.SalesNumbers[0].ToString()
            : "0";

        var dto = new ShippingLabelDto
        {
            Data = pdfBytes,
            ContentType = "application/pdf",
            FileName = $"pickliste-{salesNumberPart}-{request.Id:N}.pdf"
        };

        return Result<ShippingLabelDto>.Success(dto);
    }
}
