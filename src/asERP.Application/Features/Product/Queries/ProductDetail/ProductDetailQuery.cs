using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Queries.ProductDetail;

/// <summary>
/// Query for retrieving detailed information about a specific product.
/// Implements IRequest to work with the custom mediator, returning product details wrapped in a Result.
/// </summary>
public class ProductDetailQuery : IRequest<Result<ProductDetailDto>>
{
    /// <summary>
    /// The unique identifier of the product to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
