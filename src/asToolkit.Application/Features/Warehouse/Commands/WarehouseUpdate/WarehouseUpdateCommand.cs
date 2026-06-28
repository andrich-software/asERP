using asToolkit.Domain.Dtos.Warehouse;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Warehouse.Commands.WarehouseUpdate;

public class WarehouseUpdateCommand : WarehouseInputDto, IRequest<Result<Guid>>
{
}