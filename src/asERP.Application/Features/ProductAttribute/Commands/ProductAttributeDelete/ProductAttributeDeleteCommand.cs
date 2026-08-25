using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
