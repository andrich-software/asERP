using asToolkit.Application.Contracts.Services;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Enums;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Services;

/// <summary>
/// Service-level tests: the updater is resolved from the test server's scope, so it shares the
/// scoped DbContext and tenant context with the test.
/// </summary>
public class ShippingStatusUpdaterTests : TenantIsolatedTestBase
{
    private async Task<asToolkit.Domain.Entities.Shipping> SeedShippingAsync(
        ShippingStatus status = ShippingStatus.Open)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 831);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, status);
        await DbContext.SaveChangesAsync();

        // Service calls run in the test's own scope — adopt tenant 1 like a request would.
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        return shipping;
    }

    private IShippingStatusUpdater Updater => Scope.ServiceProvider.GetRequiredService<IShippingStatusUpdater>();

    [Fact]
    public async Task ApplyStatus_FirstInTransit_ShouldStampShippedAt()
    {
        var shipping = await SeedShippingAsync();

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit,
            rawCarrierStatus: "in transit");

        TestAssertions.AssertTrue(result.Succeeded);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.InTransit, updated.Status);
        TestAssertions.AssertNotNull(updated.ShippedAt);
        TestAssertions.AssertNull(updated.DeliveredAt);
    }

    [Fact]
    public async Task ApplyStatus_SecondTransition_ShouldKeepFirstShippedAt()
    {
        var shipping = await SeedShippingAsync();

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        var firstShippedAt = updated.ShippedAt;

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.OutForDelivery);

        updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.OutForDelivery, updated.Status);
        TestAssertions.AssertEqual(firstShippedAt, updated.ShippedAt);
    }

    [Fact]
    public async Task ApplyStatus_Delivered_ShouldStampDeliveredAt()
    {
        var shipping = await SeedShippingAsync(ShippingStatus.InTransit);

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Delivered);

        TestAssertions.AssertTrue(result.Succeeded);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.Delivered, updated.Status);
        TestAssertions.AssertNotNull(updated.DeliveredAt);
    }

    [Fact]
    public async Task ApplyStatus_SameStatus_ShouldNotWriteHistoryRow()
    {
        var shipping = await SeedShippingAsync();

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.Open);

        TestAssertions.AssertTrue(result.Succeeded);
        var historyRows = await DbContext.SalesHistory
            .Where(h => h.SalesId == shipping.SalesId)
            .ToListAsync();
        TestAssertions.AssertEmpty(historyRows);
    }

    [Fact]
    public async Task ApplyStatus_StatusChange_ShouldWriteHistoryRow()
    {
        var shipping = await SeedShippingAsync();

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit, rawCarrierStatus: "carrier says moving");

        var historyRow = await DbContext.SalesHistory
            .FirstOrDefaultAsync(h => h.SalesId == shipping.SalesId && h.ShippingStatusNew == "InTransit");
        TestAssertions.AssertNotNull(historyRow);
        TestAssertions.AssertEqual("Open", historyRow!.ShippingStatusOld);
        TestAssertions.AssertTrue(historyRow.IsSystemGenerated);
    }

    [Fact]
    public async Task ApplyStatus_SystemGenerated_ShouldNeverLeaveDelivered()
    {
        var shipping = await SeedShippingAsync(ShippingStatus.Delivered);

        var result = await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit,
            rawCarrierStatus: "stale tracking event", isSystemGenerated: true);

        TestAssertions.AssertTrue(result.Succeeded);
        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertEqual(ShippingStatus.Delivered, updated.Status);

        var historyRows = await DbContext.SalesHistory
            .Where(h => h.SalesId == shipping.SalesId)
            .ToListAsync();
        TestAssertions.AssertEmpty(historyRows);
    }

    [Fact]
    public async Task ApplyStatus_SystemGenerated_ShouldStampLastTrackedAt()
    {
        var shipping = await SeedShippingAsync();

        await Updater.ApplyStatusAsync(shipping.Id, ShippingStatus.InTransit,
            rawCarrierStatus: "in transit", isSystemGenerated: true);

        var updated = await DbContext.Shipping.FirstAsync(s => s.Id == shipping.Id);
        TestAssertions.AssertNotNull(updated.LastTrackedAt);
        TestAssertions.AssertEqual("in transit", updated.LastCarrierStatusRaw);
    }
}
