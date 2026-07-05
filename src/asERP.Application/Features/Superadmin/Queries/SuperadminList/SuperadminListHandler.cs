using System.Linq.Dynamic.Core;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Extensions;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Superadmin;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Superadmin.Queries.SuperadminList;

public class SuperadminListHandler : IRequestHandler<SuperadminListQuery, PaginatedResult<SuperadminTenantListDto>>
{
    // Ordering runs on the Tenant entity (before Select). Restrict to safe display columns; the DTO's
    // sensitive base fields (ConnectionString) are not projected here and are never sortable.
    private static readonly HashSet<string> AllowedSortFields = new(StringComparer.OrdinalIgnoreCase)
    {
        nameof(Domain.Entities.Tenant.Id),
        nameof(Domain.Entities.Tenant.Name),
        nameof(Domain.Entities.Tenant.DateCreated),
        nameof(Domain.Entities.Tenant.DateModified)
    };

    private readonly IAppLogger<SuperadminListHandler> _logger;
    private readonly ITenantRepository _tenantRepository;

    public SuperadminListHandler(
        IAppLogger<SuperadminListHandler> logger,
        ITenantRepository tenantRepository)
    {
        _logger = logger;
        _tenantRepository = tenantRepository;
    }

    public async Task<PaginatedResult<SuperadminTenantListDto>> Handle(SuperadminListQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("SuperadminListHandler.Handle: Retrieving tenants.");

        var query = _tenantRepository.Entities.AsQueryable();

        // Apply search filter
        if (!string.IsNullOrEmpty(request.SearchString))
        {
            query = query.Where(t => t.Name.Contains(request.SearchString) ||
                                   t.Description.Contains(request.SearchString) ||
                                   (t.CompanyName != null && t.CompanyName.Contains(request.SearchString)) ||
                                   (t.ContactEmail != null && t.ContactEmail.Contains(request.SearchString)) ||
                                   (t.Phone != null && t.Phone.Contains(request.SearchString)) ||
                                   (t.City != null && t.City.Contains(request.SearchString)) ||
                                   (t.Country != null && t.Country.Contains(request.SearchString)));
        }

        // Apply salesing
        query = request.SalesBy.Any()
            ? query.ApplySafeOrdering(request.SalesBy, AllowedSortFields)
            : query.OrderBy(t => t.Name);

        return await query
            .Select(t => new SuperadminTenantListDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                CompanyName = t.CompanyName,
                ContactEmail = t.ContactEmail,
                Phone = t.Phone,
                Website = t.Website,
                Street = t.Street,
                Street2 = t.Street2,
                PostalCode = t.PostalCode,
                City = t.City,
                State = t.State,
                Country = t.Country,
                Iban = t.Iban,
                DateCreated = t.DateCreated,
                DateModified = t.DateModified
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
