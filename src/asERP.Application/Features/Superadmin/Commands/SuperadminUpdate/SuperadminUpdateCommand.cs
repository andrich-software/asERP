using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminUpdate;

public class SuperadminUpdateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
