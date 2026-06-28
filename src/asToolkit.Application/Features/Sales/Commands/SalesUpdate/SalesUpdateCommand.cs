using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Sales.Commands.SalesUpdate;

public class SalesUpdateCommand : SalesInputDto, IRequest<Result<Guid>>
{
}