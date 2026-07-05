using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Mediator;
using asERP.Application.Models.Email;
using asERP.Application.Notifications;
using asERP.Domain.Enums;

namespace asERP.Application.Features.Shipping.NotificationHandlers;

/// <summary>
/// Sends the customer "on the way" / "delivered" email when <c>ShippingStatusUpdater</c> consumed
/// a notification slot. Best-effort by design: every failure is logged and swallowed — the custom
/// mediator rethrows handler exceptions, and a mail problem must never fail the status update.
/// Idempotency lives in the updater (stamps), opt-in lives here (tenant toggles, default off).
/// </summary>
public sealed class ShippingCustomerNotificationHandler : INotificationHandler<ShippingCustomerNotificationDue>
{
    private readonly IAppLogger<ShippingCustomerNotificationHandler> _logger;
    private readonly IShippingRepository _shippingRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IEmailTemplateService _emailTemplateService;
    private readonly IEmailService _emailService;

    public ShippingCustomerNotificationHandler(
        IAppLogger<ShippingCustomerNotificationHandler> logger,
        IShippingRepository shippingRepository,
        ISalesRepository salesRepository,
        ITenantRepository tenantRepository,
        IEmailTemplateService emailTemplateService,
        IEmailService emailService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shippingRepository = shippingRepository ?? throw new ArgumentNullException(nameof(shippingRepository));
        _salesRepository = salesRepository ?? throw new ArgumentNullException(nameof(salesRepository));
        _tenantRepository = tenantRepository ?? throw new ArgumentNullException(nameof(tenantRepository));
        _emailTemplateService = emailTemplateService ?? throw new ArgumentNullException(nameof(emailTemplateService));
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
    }

    public async Task Handle(ShippingCustomerNotificationDue notification, CancellationToken cancellationToken)
    {
        try
        {
            await SendAsync(notification, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError("Customer {Kind} notification for shipping {ShippingId} failed: {Error}",
                notification.Kind, notification.ShippingId, ex);
        }
    }

    private async Task SendAsync(ShippingCustomerNotificationDue notification, CancellationToken cancellationToken)
    {
        if (notification.TenantId is not { } tenantId)
        {
            return;
        }

        var tenant = await _tenantRepository.GetByIdAsync(tenantId, asNoTracking: true);
        var enabled = notification.Kind == ShippingCustomerNotificationKind.Shipped
            ? tenant?.SendShippingNotificationEmails == true
            : tenant?.SendDeliveryNotificationEmails == true;
        if (!enabled)
        {
            return;
        }

        var shipping = await _shippingRepository.GetWithDetailsAsync(notification.ShippingId);
        if (shipping == null)
        {
            _logger.LogWarning("Shipping {ShippingId} not found, skipping customer notification", notification.ShippingId);
            return;
        }

        // Safety net for a cancel racing the notification — never mail about a dead shipment.
        if (shipping.Status is ShippingStatus.Cancelled or ShippingStatus.ReturnedToSender or ShippingStatus.Lost)
        {
            return;
        }

        var sales = await _salesRepository.GetWithDetailsAsync(notification.SalesId);
        if (sales == null)
        {
            _logger.LogWarning("Sales {SalesId} not found, skipping customer notification for shipping {ShippingId}",
                notification.SalesId, notification.ShippingId);
            return;
        }

        var email = sales.Customer?.Email;
        if (string.IsNullOrWhiteSpace(email))
        {
            _logger.LogInformation("Customer of sales {SalesNumber} has no email address, skipping {Kind} notification for shipping {ShippingId}",
                sales.SalesId, notification.Kind, notification.ShippingId);
            return;
        }

        var parcelItems = await _shippingRepository.GetAssignedSalesItemsAsync(notification.ShippingId);

        var customerName = $"{sales.DeliveryAddressFirstName} {sales.DeliveryAddressLastName}".Trim();
        if (customerName.Length == 0 && sales.Customer != null)
        {
            customerName = $"{sales.Customer.Firstname} {sales.Customer.Lastname}".Trim();
        }

        var data = new ShippingNotificationEmailData
        {
            SalesNumber = sales.SalesId,
            CustomerName = customerName,
            CarrierName = shipping.ShippingProvider.Name,
            RateName = shipping.ShippingProviderRate?.Name,
            TrackingNumber = shipping.TrackingNumber,
            TrackingUrl = shipping.TrackingUrl,
            IsPartialShipment = sales.SalesItems.Any(i => i.ShippingId != shipping.Id),
            Items = parcelItems.Select(i => new ShippingNotificationEmailItem
            {
                Quantity = i.Quantity,
                Name = i.Name,
                Sku = i.MissingProductSku
            }).ToList()
        };

        var (subject, body) = notification.Kind == ShippingCustomerNotificationKind.Shipped
            ? ($"Ihre Bestellung {data.SalesNumber} ist unterwegs", await _emailTemplateService.GenerateShippingNotificationEmailAsync(data))
            : ($"Ihre Bestellung {data.SalesNumber} wurde zugestellt", await _emailTemplateService.GenerateDeliveryNotificationEmailAsync(data));

        var sent = await _emailService.SendEmailAsync(new EmailMessage
        {
            To = email,
            ToName = customerName.Length > 0 ? customerName : null,
            Subject = subject,
            Body = body,
            IsHtml = true
        }, tenantId);

        if (sent)
        {
            _logger.LogInformation("Customer {Kind} notification for shipping {ShippingId} sent to customer of sales {SalesNumber}",
                notification.Kind, notification.ShippingId, sales.SalesId);
        }
        else
        {
            _logger.LogWarning("Customer {Kind} notification for shipping {ShippingId} could not be sent",
                notification.Kind, notification.ShippingId);
        }
    }
}
