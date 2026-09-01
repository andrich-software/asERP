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

        var result = new Result<Guid>();

        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue || currentTenantId == Guid.Empty)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Ein Mandantenkontext ist erforderlich.");
            return result;
        }

        var assignedTenantIds = _tenantContext.GetAssignedTenantIds();
        if (assignedTenantIds.Count > 0 && !assignedTenantIds.Contains(currentTenantId.Value))
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Invoice.NotFound, "Mandant wurde nicht gefunden oder ist nicht zugewiesen.");
            return result;
        }

        var invoiceToUpdate = await _invoiceRepository.GetByIdAsync(request.Id);
        if (invoiceToUpdate == null || invoiceToUpdate.TenantId != currentTenantId.Value)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Invoice.NotFound, "Rechnung wurde nicht gefunden.");
            return result;
        }

        var customer = await _customerRepository.GetByCustomerIdAsync(request.CustomerId);
        if (customer == null || customer.TenantId != currentTenantId.Value)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Kunde wurde nicht gefunden oder gehört zu einem anderen Mandanten.");
            return result;
        }

        if (request.SalesId.HasValue)
        {
            var sales = await _salesRepository.GetByIdAsync(request.SalesId.Value);
            if (sales == null || sales.TenantId != currentTenantId.Value)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Verkauf wurde nicht gefunden oder gehört zu einem anderen Mandanten.");
                return result;
            }

            if (sales.CustomerId != request.CustomerId)
            {
                result.Fail(ErrorType.Validation, ErrorCodes.Invoice.Invalid, "Die Verkauf gehört nicht zum ausgewählten Kunden.");
                return result;
            }
        }

        var existingInvoices = await _invoiceRepository.GetAllAsync();
        var duplicateInvoiceNumber = existingInvoices.Any(i => i.Id != invoiceToUpdate.Id && i.InvoiceNumber == request.InvoiceNumber && i.TenantId == currentTenantId.Value);
        if (duplicateInvoiceNumber)
        {
            result.Fail(ErrorType.Validation, ErrorCodes.Invoice.AlreadyExists, "Eine Rechnung mit dieser Nummer existiert bereits.");
            return result;
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

        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = invoiceToUpdate.Id;

        _logger.LogInformation("Successfully updated invoice with ID: {Id}", invoiceToUpdate.Id);

        return result;
    }
}
