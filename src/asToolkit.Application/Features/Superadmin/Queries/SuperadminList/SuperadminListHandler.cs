using System.Linq.Dynamic.Core;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Extensions;
using asToolkit.Domain.Dtos.Superadmin;
using asToolkit.Domain.Wrapper;
using asToolkit.Application.Mediator;

namespace asToolkit.Application.Features.Superadmin.Queries.SuperadminList;

public class SuperadminListHandler : IRequestHandler<SuperadminListQuery, PaginatedResult<SuperadminTenantListDto>>
{
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
        if (request.SalesBy.Any())
        {
            var salesing = string.Join(",", request.SalesBy);
            query = query.OrderBy(salesing);
        }
        else
        {
            query = query.OrderBy(t => t.Name);
        }

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
