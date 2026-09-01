using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Dtos.CustomerAddress;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Queries.CustomerDetail;

/// <summary>
/// Handler for processing customer detail queries.
/// Implements IRequestHandler from the custom mediator to handle CustomerDetailQuery requests
/// and return detailed customer information wrapped in a Result.
/// </summary>
public class CustomerDetailHandler : IRequestHandler<CustomerDetailQuery, Result<CustomerDetailDto>>
{
    private readonly IAppLogger<CustomerDetailHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerDetailHandler(
        IAppLogger<CustomerDetailHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<CustomerDetailDto>> Handle(CustomerDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving customer details for ID: {Id}", request.Id);

        var result = new Result<CustomerDetailDto>();

        // Retrieve customer with all related details from the repository
        var customer = await _customerRepository.GetCustomerWithDetails(request.Id);

        // If customer not found, return a not found result
        if (customer == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Customer.NotFound, $"Customer with ID {request.Id} not found");

            _logger.LogWarning("Customer with ID {Id} not found", request.Id);
            return result;
        }

        // Manual mapping instead of using AutoMapper
        var data = new CustomerDetailDto
        {
            Id = customer.Id,
            CustomerId = customer.CustomerId,
            Firstname = customer.Firstname,
            Lastname = customer.Lastname,
            CompanyName = customer.CompanyName,
            Email = customer.Email,
            Phone = customer.Phone,
            Website = customer.Website,
            VatNumber = customer.VatNumber,
            Note = customer.Note,
            CustomerStatus = customer.CustomerStatus,
            DateEnrollment = customer.DateEnrollment,
            // Map customer addresses if they exist, otherwise return an empty list
            CustomerAddresses = customer.CustomerAddresses?.Select(ca => new CustomerAddressListDto
            {
                Id = ca.Id,
                Firstname = ca.Firstname,
                Lastname = ca.Lastname,
                CompanyName = ca.CompanyName,
                Street = ca.Street,
                HouseNr = ca.HouseNr,
                Zip = ca.Zip,
                City = ca.City,
                DefaultDeliveryAddress = ca.DefaultDeliveryAddress,
                DefaultInvoiceAddress = ca.DefaultInvoiceAddress,
                CountryId = ca.CountryId
            }).ToList() ?? new List<CustomerAddressListDto>()
        };

        // Set successful result with the customer details
        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = data;

        _logger.LogInformation("Customer with ID {Id} retrieved successfully", request.Id);

        return result;
    }
}
