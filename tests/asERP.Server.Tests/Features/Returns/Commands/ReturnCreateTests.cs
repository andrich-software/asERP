using asERP.Domain.Constants;
using asERP.Domain.Dtos.Returns;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Returns.Commands;

/// <summary>
/// Tests for POST /api/v1/Returns: quantity accounting against shipped lines, the shipped-only
/// guard, serial-number whole-line rule and cross-tenant isolation.
/// Customer-number range: 950–959.
/// </summary>
public class ReturnCreateTests : TenantIsolatedTestBase
{
    private async Task<(Domain.Entities.ShippingProvider Provider, Domain.Entities.Sales Sales, Domain.Entities.Shipping Shipping)>
        SeedShippedSalesAsync(int customerNumber, double itemQuantity = 1, SalesStatus salesStatus = SalesStatus.Completed)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber);
        sales.Status = salesStatus;

        var shipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate,
            status: ShippingStatus.Shipped, shippedAt: DateTime.UtcNow.AddDays(-2));

        foreach (var item in sales.SalesItems)
        {
            item.Quantity = itemQuantity;
            item.ShippingId = shipping.Id;
        }

        await DbContext.SaveChangesAsync();
        return (provider, sales, shipping);
    }

    private static ReturnShipmentInputDto BuildInput(Guid salesId, params (Guid SalesItemId, double Quantity)[] items) => new()
    {
        SalesId = salesId,
        Items = items.Select(i => new ReturnShipmentItemInputDto
        {
            SalesItemId = i.SalesItemId,
            Quantity = i.Quantity,
            Reason = ReturnReason.Defective
        }).ToList()
    };

    [Fact]
    public async Task Create_WholeLine_ShouldReturnCreated()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(950);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);

        DbContext.ChangeTracker.Clear();
        var created = await DbContext.ReturnShipment
            .Include(r => r.Items)
            .FirstOrDefaultAsync(r => r.Id == result.Data);
        TestAssertions.AssertNotNull(created);
        TestAssertions.AssertEqual(ReturnShipmentStatus.Requested, created!.Status);
        TestAssertions.AssertEqual(1, created.Items.Count);
        TestAssertions.AssertEqual(ReturnReason.Defective, created.Items.First().Reason);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, created.TenantId);
    }

    [Fact]
    public async Task Create_PartialQuantity_ShouldSucceed()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(951, itemQuantity: 3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 2)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.Created, response.StatusCode);

        DbContext.ChangeTracker.Clear();
        var createdItem = await DbContext.ReturnShipmentItem.FirstOrDefaultAsync(i => i.SalesItemId == item.Id);
        TestAssertions.AssertNotNull(createdItem);
        TestAssertions.AssertEqual(2, createdItem!.Quantity);
    }

    [Fact]
    public async Task Create_QuantityExceedingShipped_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(952);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 2)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_SecondReturnExceedingRemainder_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(953, itemQuantity: 3);
        var item = sales.SalesItems.First();
        ShippingTestDataSeeder.AddReturnShipment(DbContext, sales, items: (item.Id, 2));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var tooMuch = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 2)));
        var exactRemainder = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, tooMuch.StatusCode);
        TestAssertions.AssertEqual(System.Net.HttpStatusCode.Created, exactRemainder.StatusCode);
    }

    [Fact]
    public async Task Create_CancelledReturnDoesNotConsumeQuantity()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(954);
        var item = sales.SalesItems.First();
        ShippingTestDataSeeder.AddReturnShipment(DbContext, sales,
            status: ReturnShipmentStatus.Cancelled, items: (item.Id, 1));
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Create_UnshippedItem_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(955);
        var unshipped = sales.SalesItems.Last();
        unshipped.ShippingId = null;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (unshipped.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_ItemOfForeignSales_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(956);
        var otherSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 957);
        await DbContext.SaveChangesAsync();
        var foreignItem = otherSales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (foreignItem.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_OnCancelledSales_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(958, salesStatus: SalesStatus.Cancelled);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task Create_SerializedLinePartial_ShouldReturnBadRequest()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(959, itemQuantity: 2);
        var item = sales.SalesItems.First();
        ShippingTestDataSeeder.AddSerialNumber(DbContext, item, "SN-950-1");
        ShippingTestDataSeeder.AddSerialNumber(DbContext, item, "SN-950-2");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var partial = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));
        var whole = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 2)));

        TestAssertions.AssertEqual(System.Net.HttpStatusCode.BadRequest, partial.StatusCode);
        TestAssertions.AssertEqual(System.Net.HttpStatusCode.Created, whole.StatusCode);
    }

    [Fact]
    public async Task Create_CrossTenant_ShouldBeRejected()
    {
        var (_, sales, _) = await SeedShippedSalesAsync(950);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await PostAsJsonAsync("/api/v1/Returns", BuildInput(sales.Id, (item.Id, 1)));

        TestAssertions.AssertTrue(response.StatusCode is System.Net.HttpStatusCode.BadRequest
            or System.Net.HttpStatusCode.NotFound);

        DbContext.ChangeTracker.Clear();
        var count = await DbContext.ReturnShipment.CountAsync(r => r.SalesId == sales.Id);
        TestAssertions.AssertEqual(0, count);
    }
}
