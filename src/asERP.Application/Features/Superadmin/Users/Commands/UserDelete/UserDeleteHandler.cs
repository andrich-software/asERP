using System;
using System.Linq;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Superadmin.Users.Commands.UserDelete;

/// <summary>
/// Handler for processing user deletion commands.
/// Implements IRequestHandler from the custom mediator to handle UserDeleteCommand requests
/// and return the ID of the deleted user wrapped in a Result.
/// </summary>
public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITenantContext _tenantContext;
    private readonly IAppLogger<UserDeleteHandler> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantPermissionService _tenantPermissionService;

    public UserDeleteHandler(
        IUserRepository userRepository,
        ITenantContext tenantContext,
        IAppLogger<UserDeleteHandler> logger,
        IHttpContextAccessor httpContextAccessor,
        ITenantPermissionService tenantPermissionService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _tenantPermissionService = tenantPermissionService ?? throw new ArgumentNullException(nameof(tenantPermissionService));
    }

    public async Task<Result<string>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting user with ID: {Id}", request.Id);

        var result = new Result<string>();

        // Find the user to delete by ID
        var currentTenantId = ResolveTenantId(_tenantContext.GetCurrentTenantId());
        var httpContext = _httpContextAccessor.HttpContext;
        var currentUser = httpContext?.User;
        var isSuperadmin = currentUser?.IsInRole("Superadmin") ?? false;
        var currentUserId = httpContext.GetUserId() ?? string.Empty;

        var userToDelete = await _userRepository.GetByIdWithTenantsAsync(request.Id);

        // If user not found, return a not found result
        if (userToDelete == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, $"User with ID {request.Id} not found.");

            _logger.LogWarning("User with ID {0} not found", request.Id);
            return result;
        }

        if (!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty)
        {
            currentTenantId = userToDelete.UserTenants?.FirstOrDefault(ut => ut.IsDefault)?.TenantId
                ?? userToDelete.UserTenants?.FirstOrDefault()?.TenantId;
        }

        if (!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Tenant context is required to delete a user.");
            return result;
        }

        var isUserInCurrentTenant = userToDelete.UserTenants != null &&
                                    userToDelete.UserTenants.Any(ut => ut.TenantId == currentTenantId.Value);

        if (!isSuperadmin && !isUserInCurrentTenant)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "User not found in current tenant.");
            return result;
        }

        if (!isSuperadmin)
        {
            if (string.IsNullOrWhiteSpace(currentUserId))
            {
                result.Fail(ErrorType.Unauthorized, ErrorCodes.Superadmin.Unauthorized, "User context is required to evaluate permissions.");
                return result;
            }

            var hasPermission = await _tenantPermissionService.CanManageUsersAsync(
                currentUserId,
                currentTenantId.Value,
                cancellationToken);

            if (!hasPermission)
            {
                // A caller without permission must not learn whether the user exists in this tenant,
                // hence the two shapes.
                result.Fail(
                    isUserInCurrentTenant ? ErrorType.Forbidden : ErrorType.NotFound,
                    isUserInCurrentTenant ? ErrorCodes.Superadmin.Forbidden : ErrorCodes.Superadmin.NotFound,
                    isUserInCurrentTenant
                        ? "You do not have permission to delete users for this tenant."
                        : "User not found in current tenant.");
                return result;
            }
        }

        // Delete the user using ASP.NET Identity UserManager
        IdentityResult deleteResult;
        try
        {
            deleteResult = await _userRepository.DeleteAsync(userToDelete);
        }
        catch (DbUpdateConcurrencyException)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "User not found in current tenant.");
            return result;
        }

        // If deletion fails, return an error result with the error descriptions
        if (!deleteResult.Succeeded)
        {
            result.Fail(ErrorType.Unexpected, ErrorCodes.Superadmin.Unexpected);
            result.Messages.AddRange(deleteResult.Errors.Select(e => e.Description));

            _logger.LogError("Error deleting user {0}: {1}",
                request.Id,
                string.Join(", ", deleteResult.Errors.Select(e => e.Description)));

            return result;
        }

        // Set successful result with the deleted user's ID
        result.Succeeded = true;
        result.Status = ResultStatus.NoContent;
        result.Data = userToDelete.Id;

        _logger.LogInformation("User {0} deleted successfully", userToDelete.Id);

        return result;
    }

    private Guid? ResolveTenantId(Guid? currentTenantId)
    {
        if (currentTenantId.HasValue && currentTenantId.Value != Guid.Empty)
        {
            return currentTenantId;
        }

        var fallback = _tenantContext.GetAssignedTenantIds().FirstOrDefault(id => id != Guid.Empty);
        return fallback == Guid.Empty ? (Guid?)null : fallback;
    }
}
