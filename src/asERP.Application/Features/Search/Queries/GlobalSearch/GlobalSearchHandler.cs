using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Search;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Search.Queries.GlobalSearch;

public class GlobalSearchHandler : IRequestHandler<GlobalSearchQuery, Result<GlobalSearchResultDto>>
{
    private const int MinSearchLength = 3;

    private readonly IAppLogger<GlobalSearchHandler> _logger;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IProductRepository _productRepository;
    private readonly IShippingRepository _shippingRepository;

    public GlobalSearchHandler(
        IAppLogger<GlobalSearchHandler> logger,
        ICustomerRepository customerRepository,
        ISalesRepository salesRepository,
        IInvoiceRepository invoiceRepository,
        IProductRepository productRepository,
        IShippingRepository shippingRepository)
    {
        _logger = logger;
        _customerRepository = customerRepository;
        _salesRepository = salesRepository;
        _invoiceRepository = invoiceRepository;
        _productRepository = productRepository;
        _shippingRepository = shippingRepository;
    }

    public async Task<Result<GlobalSearchResultDto>> Handle(GlobalSearchQuery request, CancellationToken cancellationToken)
    {
        var result = new GlobalSearchResultDto();

        var search = (request.SearchString ?? string.Empty).Trim();
        if (search.Length < MinSearchLength)
        {
            return Result<GlobalSearchResultDto>.Success(result);
        }

        var limit = request.Limit > 0 ? request.Limit : 5;
        var s = search.ToLower();

        _logger.LogInformation("GlobalSearchHandler.Handle: Searching for '{SearchString}' (limit {Limit}).", search, limit);

        // All queries run through the repository IQueryable, so the EF Core global query
        // filter keeps every result scoped to the current tenant automatically.

        var customerRows = await _customerRepository.Entities
            .Where(c => c.CustomerId.ToString().Contains(search)
                        || c.Firstname.ToLower().Contains(s)
                        || c.Lastname.ToLower().Contains(s)
                        || c.CompanyName.ToLower().Contains(s))
            .OrderBy(c => c.Lastname)
            .Take(limit)
            .Select(c => new { c.Id, c.CustomerId, c.Firstname, c.Lastname, c.CompanyName })
            .ToListAsync(cancellationToken);

        result.Customers = customerRows.Select(c =>
        {
            var name = $"{c.Firstname} {c.Lastname}".Trim();
            // Keep the customer number out of the title when it already serves as the title,
            // so a name-less customer doesn't render a blank first line.
            var subtitleParts = new List<string>();
            if (name.Length > 0)
            {
                subtitleParts.Add("#" + c.CustomerId);
            }
            if (!string.IsNullOrWhiteSpace(c.CompanyName))
            {
                subtitleParts.Add(c.CompanyName);
            }

            return new GlobalSearchHitDto
            {
                Id = c.Id,
                Type = SearchEntityType.Customer,
                Title = name.Length > 0 ? name : "#" + c.CustomerId,
                Subtitle = string.Join(" · ", subtitleParts)
            };
        }).ToList();

        result.Sales = await _salesRepository.Entities
            .Where(o => o.SalesId.ToString().Contains(search))
            .OrderByDescending(o => o.SalesId)
            .Take(limit)
            .Select(o => new GlobalSearchHitDto
            {
                Id = o.Id,
                Type = SearchEntityType.Sales,
                Title = "#" + o.SalesId,
                Subtitle = (o.InvoiceAddressFirstName + " " + o.InvoiceAddressLastName).Trim()
            })
            .ToListAsync(cancellationToken);

        result.Invoices = await _invoiceRepository.Entities
            .Where(i => i.InvoiceNumber.ToLower().Contains(s))
            .OrderByDescending(i => i.InvoiceDate)
            .Take(limit)
            .Select(i => new GlobalSearchHitDto
            {
                Id = i.Id,
                Type = SearchEntityType.Invoice,
                Title = i.InvoiceNumber,
                Subtitle = (i.InvoiceAddressFirstName + " " + i.InvoiceAddressLastName).Trim()
            })
            .ToListAsync(cancellationToken);

        result.Products = await _productRepository.Entities
            .Where(p => p.ProductType != ProductType.Variant
                        && (p.Sku.ToLower().Contains(s)
                            || p.Name.ToLower().Contains(s)
                            || (p.Ean != null && p.Ean.ToLower().Contains(s))))
            .OrderBy(p => p.Name)
            .Take(limit)
            .Select(p => new GlobalSearchHitDto
            {
                Id = p.Id,
                Type = SearchEntityType.Product,
                Title = p.Name,
                Subtitle = p.Sku + (p.Ean != null && p.Ean != "" ? " · EAN " + p.Ean : "")
            })
            .ToListAsync(cancellationToken);

        result.Shippings = await _shippingRepository.Entities
            .Where(sh => sh.TrackingNumber.ToLower().Contains(s))
            .OrderByDescending(sh => sh.DateCreated)
            .Take(limit)
            .Select(sh => new GlobalSearchHitDto
            {
                Id = sh.Id,
                Type = SearchEntityType.Shipping,
                Title = sh.TrackingNumber,
                Subtitle = "#" + sh.Sales.SalesId + " · " + sh.ShippingProvider.Name
            })
            .ToListAsync(cancellationToken);

        result.TotalCount = result.Customers.Count + result.Sales.Count + result.Invoices.Count + result.Products.Count + result.Shippings.Count;

        return Result<GlobalSearchResultDto>.Success(result);
    }
}
