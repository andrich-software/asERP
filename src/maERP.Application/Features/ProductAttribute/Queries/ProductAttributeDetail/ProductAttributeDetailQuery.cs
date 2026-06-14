using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Wrapper;
using maERP.Application.Mediator;

namespace maERP.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;

public class ProductAttributeDetailQuery : IRequest<Result<ProductAttributeDetailDto>>
{
    public Guid Id { get; set; }
}
