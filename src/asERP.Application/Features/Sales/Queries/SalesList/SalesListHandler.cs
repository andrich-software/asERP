using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Features.Sales.Shared;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesList;

public class SalesListHandler : IRequestHandler<SalesListQuery, PaginatedResult<SalesListDto>>
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

    // Status sets behind the client's quick filter buttons. ReadyToShip and NotPaid live in
    // SalesQuickFilterPredicates, shared with the dedicated endpoints and the dashboard to-dos
    // so every view agrees on what it shows.
    private static readonly SalesStatus[] OpenStatuses =
    {
        SalesStatus.Pending,
        SalesStatus.Processing
    };

    private static readonly SalesStatus[] ProblemStatuses =
    {
        SalesStatus.OnHold,
        SalesStatus.Failed
    };

    private static readonly SalesStatus[] CancelledStatuses =
    {
        SalesStatus.Cancelled,
        SalesStatus.Returned,
        SalesStatus.Refunded
    };

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

        baseQuery = ApplyQuickFilter(baseQuery, request.Filter);

        return await baseQuery
            .ApplySafeOrdering(request.SortBy, AllowedSortFields)
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

    private static IQueryable<Domain.Entities.Sales> ApplyQuickFilter(IQueryable<Domain.Entities.Sales> query, SalesQuickFilter filter) => filter switch
    {
        SalesQuickFilter.ReadyToShip => query.Where(SalesQuickFilterPredicates.ReadyToShip()),
        SalesQuickFilter.Open => query.Where(o => OpenStatuses.Contains(o.Status)),
        SalesQuickFilter.NotPaid => query.Where(SalesQuickFilterPredicates.NotPaid()),
        SalesQuickFilter.PaymentOverdue => query.Where(SalesQuickFilterPredicates.PaymentOverdue(
            DateTime.UtcNow.Subtract(SalesQuickFilterPredicates.PaymentOverdueAfter))),
        SalesQuickFilter.Problems => query.Where(o => ProblemStatuses.Contains(o.Status)),
        SalesQuickFilter.Completed => query.Where(o => o.Status == SalesStatus.Completed),
        SalesQuickFilter.Cancelled => query.Where(o => CancelledStatuses.Contains(o.Status)),
        _ => query
    };
}
