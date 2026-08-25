using asERP.Application.Mediator;
using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Tenant.Commands.TenantUpdate;

public class TenantUpdateCommand : TenantInputDto, IRequest<Result<Guid>>
{
    public Guid TenantId { get; set; }
    public string UserId { get; set; } = string.Empty;
}
