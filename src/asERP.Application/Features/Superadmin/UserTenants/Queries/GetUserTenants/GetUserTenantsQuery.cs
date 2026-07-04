using asERP.Domain.Dtos.User;
using asERP.Domain.Wrapper;
using asERP.Application.Mediator;
using System.ComponentModel.DataAnnotations;

namespace asERP.Application.Features.Superadmin.UserTenants.Queries.GetUserTenants;

public class GetUserTenantsQuery : IRequest<Result<List<UserTenantAssignmentDto>>>
{
    [Required]
    public string UserId { get; set; } = string.Empty;

    public GetUserTenantsQuery(string userId)
    {
        UserId = userId;
    }
}