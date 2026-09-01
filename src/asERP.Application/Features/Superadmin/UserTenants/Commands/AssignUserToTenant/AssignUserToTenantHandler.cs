using System;
using System.Linq;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Superadmin.UserTenants.Commands.AssignUserToTenant;

public class AssignUserToTenantHandler : IRequestHandler<AssignUserToTenantCommand, Result<int>>
{
    private readonly IUserTenantRepository _userTenantRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly UserManager<ApplicationUser> _userManager;

    public AssignUserToTenantHandler(
        IUserTenantRepository userTenantRepository,
        ITenantRepository tenantRepository,
        UserManager<ApplicationUser> userManager)
    {
        _userTenantRepository = userTenantRepository;
        _tenantRepository = tenantRepository;
        _userManager = userManager;
    }

    public async Task<Result<int>> Handle(AssignUserToTenantCommand request, CancellationToken cancellationToken)
    {
        // Check if user exists
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
            return Result<int>.Invalid(ErrorCodes.Superadmin.Invalid, "User not found");
        }

        // Check if tenant exists
        if (!await _tenantRepository.ExistsAsync(request.TenantId))
        {
            return Result<int>.Invalid(ErrorCodes.Superadmin.Invalid, "Tenant not found");
        }

        // Check if assignment already exists
        var assignmentExists = await _userTenantRepository.Entities
            .AsNoTracking()
            .AnyAsync(ut => ut.UserId == request.UserId && ut.TenantId == request.TenantId, cancellationToken);

        if (assignmentExists)
        {
            return Result<int>.Invalid(ErrorCodes.Superadmin.AlreadyExists, "User is already assigned to this tenant");
        }

        // If this should be the default tenant, remove default flag from other assignments
        if (request.IsDefault)
        {
            var userAssignments = await _userTenantRepository.Entities
                .Where(ut => ut.UserId == request.UserId && ut.IsDefault)
                .ToListAsync(cancellationToken);

            foreach (var assignment in userAssignments)
            {
                assignment.IsDefault = false;
                await _userTenantRepository.UpdateAsync(assignment);
            }
        }

        var userTenant = new Domain.Entities.UserTenant
        {
            UserId = request.UserId,
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
            return Result<int>.Invalid(ErrorCodes.Superadmin.AlreadyExists, "User is already assigned to this tenant");
        }

        var success = Result<int>.Success(1, "User successfully assigned to tenant");
        success.Status = ResultStatus.Created;
        return success;
    }
}
