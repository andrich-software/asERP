using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Warehouse.Commands.WarehouseDelete;

public class WarehouseDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid? NewWarehouseId { get; set; }
}