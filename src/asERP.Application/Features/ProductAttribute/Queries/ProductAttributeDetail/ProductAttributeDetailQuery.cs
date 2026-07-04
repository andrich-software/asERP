using asERP.Domain.Dtos.ProductAttribute;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.ProductAttribute.Queries.ProductAttributeDetail;

public class ProductAttributeDetailQuery : IRequest<Result<ProductAttributeDetailDto>>
{
    public Guid Id { get; set; }
}
