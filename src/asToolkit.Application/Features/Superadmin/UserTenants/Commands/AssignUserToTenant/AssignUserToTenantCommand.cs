using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using System.ComponentModel.DataAnnotations;

namespace asToolkit.Application.Features.Superadmin.UserTenants.Commands.AssignUserToTenant;

public class AssignUserToTenantCommand : IRequest<Result<int>>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public Guid TenantId { get; set; }

    public bool IsDefault { get; set; } = false;

    public bool RoleManageUser { get; set; } = false;
}
