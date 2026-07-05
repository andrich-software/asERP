using asERP.Domain.Constants;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Returns.Queries;

/// <summary>
/// Tests for the returns detail/list/label endpoints incl. cross-tenant isolation.
/// Customer-number range: 990–994.
/// </summary>
public class ReturnQueriesTests : TenantIsolatedTestBase
{
    private async Task<(Domain.Entities.Sales Sales, Domain.Entities.ReturnShipment Return)> SeedReturnAsync(
        int customerNumber,
        ReturnShipmentStatus status = ReturnShipmentStatus.Requested,
        byte[]? labelData = null,
        Guid? tenantId = null)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var tenant = tenantId ?? TenantConstants.TestTenant1Id;
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, tenant);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, tenant, customerNumber);

        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            status: ShippingStatus.Shipped, shippedAt: DateTime.UtcNow.AddDays(-1));
        foreach (var item in sales.SalesItems)
        {
            item.ShippingId = shipping.Id;
        }

        var returnShipment = ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: status,
            shippingProviderId: provider.Id,
            trackingNumber: labelData != null ? $"RTN-{customerNumber}" : "",
            labelData: labelData,
            labelFormat: labelData != null ? "application/pdf" : null,
            items: sales.SalesItems.Select(i => (i.Id, i.Quantity)).ToArray());

        await DbContext.SaveChangesAsync();
        return (sales, returnShipment);
    }

    [Fact]
    public async Task GetDetails_ShouldReturnItemsAndProvider()
    {
        var (sales, returnShipment) = await SeedReturnAsync(990);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Returns/{returnShipment.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ReturnShipmentDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(sales.Id, result.Data!.SalesId);
        TestAssertions.AssertEqual(2, result.Data.Items.Count);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Requested, result.Data.Status);
        TestAssertions.AssertFalse(result.Data.HasLabel);
        TestAssertions.AssertEqual("DHL Provider", result.Data.ProviderName);
    }

    [Fact]
    public async Task GetAll_WithStatusAndSalesFilter_ShouldFilter()
    {
        var (sales, _) = await SeedReturnAsync(991);
        ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: ReturnShipmentStatus.Received,
            items: (sales.SalesItems.First().Id, 1));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var all = await Client.GetAsync($"/api/v1/Returns?salesId={sales.Id}");
        var received = await Client.GetAsync($"/api/v1/Returns?salesId={sales.Id}&status={(int)ReturnShipmentStatus.Received}");

        TestAssertions.AssertHttpSuccess(all);
        TestAssertions.AssertHttpSuccess(received);
        var allResult = await ReadResponseAsync<PaginatedResult<ReturnShipmentListItemDto>>(all);
        var receivedResult = await ReadResponseAsync<PaginatedResult<ReturnShipmentListItemDto>>(received);
        TestAssertions.AssertEqual(2, allResult.Data.Count);
        TestAssertions.AssertEqual(1, receivedResult.Data.Count);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Received, receivedResult.Data[0].Status);
    }

    [Fact]
    public async Task GetLabel_WithLabel_ShouldReturnFile()
    {
        var labelBytes = new byte[] { 0x25, 0x50, 0x44, 0x46 };
        var (_, returnShipment) = await SeedReturnAsync(992, labelData: labelBytes);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Returns/{returnShipment.Id}/label");

        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertEqual("application/pdf", response.Content.Headers.ContentType?.MediaType);
        var bytes = await response.Content.ReadAsByteArrayAsync();
        TestAssertions.AssertEqual(labelBytes.Length, bytes.Length);
    }

    [Fact]
    public async Task GetLabel_WithoutLabel_ShouldReturnNotFound()
    {
        var (_, returnShipment) = await SeedReturnAsync(993);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/Returns/{returnShipment.Id}/label");

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task RetryLabel_WithMissingReturnConfig_ShouldReturnBadRequest()
    {
        // Provider exists but has no ReturnReceiverId — the DHL connector fails permanently.
        var (_, returnShipment) = await SeedReturnAsync(994);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.PostAsync($"/api/v1/Returns/{returnShipment.Id}/label/retry", null);

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task GetDetails_CrossTenant_ShouldReturnNotFound()
    {
        var (_, returnShipment) = await SeedReturnAsync(990);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Returns/{returnShipment.Id}");

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetAll_CrossTenant_ShouldNotLeakRows()
    {
        var (sales, _) = await SeedReturnAsync(991);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Returns?salesId={sales.Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<ReturnShipmentListItemDto>>(response);
        TestAssertions.AssertEqual(0, result.Data.Count);
    }

    [Fact]
    public async Task GetLabel_CrossTenant_ShouldReturnNotFound()
    {
        var labelBytes = new byte[] { 0x25, 0x50, 0x44, 0x46 };
        var (_, returnShipment) = await SeedReturnAsync(992, labelData: labelBytes);
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/Returns/{returnShipment.Id}/label");

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
    }
}
