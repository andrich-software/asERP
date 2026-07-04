using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Specifications;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Customer.Queries.CustomerListWithAddress;

public class CustomerListWithAddressHandler : IRequestHandler<CustomerListWithAddressQuery, PaginatedResult<CustomerListWithAddressDto>>
{
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

        if (request.SalesBy.Any() != true)
        {
            return await baseQuery
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

        var salesing = string.Join(",", request.SalesBy);

        return await baseQuery
            .OrderBy(salesing)
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
