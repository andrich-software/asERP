using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using System.ComponentModel.DataAnnotations;

namespace asERP.Application.Features.Superadmin.UserTenants.Commands.RemoveUserFromTenant;

public class RemoveUserFromTenantCommand : IRequest<Result<bool>>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public Guid TenantId { get; set; }
}