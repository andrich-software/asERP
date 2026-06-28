using asToolkit.Domain.Dtos.User;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;
using System.ComponentModel.DataAnnotations;

namespace asToolkit.Application.Features.Superadmin.UserTenants.Queries.GetUserTenants;

public class GetUserTenantsQuery : IRequest<Result<List<UserTenantAssignmentDto>>>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    public GetUserTenantsQuery(string userId)
    {
        UserId = userId;
    }
}