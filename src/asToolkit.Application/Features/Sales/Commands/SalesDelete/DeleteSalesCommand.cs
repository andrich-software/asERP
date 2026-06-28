using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Commands.SalesDelete;

public class DeleteSalesCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}