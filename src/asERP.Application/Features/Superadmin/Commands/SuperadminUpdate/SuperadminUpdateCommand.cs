using asERP.Application.Mediator;
using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminUpdate;

public class SuperadminUpdateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
