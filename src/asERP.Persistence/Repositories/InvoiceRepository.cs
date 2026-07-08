using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Extensions;
using asERP.Domain.Dtos.Company;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace asERP.Persistence.Repositories;

/// <summary>
/// Repository for Invoice entity operations
/// </summary>
public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
    private readonly ILogger<InvoiceRepository> _logger;
    private readonly IPdfService _pdfService;

    public InvoiceRepository(ApplicationDbContext context, ITenantContext tenantContext, ILogger<InvoiceRepository> logger, IPdfService pdfService) : base(context, tenantContext)
    {
        _logger = logger;
        _pdfService = pdfService;
    }

    // You can add invoice-specific repository methods here if needed in the future
    // For example:

    /// <summary>
    /// Gets an invoice with all related details including customer and invoice items
    /// </summary>
    /// <param name="id">The invoice ID</param>
    /// <returns>The invoice with all related entities or null if not found</returns>
    public async Task<Invoice?> GetInvoiceWithDetailsAsync(Guid id)
    {
        // Tenant isolation via the global query filter.
        return await Context.Set<Invoice>()
            .Where(x => x.Id == id)
            .Include(x => x.Customer)
            .Include(x => x.Sales)
            .Include(x => x.InvoiceItems)
            .AsSplitQuery()
            .FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets invoices for a specific customer
    /// </summary>
    /// <param name="customerId">The customer ID</param>
    /// <returns>Collection of invoices for the customer</returns>
    public async Task<ICollection<Invoice>> GetInvoicesByCustomerIdAsync(int customerId)
    {
        return await Context.Set<Invoice>()
            .Where(x => x.CustomerId == customerId)
            .ToListAsync();
    }

    /// <summary>
    /// Gets invoices by their status
    /// </summary>
    /// <param name="status">The invoice status</param>
    /// <returns>Collection of invoices with the specified status</returns>
    public async Task<ICollection<Invoice>> GetInvoicesByStatusAsync(InvoiceStatus status)
    {
        return await Context.Set<Invoice>()
            .Where(x => x.InvoiceStatus == status)
            .ToListAsync();
    }

    /// <summary>
    /// Creates an invoice from an sales, including all invoice items from sales items
    /// </summary>
    /// <param name="sales">The sales with details to create invoice from</param>
    /// <returns>The created invoice</returns>
    public async Task<Invoice> CreateInvoiceFromSalesAsync(Sales sales)
    {
        _logger.LogInformation("Creating invoice for sales with ID: {Id}", sales.Id);

        try
        {
            // Create the invoice
            var invoice = new Invoice
            {
                InvoiceNumber = $"INV-{DateTime.UtcNow:yyyyMMdd}-{sales.Id}",
                InvoiceDate = DateTime.UtcNow,
                CustomerId = sales.CustomerId,
                SalesId = sales.Id,
                Subtotal = sales.Subtotal,
                ShippingCost = sales.ShippingCost,
                TotalTax = sales.TotalTax,
                Total = sales.Total,
                PaymentStatus = sales.PaymentStatus,
                InvoiceStatus = InvoiceStatus.Created,
                PaymentMethod = sales.PaymentMethod,
                PaymentTransactionId = sales.PaymentTransactionId,
                Notes = $"Automatically generated invoice for sales {sales.Id}",

                // Invoice address
                InvoiceAddressFirstName = sales.InvoiceAddressFirstName,
                InvoiceAddressLastName = sales.InvoiceAddressLastName,
                InvoiceAddressCompanyName = sales.InvoiceAddressCompanyName,
                InvoiceAddressPhone = sales.InvoiceAddressPhone,
                InvoiceAddressStreet = sales.InvoiceAddressStreet,
                InvoiceAddressCity = sales.InvoiceAddressCity,
                InvoiceAddressZip = sales.InvoiceAddressZip,
                InvoiceAddressCountry = sales.InvoiceAddressCountry,

                // Delivery address
                DeliveryAddressFirstName = sales.DeliveryAddressFirstName,
                DeliveryAddressLastName = sales.DeliveryAddressLastName,
                DeliveryAddressCompanyName = sales.DeliveryAddressCompanyName,
                DeliveryAddressPhone = sales.DeliveryAddressPhone,
                DeliveryAddressStreet = sales.DeliveryAddressStreet,
                DeliveryAddressCity = sales.DeliveryAddressCity,
                DeliveryAddressZip = sales.DeliveryAddressZip,
                DeliveryAddressCountry = sales.DeliveryAddressCountry
            };

            // Create invoice items from sales items. SalesItem.Price is the per-unit net price and
            // TaxRate is a percentage; derive line total and tax amount from quantity.
            if (sales.SalesItems != null)
            {
                foreach (var salesItem in sales.SalesItems)
                {
                    var quantity = (decimal)salesItem.Quantity;
                    var totalPrice = salesItem.Price * quantity;
                    var taxAmount = totalPrice * (decimal)salesItem.TaxRate / 100m;

                    var invoiceItem = new InvoiceItem
                    {
                        Name = salesItem.Name,
                        SKU = salesItem.MissingProductSku,
                        EAN = salesItem.MissingProductEan,
                        ProductId = salesItem.ProductId,
                        Quantity = salesItem.Quantity,
                        UnitPrice = salesItem.Price,
                        TotalPrice = totalPrice,
                        TaxRate = salesItem.TaxRate,
                        TaxAmount = taxAmount
                    };

                    invoice.InvoiceItems.Add(invoiceItem);
                }
            }

            // Persist the invoice
            var createdInvoice = await this.CreateAsync(invoice);

            // Generate the PDF invoice. The company/sender block comes from the tenant that owns
            // the invoice (no installation-wide company default exists anymore).
            string outputPath = $"Invoices/INV-{DateTime.UtcNow:yyyyMMdd}-{sales.Id}.pdf";
            var company = new CompanySenderInfo();
            var tenantId = invoice.TenantId ?? sales.TenantId;
            if (tenantId.HasValue)
            {
                var tenant = await Context.Set<Tenant>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(t => t.Id == tenantId.Value);
                if (tenant != null)
                {
                    company = tenant.ToCompanySenderInfo();
                }
            }
            _pdfService.GenerateInvoice(invoice, company, outputPath);

            _logger.LogInformation("Successfully created invoice for sales ID: {Id}", sales.Id);
            return invoice;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error creating invoice for sales ID {Id}: {Message}", sales.Id, ex.Message);
            throw;
        }
    }

    public override async Task DeleteAsync(Invoice entity)
    {
        var invoice = await Context.Invoice
            .IgnoreQueryFilters()
            .Include(i => i.InvoiceItems)
            .FirstOrDefaultAsync(i => i.Id == entity.Id);

        if (invoice == null)
        {
            throw new InvalidOperationException($"Invoice with ID {entity.Id} not found for deletion");
        }

        var currentTenantId = TenantContext.GetCurrentTenantId();
        EnsureDeletableByCurrentTenant(invoice.TenantId, currentTenantId);

        if (invoice.InvoiceItems?.Any() == true)
        {
            Context.InvoiceItem.RemoveRange(invoice.InvoiceItems);
        }

        Context.Remove(invoice);
        await Context.SaveChangesAsync();
    }
}
