using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductImage.Commands.ProductImageDelete;

public class ProductImageDeleteCommand : IRequest<Result<Guid>>
{
    public Guid ProductId { get; set; }
    public Guid ImageId { get; set; }
}
