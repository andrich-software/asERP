using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;

public class ProductAttributeDetailQuery : IRequest<Result<ProductAttributeDetailDto>>
{
    public Guid Id { get; set; }
}
