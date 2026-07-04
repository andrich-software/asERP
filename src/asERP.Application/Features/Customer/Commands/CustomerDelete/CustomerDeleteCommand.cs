using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Customer.Commands.CustomerDelete;

public class CustomerDeleteCommand : IRequest<Result<int>>
{
    public Guid Id { get; set; }
}