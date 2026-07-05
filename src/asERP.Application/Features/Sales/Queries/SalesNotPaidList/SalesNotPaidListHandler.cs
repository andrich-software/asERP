using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Queries.SalesNotPaidList;

public class SalesNotPaidListHandler : IRequestHandler<SalesNotPaidListQuery, PaginatedResult<SalesListDto>>
{
    private readonly IAppLogger<SalesNotPaidListHandler> _logger;
    private readonly ISalesRepository _salesRepository;

    // Statische Listen für Entity Framework Expression Trees
    private static readonly List<PaymentStatus> NotPaidStatuses = new()
    {
        PaymentStatus.Unknown,
        PaymentStatus.Invoiced,
        PaymentStatus.PartiallyPaid,
        PaymentStatus.FirstReminder,
        PaymentStatus.SecondReminder,
        PaymentStatus.ThirdReminder,
        PaymentStatus.Encashment,
        PaymentStatus.Reserved,
        PaymentStatus.Delayed,
        PaymentStatus.ReviewNecessary,
        PaymentStatus.NoCreditApproved,
        PaymentStatus.CreditPreliminarilyAccepted
    };

    private static readonly List<SalesStatus> ShippableStatuses = new()
    {
        SalesStatus.Pending,
        SalesStatus.Processing,
        SalesStatus.ReadyForDelivery,
        SalesStatus.OnHold
    };

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

    public SalesNotPaidListHandler(
        IAppLogger<SalesNotPaidListHandler> logger,
        ISalesRepository salesRepository)
    {
        _logger = logger;
        _salesRepository = salesRepository;
    }

    public async Task<PaginatedResult<SalesListDto>> Handle(SalesNotPaidListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handle SalesNotPaidListQuery: {0}", request);

        return await _salesRepository.Entities
            .Where(o => NotPaidStatuses.Contains(o.PaymentStatus) && ShippableStatuses.Contains(o.Status))
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
