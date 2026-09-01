using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Domain.Wrapper;

namespace asERP.Application.Features.Sales.Commands.SalesCreate;

/// <summary>
/// Handler for processing sales creation commands.
/// Implements IRequestHandler from the custom mediator to handle SalesCreateCommand requests
/// and return the ID of the newly created sales wrapped in a Result.
/// </summary>
public class SalesCreateHandler : IRequestHandler<SalesCreateCommand, Result<Guid>>
{
    private readonly IAppLogger<SalesCreateHandler> _logger;
    private readonly ISalesRepository _salesRepository;
    private readonly ICustomerRepository _customerRepository;

    public SalesCreateHandler(
        IAppLogger<SalesCreateHandler> logger,
        ISalesRepository salesRepository,
        ICustomerRepository customerRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
    }

    public async Task<Result<Guid>> Handle(SalesCreateCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new sales with ID: {Id}", request.Id);

        var result = new Result<Guid>();

        // Auto-generate SalesId if not provided
        var salesId = request.SalesId;
        if (salesId == 0)
        {
            salesId = await _salesRepository.GetNextSalesIdAsync();
        }

        // Manual mapping instead of using AutoMapper
        var salesToCreate = new Domain.Entities.Sales
        {
            SalesId = salesId,
            SalesChannelId = request.SalesChannelId,
            RemoteSalesId = request.RemoteSalesId,
            CustomerId = request.CustomerId,
            Status = request.Status,
            PaymentMethod = request.PaymentMethod,
            PaymentStatus = request.PaymentStatus,
            PaymentProvider = request.PaymentProvider,
            PaymentTransactionId = request.PaymentTransactionId,
            CustomerNote = request.CustomerNote,
            InternalNote = request.InternalNote,
            Subtotal = request.Subtotal,
            ShippingCost = request.ShippingCost,
            TotalTax = request.TotalTax,
            Total = request.Total,
            DeliveryAddressFirstName = request.DeliveryAddressFirstName,
            DeliveryAddressLastName = request.DeliveryAddressLastName,
            DeliveryAddressCompanyName = request.DeliveryAddressCompanyName,
            DeliveryAddressPhone = request.DeliveryAddressPhone,
            DeliveryAddressStreet = request.DeliveryAddressStreet,
            DeliveryAddressCity = request.DeliveryAddressCity,
            DeliveryAddressZip = request.DeliveryAddressZip,
            DeliveryAddressCountry = request.DeliveryAddressCountry,
            InvoiceAddressFirstName = request.InvoiceAddressFirstName,
            InvoiceAddressLastName = request.InvoiceAddressLastName,
            InvoiceAddressCompanyName = request.InvoiceAddressCompanyName,
            InvoiceAddressPhone = request.InvoiceAddressPhone,
            InvoiceAddressStreet = request.InvoiceAddressStreet,
            InvoiceAddressCity = request.InvoiceAddressCity,
            InvoiceAddressZip = request.InvoiceAddressZip,
            InvoiceAddressCountry = request.InvoiceAddressCountry,
            DateSalesed = request.DateSalesed.Kind == DateTimeKind.Utc
                ? request.DateSalesed
                : request.DateSalesed.ToUniversalTime()
            // SalesItems would need to be mapped separately
        };

        // Add the new sales to the database
        await _salesRepository.CreateAsync(salesToCreate);

        // Set successful result with the new sales ID
        result.Succeeded = true;
        result.Status = ResultStatus.Created;
        result.Data = salesToCreate.Id;

        _logger.LogInformation("Successfully created sales with ID: {Id}", salesToCreate.Id);

        return result;
    }
}
