using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesCancel;

public class SalesCancelCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
