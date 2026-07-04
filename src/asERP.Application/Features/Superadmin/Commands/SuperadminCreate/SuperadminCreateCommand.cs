using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminCreate;

public class SuperadminCreateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
