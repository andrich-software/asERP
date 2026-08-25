using asERP.Application.Mediator;
using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Customer.Commands.CustomerUpdate;

public class CustomerUpdateCommand : CustomerInputDto, IRequest<Result<Guid>>
{
}
