using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesDelete;

public class DeleteSalesCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
