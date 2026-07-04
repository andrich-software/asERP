using asERP.Domain.Dtos.Warehouse;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Warehouse.Commands.WarehouseCreate;

/// <summary>
/// Command for creating a new warehouse in the system.
/// Inherits from WarehouseInputDto to get all warehouse properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created warehouse wrapped in a Result.
/// </summary>
public class WarehouseCreateCommand : WarehouseInputDto, IRequest<Result<Guid>>
{
}