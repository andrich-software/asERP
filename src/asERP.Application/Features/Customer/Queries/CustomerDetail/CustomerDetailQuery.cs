using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Customer.Queries.CustomerDetail;

/// <summary>
/// Query for retrieving detailed information about a specific customer.
/// Implements IRequest to work with MediatR, returning customer details wrapped in a Result.
/// </summary>
public class CustomerDetailQuery : IRequest<Result<CustomerDetailDto>>
{
    /// <summary>
    /// The unique identifier of the customer to retrieve
    /// </summary>
    public Guid Id { get; set; }
}