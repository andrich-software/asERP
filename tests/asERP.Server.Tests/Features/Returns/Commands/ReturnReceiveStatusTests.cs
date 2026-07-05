using asERP.Application.Contracts.Services;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Features.Returns.Commands;

/// <summary>
/// Tests for the receive/cancel/complete transitions and the order-level "fully returned"
/// automation (SalesStatus.Returned comes from the returns handler, never from the recompute).
/// Customer-number range: 980–989.
/// </summary>
public class ReturnReceiveStatusTests : TenantIsolatedTestBase
{
    private async Task<(Domain.Entities.Sales Sales, Domain.Entities.ReturnShipment Return)> SeedReturnAsync(
        int customerNumber,
        ReturnShipmentStatus returnStatus = ReturnShipmentStatus.Requested,
        SalesStatus salesStatus = SalesStatus.Completed,
        bool returnAllItems = true,
        bool leaveOneItemUnshipped = false)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        sales.Status = salesStatus;

        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            status: ShippingStatus.Delivered, shippedAt: DateTime.UtcNow.AddDays(-5),
            deliveredAt: DateTime.UtcNow.AddDays(-3));

        var items = sales.SalesItems.ToList();
        foreach (var item in items)
        {
            item.ShippingId = shipping.Id;
        }
        if (leaveOneItemUnshipped)
        {
            items.Last().ShippingId = null;
        }

        var returnedItems = (returnAllItems ? items.Where(i => i.ShippingId != null) : items.Take(1))
            .Select(i => (i.Id, i.Quantity))
            .ToArray();
        var returnShipment = ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: returnStatus, items: returnedItems);

        await DbContext.SaveChangesAsync();
        return (sales, returnShipment);
    }

    private static ReturnReceiveInputDto BuildReceiveInput(
        Domain.Entities.ReturnShipment returnShipment,
        ReturnItemCondition condition = ReturnItemCondition.Resalable,
        List<string>? serialNumbers = null) => new()
    {
        Items = returnShipment.Items.Select(i => new ReturnReceiveItemInputDto
        {
            ReturnShipmentItemId = i.Id,
            Condition = condition,
            SerialNumbers = serialNumbers ?? new List<string>()
        }).ToList()
    };

    [Fact]
    public async Task Receive_ShouldStampConditionReceivedAtAndStatus()
    {
        var (sales, returnShipment) = await SeedReturnAsync(980);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment, ReturnItemCondition.Damaged));

        TestAssertions.AssertHttpSuccess(response);

        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.ReturnShipment
            .Include(r => r.Items)
            .FirstAsync(r => r.Id == returnShipment.Id);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Received, updated.Status);
        TestAssertions.AssertNotNull(updated.ReceivedAt);
        TestAssertions.AssertTrue(updated.Items.All(i => i.Condition == ReturnItemCondition.Damaged));

        var history = await DbContext.SalesHistory
            .Where(h => h.SalesId == sales.Id && h.Description.Contains("Received"))
            .ToListAsync();
        TestAssertions.AssertTrue(history.Count > 0);
    }

    [Fact]
    public async Task Receive_WithValidSerialNumbers_ShouldRecordThem()
    {
        var (_, returnShipment) = await SeedReturnAsync(981, returnAllItems: false);
        // Act as tenant 1 before reading the seeded sales item — the tenant filter hides it otherwise.
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var salesItemId = returnShipment.Items.First().SalesItemId;
        var salesItem = await DbContext.SalesItem.FirstAsync(i => i.Id == salesItemId);
        ShippingTestDataSeeder.AddSerialNumber(DbContext, salesItem, "SN-981-1");
        await DbContext.SaveChangesAsync();

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment, serialNumbers: ["SN-981-1"]));

        TestAssertions.AssertHttpSuccess(response);

        DbContext.ChangeTracker.Clear();
        var serials = await DbContext.ReturnShipmentItemSerialNumber
            .Where(s => s.ReturnShipmentItemId == returnShipment.Items.First().Id)
            .ToListAsync();
        TestAssertions.AssertEqual(1, serials.Count);
        TestAssertions.AssertEqual("SN-981-1", serials[0].SerialNumber);
    }

    [Fact]
    public async Task Receive_WithUnknownSerialNumber_ShouldReturnBadRequest()
    {
        var (_, returnShipment) = await SeedReturnAsync(982, returnAllItems: false);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment, serialNumbers: ["SN-DOES-NOT-EXIST"]));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Receive_AllShippedItemsReturned_ShouldFlipSalesToReturned()
    {
        var (sales, returnShipment) = await SeedReturnAsync(983);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));

        TestAssertions.AssertHttpSuccess(response);

        DbContext.ChangeTracker.Clear();
        var updatedSales = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Returned, updatedSales.Status);
    }

    [Fact]
    public async Task Receive_PartialReturn_ShouldKeepSalesStatus()
    {
        var (sales, returnShipment) = await SeedReturnAsync(984, returnAllItems: false);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));

        TestAssertions.AssertHttpSuccess(response);

        DbContext.ChangeTracker.Clear();
        var updatedSales = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Completed, updatedSales.Status);
    }

    [Fact]
    public async Task Receive_WithUnshippedItems_ShouldNotFlipSalesToReturned()
    {
        var (sales, returnShipment) = await SeedReturnAsync(985, leaveOneItemUnshipped: true);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));

        TestAssertions.AssertHttpSuccess(response);

        DbContext.ChangeTracker.Clear();
        var updatedSales = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Completed, updatedSales.Status);
    }

    [Fact]
    public async Task Recompute_AfterReturned_ShouldNotResurrectSalesStatus()
    {
        var (sales, returnShipment) = await SeedReturnAsync(986);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));
        TestAssertions.AssertHttpSuccess(response);

        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        var recompute = Scope.ServiceProvider.GetRequiredService<ISalesShippingStatusService>();
        await recompute.RecomputeAsync(sales.Id);

        DbContext.ChangeTracker.Clear();
        var updatedSales = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(SalesStatus.Returned, updatedSales.Status);
    }

    [Fact]
    public async Task Receive_OnCancelledReturn_ShouldReturnBadRequest()
    {
        var (_, returnShipment) = await SeedReturnAsync(987, returnStatus: ReturnShipmentStatus.Cancelled);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Cancel_FromRequested_ShouldSucceed_FromReceived_ShouldFail()
    {
        var (_, requested) = await SeedReturnAsync(988);
        var (_, received) = await SeedReturnAsync(989, returnStatus: ReturnShipmentStatus.Received);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var cancelRequested = await Client.PostAsync($"/api/v1/Returns/{requested.Id}/cancel", null);
        var cancelReceived = await Client.PostAsync($"/api/v1/Returns/{received.Id}/cancel", null);

        TestAssertions.AssertHttpSuccess(cancelRequested);
        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, cancelReceived.StatusCode);

        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.ReturnShipment.FirstAsync(r => r.Id == requested.Id);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Cancelled, updated.Status);
    }

    [Fact]
    public async Task Complete_FromReceived_ShouldCloseOrReject()
    {
        var (_, toComplete) = await SeedReturnAsync(980, returnStatus: ReturnShipmentStatus.Received);
        var (_, toReject) = await SeedReturnAsync(981, returnStatus: ReturnShipmentStatus.Received);
        var (_, notReceived) = await SeedReturnAsync(982);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var complete = await Client.PostAsync($"/api/v1/Returns/{toComplete.Id}/complete", null);
        var reject = await Client.PostAsync($"/api/v1/Returns/{toReject.Id}/complete?reject=true", null);
        var tooEarly = await Client.PostAsync($"/api/v1/Returns/{notReceived.Id}/complete", null);

        TestAssertions.AssertHttpSuccess(complete);
        TestAssertions.AssertHttpSuccess(reject);
        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, tooEarly.StatusCode);

        DbContext.ChangeTracker.Clear();
        TestAssertions.AssertEqual(ReturnShipmentStatus.Completed,
            (await DbContext.ReturnShipment.FirstAsync(r => r.Id == toComplete.Id)).Status);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Rejected,
            (await DbContext.ReturnShipment.FirstAsync(r => r.Id == toReject.Id)).Status);
    }

    [Fact]
    public async Task StatusUpdater_OnTerminalReturn_ShouldRejectTransition()
    {
        var (_, cancelled) = await SeedReturnAsync(983, returnStatus: ReturnShipmentStatus.Cancelled);
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        var updater = Scope.ServiceProvider.GetRequiredService<IReturnStatusUpdater>();

        var result = await updater.ApplyStatusAsync(cancelled.Id, ReturnShipmentStatus.Received);

        TestAssertions.AssertFalse(result.Succeeded);

        DbContext.ChangeTracker.Clear();
        var untouched = await DbContext.ReturnShipment.FirstAsync(r => r.Id == cancelled.Id);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Cancelled, untouched.Status);
    }

    [Fact]
    public async Task Receive_CrossTenant_ShouldReturnNotFound()
    {
        var (_, returnShipment) = await SeedReturnAsync(984);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await PostAsJsonAsync($"/api/v1/Returns/{returnShipment.Id}/receive",
            BuildReceiveInput(returnShipment));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
