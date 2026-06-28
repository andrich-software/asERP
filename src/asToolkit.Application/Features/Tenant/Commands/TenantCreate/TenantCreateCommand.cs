using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Tenant.Commands.TenantCreate;

public class TenantCreateCommand : TenantInputDto, IRequest<Result<Guid>>
{
    public string UserId { get; set; } = string.Empty;
}
