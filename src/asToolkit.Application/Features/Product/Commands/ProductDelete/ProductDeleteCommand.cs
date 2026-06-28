using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Product.Commands.ProductDelete;

public class ProductDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}