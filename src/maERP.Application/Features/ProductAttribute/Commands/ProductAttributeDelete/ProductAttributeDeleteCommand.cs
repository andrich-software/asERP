using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
