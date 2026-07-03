using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Enums;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Commands;

public class ShippingUpdateCancelDeleteTests : TenantIsolatedTestBase
{
    private async Task<asToolkit.Domain.Entities.Shipping> SeedShippingAsync(
        ShippingStatus status = ShippingStatus.Open, bool assignItems = false, int customerNumber = 811)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, status);

        if (assignItems)
        {
            foreach (var item in sales.SalesItems)
            {
                item.ShippingId = shipping.Id;
            }
        }

        await DbContext.SaveChangesAsync();
        return shipping;
    }

    private object CreateStatusUpdateBody(Guid id, ShippingStatus status)
    {
        return new { Id = id, Status = (int)status };
    }

    [Fact]
    public async Task UpdateShipping_ManualStatusChange_ShouldWriteSalesHistoryAsManual()
    {
        var shipping = await SeedShippingAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Shippings/{shipping.Id}",
            CreateStatusUpdateBody(shipping.Id, ShippingStatus.InTransit));

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var historyRow = await DbContext.SalesHistory
            .FirstOrDefaultAsync(h => h.SalesId == shipping.SalesId && h.ShippingStatusNew == "InTransit");
        TestAssertions.AssertNotNull(historyRow);
        TestAssertions.AssertEqual("Open", historyRow!.ShippingStatusOld);
        TestAssertions.AssertFalse(historyRow.IsSystemGenerated);
    }

    [Fact]
    public async Task UpdateShipping_ManualStatusChangeToInTransit_ShouldStampShippedAt()
    {
        var shipping = await SeedShippingAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Shippings/{shipping.Id}",
            CreateStatusUpdateBody(shipping.Id, ShippingStatus.InTransit));

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.InTransit, updated.Status);
        TestAssertions.AssertNotNull(updated.ShippedAt);
    }

    [Fact]
    public async Task UpdateShipping_OnCancelledShipment_ShouldReturnBadRequest()
    {
        var shipping = await SeedShippingAsync(ShippingStatus.Cancelled);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Shippings/{shipping.Id}",
            new { Id = shipping.Id, TrackingNumber = "NEW-TRACKING" });

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateShipping_MutableFields_ShouldPersist()
    {
        var shipping = await SeedShippingAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PutAsJsonAsync($"/api/v1/Shippings/{shipping.Id}",
            new { Id = shipping.Id, TrackingNumber = "TRACK-42", ShippingCost = 7.77m });

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual("TRACK-42", updated.TrackingNumber);
        TestAssertions.AssertEqual(7.77m, updated.ShippingCost);
    }

    [Fact]
    public async Task CancelShipping_ShouldSetCancelledAndFreeSalesItems()
    {
        var shipping = await SeedShippingAsync(assignItems: true);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Shippings/{shipping.Id}/cancel", null);

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var cancelled = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.Cancelled, cancelled.Status);

        var stillAssigned = await DbContext.SalesItem.AnyAsync(i => i.ShippingId == shipping.Id);
        TestAssertions.AssertFalse(stillAssigned, "Cancel must clear the SalesItem.ShippingId links.");
    }

    [Fact]
    public async Task CancelShipping_OnDelivered_ShouldReturnBadRequest()
    {
        var shipping = await SeedShippingAsync(ShippingStatus.Delivered);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Shippings/{shipping.Id}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DeleteShipping_Open_ShouldReturnNoContent()
    {
        var shipping = await SeedShippingAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NoContent, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var exists = await DbContext.Shipping.AnyAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertFalse(exists);
    }

    [Fact]
    public async Task DeleteShipping_InTransit_ShouldReturnBadRequest()
    {
        var shipping = await SeedShippingAsync(ShippingStatus.InTransit);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        var raw = await ReadResponseStringAsync(response);
        TestAssertions.AssertTrue(raw.Contains("Cancel it instead", StringComparison.OrdinalIgnoreCase));

        DbContext.ChangeTracker.Clear();
        var exists = await DbContext.Shipping.AnyAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertTrue(exists);
    }
}
