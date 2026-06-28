using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Superadmin.Commands.SuperadminUpdate;

public class SuperadminUpdateCommand : SuperadminTenantInputDto, IRequest<Result<Guid>>
{
}
