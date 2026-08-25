using asERP.Application.Mediator;
using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateCommand : ProductAttributeInputDto, IRequest<Result<Guid>>
{
}
