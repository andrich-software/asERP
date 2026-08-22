using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainCreate;

public class ShopDomainCreateCommand : ShopDomainInputDto, IRequest<Result<Guid>>
{
}
