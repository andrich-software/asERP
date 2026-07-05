using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Services;

/// <summary>
/// Customer shipping/delivery notification emails: exactly one mail per shipment and kind,
/// tenant opt-in respected, mail failures never fail the status update.
/// Customer numbers 960-979 are reserved for this class.
/// </summary>
public class ShippingCustomerNotificationTests : TenantIsolatedTestBase
{
    private IShippingStatusUpdater Updater => Scope.ServiceProvider.GetRequiredService<IShippingStatusUpdater>();

    private FakeEmailService EmailService => (FakeEmailService)Factory.Services.GetRequiredService<IEmailService>();

    private async Task<Domain.Entities.Shipping> SeedShippingAsync(
        int customerNumber,
        Guid? tenantId = null,
        ShippingStatus status = ShippingStatus.LabelCreated,
        bool sendShippedMail = true,
        bool sendDeliveredMail = true,
        bool assignAllItems = false,
        string? customerEmail = "unset")
    {
        var tenant = tenantId ?? TenantConstants.TestTenant1Id;
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var tenantEntity = await DbContext.Tenant.FirstAsync(t => t.Id == tenant);
        tenantEntity.SendShippingNotificationEmails = sendShippedMail;
        tenantEntity.SendDeliveryNotificationEmails = sendDeliveredMail;

        var provider = ShippingTestDataSeeder.AddProvider(DbContext, tenant);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, tenant, customerNumber);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, status,
            trackingNumber: $"TRACK-{customerNumber}");
        shipping.TrackingUrl = $"https://tracking.example/{customerNumber}";

        // First order line goes into the parcel; the second stays open (partial shipment)
        // unless the test wants a full shipment.
        var items = sales.SalesItems.ToList();
        items[0].ShippingId = shipping.Id;
        if (assignAllItems)
        {
            items[1].ShippingId = shipping.Id;
        }

        await DbContext.SaveChangesAsync();

        if (customerEmail != "unset")
        {
            var customer = await DbContext.Customer.FirstAsync(c => c.CustomerId == customerNumber);
            customer.Email = customerEmail ?? string.Empty;
            await DbContext.SaveChangesAsync();
        }

        TenantContext.SetCurrentTenantId(tenant);
        return shipping;
    }

    [Fact]
    public async Task FirstInTransit_SendsShippedMail_WithTrackingLinkAndPartialHint()
    {
        var shipping = await SeedShippingAsync(960);

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        TestAssertions.AssertTrue(result.Succeeded);
        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertEqual("ship.tester960@test.com", sent[0].Message.To);
        TestAssertions.AssertTrue(sent[0].Message.Subject.Contains("unterwegs"));
        TestAssertions.AssertTrue(sent[0].Message.Subject.Contains($"{30000 + 960}"));
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("TRACK-960"));
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("https://tracking.example/960"));
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("Item 1"));
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("separat versendet"));

        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNotNull(updated.CustomerNotifiedAt);
        TestAssertions.AssertNull(updated.CustomerDeliveryNotifiedAt);
    }

    [Fact]
    public async Task SecondOnTheWayTransition_DoesNotSendAgain()
    {
        var shipping = await SeedShippingAsync(961);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);
        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.OutForDelivery);

        TestAssertions.AssertEqual(1, EmailService.Sent.Count);
    }

    [Fact]
    public async Task Delivered_AfterShipped_SendsSecondMail()
    {
        var shipping = await SeedShippingAsync(962);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);
        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Delivered);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(2, sent.Count);
        TestAssertions.AssertTrue(sent[1].Message.Subject.Contains("zugestellt"));

        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNotNull(updated.CustomerNotifiedAt);
        TestAssertions.AssertNotNull(updated.CustomerDeliveryNotifiedAt);
    }

    [Fact]
    public async Task SkipAheadToDelivered_SendsOnlyDeliveredMail()
    {
        var shipping = await SeedShippingAsync(963);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Delivered);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertTrue(sent[0].Message.Subject.Contains("zugestellt"));

        // Both slots consumed — a later manual downgrade + re-transition must not mail again.
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNotNull(updated.CustomerNotifiedAt);
        TestAssertions.AssertNotNull(updated.CustomerDeliveryNotifiedAt);
    }

    [Fact]
    public async Task LabelCreated_DoesNotSendMail()
    {
        var shipping = await SeedShippingAsync(964, status: ShippingStatus.Open);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.LabelCreated);

        TestAssertions.AssertEmpty(EmailService.Sent);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNull(updated.CustomerNotifiedAt);
    }

    [Fact]
    public async Task Cancelled_DoesNotSendMail()
    {
        var shipping = await SeedShippingAsync(965);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Cancelled, isSystemGenerated: false);

        TestAssertions.AssertEmpty(EmailService.Sent);
    }

    [Fact]
    public async Task ToggleOff_DoesNotSend_ButConsumesSlot()
    {
        var shipping = await SeedShippingAsync(966, sendShippedMail: false, sendDeliveredMail: false);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        TestAssertions.AssertEmpty(EmailService.Sent);

        // The slot is consumed regardless — enabling the toggle later must not mail old shipments.
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNotNull(updated.CustomerNotifiedAt);
    }

    [Fact]
    public async Task DeliveredToggleOff_SkipAhead_SendsNoMail()
    {
        var shipping = await SeedShippingAsync(967, sendShippedMail: true, sendDeliveredMail: false);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Delivered);

        // Skip-ahead is a Delivered-kind notification; the shipped toggle does not apply.
        TestAssertions.AssertEmpty(EmailService.Sent);
    }

    [Fact]
    public async Task ShippedToggleOff_DeliveredToggleOn_SendsOnlyDeliveredMail()
    {
        var shipping = await SeedShippingAsync(968, sendShippedMail: false, sendDeliveredMail: true);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);
        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Delivered);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertTrue(sent[0].Message.Subject.Contains("zugestellt"));
    }

    [Fact]
    public async Task CustomerWithoutEmail_SkipsSilently_StatusUpdateSucceeds()
    {
        var shipping = await SeedShippingAsync(969, customerEmail: null);

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEmpty(EmailService.Sent);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.InTransit, updated.Status);
        TestAssertions.AssertNotNull(updated.CustomerNotifiedAt);
    }

    [Fact]
    public async Task EmailServiceThrows_StatusUpdateStillSucceeds()
    {
        var shipping = await SeedShippingAsync(970);
        EmailService.ThrowOnSend = true;

        try
        {
            var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

            TestAssertions.AssertTrue(result.Succeeded);
            var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
            TestAssertions.AssertEqual(ShippingStatus.InTransit, updated.Status);
        }
        finally
        {
            EmailService.ThrowOnSend = false;
        }
    }

    [Fact]
    public async Task EmailServiceReturnsFalse_StatusUpdateStillSucceeds()
    {
        var shipping = await SeedShippingAsync(971);
        EmailService.FailNextSend = true;

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEmpty(EmailService.Sent);
    }

    [Fact]
    public async Task FullShipment_MailHasNoPartialHint()
    {
        var shipping = await SeedShippingAsync(972, assignAllItems: true);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertFalse(sent[0].Message.Body.Contains("separat versendet"),
            "full shipment must not contain the partial-shipment hint");
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("Item 2"));
    }

    [Fact]
    public async Task MissingTrackingUrl_MailContainsPlainNumber()
    {
        var shipping = await SeedShippingAsync(973);
        var tracked = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        tracked.TrackingUrl = null;
        await DbContext.SaveChangesAsync();

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertTrue(sent[0].Message.Body.Contains("TRACK-973"));
        TestAssertions.AssertFalse(sent[0].Message.Body.Contains("href='https://tracking.example"),
            "no tracking link expected without a TrackingUrl");
    }

    [Fact]
    public async Task CrossTenant_MailIsSentWithShipmentTenant()
    {
        var shipping = await SeedShippingAsync(974, tenantId: TenantConstants.TestTenant2Id);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        var sent = EmailService.Sent;
        TestAssertions.AssertEqual(1, sent.Count);
        TestAssertions.AssertEqual(TenantConstants.TestTenant2Id, sent[0].TenantId);
    }

    [Fact]
    public async Task CrossTenant_ToggleOfOtherTenant_DoesNotLeak()
    {
        // Tenant 1 has both toggles ON, but the shipment belongs to tenant 2 with toggles OFF.
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var tenant1 = await DbContext.Tenant.FirstAsync(t => t.Id == TenantConstants.TestTenant1Id);
        tenant1.SendShippingNotificationEmails = true;
        tenant1.SendDeliveryNotificationEmails = true;
        await DbContext.SaveChangesAsync();

        var shipping = await SeedShippingAsync(975, tenantId: TenantConstants.TestTenant2Id,
            sendShippedMail: false, sendDeliveredMail: false);

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);

        TestAssertions.AssertEmpty(EmailService.Sent);
    }
}
