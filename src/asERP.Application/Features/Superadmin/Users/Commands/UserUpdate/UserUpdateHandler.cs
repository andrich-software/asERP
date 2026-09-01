using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace asERP.Application.Features.Superadmin.Users.Commands.UserUpdate;

/// <summary>
/// Handler for processing user update commands.
/// Implements IRequestHandler from the custom mediator to handle UserUpdateCommand requests
/// and return the ID of the updated user wrapped in a Result.
/// </summary>
public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, Result<string>>
{
    private readonly IAppLogger<UserUpdateHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITenantContext _tenantContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantPermissionService _tenantPermissionService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserUpdateHandler(
        IAppLogger<UserUpdateHandler> logger,
        IUserRepository userRepository,
        ITenantContext tenantContext,
        IHttpContextAccessor httpContextAccessor,
        ITenantPermissionService tenantPermissionService,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _tenantPermissionService = tenantPermissionService ?? throw new ArgumentNullException(nameof(tenantPermissionService));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
    }

    public async Task<Result<string>> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating user with ID: {Id}", request.Id);

        var result = new Result<string>();

        var rawTenantId = _tenantContext.GetCurrentTenantId();
        var currentTenantId = ResolveTenantId(rawTenantId);
        var httpContext = _httpContextAccessor.HttpContext;
        var currentUser = httpContext?.User;
        var isSuperadmin = currentUser?.IsInRole("Superadmin") ?? false;
        var currentUserId = httpContext.GetUserId() ?? string.Empty;

        // Get existing user with tenant assignments
        var existingUser = await _userRepository.GetByIdWithTenantsAsync(request.Id);
        if (existingUser == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, $"User with ID {request.Id} not found.");
            return result;
        }

        // The tenant context must come from the server (JWT/tenant middleware or the target
        // user's own assignments) — never from the client-supplied request.DefaultTenantId,
        // which would let a caller pick the tenant scope the update runs in.
        if ((!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty) && existingUser.UserTenants != null && existingUser.UserTenants.Any())
        {
            currentTenantId = existingUser.UserTenants.FirstOrDefault(ut => ut.IsDefault)?.TenantId
                              ?? existingUser.UserTenants.First().TenantId;
        }

        if (!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Tenant context is required to update a user.");
            return result;
        }

        if (!isSuperadmin && string.IsNullOrWhiteSpace(currentUserId))
        {
            result.Fail(ErrorType.Unauthorized, ErrorCodes.Superadmin.Unauthorized, "User context is required to evaluate permissions.");
            return result;
        }

        if (!isSuperadmin && currentTenantId.HasValue && (existingUser.UserTenants == null || !existingUser.UserTenants.Any(ut => ut.TenantId == currentTenantId.Value)))
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "User not found in current tenant.");
            return result;
        }

        var canManageUsers = isSuperadmin;
        if (!isSuperadmin)
        {
            canManageUsers = await _tenantPermissionService.CanManageUsersAsync(
                currentUserId,
                currentTenantId.Value,
                cancellationToken);
        }

        var isSelfUpdate = !string.IsNullOrWhiteSpace(currentUserId) && currentUserId == request.Id;

        if (!isSuperadmin && !isSelfUpdate && !canManageUsers)
        {
            _logger.LogWarning("User {UserId} lacks manage permission for tenant {TenantId} when updating {TargetUserId}",
                currentUserId,
                currentTenantId,
                request.Id);
            result.Fail(ErrorType.Forbidden, ErrorCodes.Superadmin.Forbidden, "You do not have permission to update other users in this tenant.");
            return result;
        }

        var tenantIdsProvided = request.TenantIds != null;
        var tenantIds = request.TenantIds ?? new List<Guid>();
        var shouldUpdateTenants = tenantIdsProvided;

        if (isSelfUpdate && !canManageUsers)
        {
            var existingTenantIds = existingUser.UserTenants?.Select(ut => ut.TenantId).OrderBy(id => id).ToList() ?? new List<Guid>();
            var requestedTenantIds = tenantIds.OrderBy(id => id).ToList();
            var tenantAssignmentsChanged = shouldUpdateTenants && !existingTenantIds.SequenceEqual(requestedTenantIds);

            var existingDefaultTenantId = existingUser.UserTenants?.FirstOrDefault(ut => ut.IsDefault)?.TenantId;
            var defaultTenantChanged = request.DefaultTenantId.HasValue &&
                existingDefaultTenantId.HasValue &&
                request.DefaultTenantId.Value != existingDefaultTenantId.Value;

            // If no default was set previously, any attempt to set a new one counts as a change
            if (!existingDefaultTenantId.HasValue && request.DefaultTenantId.HasValue)
            {
                defaultTenantChanged = true;
            }

            if (tenantAssignmentsChanged || defaultTenantChanged)
            {
                result.Fail(ErrorType.Forbidden, ErrorCodes.Superadmin.Forbidden, "You are not allowed to change tenant assignments for your account.");
                return result;
            }

            shouldUpdateTenants = false;
        }

        if (shouldUpdateTenants)
        {
            if (!await _userRepository.TenantsExistAsync(tenantIds))
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "One or more provided tenant IDs do not exist.");
                return result;
            }

            if (!tenantIds.Contains(currentTenantId.Value))
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "User must remain assigned to the current tenant.");
                return result;
            }

            if (request.DefaultTenantId.HasValue && request.DefaultTenantId.Value != Guid.Empty &&
                !tenantIds.Contains(request.DefaultTenantId.Value))
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Default tenant must be part of the tenant assignments.");
                return result;
            }
        }

        if (!request.DefaultTenantId.HasValue || request.DefaultTenantId.Value == Guid.Empty)
        {
            request.DefaultTenantId = existingUser.UserTenants?.FirstOrDefault(ut => ut.IsDefault)?.TenantId ?? currentTenantId.Value;
        }

        var normalizedEmail = _userManager.NormalizeEmail(request.Email);
        var normalizedUserName = _userManager.NormalizeName(request.Email);

        if (!string.Equals(existingUser.NormalizedEmail, normalizedEmail, StringComparison.OrdinalIgnoreCase))
        {
            var userWithEmail = await _userManager.FindByEmailAsync(request.Email);
            var emailInUse = userWithEmail != null && !string.Equals(userWithEmail.Id, existingUser.Id, StringComparison.OrdinalIgnoreCase);

            _logger.LogInformation("Email duplication check for user {UserId}: requested={RequestedEmail}, existsForOtherUser={Exists}",
                request.Id,
                normalizedEmail ?? string.Empty,
                emailInUse);

            if (emailInUse)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.AlreadyExists, "Email address is already in use.");
                return result;
            }
        }

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            foreach (var passwordValidator in _userManager.PasswordValidators)
            {
                var passwordValidationResult = await passwordValidator.ValidateAsync(_userManager, existingUser, request.Password);
                if (!passwordValidationResult.Succeeded)
                {
                    result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid);
                    result.Messages.AddRange(passwordValidationResult.Errors.Select(e => e.Description));
                    return result;
                }
            }

            existingUser.PasswordHash = _userManager.PasswordHasher.HashPassword(existingUser, request.Password);
        }

        // Update user properties
        existingUser.Email = request.Email;
        existingUser.NormalizedEmail = normalizedEmail;
        existingUser.UserName = request.Email;
        existingUser.NormalizedUserName = normalizedUserName;
        existingUser.Firstname = request.Firstname;
        existingUser.Lastname = request.Lastname;
        existingUser.DateModified = DateTime.UtcNow;

        // Update the user in the database
        await _userRepository.UpdateWithDetailsAsync(existingUser);

        // Update tenant assignments if provided
        if (shouldUpdateTenants)
        {
            await _userRepository.UpdateUserTenantAssignmentsAsync(
                request.Id,
                tenantIds,
                request.DefaultTenantId);

            _logger.LogInformation("Updated tenant assignments for user ID: {Id}", request.Id);
        }

        // Set successful result with the updated user's ID
        result.Succeeded = true;
        result.Status = ResultStatus.NoContent;
        result.Data = existingUser.Id;

        _logger.LogInformation("Successfully updated user with ID: {Id}", existingUser.Id);

        return result;
    }

    private Guid? ResolveTenantId(Guid? currentTenantId)
    {
        if (currentTenantId.HasValue && currentTenantId.Value != Guid.Empty)
        {
            return currentTenantId;
        }

        var assignedTenants = _tenantContext.GetAssignedTenantIds();
        var fallback = assignedTenants.FirstOrDefault(id => id != Guid.Empty);

        return fallback == Guid.Empty ? (Guid?)null : fallback;
    }
}
