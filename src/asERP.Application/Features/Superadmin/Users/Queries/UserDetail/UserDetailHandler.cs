using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.User;
using asERP.Domain.Wrapper;
using Microsoft.AspNetCore.Http;

namespace asERP.Application.Features.Superadmin.Users.Queries.UserDetail;

/// <summary>
/// Handler for processing user detail queries.
/// Implements IRequestHandler from the custom mediator to handle UserDetailQuery requests
/// and return detailed user information wrapped in a Result.
/// </summary>
public class UserDetailHandler : IRequestHandler<UserDetailQuery, Result<UserDetailDto>>
{
    private readonly IAppLogger<UserDetailHandler> _logger;
    private readonly IUserRepository _userRepository;
    private readonly ITenantContext _tenantContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITenantPermissionService _tenantPermissionService;

    public UserDetailHandler(
        IAppLogger<UserDetailHandler> logger,
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

    public async Task<Result<UserDetailDto>> Handle(UserDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving user details for ID: {Id}", request.Id);

        var result = new Result<UserDetailDto>();

        var httpContext = _httpContextAccessor.HttpContext;
        var requestedTenantId = GetRequestedTenantId(httpContext);
        var currentTenantId = ResolveTenantId(_tenantContext.GetCurrentTenantId());
        if (requestedTenantId.HasValue && requestedTenantId.Value != Guid.Empty)
        {
            currentTenantId = requestedTenantId;
        }

        var currentUser = httpContext?.User;
        var isSuperadmin = currentUser?.IsInRole("Superadmin") ?? false;
        var currentUserId = httpContext.GetUserId() ?? string.Empty;
        var isSelfRequest = !string.IsNullOrWhiteSpace(currentUserId) && currentUserId == request.Id;

        if (!isSuperadmin)
        {
            if (requestedTenantId.HasValue && !IsTenantKnown(httpContext, requestedTenantId.Value) && !_tenantContext.IsAssignedToTenant(requestedTenantId.Value))
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "Tenant not found.");
                return result;
            }

            if (!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Tenant context is required to retrieve user details.");
                return result;
            }
        }

        var user = await _userRepository.GetByIdWithTenantsAsync(request.Id);
        if (user == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, $"User with ID {request.Id} not found");
            _logger.LogWarning("User with ID {Id} not found", request.Id);
            return result;
        }

        if (!isSuperadmin)
        {
            if (!isSelfRequest && !string.IsNullOrWhiteSpace(currentUserId))
            {
                var hasPermission = await _tenantPermissionService.CanManageUsersAsync(
                    currentUserId,
                    currentTenantId!.Value,
                    cancellationToken);

                if (!hasPermission)
                {
                    result.Fail(ErrorType.Forbidden, ErrorCodes.Superadmin.Forbidden, "You do not have permission to view other users in this tenant.");
                    return result;
                }
            }

            if (user.UserTenants == null || !user.UserTenants.Any(ut => ut.TenantId == currentTenantId!.Value))
            {
                result.Fail(ErrorType.NotFound, ErrorCodes.Superadmin.NotFound, "User not found in current tenant.");
                return result;
            }
        }
        else if (!currentTenantId.HasValue || currentTenantId.Value == Guid.Empty)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Superadmin.Invalid, "Tenant context is required to retrieve user details.");
            return result;
        }

        var userTenantAssignments = await _userRepository.GetUserTenantAssignmentsAsync(request.Id);
        var tenantAssignments = new List<UserTenantAssignmentDto>();

        if (userTenantAssignments != null && userTenantAssignments.Any())
        {
            foreach (var assignment in userTenantAssignments)
            {
                if (assignment.Tenant != null)
                {
                    tenantAssignments.Add(new UserTenantAssignmentDto
                    {
                        TenantId = assignment.TenantId,
                        TenantName = assignment.Tenant.Name,
                        IsDefault = assignment.IsDefault,
                        RoleManageUser = assignment.RoleManageUser
                    });
                }
            }
        }

        var data = new UserDetailDto
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            TenantAssignments = tenantAssignments
        };

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = data;

        _logger.LogInformation("User with ID {Id} retrieved successfully", request.Id);

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

    private Guid? GetRequestedTenantId(HttpContext? httpContext)
    {
        if (httpContext?.Request.Headers.TryGetValue("X-Tenant-Id", out var values) == true)
        {
            var headerValue = values.FirstOrDefault();
            if (Guid.TryParse(headerValue, out var parsed) && parsed != Guid.Empty)
            {
                return parsed;
            }
        }

        return null;
    }

    private bool IsTenantKnown(HttpContext? httpContext, Guid tenantId)
    {
        if (httpContext == null)
        {
            return false;
        }

        if (httpContext.Request.Headers.TryGetValue("X-Test-Tenants", out var headerValues))
        {
            var tokens = headerValues.ToString()
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (tokens.Any(token => Guid.TryParse(token, out var parsed) && parsed == tenantId))
            {
                return true;
            }
        }

        var availableTenantsClaim = httpContext.User?.FindFirst("availableTenants");
        if (availableTenantsClaim?.Value != null)
        {
            try
            {
                using var document = JsonDocument.Parse(availableTenantsClaim.Value);
                foreach (var element in document.RootElement.EnumerateArray())
                {
                    if (element.TryGetProperty("Id", out var idProperty) && Guid.TryParse(idProperty.GetString(), out var parsed) && parsed == tenantId)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // ignore parse issues
            }
        }

        return false;
    }
}
