using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Shipping;
using asERP.Domain.Entities;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Shipping.Commands;

/// <summary>
/// Partial-quantity shipment creation: the original row becomes the shipped part,
/// the remainder is split into a new unassigned row.
/// </summary>
public class ShippingCreatePartialQuantityTests : TenantIsolatedTestBase
{
    private async Task<(asERP.Domain.Entities.ShippingProviderRate Rate,
        asERP.Domain.Entities.Sales Sales)> SeedSetupAsync(
        int customerNumber, double firstItemQuantity = 3)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, customerNumber,
            itemCount: 1);
        sales.SalesItems.First().Quantity = firstItemQuantity;
        await DbContext.SaveChangesAsync();
        return (rate, sales);
    }

    private static ShippingInputDto CreateInputDto(Guid salesId, Guid rateId,
        params (Guid ItemId, double Quantity)[] items)
    {
        return new ShippingInputDto
        {
            SalesId = salesId,
            ShippingProviderRateId = rateId,
            TaxRate = 19.0,
            Items = items.Select(i => new ShippingItemInputDto { SalesItemId = i.ItemId, Quantity = i.Quantity })
                .ToList(),
            RequestLabel = false
        };
    }

    private void AddSerialNumbers(SalesItem item, params string[] serials)
    {
        foreach (var serial in serials)
        {
            DbContext.SalesItemSerialNumber.Add(new SalesItemSerialNumber
            {
                Id = Guid.NewGuid(),
                SalesItemId = item.Id,
                SerialNumber = serial,
                TenantId = item.TenantId
            });
        }
    }

    [Fact]
    public async Task PartialQuantity_ShouldSplitLine()
    {
        var (rate, sales) = await SeedSetupAsync(830, firstItemQuantity: 3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);

        DbContext.ChangeTracker.Clear();
        var rows = await DbContext.SalesItem.Where(i => i.SalesId == sales.Id).ToListAsync();
        TestAssertions.AssertEqual(2, rows.Count);

        var shipped = rows.First(r => r.Id == item.Id);
        TestAssertions.AssertEqual<Guid?>(result.Data, shipped.ShippingId);
        TestAssertions.AssertEqual(1d, shipped.Quantity);

        var remainder = rows.First(r => r.Id != item.Id);
        TestAssertions.AssertNull(remainder.ShippingId);
        TestAssertions.AssertEqual(2d, remainder.Quantity);
        TestAssertions.AssertEqual(item.ProductId, remainder.ProductId);
        TestAssertions.AssertEqual(item.Price, remainder.Price);
        TestAssertions.AssertEqual(item.TaxRate, remainder.TaxRate);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, remainder.TenantId);
    }

    [Fact]
    public async Task FullQuantityViaItems_ShouldNotSplit()
    {
        var (rate, sales) = await SeedSetupAsync(831, firstItemQuantity: 3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 3)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var rows = await DbContext.SalesItem.Where(i => i.SalesId == sales.Id).ToListAsync();
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertNotNull(rows[0].ShippingId);
    }

    [Fact]
    public async Task DoubleRounding_ShouldProduceCleanRemainder()
    {
        var (rate, sales) = await SeedSetupAsync(832, firstItemQuantity: 0.3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 0.1)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var remainder = await DbContext.SalesItem
            .FirstAsync(i => i.SalesId == sales.Id && i.ShippingId == null);
        TestAssertions.AssertEqual(0.2d, remainder.Quantity);
    }

    [Fact]
    public async Task QuantityWithinTolerance_ShouldCountAsFullLine()
    {
        var (rate, sales) = await SeedSetupAsync(833, firstItemQuantity: 2);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 2.00005)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var rows = await DbContext.SalesItem.Where(i => i.SalesId == sales.Id).ToListAsync();
        TestAssertions.AssertEqual(1, rows.Count);
        TestAssertions.AssertEqual(2d, rows[0].Quantity);
    }

    [Fact]
    public async Task QuantityAboveOpenQuantity_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(834, firstItemQuantity: 3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 4)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ZeroQuantity_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(835);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 0)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task DuplicateItemInItems_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(836, firstItemQuantity: 4);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 1), (item.Id, 1)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ItemInBothListsAtOnce_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(837, firstItemQuantity: 4);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateInputDto(sales.Id, rate.Id, (item.Id, 1));
        dto.SalesItemIds.Add(item.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task PartialQuantityWithSerialNumbers_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(838, firstItemQuantity: 2);
        var item = sales.SalesItems.First();
        AddSerialNumbers(item, "SN-1", "SN-2");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task FullQuantityWithSerialNumbers_ShouldKeepSerialsOnShippedRow()
    {
        var (rate, sales) = await SeedSetupAsync(839, firstItemQuantity: 2);
        var item = sales.SalesItems.First();
        AddSerialNumbers(item, "SN-1", "SN-2");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 2)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var serials = await DbContext.SalesItemSerialNumber
            .Where(s => s.SalesItemId == item.Id)
            .ToListAsync();
        TestAssertions.AssertEqual(2, serials.Count);
        var shipped = await DbContext.SalesItem.FirstAsync(i => i.Id == item.Id);
        TestAssertions.AssertNotNull(shipped.ShippingId);
    }

    [Fact]
    public async Task AlreadyAssignedItemViaItems_ShouldReturnBadRequest()
    {
        var (rate, sales) = await SeedSetupAsync(840, firstItemQuantity: 3);
        var provider = await DbContext.ShippingProvider.FirstAsync();
        var existing = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        var item = sales.SalesItems.First();
        item.ShippingId = existing.Id;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task PartialQuantityShipment_ShouldLeaveOrderPartiallyDelivered()
    {
        var (rate, sales) = await SeedSetupAsync(841, firstItemQuantity: 3);
        var item = sales.SalesItems.First();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Shippings",
            CreateInputDto(sales.Id, rate.Id, (item.Id, 1)));

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var order = await DbContext.Sales.FirstAsync(s => s.Id == sales.Id);
        TestAssertions.AssertEqual(asERP.Domain.Enums.SalesStatus.PartiallyDelivered, order.Status);
    }
}
