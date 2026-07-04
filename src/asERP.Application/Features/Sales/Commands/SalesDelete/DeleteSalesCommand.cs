using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Sales.Commands.SalesDelete;

public class DeleteSalesCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}