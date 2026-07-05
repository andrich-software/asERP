using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesReadyForDeliveryList;

public class SalesReadyForDeliveryListHandler : IRequestHandler<SalesReadyForDeliveryListQuery, PaginatedResult<SalesListDto>>
{
    // Only columns surfaced in SalesListDto are sortable; client sort terms outside this set are ignored.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Sales.Id),
        nameof(Domain.Entities.Sales.SalesId),
        nameof(Domain.Entities.Sales.CustomerId),
        nameof(Domain.Entities.Sales.InvoiceAddressFirstName),
        nameof(Domain.Entities.Sales.InvoiceAddressLastName),
        nameof(Domain.Entities.Sales.Total),
        nameof(Domain.Entities.Sales.Status),
        nameof(Domain.Entities.Sales.PaymentStatus),
        nameof(Domain.Entities.Sales.DateSalesed)
    };

    private readonly IAppLogger<SalesReadyForDeliveryListHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalesReadyForDeliveryListHandler(
        IAppLogger<SalesReadyForDeliveryListHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<PaginatedResult<SalesListDto>> Handle(SalesReadyForDeliveryListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle SalesReadyForDeliveryListQuery: {0}", request);

        return await _salesRepository.Entities
            .Where(o => o.Status == SalesStatus.ReadyForDelivery && o.PaymentStatus == PaymentStatus.CompletelyPaid)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(o => new SalesListDto
            {
                Id = o.Id,
                SalesId = o.SalesId,
                CustomerId = o.CustomerId,
                InvoiceAddressFirstName = o.InvoiceAddressFirstName,
                InvoiceAddressLastName = o.InvoiceAddressLastName,
                Total = o.Total,
                Status = o.Status,
                PaymentStatus = o.PaymentStatus,
                DateSalesed = o.DateSalesed
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
