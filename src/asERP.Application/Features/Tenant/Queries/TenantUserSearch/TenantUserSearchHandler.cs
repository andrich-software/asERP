using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.User;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Tenant.Queries.TenantUserSearch;

/// <summary>
/// Handler for searching users by email.
/// Requires the current user to have RoleManageUser permission on the tenant.
/// </summary>
public class TenantUserSearchHandler : IRequestHandler<TenantUserSearchQuery, Result<UserListDto?>>
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public TenantUserSearchHandler(
        IUserTenantRepository userTenantRepository,
        UserManager<ApplicationUser> userManager)
    {
        _userTenantRepository = userTenantRepository;
        _userManager = userManager;
    }

    public async Task<Result<UserListDto?>> Handle(TenantUserSearchQuery request, CancellationToken cancellationToken)
    {
        // Check if the current user has RoleManageUser permission on this tenant
        var currentUserTenant = await _userTenantRepository.Entities
            .AsNoTracking()
            .FirstOrDefaultAsync(ut => ut.UserId == request.CurrentUserId && ut.TenantId == request.TenantId, cancellationToken);

        if (currentUserTenant == null || !currentUserTenant.RoleManageUser)
        {
            return Result<UserListDto?>.Forbidden(ErrorCodes.Tenant.Forbidden, "You do not have permission to manage users for this tenant");
        }

        // Search for user by email (exact match, case-insensitive)
        var user = await _userManager.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.NormalizedEmail == request.Email.ToUpperInvariant(), cancellationToken);

        if (user == null)
        {
            return Result<UserListDto?>.NotFound(ErrorCodes.Tenant.NotFound, "User not found with this email address");
        }

        // Check if user is already assigned to this tenant
        var alreadyAssigned = await _userTenantRepository.Entities
            .AsNoTracking()
            .AnyAsync(ut => ut.UserId == user.Id && ut.TenantId == request.TenantId, cancellationToken);

        if (alreadyAssigned)
        {
            return Result<UserListDto?>.Invalid(ErrorCodes.Tenant.Invalid, "User is already a member of this tenant");
        }

        var dto = new UserListDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            DateCreated = user.DateCreated
        };

        return Result<UserListDto?>.Success(dto, "User found");
    }
}
