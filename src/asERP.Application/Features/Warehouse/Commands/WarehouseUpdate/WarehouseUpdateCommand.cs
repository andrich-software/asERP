using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseUpdate;

public class WarehouseUpdateCommand : WarehouseInputDto, IRequest<Result<Guid>>
{
}