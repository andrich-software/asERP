using asERP.Application.Mediator;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseUpdate;

public class WarehouseUpdateCommand : WarehouseInputDto, IRequest<Result<Guid>>
{
}
