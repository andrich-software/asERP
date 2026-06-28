using asToolkit.Application.Mediator;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;

namespace asToolkit.Application.Features.ProductImage.Queries.ProductImageList;

public class ProductImageListQuery : IRequest<Result<List<ProductImageDto>>>
{
    public Guid ProductId { get; set; }
}
