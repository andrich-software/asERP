using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Commands;

/// <summary>
/// Order-status automation driven by shipment item assignment: all items assigned → Completed,
/// some assigned → PartiallyDelivered, none left → revert to Processing.
/// </summary>
public class SalesShippingStatusAutomationTests : TenantIsolatedTestBase
{
    private async Task<(asERP.Domain.Entities.ShippingProvider Provider,
        asERP.Domain.Entities.ShippingProviderRate Rate,
        asERP.Domain.Entities.Sales Sales)> SeedShippingSetupAsync(
        int customerNumber, int itemCount = 2)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id,
            customerNumber, itemCount: itemCount);
        await DbContext.SaveChangesAsync();
        return (provider, rate, sales);
    }

    private static ShippingInputDto CreateInputDto(Guid salesId, Guid rateId, params Guid[] salesItemIds)
    {
        return new ShippingInputDto
        {
            SalesId = salesId,
            ShippingProviderRateId = rateId,
            TaxRate = 19.0,
            SalesItemIds = salesItemIds.ToList(),
            RequestLabel = false
        };
    }

    private async Task<Guid> CreateShipmentAsync(Guid salesId, Guid rateId, params Guid[] itemIds)
    {
        var response = await PostAsJsonAsync("/api/v1/Shippings", CreateInputDto(salesId, rateId, itemIds));
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    private async Task<SalesStatus> GetSalesStatusAsync(Guid salesId)
    {
        DbContext.ChangeTracker.Clear();
        var sales = await DbContext.Sales.FirstAsync(s => s.Id == salesId);
        return sales.Status;
    }

    [Fact]
    public async Task CreateShipping_CoveringAllItems_ShouldSetSalesCompleted()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(810);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.Select(i => i.Id).ToArray());

        TestAssertions.AssertEqual(SalesStatus.Completed, await GetSalesStatusAsync(sales.Id));
    }

    [Fact]
    public async Task CreateShipping_CoveringAllItems_ShouldWriteSystemGeneratedHistoryRow()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(811);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.Select(i => i.Id).ToArray());

        DbContext.ChangeTracker.Clear();
        var historyRow = await DbContext.SalesHistory.FirstOrDefaultAsync(h =>
            h.SalesId == sales.Id && h.SalesStatusNew == SalesStatus.Completed && h.IsSystemGenerated);
        TestAssertions.AssertNotNull(historyRow);
        TestAssertions.AssertEqual(SalesStatus.Processing, historyRow!.SalesStatusOld);
    }

    [Fact]
    public async Task CreateShipping_CoveringSomeItems_ShouldSetSalesPartiallyDelivered()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(812);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.First().Id);

        TestAssertions.AssertEqual(SalesStatus.PartiallyDelivered, await GetSalesStatusAsync(sales.Id));
    }

    [Fact]
    public async Task CancelOnlyShipping_ShouldRevertSalesToProcessing()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(813);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var shippingId = await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.Select(i => i.Id).ToArray());
        TestAssertions.AssertEqual(SalesStatus.Completed, await GetSalesStatusAsync(sales.Id));

        var response = await Client.PostAsync($"/api/v1/Shippings/{shippingId}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        TestAssertions.AssertEqual(SalesStatus.Processing, await GetSalesStatusAsync(sales.Id));
    }

    [Fact]
    public async Task DeleteOnlyShipping_ShouldRevertSalesToProcessing()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(814);
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var shippingId = await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.First().Id);
        TestAssertions.AssertEqual(SalesStatus.PartiallyDelivered, await GetSalesStatusAsync(sales.Id));

        var response = await Client.DeleteAsync($"/api/v1/Shippings/{shippingId}");

        TestAssertions.AssertEqual(HttpStatusCode.NoContent, response.StatusCode);
        TestAssertions.AssertEqual(SalesStatus.Processing, await GetSalesStatusAsync(sales.Id));
    }

    [Fact]
    public async Task CancelOneOfTwoShippings_ShouldFallBackToPartiallyDelivered()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(815);
        var itemIds = sales.SalesItems.Select(i => i.Id).ToArray();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        await CreateShipmentAsync(sales.Id, rate.Id, itemIds[0]);
        var secondShippingId = await CreateShipmentAsync(sales.Id, rate.Id, itemIds[1]);
        TestAssertions.AssertEqual(SalesStatus.Completed, await GetSalesStatusAsync(sales.Id));

        var response = await Client.PostAsync($"/api/v1/Shippings/{secondShippingId}/cancel", null);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        TestAssertions.AssertEqual(SalesStatus.PartiallyDelivered, await GetSalesStatusAsync(sales.Id));
    }

    [Theory]
    [InlineData(SalesStatus.Cancelled)]
    [InlineData(SalesStatus.Returned)]
    [InlineData(SalesStatus.Refunded)]
    [InlineData(SalesStatus.Failed)]
    public async Task CreateShipping_OnProtectedOrderStatus_ShouldNotResurrectOrder(SalesStatus protectedStatus)
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(816);
        sales.Status = protectedStatus;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await CreateShipmentAsync(sales.Id, rate.Id, sales.SalesItems.Select(i => i.Id).ToArray());

        TestAssertions.AssertEqual(protectedStatus, await GetSalesStatusAsync(sales.Id));
    }

    [Fact]
    public async Task CreateShipping_OnOrderWithoutItems_ShouldLeaveStatusUnchanged()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(817, itemCount: 0);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await CreateShipmentAsync(sales.Id, rate.Id);

        TestAssertions.AssertEqual(SalesStatus.Processing, await GetSalesStatusAsync(sales.Id));
    }
}
