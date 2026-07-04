using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using System.ComponentModel.DataAnnotations;

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
