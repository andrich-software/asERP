using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Invoice;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Invoice.Queries.InvoiceDetail;

/// <summary>
/// Handler for processing invoice detail queries.
/// Implements IRequestHandler from the custom mediator to handle InvoiceDetailQuery requests
/// and return detailed invoice information wrapped in a Result.
/// </summary>
public class InvoiceDetailHandler : IRequestHandler<InvoiceDetailQuery, Result<InvoiceDetailDto>>
{
    private readonly IAppLogger<InvoiceDetailHandler> _logger;
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly ICustomerRepository _customerRepository;

    public InvoiceDetailHandler(
        IAppLogger<InvoiceDetailHandler> logger,
        IInvoiceRepository invoiceRepository,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _invoiceRepository = invoiceRepository ?? throw new ArgumentNullException(nameof(invoiceRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<InvoiceDetailDto>> Handle(InvoiceDetailQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving invoice details for ID: {Id}", request.Id);

        var result = new Result<InvoiceDetailDto>();

        // Retrieve invoice with all related details from the repository
        var invoice = await _invoiceRepository.GetInvoiceWithDetailsAsync(request.Id);

        // If invoice not found, return a not found result
        if (invoice == null)
        {
            result.Fail(ErrorType.NotFound, ErrorCodes.Invoice.NotFound, $"Rechnung mit ID {request.Id} wurde nicht gefunden");

            _logger.LogWarning("Invoice with ID {Id} not found", request.Id);
            return result;
        }

        // Get customer data to include customer name
        var customer = await _customerRepository.GetByCustomerIdAsync(invoice.CustomerId);
        var customerName = customer != null
            ? $"{customer.Firstname} {customer.Lastname}".Trim()
            : string.Empty;

        // Manual mapping from entity to DTO
        var data = new InvoiceDetailDto
        {
            Id = invoice.Id,
            InvoiceNumber = invoice.InvoiceNumber,
            InvoiceDate = invoice.InvoiceDate,
            CreatedDate = invoice.DateCreated,
            LastModifiedDate = invoice.DateModified,
            CustomerId = invoice.CustomerId,
            CustomerName = customerName,
            SalesId = invoice.SalesId,
            SalesNumber = invoice.SalesId.HasValue ? invoice.SalesId.Value.ToString() : string.Empty,
            InvoiceItems = invoice.InvoiceItems?.Select(item => new InvoiceItemDto
            {
                Id = item.Id,
                InvoiceId = item.InvoiceId,
                ProductId = item.ProductId,
                Name = item.Name,
                //Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                //Tax = item.TaxRate,
                //Subtotal = item.Subtotal,
                //Total = item.Total
            }).ToList() ?? new List<InvoiceItemDto>(),
            Subtotal = invoice.Subtotal,
            ShippingCost = invoice.ShippingCost,
            TotalTax = invoice.TotalTax,
            Total = invoice.Total,
            PaymentStatus = invoice.PaymentStatus,
            InvoiceStatus = invoice.InvoiceStatus,
            PaymentMethod = invoice.PaymentMethod,
            PaymentTransactionId = invoice.PaymentTransactionId,
            Notes = invoice.Notes,
            // Invoice address details
            InvoiceAddressFirstName = invoice.InvoiceAddressFirstName,
            InvoiceAddressLastName = invoice.InvoiceAddressLastName,
            InvoiceAddressCompanyName = invoice.InvoiceAddressCompanyName,
            InvoiceAddressPhone = invoice.InvoiceAddressPhone,
            InvoiceAddressStreet = invoice.InvoiceAddressStreet,
            InvoiceAddressCity = invoice.InvoiceAddressCity,
            InvoiceAddressZip = invoice.InvoiceAddressZip,
            InvoiceAddressCountry = invoice.InvoiceAddressCountry,
            // Delivery address details
            DeliveryAddressFirstName = invoice.DeliveryAddressFirstName,
            DeliveryAddressLastName = invoice.DeliveryAddressLastName,
            DeliveryAddressCompanyName = invoice.DeliveryAddressCompanyName,
            DeliveryAddressPhone = invoice.DeliveryAddressPhone,
            DeliveryAddressStreet = invoice.DeliveryAddressStreet,
            DeliveryAddressCity = invoice.DeliveryAddressCity,
            DeliveryAddressZip = invoice.DeliveryAddressZip,
            DeliveryAddressCountry = invoice.DeliveryAddressCountry
        };

        // Set successful result with the invoice details
        result.Succeeded = true;
        result.Status = ResultStatus.Ok;
        result.Data = data;

        _logger.LogInformation("Invoice with ID {Id} retrieved successfully", request.Id);

        return result;
    }
}
