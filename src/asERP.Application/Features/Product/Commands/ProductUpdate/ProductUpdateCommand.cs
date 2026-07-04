using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Product.Commands.ProductUpdate;

public class ProductUpdateCommand : ProductInputDto, IRequest<Result<Guid>>
{
}