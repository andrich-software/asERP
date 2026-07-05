using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Tenant;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Tenant.Queries.TenantList;

public class TenantListHandler : IRequestHandler<TenantListQuery, PaginatedResult<TenantListDto>>
{
    // Ordering runs on the projected TenantListDto; restrict to safe display columns and never
    // expose secret-like fields (e.g. ConnectionString) to client-supplied sorting.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(TenantListDto.Id),
        nameof(TenantListDto.Name),
        nameof(TenantListDto.DateCreated),
        nameof(TenantListDto.DateModified)
    };

    private readonly IAppLogger<TenantListHandler> _logger;
    private readonly IUserTenantRepository _userTenantRepository;

    public TenantListHandler(
        IAppLogger<TenantListHandler> logger,
        IUserTenantRepository userTenantRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _userTenantRepository = userTenantRepository ?? throw new ArgumentNullException(nameof(userTenantRepository));
    }

    public async Task<PaginatedResult<TenantListDto>> Handle(TenantListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("TenantListHandler.Handle: Retrieving tenants for user {UserId}", request.UserId);

        // Start with tenants assigned to the user
        var query = _userTenantRepository.Entities
            .IgnoreQueryFilters()
            .Include(ut => ut.Tenant)
            .Where(ut => ut.UserId == request.UserId)
            .Select(ut => new TenantListDto
            {
                Id = ut.Tenant!.Id,
                Name = ut.Tenant.Name,
                Description = ut.Tenant.Description,
                CompanyName = ut.Tenant.CompanyName,
                ContactEmail = ut.Tenant.ContactEmail,
                Phone = ut.Tenant.Phone,
                Website = ut.Tenant.Website,
                Street = ut.Tenant.Street,
                Street2 = ut.Tenant.Street2,
                PostalCode = ut.Tenant.PostalCode,
                City = ut.Tenant.City,
                State = ut.Tenant.State,
                Country = ut.Tenant.Country,
                Iban = ut.Tenant.Iban,
                DateCreated = ut.Tenant.DateCreated,
                DateModified = ut.Tenant.DateModified,
                CanManageTenant = ut.RoleManageTenant
            });

        // Apply search filter
        if (!string.IsNullOrWhiteSpace(request.SearchString))
        {
            var searchTerm = request.SearchString.ToLower();
            query = query.Where(t =>
                t.Name.ToLower().Contains(searchTerm) ||
                (t.Description != null && t.Description.ToLower().Contains(searchTerm)) ||
                (t.CompanyName != null && t.CompanyName.ToLower().Contains(searchTerm)) ||
                (t.ContactEmail != null && t.ContactEmail.ToLower().Contains(searchTerm)) ||
                (t.City != null && t.City.ToLower().Contains(searchTerm)) ||
                (t.Country != null && t.Country.ToLower().Contains(searchTerm))
            );
        }

        // Apply salesing
        query = request.SalesBy.Any()
            ? query.ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            : query.OrderBy(t => t.Name);

        // Return paginated result
        var result = await query.ToPaginatedListAsync(request.PageNumber, request.PageSize);

        _logger.LogInformation("TenantListHandler.Handle: Found {Count} tenants for user {UserId}",
            result.TotalCount, request.UserId);

        return result;
    }
}
