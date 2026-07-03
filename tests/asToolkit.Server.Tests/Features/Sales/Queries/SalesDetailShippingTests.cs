using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Sales;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.Sales.Queries;

/// <summary>
/// Verifies that SalesDetail exposes the new Shippings list and feeds the legacy
/// single-shipment fields from the newest non-cancelled shipment.
/// </summary>
public class SalesDetailShippingTests : TenantIsolatedTestBase
{
    [Fact]
    public async Task GetSalesDetail_WithShipments_ShouldReturnShippingsAndLegacyFields()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            name: "DHL Express");
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Paket L");
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 861);
        var cancelledShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Cancelled, trackingNumber: "CANCELLED-1");
        var activeShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.InTransit, trackingNumber: "TRACK123");
        await DbContext.SaveChangesAsync();

        // Make the cancelled shipment the NEWEST one — the legacy fields must skip it.
        cancelledShipping.DateCreated = DateTime.UtcNow;
        activeShipping.DateCreated = DateTime.UtcNow.AddHours(-1);
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<SalesDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);

        var detail = result.Data!;
        TestAssertions.AssertEqual(2, detail.Shippings.Count);
        TestAssertions.AssertContains(cancelledShipping.Id, detail.Shippings.Select(s => s.Id).ToList());
        TestAssertions.AssertContains(activeShipping.Id, detail.Shippings.Select(s => s.Id).ToList());

        // Legacy fields come from the newest non-cancelled shipment.
        TestAssertions.AssertEqual("InTransit", detail.ShippingStatus);
        TestAssertions.AssertEqual("TRACK123", detail.ShippingTrackingId);
        TestAssertions.AssertEqual("DHL Express", detail.ShippingProvider);
        TestAssertions.AssertEqual("Paket L", detail.ShippingMethod);
    }

    [Fact]
    public async Task GetSalesDetail_ShippingsOrderedNewestFirst()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 862);
        var older = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            trackingNumber: "OLDER");
        var newer = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            trackingNumber: "NEWER");
        await DbContext.SaveChangesAsync();

        older.DateCreated = DateTime.UtcNow.AddHours(-2);
        newer.DateCreated = DateTime.UtcNow.AddHours(-1);
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<SalesDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data!.Shippings.Count);
        TestAssertions.AssertEqual(newer.Id, result.Data.Shippings[0].Id);
        TestAssertions.AssertEqual(older.Id, result.Data.Shippings[1].Id);
    }

    [Fact]
    public async Task GetSalesDetail_WithOnlyCancelledShipment_ShouldLeaveLegacyFieldsEmpty()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 863);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Cancelled, trackingNumber: "CANCELLED-ONLY");
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<SalesDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Shippings.Count);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingStatus);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingTrackingId);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingProvider);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingMethod);
    }

    [Fact]
    public async Task GetSalesDetail_WithoutShipments_ShouldReturnEmptyShippingData()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 864);
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var response = await Client.GetAsync($"/api/v1/Saless/{sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<SalesDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEmpty(result.Data!.Shippings);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingStatus);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingTrackingId);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingProvider);
        TestAssertions.AssertEqual(string.Empty, result.Data.ShippingMethod);
    }
}
