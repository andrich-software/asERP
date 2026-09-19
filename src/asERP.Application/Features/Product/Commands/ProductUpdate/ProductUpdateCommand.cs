using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductUpdate;

public class ProductUpdateCommand : ProductInputDto, IRequest<Result<Guid>>
{
}
