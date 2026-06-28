using asToolkit.Domain.Dtos.Customer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Customer.Commands.CustomerUpdate;

public class CustomerUpdateCommand : CustomerInputDto, IRequest<Result<Guid>>
{
}