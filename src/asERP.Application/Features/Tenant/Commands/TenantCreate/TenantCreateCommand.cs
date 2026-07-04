using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;

namespace asERP.Application.Features.Tenant.Commands.TenantCreate;

public class TenantCreateCommand : TenantInputDto, IRequest<Result<Guid>>
{
    public string UserId { get; set; } = string.Empty;
}
