using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Country.Queries;

/// <summary>
/// The list-query parameter was renamed from <c>salesBy</c> to <c>sortBy</c>. Third-party callers
/// still sending the old name must keep working until the deprecation is dropped
/// (<c>LegacySortParameterMiddleware</c>).
/// </summary>
public class LegacySortParameterTests : TenantIsolatedTestBase
{
    private async Task SeedCountriesAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        foreach (var (name, code) in new[] { ("Zimbabwe", "ZW"), ("Albania", "AL"), ("Mexico", "MX") })
        {
            var created = await PostAsJsonAsync("/api/v1/Countries",
                new CountryInputDto { Name = name, CountryCode = code });
            TestAssertions.AssertHttpStatusCode(created, HttpStatusCode.Created);
        }
    }

    private async Task<List<string>> GetNamesAsync(string query)
    {
        var response = await Client.GetAsync($"/api/v1/Countries?pageSize=100&{query}");
        TestAssertions.AssertHttpSuccess(response);

        var result = await ReadResponseAsync<PaginatedResult<CountryListDto>>(response);
        return result.Data.Select(country => country.Name).ToList();
    }

    [Fact]
    public async Task DeprecatedSalesByAlias_SortsLikeSortBy()
    {
        await SeedCountriesAsync();

        var viaSortBy = await GetNamesAsync("sortBy=Name");
        var viaLegacyAlias = await GetNamesAsync("salesBy=Name");

        TestAssertions.AssertEqual(viaSortBy.Count, viaLegacyAlias.Count);
        TestAssertions.AssertTrue(viaSortBy.SequenceEqual(viaLegacyAlias),
            $"sortBy gave [{string.Join(", ", viaSortBy)}], salesBy gave [{string.Join(", ", viaLegacyAlias)}]");
    }

    [Fact]
    public async Task SortBy_WinsWhenBothAreSent()
    {
        await SeedCountriesAsync();

        var sortedByName = await GetNamesAsync("sortBy=Name");
        var bothSent = await GetNamesAsync("sortBy=Name&salesBy=CountryCode");

        TestAssertions.AssertTrue(sortedByName.SequenceEqual(bothSent),
            $"expected [{string.Join(", ", sortedByName)}], got [{string.Join(", ", bothSent)}]");
    }

    [Fact]
    public async Task OtherQueryParametersSurviveTheRewrite()
    {
        await SeedCountriesAsync();

        var response = await Client.GetAsync("/api/v1/Countries?pageNumber=0&pageSize=2&salesBy=Name");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<PaginatedResult<CountryListDto>>(response);
        TestAssertions.AssertEqual(2, result.Data.Count);
    }
}
