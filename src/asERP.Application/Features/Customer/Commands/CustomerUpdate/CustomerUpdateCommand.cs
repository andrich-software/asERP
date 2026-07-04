using asERP.Domain.Dtos.Customer;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Customer.Commands.CustomerUpdate;

public class CustomerUpdateCommand : CustomerInputDto, IRequest<Result<Guid>>
{
}