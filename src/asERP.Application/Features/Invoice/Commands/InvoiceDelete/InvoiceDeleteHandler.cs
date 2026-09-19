using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Mediator;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Commands.InvoiceDelete;

/// <summary>
/// Handler for processing invoice deletion commands.
/// Implements IRequestHandler from the custom mediator to handle DeleteInvoiceCommand requests
/// and return the ID of the deleted invoice wrapped in a Result.
/// </summary>
public class InvoiceDeleteHandler : IRequestHandler<InvoiceDeleteCommand, Result<Guid>>
{
    private readonly IAppLogger<InvoiceDeleteHandler> _logger;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ITenantContext _tenantContext;

    public InvoiceDeleteHandler(
        IAppLogger<InvoiceDeleteHandler> logger,
        IInvoiceRepository invoiceRepository,
        ITenantContext tenantContext)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        _tenantContext = tenantContext ?? throw new ArgumentNullException(nameof(tenantContext));
    }

    public async Task<Result<Guid>> Handle(InvoiceDeleteCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting invoice with ID: {Id}", request.Id);

        var currentTenantId = _tenantContext.GetCurrentTenantId();
        if (!currentTenantId.HasValue || currentTenantId == Guid.Empty)
        {
            return Result<Guid>.NotFound(ErrorCodes.Invoice.NotFound, "Invoice not found.");
        }

        var assignedTenantIds = _tenantContext.GetAssignedTenantIds();
        if (assignedTenantIds.Count > 0 && !assignedTenantIds.Contains(currentTenantId.Value))
        {
            return Result<Guid>.NotFound(ErrorCodes.Invoice.NotFound, "Tenant not found or not assigned.");
        }

        var invoiceToDelete = await _invoiceRepository.GetInvoiceWithDetailsAsync(request.Id);
        if (invoiceToDelete == null || invoiceToDelete.TenantId != currentTenantId.Value)
        {
            return Result<Guid>.NotFound(ErrorCodes.Invoice.NotFound, "Invoice not found.");
        }

        if (invoiceToDelete.PaymentStatus == PaymentStatus.CompletelyPaid)
        {
            return Result<Guid>.Invalid(ErrorCodes.Invoice.Invalid, "Paid invoices cannot be deleted.");
        }

        await _invoiceRepository.DeleteAsync(invoiceToDelete);

        _logger.LogInformation("Successfully deleted invoice with ID: {Id}", invoiceToDelete.Id);

        return Result<Guid>.Ok(invoiceToDelete.Id);
    }
}
