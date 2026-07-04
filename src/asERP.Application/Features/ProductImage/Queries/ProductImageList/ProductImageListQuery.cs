using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ProductImage.Queries.ProductImageList;

public class ProductImageListQuery : IRequest<Result<List<ProductImageDto>>>
{
    public Guid ProductId { get; set; }
}
