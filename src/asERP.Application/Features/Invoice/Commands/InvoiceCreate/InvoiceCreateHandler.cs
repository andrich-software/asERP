using System.Linq;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Commands.InvoiceCreate;

/// <summary>
/// Handler for processing invoice creation commands.
/// Implements IRequestHandler from the custom mediator to handle InvoiceCreateCommand requests
/// and return the ID of the newly created invoice wrapped in a Result.
/// </summary>
public class InvoiceCreateHandler : IRequestHandler<InvoiceCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<InvoiceCreateHandler> _logger;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly ITenantContext _tenantContext;

    public InvoiceCreateHandler(
        IAppLogger<InvoiceCreateHandler> logger,
        IInvoiceRepository invoiceRepository,
        ICustomerRepository customerRepository,
        ISalesRepository salesRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<Guid>> Handle(InvoiceCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new invoice with number: {InvoiceNumber}", request.InvoiceNumber);

        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue || currentTenantId == Guid.Empty)
        {
            return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "A tenant context is required.");
        }

        var assignedTenantIds = _tenantContext.GetAssignedTenantIds();
        if (assignedTenantIds.Count > 0 && !assignedTenantIds.Contains(currentTenantId.Value))
        {
            return Result<Guid>.NotFound(ErrorCodes.Invoice.NotFound, "Tenant not found or not assigned.");
        }

        var customer = await _customerRepository.GetByCustomerIdAsync(request.CustomerId);
        if (customer == null || customer.TenantId != currentTenantId.Value)
        {
            return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Customer not found or belongs to another tenant.");
        }

        if (request.SalesId.HasValue)
        {
            var relatedSales = await _salesRepository.GetByIdAsync(request.SalesId.Value);
            if (relatedSales == null || relatedSales.TenantId != currentTenantId.Value)
            {
                return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Sales order not found or belongs to another tenant.");
            }

            if (relatedSales.CustomerId != request.CustomerId)
            {
                return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "The sales order does not belong to the selected customer.");
            }
        }

        // Manual mapping instead of using AutoMapper
        var invoiceToCreate = new Domain.Entities.Invoice
        {
            InvoiceNumber = request.InvoiceNumber,
            InvoiceDate = request.InvoiceDate,
            CustomerId = request.CustomerId,
            SalesId = request.SalesId,
            Subtotal = request.Subtotal,
            ShippingCost = request.ShippingCost,
            TotalTax = request.TotalTax,
            Total = request.Total,
            PaymentStatus = request.PaymentStatus,
            InvoiceStatus = request.InvoiceStatus,
            PaymentMethod = request.PaymentMethod,
            PaymentTransactionId = request.PaymentTransactionId,
            Notes = request.Notes,
            InvoiceAddressFirstName = request.InvoiceAddressFirstName,
            InvoiceAddressLastName = request.InvoiceAddressLastName,
            InvoiceAddressCompanyName = request.InvoiceAddressCompanyName,
            InvoiceAddressPhone = request.InvoiceAddressPhone,
            InvoiceAddressStreet = request.InvoiceAddressStreet,
            InvoiceAddressCity = request.InvoiceAddressCity,
            InvoiceAddressZip = request.InvoiceAddressZip,
            InvoiceAddressCountry = request.InvoiceAddressCountry,
            DeliveryAddressFirstName = request.DeliveryAddressFirstName,
            DeliveryAddressLastName = request.DeliveryAddressLastName,
            DeliveryAddressCompanyName = request.DeliveryAddressCompanyName,
            DeliveryAddressPhone = request.DeliveryAddressPhone,
            DeliveryAddressStreet = request.DeliveryAddressStreet,
            DeliveryAddressCity = request.DeliveryAddressCity,
            DeliveryAddressZip = request.DeliveryAddressZip,
            DeliveryAddressCountry = request.DeliveryAddressCountry,
            TenantId = currentTenantId.Value
            // InvoiceItems would need to be mapped separately
        };

        // Add the new invoice to the database
        await _invoiceRepository.CreateAsync(invoiceToCreate);

        _logger.LogInformation("Successfully created invoice with ID: {Id}", invoiceToCreate.Id);

        return Result<Guid>.Created(invoiceToCreate.Id);
    }
}
