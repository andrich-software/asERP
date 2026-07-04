using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Queries;

public class ShippingQueriesTests : TenantIsolatedTestBase
{
    [Fact]
    public async Task List_WithSalesIdFilter_ShouldReturnOnlyShipmentsOfThatSales()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var salesA = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 821);
        var salesB = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 822);
        var shippingA1 = ShippingTestDataSeeder.AddShipping(DbContext, salesA, provider, rate);
        var shippingA2 = ShippingTestDataSeeder.AddShipping(DbContext, salesA, provider, rate);
        ShippingTestDataSeeder.AddShipping(DbContext, salesB, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings?salesId={salesA.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ShipmentListItemDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data.Count);
        TestAssertions.AssertEqual(2, result.TotalCount);
        var ids = result.Data.Select(s => s.Id).ToList();
        TestAssertions.AssertContains(shippingA1.Id, ids);
        TestAssertions.AssertContains(shippingA2.Id, ids);
    }

    [Fact]
    public async Task List_WithoutSalesId_ShouldReturnAllTenantShipments()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var salesA = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 826);
        var salesB = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 827);
        ShippingTestDataSeeder.AddShipping(DbContext, salesA, provider, rate);
        ShippingTestDataSeeder.AddShipping(DbContext, salesB, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Shippings");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ShipmentListItemDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data.Count);
        TestAssertions.AssertEqual(2, result.TotalCount);
    }

    [Fact]
    public async Task GetDetail_WithoutLabel_ShouldReturnHasLabelFalseAndSalesItemIds()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 823);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        foreach (var item in sales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ShippingDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertFalse(result.Data!.HasLabel);
        TestAssertions.AssertEqual(2, result.Data.SalesItemIds.Count);
        foreach (var itemId in sales.SalesItems.Select(i => i.Id))
        {
            TestAssertions.AssertContains(itemId, result.Data.SalesItemIds);
        }
        TestAssertions.AssertEqual(provider.Name, result.Data.ProviderName);
        TestAssertions.AssertEqual(rate.Name, result.Data.RateName);
        TestAssertions.AssertEqual(sales.SalesId, result.Data.SalesNumber);
    }

    [Fact]
    public async Task GetDetail_WithUnknownId_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetDetail_History_ShouldReturnOwnEntriesNewestFirst()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 828);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        var otherShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();

        var older = new asToolkit.Domain.Entities.SalesHistory
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingId = shipping.Id,
            ShippingStatusOld = null,
            ShippingStatusNew = "Open",
            Description = "Shipment created",
            IsSystemGenerated = false,
            DateCreated = DateTime.UtcNow.AddHours(-2),
            TenantId = TenantConstants.TestTenant1Id
        };
        var newer = new asToolkit.Domain.Entities.SalesHistory
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingId = shipping.Id,
            ShippingStatusOld = "Open",
            ShippingStatusNew = "Shipped",
            Description = "Shipment shipped",
            IsSystemGenerated = true,
            DateCreated = DateTime.UtcNow.AddHours(-1),
            TenantId = TenantConstants.TestTenant1Id
        };
        // Entries of another shipment and order-level entries must not leak into the timeline.
        var foreign = new asToolkit.Domain.Entities.SalesHistory
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingId = otherShipping.Id,
            ShippingStatusNew = "Open",
            Description = "Other shipment",
            DateCreated = DateTime.UtcNow,
            TenantId = TenantConstants.TestTenant1Id
        };
        var orderLevel = new asToolkit.Domain.Entities.SalesHistory
        {
            Id = Guid.NewGuid(),
            SalesId = sales.Id,
            ShippingId = null,
            Description = "Order-level entry",
            DateCreated = DateTime.UtcNow,
            TenantId = TenantConstants.TestTenant1Id
        };
        DbContext.SalesHistory.AddRange(older, newer, foreign, orderLevel);
        await DbContext.SaveChangesAsync();

        // SaveChangesAsync force-stamps DateCreated on insert — restore the intended
        // timestamps afterwards so the ordering assertion is deterministic.
        older.DateCreated = DateTime.UtcNow.AddHours(-2);
        newer.DateCreated = DateTime.UtcNow.AddHours(-1);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ShippingDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(2, result.Data!.History.Count);
        TestAssertions.AssertEqual(newer.Id, result.Data.History[0].Id);
        TestAssertions.AssertEqual(older.Id, result.Data.History[1].Id);
        TestAssertions.AssertEqual("Shipped", result.Data.History[0].ShippingStatusNew);
        TestAssertions.AssertTrue(result.Data.History[0].IsSystemGenerated);
        TestAssertions.AssertFalse(result.Data.History[1].IsSystemGenerated);
    }

    [Fact]
    public async Task GetDetail_WithoutHistoryRows_ShouldReturnEmptyHistory()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 829);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ShippingDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEmpty(result.Data!.History);
    }

    [Fact]
    public async Task GetLabel_WithoutLabel_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 824);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/label");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetLabel_WithSeededLabelData_ShouldReturnFileWithContentType()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 825);
        var labelBytes = new byte[] { 0x25, 0x50, 0x44, 0x46 };
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.LabelCreated, trackingNumber: "TRACK-LABEL-1",
            labelData: labelBytes, labelFormat: "application/pdf");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/{shipping.Id}/label");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        var body = await response.Content.ReadAsByteArrayAsync();
        TestAssertions.AssertTrue(labelBytes.SequenceEqual(body));
    }
}
