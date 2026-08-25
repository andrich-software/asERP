using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Product.Commands.ProductDelete;

public class ProductDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
