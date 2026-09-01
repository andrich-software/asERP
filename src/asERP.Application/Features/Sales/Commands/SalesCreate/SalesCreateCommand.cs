using asERP.Application.Mediator;
using asERP.Domain.Dtos.Sales;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesCreate;

/// <summary>
/// Command for creating a new sales in the system.
/// Inherits from SalesInputDto to get all sales properties and implements IRequest
/// to work with the custom mediator, returning the ID of the newly created sales wrapped in a Result.
/// </summary>
public class SalesCreateCommand : SalesInputDto, IRequest<Result<Guid>>
{
}
