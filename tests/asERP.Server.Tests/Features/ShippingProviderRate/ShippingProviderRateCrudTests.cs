using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.ShippingProviderRate;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.ShippingProviderRate;

public class ShippingProviderRateCrudTests : TenantIsolatedTestBase
{
    private async Task<asERP.Domain.Entities.ShippingProvider> SeedProviderAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        ShippingTestDataSeeder.EnsureCountries(DbContext);
        var provider = ShippingTestDataSeeder.AddProvider(DbContext, TenantConstants.TestTenant1Id);
        await DbContext.SaveChangesAsync();
        return provider;
    }

    private static ShippingProviderRateCreateDto CreateValidRateDto(params Guid[] countryIds)
    {
        return new ShippingProviderRateCreateDto
        {
            Name = "Paket M",
            MaxLength = 120m,
            MaxWidth = 60m,
            MaxHeight = 60m,
            MaxWeight = 31.5m,
            Price = 5.99m,
            AllowedCountryIds = (countryIds.Length == 0
                ? new[] { ShippingTestDataSeeder.GermanyCountryId }
                : countryIds).ToList()
        };
    }

    [Fact]
    public async Task CreateRate_WithValidCountries_ShouldReturnCreatedAndPersistJoinRows()
    {
        var provider = await SeedProviderAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto(ShippingTestDataSeeder.GermanyCountryId, ShippingTestDataSeeder.AustriaCountryId);
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);

        DbContext.ChangeTracker.Clear();
        var joinRows = await DbContext.ShippingProviderRateCountry
            .Where(c => c.ShippingProviderRateId == result.Data)
            .Select(c => c.CountryId)
            .ToListAsync();
        TestAssertions.AssertEqual(2, joinRows.Count);
        TestAssertions.AssertContains(ShippingTestDataSeeder.GermanyCountryId, joinRows);
        TestAssertions.AssertContains(ShippingTestDataSeeder.AustriaCountryId, joinRows);
    }

    [Fact]
    public async Task CreateRate_WithNonexistentCountryId_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto(Guid.NewGuid());
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateRate_WithEmptyCountryList_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto();
        dto.AllowedCountryIds = new List<Guid>();
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateRate_WithDuplicateCountryIds_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto(ShippingTestDataSeeder.GermanyCountryId, ShippingTestDataSeeder.GermanyCountryId);
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateRate_WithNegativePrice_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto();
        dto.Price = -1m;
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateRate_WithDuplicateNamePerProvider_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        ShippingTestDataSeeder.AddRate(DbContext, provider, name: "Paket M");
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = CreateValidRateDto();
        var response = await PostAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates", dto);

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task UpdateRate_ShouldReplaceCountrySet()
    {
        var provider = await SeedProviderAsync();
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider,
            allowedCountryIds: new[] { ShippingTestDataSeeder.GermanyCountryId });
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var dto = new ShippingProviderRateUpdateDto
        {
            Name = rate.Name,
            MaxLength = rate.MaxLength,
            MaxWidth = rate.MaxWidth,
            MaxHeight = rate.MaxHeight,
            MaxWeight = rate.MaxWeight,
            Price = rate.Price,
            AllowedCountryIds = new List<Guid>
            {
                ShippingTestDataSeeder.AustriaCountryId,
                ShippingTestDataSeeder.SwitzerlandCountryId
            }
        };
        var response = await PutAsJsonAsync($"/api/v1/ShippingProviders/{provider.Id}/rates/{rate.Id}", dto);

        TestAssertions.AssertHttpSuccess(response);
        DbContext.ChangeTracker.Clear();
        var joinRows = await DbContext.ShippingProviderRateCountry
            .Where(c => c.ShippingProviderRateId == rate.Id)
            .Select(c => c.CountryId)
            .ToListAsync();
        TestAssertions.AssertEqual(2, joinRows.Count);
        TestAssertions.AssertContains(ShippingTestDataSeeder.AustriaCountryId, joinRows);
        TestAssertions.AssertContains(ShippingTestDataSeeder.SwitzerlandCountryId, joinRows);
        TestAssertions.AssertDoesNotContain(ShippingTestDataSeeder.GermanyCountryId, joinRows);
    }

    [Fact]
    public async Task DeleteRate_ShouldRemoveJoinRows()
    {
        var provider = await SeedProviderAsync();
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider,
            allowedCountryIds: new[] { ShippingTestDataSeeder.GermanyCountryId, ShippingTestDataSeeder.AustriaCountryId });
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}/rates/{rate.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NoContent, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var rateExists = await DbContext.ShippingProviderRate.AnyAsync(r => r.Id == rate.Id);
        var joinRowsExist = await DbContext.ShippingProviderRateCountry.AnyAsync(c => c.ShippingProviderRateId == rate.Id);
        TestAssertions.AssertFalse(rateExists);
        TestAssertions.AssertFalse(joinRowsExist);
    }

    [Fact]
    public async Task DeleteRate_ReferencedByShipping_ShouldReturnBadRequest()
    {
        var provider = await SeedProviderAsync();
        var rate = ShippingTestDataSeeder.AddRate(DbContext, provider);
        var sales = ShippingTestDataSeeder.AddSales(DbContext, TenantConstants.TestTenant1Id, 701);
        ShippingTestDataSeeder.AddShipping(DbContext, sales, provider, rate);
        await DbContext.SaveChangesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.DeleteAsync($"/api/v1/ShippingProviders/{provider.Id}/rates/{rate.Id}");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
        DbContext.ChangeTracker.Clear();
        var rateExists = await DbContext.ShippingProviderRate.AnyAsync(r => r.Id == rate.Id);
        TestAssertions.AssertTrue(rateExists);
    }
}
