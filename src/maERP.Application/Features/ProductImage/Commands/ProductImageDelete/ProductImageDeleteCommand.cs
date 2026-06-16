using maERP.Application.Mediator;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.ProductImage.Commands.ProductImageDelete;

public class ProductImageDeleteCommand : IRequest<Result<Guid>>
{
    public Guid ProductId { get; set; }
    public Guid ImageId { get; set; }
}
