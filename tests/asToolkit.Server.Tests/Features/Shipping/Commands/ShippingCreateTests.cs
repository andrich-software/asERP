using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Shipping;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.Shipping.Commands;

public class ShippingCreateTests : TenantIsolatedTestBase
{
    private async Task<(asToolkit.Domain.Entities.ShippingProvider Provider,
        asToolkit.Domain.Entities.ShippingProviderRate Rate,
        asToolkit.Domain.Entities.Sales Sales)> SeedShippingSetupAsync(
        string deliveryCountry = "Germany", bool providerEnabled = true, int customerNumber = 801)
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id,
            isEnabled: providerEnabled);
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id,
            customerNumber, deliveryCountry);
        await DbContext.SaveChangesAsync();
        return (provider, rate, sales);
    }

    private static ShippingInputDto CreateValidInputDto(Guid salesId, Guid rateId, params Guid[] salesItemIds)
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

    [Fact]
    public async Task CreateShipping_WithoutLabel_ShouldReturnCreatedWithDefaults()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        var itemIds = sales.SalesItems.Select(i => i.Id).ToArray();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id, itemIds);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);

        DbContext.ChangeTracker.Clear();
        var created = await DbContext.Shipping.FirstOrDefaultAsync(s => s.Id == result.Data);
        TestAssertions.AssertNotNull(created);
        TestAssertions.AssertEqual(ShippingStatus.Open, created!.Status);
        TestAssertions.AssertEqual(rate.Price, created.ShippingCost);
        TestAssertions.AssertEqual(TenantConstants.TestTenant1Id, created.TenantId);
    }

    [Fact]
    public async Task CreateShipping_ShouldWriteSalesHistoryRow()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var historyRow = await DbContext.SalesHistory
            .FirstOrDefaultAsync(h => h.SalesId == sales.Id && h.ShippingStatusNew == "Open");
        TestAssertions.AssertNotNull(historyRow);
    }

    [Fact]
    public async Task CreateShipping_ShouldStampSalesItemIds()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        var itemIds = sales.SalesItems.Select(i => i.Id).ToArray();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id, itemIds);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);

        DbContext.ChangeTracker.Clear();
        var items = await DbContext.SalesItem.Where(i => itemIds.Contains(i.Id)).ToListAsync();
        TestAssertions.AssertEqual(2, items.Count);
        foreach (var item in items)
        {
            TestAssertions.AssertEqual<Guid?>(result.Data, item.ShippingId);
        }
    }

    [Fact]
    public async Task CreateShipping_WithExplicitShippingCost_ShouldKeepIt()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        dto.ShippingCost = 9.49m;
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        DbContext.ChangeTracker.Clear();
        var created = await DbContext.Shipping.FirstAsync(s => s.Id == result.Data);
        TestAssertions.AssertEqual(9.49m, created.ShippingCost);
    }

    [Fact]
    public async Task CreateShipping_DeliveryCountryNotAllowed_ShouldReturnBadRequest()
    {
        // Rate only ships to Germany, order goes to Austria.
        var (_, rate, sales) = await SeedShippingSetupAsync(deliveryCountry: "Austria");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_UnresolvableCountry_ShouldReturnBadRequest()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(deliveryCountry: "Atlantis");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_Overweight_ShouldReturnBadRequest()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        dto.WeightKg = rate.MaxWeight + 1m;
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_Oversize_ShouldReturnBadRequest()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        dto.LengthCm = rate.MaxLength + 10m;
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_DisabledProvider_ShouldReturnBadRequest()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync(providerEnabled: false);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_ItemOfOtherSales_ShouldReturnBadRequest()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        var otherSales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 802);
        await DbContext.SaveChangesAsync();
        var foreignItemId = otherSales.SalesItems.First().Id;
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id, foreignItemId);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_ItemAlreadyAssigned_ShouldReturnBadRequest()
    {
        var (provider, rate, sales) = await SeedShippingSetupAsync();
        var existingShipping = ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        var item = sales.SalesItems.First();
        item.ShippingId = existingShipping.Id;
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id, item.Id);
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateShipping_WithLabelRequestButNoCarrierConfig_ShouldReturnCreatedWithWarning()
    {
        var (_, rate, sales) = await SeedShippingSetupAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidInputDto(sales.Id, rate.Id);
        dto.RequestLabel = true;
        var response = await PostAsJsonAsync("/api/v1/Shippings", dto);

        // Label problems never fail the shipment creation — the error surfaces as a message.
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertNotEmpty(result.Messages);
    }
}
