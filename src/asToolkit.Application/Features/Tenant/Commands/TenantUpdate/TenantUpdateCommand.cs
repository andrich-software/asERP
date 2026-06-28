using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Tenant.Commands.TenantUpdate;

public class TenantUpdateCommand : TenantInputDto, IRequest<Result<Guid>>
{
    public Guid TenantId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
