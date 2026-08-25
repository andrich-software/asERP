using asERP.Application.Mediator;
using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Commands.SuperadminCreate;

public class SuperadminCreateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
