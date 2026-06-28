using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Commands.ProductAttributeDelete;

public class ProductAttributeDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
