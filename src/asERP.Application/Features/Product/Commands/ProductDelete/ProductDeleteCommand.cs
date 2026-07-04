using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Product.Commands.ProductDelete;

public class ProductDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}