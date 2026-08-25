using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesUpdate;

public class SalesUpdateCommand : SalesInputDto, IRequest<Result<Guid>>
{
}
