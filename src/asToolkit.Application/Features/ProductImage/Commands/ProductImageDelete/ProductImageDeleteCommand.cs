using asToolkit.Application.Mediator;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Commands.ProductImageDelete;

public class ProductImageDeleteCommand : IRequest<Result<Guid>>
{
    public Guid ProductId { get; set; }
    public Guid ImageId { get; set; }
}
