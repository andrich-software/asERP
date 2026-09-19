using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Dtos.TaxClass;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Features.Country.Commands;

/// <summary>
/// The Country and TaxClass validators always carried a uniqueness rule, but it dispatched to
/// <c>GenericRepository.IsUniqueAsync</c>, whose base implementation returned <c>true</c> for
/// everything — so the rule never rejected anything. These tests pin the now-working behaviour,
/// including that it stays tenant-scoped.
/// </summary>
public class UniquenessRulesTests : TenantIsolatedTestBase
{
    private async Task SeedAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
    }

    [Fact]
    public async Task Country_WithDuplicateName_IsRejected()
    {
        await SeedAsync();
        var country = new CountryInputDto { Name = "Duplicate Land", CountryCode = "D1" };

        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/Countries", country), HttpStatusCode.Created);

        var second = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Duplicate Land", CountryCode = "D2" });

        TestAssertions.AssertHttpStatusCode(second, HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Country_WithDuplicateCode_IsRejected()
    {
        await SeedAsync();

        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/Countries",
                new CountryInputDto { Name = "Code Land One", CountryCode = "CD" }),
            HttpStatusCode.Created);

        var second = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Code Land Two", CountryCode = "CD" });

        TestAssertions.AssertHttpStatusCode(second, HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task Country_SameNameInAnotherTenant_IsAllowed()
    {
        await SeedAsync();
        var country = new CountryInputDto { Name = "Shared Land", CountryCode = "SL" };

        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/Countries", country), HttpStatusCode.Created);

        SetTenantHeader(TenantConstants.TestTenant2Id);

        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/Countries", country), HttpStatusCode.Created);
    }

    [Fact]
    public async Task Country_KeepingItsOwnValuesOnUpdate_IsAllowed()
    {
        await SeedAsync();

        var created = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Editable Land", CountryCode = "EL" });
        var id = (await ReadResponseAsync<Result<Guid>>(created)).Data;

        var update = await PutAsJsonAsync($"/api/v1/Countries/{id}",
            new CountryInputDto { Id = id, Name = "Editable Land", CountryCode = "EL" });

        TestAssertions.AssertHttpSuccess(update);
    }

    [Fact]
    public async Task TaxClass_WithDuplicateRate_IsRejected()
    {
        await SeedAsync();

        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/TaxClasses",
                new TaxClassInputDto { TaxRate = 13.5 }),
            HttpStatusCode.Created);

        var second = await PostAsJsonAsync("/api/v1/TaxClasses",
            new TaxClassInputDto { TaxRate = 13.5 });

        TestAssertions.AssertHttpStatusCode(second, HttpStatusCode.BadRequest);
    }
}
