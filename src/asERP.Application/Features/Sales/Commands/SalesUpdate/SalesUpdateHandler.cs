using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesUpdate;

public class SalesUpdateHandler : IRequestHandler<SalesUpdateCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesUpdateHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IPdfService _pdfService;


    public SalesUpdateHandler(
        IAppLogger<SalesUpdateHandler> logger,
        ISalesRepository salesRepository,
        ICustomerRepository customerRepository,
        IInvoiceRepository invoiceRepository,
        IPdfService pdfService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        _pdfService = pdfService ?? throw new ArgumentNullException(nameof(pdfService));
    }

    public async Task<Result<Guid>> Handle(SalesUpdateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating sales with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Validate incoming data
        var validator = new SalesUpdateValidator(_salesRepository, _customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.BadRequest;
            result.Messages.AddRange(validationResult.Errors.Select(e => e.ErrorMessage));

            _logger.LogWarning("Validation errors in update request for {0}: {1}",
                nameof(SalesUpdateCommand),
                string.Join(", ", result.Messages));

            return result;
        }

        try
        {
            // First check if sales exists globally
            var existsGlobally = await _salesRepository.ExistsGloballyAsync(request.Id);
            if (!existsGlobally)
            {
                // Sales doesn't exist at all
                _logger.LogWarning("Sales not found: {SalesId}", request.Id);
                throw new NotFoundException("Sales", request.Id);
            }

            // Check tenant isolation - sales exists globally but might belong to different tenant
            var existsForCurrentTenant = await _salesRepository.ExistsAsync(request.Id);
            if (!existsForCurrentTenant)
            {
                // Sales exists globally but not for current tenant - cross-tenant access attempt
                _logger.LogWarning("Cross-tenant access attempt for sales {SalesId}", request.Id);
                throw new NotFoundException("Sales", request.Id);
            }

            // Validate customer belongs to current tenant
            var customer = await _customerRepository.GetByCustomerIdAsync(request.CustomerId);
            if (customer == null)
            {
                result.Succeeded = false;
                result.StatusCode = ResultStatusCode.BadRequest;
                result.Messages.Add("The specified customer does not exist or does not belong to your tenant.");
                _logger.LogWarning("Cross-tenant customer access attempt for customer {CustomerId}", request.CustomerId);
                return result;
            }

            // Load the tracked entity and mutate it, so the persistence layer keeps
            // TenantId/DateCreated intact instead of nulling them on a detached update.
            var salesToUpdate = await _salesRepository.GetByIdAsync(request.Id);
            if (salesToUpdate == null)
            {
                _logger.LogWarning("Cross-tenant access attempt for sales {SalesId}", request.Id);
                throw new NotFoundException("Sales", request.Id);
            }

            // The multi-step mutation (sales row + invoice) is wrapped in a transaction so a
            // failure mid-way does not leave a partially updated order.
            await using var transaction = await _salesRepository.BeginTransactionAsync(cancellationToken);

            salesToUpdate.SalesId = request.SalesId;
            salesToUpdate.SalesChannelId = request.SalesChannelId;
            salesToUpdate.RemoteSalesId = request.RemoteSalesId;
            salesToUpdate.CustomerId = request.CustomerId;
            salesToUpdate.Status = request.Status;
            salesToUpdate.PaymentMethod = request.PaymentMethod;
            salesToUpdate.PaymentStatus = request.PaymentStatus;
            salesToUpdate.PaymentProvider = request.PaymentProvider;
            salesToUpdate.PaymentTransactionId = request.PaymentTransactionId;
            salesToUpdate.CustomerNote = request.CustomerNote;
            salesToUpdate.InternalNote = request.InternalNote;
            salesToUpdate.Subtotal = request.Subtotal;
            salesToUpdate.ShippingCost = request.ShippingCost;
            salesToUpdate.TotalTax = request.TotalTax;
            salesToUpdate.Total = request.Total;
            salesToUpdate.DeliveryAddressFirstName = request.DeliveryAddressFirstName;
            salesToUpdate.DeliveryAddressLastName = request.DeliveryAddressLastName;
            salesToUpdate.DeliveryAddressCompanyName = request.DeliveryAddressCompanyName;
            salesToUpdate.DeliveryAddressPhone = request.DeliveryAddressPhone;
            salesToUpdate.DeliveryAddressStreet = request.DeliveryAddressStreet;
            salesToUpdate.DeliveryAddressCity = request.DeliveryAddressCity;
            salesToUpdate.DeliveryAddressZip = request.DeliveryAddressZip;
            salesToUpdate.DeliveryAddressCountry = request.DeliveryAddressCountry;
            salesToUpdate.InvoiceAddressFirstName = request.InvoiceAddressFirstName;
            salesToUpdate.InvoiceAddressLastName = request.InvoiceAddressLastName;
            salesToUpdate.InvoiceAddressCompanyName = request.InvoiceAddressCompanyName;
            salesToUpdate.InvoiceAddressPhone = request.InvoiceAddressPhone;
            salesToUpdate.InvoiceAddressStreet = request.InvoiceAddressStreet;
            salesToUpdate.InvoiceAddressCity = request.InvoiceAddressCity;
            salesToUpdate.InvoiceAddressZip = request.InvoiceAddressZip;
            salesToUpdate.InvoiceAddressCountry = request.InvoiceAddressCountry;
            salesToUpdate.DateSalesed = request.DateSalesed.Kind == DateTimeKind.Utc
                ? request.DateSalesed
                : request.DateSalesed.ToUniversalTime();
            // SalesItems would have to be mapped separately.

            // Save changes (entity is already tracked, so just save)
            await _salesRepository.SaveChangesAsync(cancellationToken);

            // Check whether an invoice can be created for this order.
            bool canCreateInvoice = await _salesRepository.CanCreateInvoice(salesToUpdate.Id);

            if (canCreateInvoice)
            {
                try
                {
                    // Load the sales order with its details.
                    var salesWithDetails = await _salesRepository.GetWithDetailsAsync(salesToUpdate.Id);

                    if (salesWithDetails != null)
                    {
                        await _invoiceRepository.CreateInvoiceFromSalesAsync(salesWithDetails);
                    }
                }
                catch (Exception ex)
                {
                    // Invoice creation must not silently succeed: surface a warning to the caller
                    // (compliance-relevant in an ERP) and log the full exception server-side.
                    _logger.LogError(ex, "Error creating invoice for sales ID {Id}", salesToUpdate.Id);
                    result.Messages.Add("The sales order was updated, but the invoice could not be created. Please create it manually.");
                }
            }

            await transaction.CommitAsync(cancellationToken);

            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
            result.Data = salesToUpdate.Id;

            _logger.LogInformation("Successfully updated sales with ID: {Id}", salesToUpdate.Id);
        }
        catch (NotFoundException)
        {
            // Let NotFoundException bubble up to middleware for proper 404 handling
            throw;
        }
        catch (Exception ex)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.InternalServerError;
            result.Messages.Add("An error occurred while updating the sales.");

            _logger.LogError(ex, "Error updating sales with ID: {Id}", request.Id);
        }

        return result;
    }
}
