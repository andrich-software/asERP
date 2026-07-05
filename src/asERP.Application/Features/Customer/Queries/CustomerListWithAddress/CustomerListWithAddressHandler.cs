using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Customer.Queries.CustomerListWithAddress;

public class CustomerListWithAddressHandler : IRequestHandler<CustomerListWithAddressQuery, PaginatedResult<CustomerListWithAddressDto>>
{
    // Restrict client-supplied ordering to the columns surfaced in the list DTO.
    // InvoiceAddress is a computed navigation projection with no direct entity property, so it is omitted.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Customer.Id),
        nameof(Domain.Entities.Customer.CustomerId),
        nameof(Domain.Entities.Customer.Firstname),
        nameof(Domain.Entities.Customer.Lastname),
        nameof(Domain.Entities.Customer.Email),
        nameof(Domain.Entities.Customer.DateEnrollment)
    };

    private readonly IAppLogger<CustomerListWithAddressHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerListWithAddressHandler(
        IAppLogger<CustomerListWithAddressHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
    }

    public async Task<PaginatedResult<CustomerListWithAddressDto>> Handle(CustomerListWithAddressQuery request, CancellationToken cancellationToken)
    {
        var customerFilterSpec = new CustomerFilterSpecification(request.SearchString);

        _logger.LogInformation("CustomerListWithAddressHandler.Handle: Retrieving customers with address.");

        var baseQuery = _customerRepository.Entities
            .Specify(customerFilterSpec)
            .Include(c => c.CustomerAddresses);

        return await baseQuery
            .ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            .Select(c => new CustomerListWithAddressDto
            {
                Id = c.Id,
                CustomerId = c.CustomerId,
                Firstname = c.Firstname,
                Lastname = c.Lastname,
                Email = c.Email,
                InvoiceAddress = c.CustomerAddresses != null
                    ? c.CustomerAddresses
                        .Where(a => a.DefaultInvoiceAddress)
                        .Select(a => a.Street + " " + a.HouseNr + ", " + a.Zip + " " + a.City)
                        .FirstOrDefault() ?? ""
                    : "",
                DateEnrollment = c.DateEnrollment
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
