using asERP.Application.Mediator;
using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Tenant.Commands.TenantCreate;

public class TenantCreateCommand : TenantInputDto, IRequest<Result<Guid>>
{
    public string UserId { get; set; } = string.Empty;
}
