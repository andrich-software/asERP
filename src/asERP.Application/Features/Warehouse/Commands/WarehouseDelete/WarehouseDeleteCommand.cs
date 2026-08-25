using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseDelete;

public class WarehouseDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid? NewWarehouseId { get; set; }
}
