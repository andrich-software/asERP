using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainDelete;

public class ShopDomainDeleteCommand : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
}
