using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Queries.SalesCustomerList;

public class SalesCustomerListHandler : IRequestHandler<SalesCustomerListQuery, PaginatedResult<SalesListDto>>
{
    private readonly IAppLogger<SalesCustomerListHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalesCustomerListHandler(
        IAppLogger<SalesCustomerListHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<PaginatedResult<SalesListDto>> Handle(SalesCustomerListQuery request, CancellationToken cancellationToken)
    {
        var salesFilterSpec = new SalesCustomerFilterSpecification(request.CustomerId, request.SearchString);

        _logger.LogInformation("Handle SalesCustomerListQuery für Kunde {CustomerId}: {Request}", request.CustomerId, request);

        if (request.SalesBy.Any() != true)
        {
            return await _salesRepository.Entities
               .Specify(salesFilterSpec)
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
            .Specify(salesFilterSpec)
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