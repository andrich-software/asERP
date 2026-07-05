using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Queries.CustomerList;

public class CustomerListHandler : IRequestHandler<CustomerListQuery, PaginatedResult<CustomerListDto>>
{
    // Only columns exposed in CustomerListDto are sortable; anything else is ignored so clients
    // cannot sort by (and thereby probe) non-projected or secret entity columns.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Customer.Id),
        nameof(Domain.Entities.Customer.CustomerId),
        nameof(Domain.Entities.Customer.Firstname),
        nameof(Domain.Entities.Customer.Lastname),
        nameof(Domain.Entities.Customer.DateEnrollment)
    };

    private readonly IAppLogger<CustomerListHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerListHandler(
        IAppLogger<CustomerListHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }
    public async Task<PaginatedResult<CustomerListDto>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
    {
        var customerFilterSpec = new CustomerFilterSpecification(request.SearchString);

        _logger.LogInformation("CustomerListHandler.Handle: Retrieving customers.");

        return await _customerRepository.Entities
            .Specify(customerFilterSpec)
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(c => new CustomerListDto
            {
                Id = c.Id,
                CustomerId = c.CustomerId,
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                DateEnrollment = c.DateEnrollment
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}
