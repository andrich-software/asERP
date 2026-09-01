using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Commands.CustomerDelete;

public class CustomerDeleteHandler : IRequestHandler<CustomerDeleteCommand, Result<int>>
{
    private readonly IAppLogger<CustomerDeleteHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly IGenericRepository<CustomerAddress> _customerAddressRepository;


    public CustomerDeleteHandler(
        IAppLogger<CustomerDeleteHandler> logger,
        ICustomerRepository customerRepository,
        IGenericRepository<CustomerAddress> customerAddressRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _customerAddressRepository = customerAddressRepository ?? throw new ArgumentNullException(nameof(customerAddressRepository));
    }

    public async Task<Result<int>> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting customer with ID: {Id}", request.Id);

        var result = new Result<int>();

        try
        {
            // Get entity from database first
            var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);

            if (customerToDelete == null)
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.Customer.NotFound, "Customer not found");

                _logger.LogWarning("Customer with ID: {Id} not found for deletion", request.Id);
                return result;
            }

            // Delete related addresses first (for InMemory database compatibility with CASCADE DELETE)
            var addresses = await _customerRepository.GetCustomerAddressByCustomerIdAsync(customerToDelete.Id);
            foreach (var address in addresses)
            {
                await _customerAddressRepository.DeleteAsync(address);
            }

            // Delete customer
            await _customerRepository.DeleteAsync(customerToDelete);

            result.Succeeded = true;
            result.Status = ResultStatus.NoContent;
            result.Data = 1;

            _logger.LogInformation("Successfully deleted customer with ID: {Id}", customerToDelete.Id);
        }
        catch (InvalidOperationException ex)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Customer.NotFound, "Customer not found");

            _logger.LogWarning("Customer with ID: {Id} not found during deletion: {Message}", request.Id, ex.Message);
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException ex)
        {
            // Handle concurrent deletion - customer was already deleted by another request
            result.Fail(ErrorType.NotFound, ErrorCodes.Customer.NotFound, "Customer not found");

            _logger.LogWarning("Customer with ID: {Id} was deleted by another request: {Message}", request.Id, ex.Message);
        }

        return result;
    }
}
