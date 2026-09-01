using System;
using System.Collections.Generic;
using System.Linq;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace asERP.Application.Features.Superadmin.Users.Commands.UserCreate;

/// <summary>
/// Handler for processing user creation commands.
/// Implements IRequestHandler from the custom mediator to handle UserCreateCommand requests
/// and return the ID of the newly created user wrapped in a Result.
/// </summary>
public class UserCreateHandler : IRequestHandler<UserCreateCommand, Result<string>>
{
    private readonly IAppLogger<UserCreateHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITenantContext _tenantContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantPermissionService _tenantPermissionService;

    public UserCreateHandler(
        IAppLogger<UserCreateHandler> logger,
        IUserRepository userRepository,
        ITenantContext tenantContext,
        IHttpContextAccessor httpContextAccessor,
        ITenantPermissionService tenantPermissionService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _tenantPermissionService = tenantPermissionService ?? throw new ArgumentNullException(nameof(tenantPermissionService));
    }

    public async Task<Result<string>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new user with email: {Email}", request.Email);

        var result = new Result<string>();

        var httpContext = _httpContextAccessor.HttpContext;
        var currentUser = httpContext?.User;
        var currentUserId = httpContext.GetUserId() ?? string.Empty;
        var isSuperadmin = currentUser?.IsInRole("Superadmin") ?? false;

        var resolvedTenantId = ResolveTenantId(_tenantContext.GetCurrentTenantId());
        var desiredDefaultTenantId = request.DefaultTenantId != Guid.Empty
            ? request.DefaultTenantId
            : resolvedTenantId;

        if (!desiredDefaultTenantId.HasValue || desiredDefaultTenantId.Value == Guid.Empty)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Default tenant is required to create a user.");
            return result;
        }

        request.DefaultTenantId = desiredDefaultTenantId.Value;

        var normalizedAdditionalIds = request.AdditionalTenantIds?
            .Where(id => id != Guid.Empty && id != request.DefaultTenantId)
            .Distinct()
            .ToList() ?? new List<Guid>();

        var allTenantIds = new List<Guid> { request.DefaultTenantId };
        allTenantIds.AddRange(normalizedAdditionalIds);

        if (!await _userRepository.TenantsExistAsync(allTenantIds))
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "One or more provided tenant IDs do not exist.");
            return result;
        }

        if (!isSuperadmin)
        {
            if (string.IsNullOrWhiteSpace(currentUserId))
            {
                result.Fail(ErrorType.Unauthorized, ErrorCodes.Superadmin.Unauthorized, "User context is required to evaluate permissions.");
                return result;
            }

            foreach (var tenantId in allTenantIds.Distinct())
            {
                var hasPermission = await _tenantPermissionService.CanManageUsersAsync(
                    currentUserId,
                    tenantId,
                    cancellationToken);

                if (!hasPermission)
                {
                    result.Fail(ErrorType.Forbidden, ErrorCodes.Superadmin.Forbidden, "You do not have permission to create users for this tenant.");
                    return result;
                }
            }
        }

        request.AdditionalTenantIds = normalizedAdditionalIds;

        // Manual mapping from command to entity (instead of using AutoMapper)
        var userToCreate = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        // Add the new user to the database with the provided password
        var createResult = await _userRepository.CreateAsync(userToCreate, request.Password);

        // Check if user creation was successful
        if (createResult.Any())
        {
            // Creation failed, return errors
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid);
            result.Messages.AddRange(createResult.Select(e => e.Description));
            return result;
        }

        // Assign user to tenants
        await _userRepository.AssignUserToTenantsAsync(
            userToCreate.Id,
            allTenantIds,
            request.DefaultTenantId);

        // Set successful result with the new user's ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = userToCreate.Id;

        _logger.LogInformation("Successfully created user with ID: {Id} and assigned to {TenantCount} tenants",
            userToCreate.Id, allTenantIds.Count);

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
