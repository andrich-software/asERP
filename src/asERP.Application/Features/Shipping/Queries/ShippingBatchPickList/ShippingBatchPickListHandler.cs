using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Services;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Shipping.Queries.ShippingBatchPickList;

public class ShippingBatchPickListHandler : IRequestHandler<ShippingBatchPickListQuery, Result<ShippingLabelDto>>
{
    private readonly IAppLogger<ShippingBatchPickListHandler> _logger;
    private readonly IShippingDocumentDataService _documentDataService;
    private readonly IPdfService _pdfService;

    public ShippingBatchPickListHandler(
        IAppLogger<ShippingBatchPickListHandler> logger,
        IShippingDocumentDataService documentDataService,
        IPdfService pdfService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _documentDataService = documentDataService ?? throw new ArgumentNullException(nameof(documentDataService));
        _pdfService = pdfService ?? throw new ArgumentNullException(nameof(pdfService));
    }

    public async Task<Result<ShippingLabelDto>> Handle(ShippingBatchPickListQuery request, CancellationToken cancellationToken)
    {
        var ids = request.Ids.Where(id => id != Guid.Empty).Distinct().ToArray();
        if (ids.Length == 0)
        {
            var invalid = new Result<ShippingLabelDto>
            {
                Succeeded = false,
                StatusCode = ResultStatusCode.BadRequest
            };
            invalid.Messages.Add("At least one shipping id is required");
            return invalid;
        }

        _logger.LogInformation("Generating batch pick list for {Count} shipments", ids.Length);

        var data = await _documentDataService.GetPickListDataAsync(ids, cancellationToken);
        if (data == null)
        {
            _logger.LogWarning("None of the requested shipments were found");
            throw new NotFoundException("Shipping", string.Join(",", ids));
        }

        var pdfBytes = _pdfService.GeneratePickList(data);

        var dto = new ShippingLabelDto
        {
            Data = pdfBytes,
            ContentType = "application/pdf",
            FileName = $"pickliste-sammel-{data.SalesNumbers.Count}-bestellungen.pdf"
        };

        return Result<ShippingLabelDto>.Success(dto);
    }
}
