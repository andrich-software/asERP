using asERP.Application.Mediator;
using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseCreate;

/// <summary>
/// Command for creating a new warehouse in the system.
/// Inherits from WarehouseInputDto to get all warehouse properties and implements IRequest
/// to work with the custom mediator, returning the ID of the newly created warehouse wrapped in a Result.
/// </summary>
public class WarehouseCreateCommand : WarehouseInputDto, IRequest<Result<Guid>>
{
}
