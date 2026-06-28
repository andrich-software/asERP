using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Application.Specifications;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Queries.SalesList;

public class SalesListHandler : IRequestHandler<SalesListQuery, PaginatedResult<SalesListDto>>
{
    private readonly IAppLogger<SalesListHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    public SalesListHandler(
        IAppLogger<SalesListHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<PaginatedResult<SalesListDto>> Handle(SalesListQuery request, CancellationToken cancellationToken)
    {
        var salesFilterSpec = new SalesFilterSpecification(request.SearchString);

        _logger.LogInformation("Handle SalesListQuery: {0}", request);

        var baseQuery = _salesRepository.Entities
            .Specify(salesFilterSpec);

        if (request.SalesChannelId.HasValue)
            baseQuery = baseQuery.Where(o => o.SalesChannelId == request.SalesChannelId.Value);

        if (request.SalesBy.Any() != true)
        {
            return await baseQuery
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

        return await baseQuery
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