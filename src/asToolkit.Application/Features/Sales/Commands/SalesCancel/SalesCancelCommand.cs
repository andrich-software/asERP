using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.Sales.Commands.SalesCancel;

public class SalesCancelCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
