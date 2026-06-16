using maERP.Application.Mediator;
using maERP.Domain.Dtos.Product;
using maERP.Domain.Wrapper;

namespace maERP.Application.Features.ProductImage.Queries.ProductImageList;

public class ProductImageListQuery : IRequest<Result<List<ProductImageDto>>>
{
    public Guid ProductId { get; set; }
}
