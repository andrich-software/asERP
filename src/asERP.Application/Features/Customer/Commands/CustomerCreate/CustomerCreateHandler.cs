using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Commands.CustomerCreate;

/// <summary>
/// Handler for processing customer creation commands.
/// Implements IRequestHandler from custom mediator to handle CustomerCreateCommand requests
/// and return the ID of the newly created customer wrapped in a Result.
/// </summary>
public class CustomerCreateHandler : IRequestHandler<CustomerCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<CustomerCreateHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerCreateHandler(
        IAppLogger<CustomerCreateHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<Guid>> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new customer with firstname: {Firstname}, lastname: {Lastname}",
            request.Firstname, request.Lastname);

        // Manual mapping instead of using AutoMapper
        var customerToCreate = new Domain.Entities.Customer
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            CompanyName = request.CompanyName,
            Email = request.Email,
            Phone = request.Phone,
            Website = request.Website,
            VatNumber = request.VatNumber,
            Note = request.Note,
            CustomerStatus = request.CustomerStatus,
            DateEnrollment = request.DateEnrollment
            // CustomerAddresses would require additional mapping logic
        };

        // Add the new customer to the database
        await _customerRepository.CreateAsync(customerToCreate);

        _logger.LogInformation("Successfully created customer with ID: {Id}", customerToCreate.Id);

        var result = Result<Guid>.Success(customerToCreate.Id);
        result.Status = ResultStatus.Created;
        return result;
    }
}
