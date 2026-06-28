using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeCreate;

/// <summary>
/// Command for creating a new product attribute (incl. its values) in the system.
/// Inherits from ProductAttributeInputDto to get all attribute properties and implements IRequest
/// to work with MediatR, returning the ID of the newly created attribute wrapped in a Result.
/// </summary>
public class ProductAttributeCreateCommand : ProductAttributeInputDto, IRequest<Result<Guid>>
{
}
