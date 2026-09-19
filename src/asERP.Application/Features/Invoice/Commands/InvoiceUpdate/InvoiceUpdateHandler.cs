using System.Linq;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Commands.InvoiceUpdate;

/// <summary>
/// Handler for processing invoice update commands.
/// Implements IRequestHandler from the custom mediator to handle InvoiceUpdateCommand requests
/// and return the ID of the updated invoice wrapped in a Result.
/// </summary>
public class InvoiceUpdateHandler : IRequestHandler<InvoiceUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<InvoiceUpdateHandler> _logger;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly ITenantContext _tenantContext;

    public InvoiceUpdateHandler(
        IAppLogger<InvoiceUpdateHandler> logger,
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

    public async Task<Result<Guid>> Handle(InvoiceUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating invoice with ID: {Id}", request.Id);

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

        var invoiceToUpdate = await _invoiceRepository.GetByIdAsync(request.Id);
        if (invoiceToUpdate == null || invoiceToUpdate.TenantId != currentTenantId.Value)
        {
            return Result<Guid>.NotFound(ErrorCodes.Invoice.NotFound, "Invoice not found.");
        }

        var customer = await _customerRepository.GetByCustomerIdAsync(request.CustomerId);
        if (customer == null || customer.TenantId != currentTenantId.Value)
        {
            return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Customer not found or belongs to another tenant.");
        }

        if (request.SalesId.HasValue)
        {
            var sales = await _salesRepository.GetByIdAsync(request.SalesId.Value);
            if (sales == null || sales.TenantId != currentTenantId.Value)
            {
                return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Sales order not found or belongs to another tenant.");
            }

            if (sales.CustomerId != request.CustomerId)
            {
                return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "The sales order does not belong to the selected customer.");
            }
        }

        var existingInvoices = await _invoiceRepository.GetAllAsync();
        var duplicateInvoiceNumber = existingInvoices.Any(i => i.Id != invoiceToUpdate.Id && i.InvoiceNumber == request.InvoiceNumber && i.TenantId == currentTenantId.Value);
        if (duplicateInvoiceNumber)
        {
            return Result<Guid>.Invalid(ErrorCodes.Invoice.AlreadyExists, "An invoice with this number already exists.");
        }

        invoiceToUpdate.InvoiceNumber = request.InvoiceNumber;
        invoiceToUpdate.InvoiceDate = request.InvoiceDate;
        invoiceToUpdate.CustomerId = request.CustomerId;
        invoiceToUpdate.SalesId = request.SalesId;
        invoiceToUpdate.Subtotal = request.Subtotal;
        invoiceToUpdate.ShippingCost = request.ShippingCost;
        invoiceToUpdate.TotalTax = request.TotalTax;
        invoiceToUpdate.Total = request.Total;
        invoiceToUpdate.PaymentStatus = request.PaymentStatus;
        invoiceToUpdate.InvoiceStatus = request.InvoiceStatus;
        invoiceToUpdate.PaymentMethod = request.PaymentMethod;
        invoiceToUpdate.PaymentTransactionId = request.PaymentTransactionId;
        invoiceToUpdate.Notes = request.Notes;
        invoiceToUpdate.InvoiceAddressFirstName = request.InvoiceAddressFirstName;
        invoiceToUpdate.InvoiceAddressLastName = request.InvoiceAddressLastName;
        invoiceToUpdate.InvoiceAddressCompanyName = request.InvoiceAddressCompanyName;
        invoiceToUpdate.InvoiceAddressPhone = request.InvoiceAddressPhone;
        invoiceToUpdate.InvoiceAddressStreet = request.InvoiceAddressStreet;
        invoiceToUpdate.InvoiceAddressCity = request.InvoiceAddressCity;
        invoiceToUpdate.InvoiceAddressZip = request.InvoiceAddressZip;
        invoiceToUpdate.InvoiceAddressCountry = request.InvoiceAddressCountry;
        invoiceToUpdate.DeliveryAddressFirstName = request.DeliveryAddressFirstName;
        invoiceToUpdate.DeliveryAddressLastName = request.DeliveryAddressLastName;
        invoiceToUpdate.DeliveryAddressCompanyName = request.DeliveryAddressCompanyName;
        invoiceToUpdate.DeliveryAddressPhone = request.DeliveryAddressPhone;
        invoiceToUpdate.DeliveryAddressStreet = request.DeliveryAddressStreet;
        invoiceToUpdate.DeliveryAddressCity = request.DeliveryAddressCity;
        invoiceToUpdate.DeliveryAddressZip = request.DeliveryAddressZip;
        invoiceToUpdate.DeliveryAddressCountry = request.DeliveryAddressCountry;

        await _invoiceRepository.UpdateAsync(invoiceToUpdate);

        _logger.LogInformation("Successfully updated invoice with ID: {Id}", invoiceToUpdate.Id);

        return Result<Guid>.Ok(invoiceToUpdate.Id);
    }
}
