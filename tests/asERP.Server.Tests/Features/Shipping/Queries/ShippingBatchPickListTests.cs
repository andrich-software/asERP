using System.Net;
using asERP.Domain.Constants;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Queries;

// Customer number range for this class: 930–939.
public class ShippingBatchPickListTests : TenantIsolatedTestBase
{
    private static void AssertPdf(byte[] body)
    {
        TestAssertions.AssertTrue(body.Length > 500);
        var header = System.Text.Encoding.ASCII.GetString(body, 0, 4);
        TestAssertions.AssertEqual("%PDF", header);
    }

    private static string GetFileName(HttpResponseMessage response)
    {
        return response.Content.Headers.ContentDisposition?.FileNameStar
            ?? response.Content.Headers.ContentDisposition?.FileName
            ?? string.Empty;
    }

    private async Task<Domain.Entities.Shipping> SeedShipmentWithItemsAsync(int customerNumber)
    {
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            name: $"Provider {customerNumber}");
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        foreach (var item in sales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }
        await DbContext.SaveChangesAsync();
        return shipping;
    }

    [Fact]
    public async Task GetBatchPickList_WithMultipleShipments_ShouldReturnCombinedPdf()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var shipping1 = await SeedShipmentWithItemsAsync(930);
        var shipping2 = await SeedShipmentWithItemsAsync(931);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync(
            $"/api/v1/Shippings/pick-list?ids={shipping1.Id}&ids={shipping2.Id}");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        AssertPdf(await response.Content.ReadAsByteArrayAsync());
        TestAssertions.AssertTrue(GetFileName(response).StartsWith("pickliste-sammel-"));
    }

    [Fact]
    public async Task GetBatchPickList_UnknownIdsAreSkipped()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var shipping = await SeedShipmentWithItemsAsync(932);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync(
            $"/api/v1/Shippings/pick-list?ids={shipping.Id}&ids={Guid.NewGuid()}");

        TestAssertions.AssertHttpSuccess(response);
        AssertPdf(await response.Content.ReadAsByteArrayAsync());
    }

    [Fact]
    public async Task GetBatchPickList_AllUnknown_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync(
            $"/api/v1/Shippings/pick-list?ids={Guid.NewGuid()}&ids={Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetBatchPickList_WithoutIds_ShouldReturnBadRequest()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Shippings/pick-list");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetBatchPickList_CrossTenant_ShouldReturnNotFound()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var shipping = await SeedShipmentWithItemsAsync(933);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Shippings/pick-list?ids={shipping.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
