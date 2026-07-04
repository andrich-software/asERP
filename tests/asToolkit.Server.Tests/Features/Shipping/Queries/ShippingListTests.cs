using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Queries;

public class ShippingListTests : TenantIsolatedTestBase
{
    private async Task<(asToolkit.Domain.Entities.ShippingProvider Provider,
        asToolkit.Domain.Entities.ShippingProviderRate Rate)> SeedProviderAsync(
        Guid tenantId)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, tenantId);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        return (provider, rate);
    }

    private async Task<PaginatedResult<ShipmentListItemDto>> GetListAsync(string queryString = "")
    {
        var response = await Client.GetAsync($"/api/v1/Shippings{queryString}");
        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ShipmentListItemDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        return result;
    }

    [Fact]
    public async Task List_ZeroBasedPagination_ReturnsPagesAndTotalCount()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 870);
        for (var i = 0; i < 3; i++)
        {
            ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
                shippedAt: DateTime.UtcNow.AddHours(-i));
        }
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var page0 = await GetListAsync("?pageNumber=0&pageSize=2");
        var page1 = await GetListAsync("?pageNumber=1&pageSize=2");

        TestAssertions.AssertEqual(2, page0.Data.Count);
        TestAssertions.AssertEqual(3, page0.TotalCount);
        TestAssertions.AssertEqual(1, page1.Data.Count);
        TestAssertions.AssertEqual(3, page1.TotalCount);
    }

    [Fact]
    public async Task List_SearchByTrackingNumber_ReturnsMatch()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 871);
        var match = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            trackingNumber: "TRACK-FIND-ME");
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            trackingNumber: "OTHER-1");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?searchString=find-me");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(match.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task List_SearchByRecipientName_ReturnsMatch()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 872);
        var match = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // AddSales sets DeliveryAddressLastName = "Tester{customerNumber}".
        var result = await GetListAsync("?searchString=Tester872");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(match.Id, result.Data[0].Id);
        TestAssertions.AssertEqual("Ship Tester872", result.Data[0].RecipientName);
    }

    [Fact]
    public async Task List_SearchBySalesNumber_ReturnsMatch()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        // AddSales sets SalesId = 30000 + customerNumber.
        var salesA = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 873);
        var salesB = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 874);
        var match = ShippingTestDataSeeder.AddShipping(DbContext, salesA, provider, rate);
        ShippingTestDataSeeder.AddShipping(DbContext, salesB, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?searchString=30873");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(match.Id, result.Data[0].Id);
        TestAssertions.AssertEqual(30873, result.Data[0].SalesNumber);
    }

    [Fact]
    public async Task List_StatusFilter_ReturnsOnlyMatchingStatus()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 875);
        var shipped = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Shipped);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, ShippingStatus.Open);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?status=Shipped");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(shipped.Id, result.Data[0].Id);
    }

    [Fact]
    public async Task List_SalesIdFilter_ReturnsOnlyShipmentsOfThatSales()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var salesA = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 876);
        var salesB = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 877);
        var matchA = ShippingTestDataSeeder.AddShipping(DbContext, salesA, provider, rate);
        ShippingTestDataSeeder.AddShipping(DbContext, salesB, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync($"?salesId={salesA.Id}");

        TestAssertions.AssertEqual(1, result.Data.Count);
        TestAssertions.AssertEqual(matchA.Id, result.Data[0].Id);
        TestAssertions.AssertEqual(salesA.Id, result.Data[0].SalesId);
    }

    [Fact]
    public async Task List_ProblemsOnly_ReturnsExactlyTheProblemShipments()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 878);

        var lost = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Lost);
        var returned = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.ReturnedToSender);
        var deliveryFailed = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.DeliveryFailed);
        var overdue = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.InTransit, shippedAt: DateTime.UtcNow.AddDays(-5));
        var deadLetterShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Open);
        ShippingTestDataSeeder.AddLabelOutbox(DbContext, deadLetterShipping,
            ShippingOutboxStatus.DeadLetter);

        // Not problems: delivered long ago, freshly shipped, pending outbox row.
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Delivered, shippedAt: DateTime.UtcNow.AddDays(-10),
            deliveredAt: DateTime.UtcNow.AddDays(-8));
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.InTransit, shippedAt: DateTime.UtcNow.AddHours(-2));
        var pendingOutboxShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Open);
        ShippingTestDataSeeder.AddLabelOutbox(DbContext, pendingOutboxShipping,
            ShippingOutboxStatus.Pending);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?problemsOnly=true&pageSize=20");

        var ids = result.Data.Select(x => x.Id).ToList();
        TestAssertions.AssertEqual(5, result.Data.Count);
        TestAssertions.AssertContains(lost.Id, ids);
        TestAssertions.AssertContains(returned.Id, ids);
        TestAssertions.AssertContains(deliveryFailed.Id, ids);
        TestAssertions.AssertContains(overdue.Id, ids);
        TestAssertions.AssertContains(deadLetterShipping.Id, ids);
        TestAssertions.AssertTrue(result.Data.All(x => x.IsProblem));
    }

    [Fact]
    public async Task List_SortByIsProblemDescending_PutsProblemRowsFirst()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 879);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, ShippingStatus.Open);
        var problem = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Lost);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate, ShippingStatus.Open);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync("?salesBy=IsProblem%20descending");

        TestAssertions.AssertEqual(3, result.Data.Count);
        TestAssertions.AssertEqual(problem.Id, result.Data[0].Id);
        TestAssertions.AssertTrue(result.Data[0].IsProblem);
        TestAssertions.AssertFalse(result.Data[1].IsProblem);
    }

    [Fact]
    public async Task List_DefaultSort_IsShippedAtDescending()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 880);
        var older = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Shipped, shippedAt: DateTime.UtcNow.AddDays(-2));
        var newest = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Shipped, shippedAt: DateTime.UtcNow.AddHours(-1));
        var middle = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.Shipped, shippedAt: DateTime.UtcNow.AddDays(-1));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(3, result.Data.Count);
        TestAssertions.AssertEqual(newest.Id, result.Data[0].Id);
        TestAssertions.AssertEqual(middle.Id, result.Data[1].Id);
        TestAssertions.AssertEqual(older.Id, result.Data[2].Id);
    }

    [Fact]
    public async Task List_HasLabelAndRecipientCompany_AreProjected()
    {
        var (provider, rate) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 881);
        sales.DeliveryAddressCompanyName = "ACME GmbH";
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            ShippingStatus.LabelCreated, trackingNumber: "TRK-881",
            labelData: new byte[] { 1, 2, 3 }, labelFormat: "application/pdf");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var result = await GetListAsync();

        TestAssertions.AssertEqual(1, result.Data.Count);
        var row = result.Data[0];
        TestAssertions.AssertEqual(shipping.Id, row.Id);
        TestAssertions.AssertTrue(row.HasLabel);
        // Company name wins over person name.
        TestAssertions.AssertEqual("ACME GmbH", row.RecipientName);
        TestAssertions.AssertEqual(provider.Name, row.ProviderName);
        TestAssertions.AssertEqual(rate.Name, row.RateName);
    }

    [Fact]
    public async Task List_TenantIsolation_DoesNotReturnOtherTenantShipments()
    {
        var (provider1, rate1) = await SeedProviderAsync(TenantConstants.TestTenant1Id);
        var sales1 = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 882);
        var shipping1 = ShippingTestDataSeeder.AddShipping(DbContext, sales1, provider1, rate1);

        var provider2 = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant2Id,
            name: "Tenant2 GLS");
        var rate2 = ShippingTestDataSeeder.AddRate(DbContext, provider2);
        var sales2 = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant2Id, 883);
        var shipping2 = ShippingTestDataSeeder.AddShipping(DbContext, sales2, provider2, rate2);
        await DbContext.SaveChangesAsync();

        SetTenantHeader(TenantConstants.TestTenant1Id);
        var tenant1Result = await GetListAsync();

        TestAssertions.AssertEqual(1, tenant1Result.Data.Count);
        TestAssertions.AssertEqual(shipping1.Id, tenant1Result.Data[0].Id);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var tenant2Result = await GetListAsync();

        TestAssertions.AssertEqual(1, tenant2Result.Data.Count);
        TestAssertions.AssertEqual(shipping2.Id, tenant2Result.Data[0].Id);
    }
}
