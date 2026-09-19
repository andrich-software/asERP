using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Commands.CustomerUpdate;

public class CustomerUpdateHandler : IRequestHandler<CustomerUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<CustomerUpdateHandler> _logger;
    private readonly ICustomerRepository _customerRepository;

    public CustomerUpdateHandler(
        IAppLogger<CustomerUpdateHandler> logger,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<Guid>> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating customer with ID: {Id}", request.Id);

        // Get the customer for tracking (required for update)
        var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);

        if (customerToUpdate == null)
        {
            _logger.LogWarning("Customer with ID {Id} not found or access denied due to tenant isolation", request.Id);
            return Result<Guid>.NotFound(ErrorCodes.Customer.NotFound, "Customer not found or access denied due to tenant isolation.");
        }

        // Manual assignment of properties
        customerToUpdate.Firstname = request.Firstname;
        customerToUpdate.Lastname = request.Lastname;
        customerToUpdate.CompanyName = request.CompanyName;
        customerToUpdate.Email = request.Email;
        customerToUpdate.Phone = request.Phone;
        customerToUpdate.Website = request.Website;
        customerToUpdate.VatNumber = request.VatNumber;
        customerToUpdate.Note = request.Note;
        customerToUpdate.CustomerStatus = request.CustomerStatus;
        customerToUpdate.DateEnrollment = request.DateEnrollment;

        // Update CustomerAddresses if available
        if (request.CustomerAddresses.Any())
        {
            // Load existing addresses
            var existingAddresses = await _customerRepository.GetCustomerAddressByCustomerIdAsync(request.Id);

            foreach (var addressDto in request.CustomerAddresses)
            {
                // Search for existing address
                var existingAddress = existingAddresses.FirstOrDefault(a => a.Id == addressDto.Id);

                if (existingAddress != null)
                {
                    // Update existing address
                    existingAddress.Firstname = addressDto.Firstname;
                    existingAddress.Lastname = addressDto.Lastname;
                    existingAddress.CompanyName = addressDto.CompanyName;
                    existingAddress.Street = addressDto.Street;
                    existingAddress.HouseNr = addressDto.HouseNr;
                    existingAddress.Zip = addressDto.Zip;
                    existingAddress.City = addressDto.City;
                    existingAddress.DefaultDeliveryAddress = addressDto.DefaultDeliveryAddress;
                    existingAddress.DefaultInvoiceAddress = addressDto.DefaultInvoiceAddress;
                    existingAddress.CountryId = addressDto.CountryId;
                }
                else if (addressDto.Id == Guid.Empty)
                {
                    // Add new address
                    var newAddress = new CustomerAddress
                    {
                        CustomerId = request.Id,
                        Firstname = addressDto.Firstname,
                        Lastname = addressDto.Lastname,
                        CompanyName = addressDto.CompanyName,
                        Street = addressDto.Street,
                        HouseNr = addressDto.HouseNr,
                        Zip = addressDto.Zip,
                        City = addressDto.City,
                        DefaultDeliveryAddress = addressDto.DefaultDeliveryAddress,
                        DefaultInvoiceAddress = addressDto.DefaultInvoiceAddress,
                        CountryId = addressDto.CountryId
                    };

                    await _customerRepository.AddCustomerAddressAsync(newAddress);
                }
            }
        }

        // Update in database
        await _customerRepository.UpdateAsync(customerToUpdate);

        _logger.LogInformation("Successfully updated customer with ID: {Id}", customerToUpdate.Id);

        return Result<Guid>.NoContent(customerToUpdate.Id);
    }
}
