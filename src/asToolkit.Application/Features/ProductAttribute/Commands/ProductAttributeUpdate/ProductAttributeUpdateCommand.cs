using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateCommand : ProductAttributeInputDto, IRequest<Result<Guid>>
{
}
