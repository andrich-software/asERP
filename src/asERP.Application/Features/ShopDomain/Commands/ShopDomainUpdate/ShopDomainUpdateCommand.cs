using asERP.Application.Mediator;
using asERP.Domain.Dtos.ShopDomain;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.ShopDomain.Commands.ShopDomainUpdate;

public class ShopDomainUpdateCommand : ShopDomainInputDto, IRequest<Result<Guid>>
{
}
