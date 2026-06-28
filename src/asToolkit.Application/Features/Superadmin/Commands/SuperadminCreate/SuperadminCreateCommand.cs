using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Superadmin.Commands.SuperadminCreate;

public class SuperadminCreateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
