using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Commands.ProductAttributeUpdate;

public class ProductAttributeUpdateCommand : ProductAttributeInputDto, IRequest<Result<Guid>>
{
}
