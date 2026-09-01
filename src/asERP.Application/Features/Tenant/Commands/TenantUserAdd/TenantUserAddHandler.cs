using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Tenant.Commands.TenantUserAdd;

/// <summary>
/// Handler for adding a user to a tenant.
/// Requires the current user to have RoleManageUser permission on the tenant.
/// </summary>
public class TenantUserAddHandler : IRequestHandler<TenantUserAddCommand, Result<bool>>
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public TenantUserAddHandler(
        IUserTenantRepository userTenantRepository,
        ITenantRepository tenantRepository,
        UserManager<ApplicationUser> userManager)
    {
        _userTenantRepository = userTenantRepository;
        _tenantRepository = tenantRepository;
        _userManager = userManager;
    }

    public async Task<Result<bool>> Handle(TenantUserAddCommand request, CancellationToken cancellationToken)
    {
        // Check if the current user has RoleManageUser permission on this tenant
        var currentUserTenant = await _userTenantRepository.Entities
            .AsNoTracking()
            .FirstOrDefaultAsync(ut => ut.UserId == request.CurrentUserId && ut.TenantId == request.TenantId, cancellationToken);

        if (currentUserTenant == null || !currentUserTenant.RoleManageUser)
        {
            return Result<bool>.Forbidden(ErrorCodes.Tenant.Forbidden, "You do not have permission to manage users for this tenant");
        }

        // Check if tenant exists
        if (!await _tenantRepository.ExistsAsync(request.TenantId))
        {
            return Result<bool>.NotFound(ErrorCodes.Tenant.NotFound, "Tenant not found");
        }

        // Find user by email
        var user = await _userManager.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.NormalizedEmail == request.Email.ToUpperInvariant(), cancellationToken);

        if (user == null)
        {
            return Result<bool>.NotFound(ErrorCodes.Tenant.NotFound, "User not found with this email address");
        }

        // Check if user is already assigned to this tenant
        var alreadyAssigned = await _userTenantRepository.Entities
            .AsNoTracking()
            .AnyAsync(ut => ut.UserId == user.Id && ut.TenantId == request.TenantId, cancellationToken);

        if (alreadyAssigned)
        {
            return Result<bool>.Invalid(ErrorCodes.Tenant.Invalid, "User is already a member of this tenant");
        }

        // If this should be the default tenant, remove default flag from other assignments for the target user
        if (request.IsDefault)
        {
            var userAssignments = await _userTenantRepository.Entities
                .Where(ut => ut.UserId == user.Id && ut.IsDefault)
                .ToListAsync(cancellationToken);

            foreach (var assignment in userAssignments)
            {
                assignment.IsDefault = false;
                await _userTenantRepository.UpdateAsync(assignment);
            }
        }

        // Create the user-tenant assignment
        var userTenant = new UserTenant
        {
            UserId = user.Id,
            TenantId = request.TenantId,
            IsDefault = request.IsDefault,
            RoleManageUser = request.RoleManageUser,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        try
        {
            await _userTenantRepository.CreateAsync(userTenant);
        }
        catch (Exception ex) when (ex is DbUpdateException or ArgumentException)
        {
            return Result<bool>.Invalid(ErrorCodes.Tenant.Invalid, "Failed to add user to tenant");
        }

        var success = Result<bool>.Success(true, "User successfully added to tenant");
        success.Status = ResultStatus.Created;
        return success;
    }
}
