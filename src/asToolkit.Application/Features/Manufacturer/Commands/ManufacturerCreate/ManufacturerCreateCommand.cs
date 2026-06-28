using asToolkit.Domain.Dtos.Manufacturer;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Manufacturer.Commands.ManufacturerCreate;

/// <summary>
/// Command for creating a new manufacturer in the system.
/// Inherits from ManufacturerInputDto to get all manufacturer properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created manufacturer wrapped in a Result.
/// </summary>
public class ManufacturerCreateCommand : ManufacturerInputDto, IRequest<Result<Guid>>
{
}