using System.ComponentModel.DataAnnotations;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.UserTenants.Commands.AssignUserToTenant;

public class AssignUserToTenantCommand : IRequest<Result<int>>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public Guid TenantId { get; set; }

    public bool IsDefault { get; set; } = false;

    public bool RoleManageUser { get; set; } = false;
}
