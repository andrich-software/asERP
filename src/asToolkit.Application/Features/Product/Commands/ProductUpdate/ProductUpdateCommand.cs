using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Product.Commands.ProductUpdate;

public class ProductUpdateCommand : ProductInputDto, IRequest<Result<Guid>>
{
}