using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateCommand : ProductAttributeInputDto, IRequest<Result<Guid>>
{
}
