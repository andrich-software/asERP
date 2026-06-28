using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Queries.SalesNotPaidList;

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

        if (request.SalesBy.Any() != true)
        {
            return await _salesRepository.Entities
               .Where(o => NotPaidStatuses.Contains(o.PaymentStatus) && ShippableStatuses.Contains(o.Status))
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
            .Where(o => NotPaidStatuses.Contains(o.PaymentStatus) && ShippableStatuses.Contains(o.Status))
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
