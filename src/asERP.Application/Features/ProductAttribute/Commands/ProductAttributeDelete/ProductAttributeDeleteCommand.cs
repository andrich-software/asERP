using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
