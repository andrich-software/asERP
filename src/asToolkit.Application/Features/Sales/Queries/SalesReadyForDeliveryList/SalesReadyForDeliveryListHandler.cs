using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Queries.SalesReadyForDeliveryList;

public class SalesReadyForDeliveryListHandler : IRequestHandler<SalesReadyForDeliveryListQuery, PaginatedResult<SalesListDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await _salesRepository.Entities
               .Where(o => o.Status == SalesStatus.ReadyForDelivery && o.PaymentStatus == PaymentStatus.CompletelyPaid)
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

        var salesing = string.Join(",", request.SalesBy);

        return await _salesRepository.Entities
            .Where(o => o.Status == SalesStatus.ReadyForDelivery && o.PaymentStatus == PaymentStatus.CompletelyPaid)
            .OrderBy(salesing)
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