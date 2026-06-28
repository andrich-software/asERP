using asToolkit.Client.Core.Models;
using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Dtos.Tenant;
using asToolkit.Domain.Dtos.User;

namespace asToolkit.Client.Features.Superadmin.Services;

/// <summary>
/// Service interface for superadmin tenant-related API operations.
/// Uses the /api/v1/superadmin/tenants endpoint.
/// </summary>
public interface ISuperadminTenantService
{
    /// <summary>
    /// Gets a paginated list of all tenants (superadmin only).
    /// </summary>
    Task<PaginatedResponse<TenantListDto>> GetTenantsAsync(
        QueryParameters parameters,
        CancellationToken ct = default);

    /// <summary>
    /// Gets a single tenant by ID (superadmin only).
    /// </summary>
    Task<TenantDetailDto?> GetTenantAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Gets detailed tenant information including assigned users (superadmin only).
    /// </summary>
    Task<SuperadminTenantDetailDto?> GetTenantDetailAsync(Guid id, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing tenant (superadmin only).
    /// </summary>
    Task UpdateTenantAsync(Guid id, TenantInputDto input, CancellationToken ct = default);

    /// <summary>
    /// Assigns a user to a tenant (superadmin only).
    /// </summary>
    Task AssignUserToTenantAsync(string userId, Guid tenantId, CancellationToken ct = default);

    /// <summary>
    /// Removes a user from a tenant (superadmin only).
    /// </summary>
    Task RemoveUserFromTenantAsync(string userId, Guid tenantId, CancellationToken ct = default);

    /// <summary>
    /// Gets all users (superadmin only).
    /// Used to select users for tenant assignment.
    /// </summary>
    Task<List<UserListDto>> GetAllUsersAsync(CancellationToken ct = default);
}
