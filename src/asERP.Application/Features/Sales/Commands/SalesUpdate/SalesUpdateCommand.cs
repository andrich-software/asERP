using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Sales.Commands.SalesUpdate;

public class SalesUpdateCommand : SalesInputDto, IRequest<Result<Guid>>
{
}