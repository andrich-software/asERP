using System.Net;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asERP.Server.Tests.Features.Country.Commands;

/// <summary>
/// Country is the only entity allowed to live without a tenant (see
/// <c>ApplicationDbContext.IsGloballyOwnedEntity</c>): rows with <c>TenantId == null</c> are shared
/// reference data that every tenant reads through the <c>TenantId == null</c> arm of the global
/// query filter. Writing such a row is therefore installation-wide and reserved for Superadmins,
/// while tenant-owned rows stay fully writable by their own tenant.
/// <para>
/// Note on coverage: the production report is about a request with no tenant context at all. Under
/// the Testing environment <c>TenantMiddleware</c> sets <c>Guid.Empty</c> when the X-Tenant-Id
/// header is missing, so this harness cannot produce a null tenant context over HTTP — that arm is
/// covered by <see cref="TenantlessCountryWriteAuthorizationTests"/>, which drives the controller
/// directly. What the tests below pin is the shared-row arm (the targeted row's
/// <c>TenantId</c> is null) and that ordinary tenant users keep their own rows.
/// </para>
/// </summary>
public class SharedCountryRowAuthorizationTests : TenantIsolatedTestBase
{
    private async Task<Guid> CreateSharedCountryAsync(string name = "Shared Land", string countryCode = "SL")
    {
        // No tenant context -> the row is persisted with TenantId == null (installation-wide).
        TenantContext.SetCurrentTenantId(null);

        var country = new Domain.Entities.Country
        {
            Name = name,
            CountryCode = countryCode,
            TenantId = null,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        DbContext.Country.Add(country);
        await DbContext.SaveChangesAsync();

        return country.Id;
    }

    private async Task<Guid> CreateTenantCountryAsync(Guid tenantId, string name = "Owned Land", string countryCode = "OL")
    {
        TenantContext.SetCurrentTenantId(tenantId);

        var country = new Domain.Entities.Country
        {
            Name = name,
            CountryCode = countryCode,
            TenantId = tenantId,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        DbContext.Country.Add(country);
        await DbContext.SaveChangesAsync();

        return country.Id;
    }

    private async Task<bool> CountryStillExistsAsync(Guid id)
    {
        return await DbContext.Country.IgnoreQueryFilters().AnyAsync(c => c.Id == id);
    }

    [Fact]
    public async Task DeleteSharedCountry_WithoutTenantHeader_AsNonSuperadmin_IsForbidden()
    {
        // Arrange
        var sharedCountryId = await CreateSharedCountryAsync();
        RemoveTenantHeader();

        // Act
        var response = await Client.DeleteAsync($"/api/v1/Countries/{sharedCountryId}");

        // Assert
        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Forbidden);
        TestAssertions.AssertTrue(await CountryStillExistsAsync(sharedCountryId));
    }

    [Fact]
    public async Task DeleteSharedCountry_WithTenantHeader_AsNonSuperadmin_IsForbidden()
    {
        // Arrange
        var sharedCountryId = await CreateSharedCountryAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Act
        var response = await Client.DeleteAsync($"/api/v1/Countries/{sharedCountryId}");

        // Assert
        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Forbidden);
        TenantContext.SetCurrentTenantId(TenantConstants.TestTenant1Id);
        TestAssertions.AssertTrue(await CountryStillExistsAsync(sharedCountryId));
    }

    [Fact]
    public async Task UpdateSharedCountry_WithTenantHeader_AsNonSuperadmin_IsForbidden()
    {
        // Arrange
        var sharedCountryId = await CreateSharedCountryAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Act
        var response = await PutAsJsonAsync($"/api/v1/Countries/{sharedCountryId}",
            new CountryInputDto { Name = "Hijacked Land", CountryCode = "HL" });

        // Assert
        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Forbidden);

        TenantContext.SetCurrentTenantId(null);
        var stored = await DbContext.Country.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(c => c.Id == sharedCountryId);
        TestAssertions.AssertEqual("Shared Land", stored.Name);
    }

    [Fact]
    public async Task DeleteOwnTenantCountry_AsNonSuperadmin_StillSucceeds()
    {
        // Arrange
        var countryId = await CreateTenantCountryAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Act
        var response = await Client.DeleteAsync($"/api/v1/Countries/{countryId}");

        // Assert
        TestAssertions.AssertHttpSuccess(response);
        TestAssertions.AssertFalse(await CountryStillExistsAsync(countryId));
    }

    [Fact]
    public async Task CreateCountry_WithTenantHeader_AsNonSuperadmin_StillSucceeds()
    {
        // Arrange
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Act
        var response = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Tenant Land", CountryCode = "TL" });

        // Assert
        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Created);
        var result = await ReadResponseAsync<Result<Guid>>(response);

        var created = await DbContext.Country.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(c => c.Id == result.Data);
        TestAssertions.AssertEqual<Guid?>(TenantConstants.TestTenant1Id, created.TenantId);
    }

    [Fact]
    public async Task UpdateOwnTenantCountry_AsNonSuperadmin_StillSucceeds()
    {
        // Arrange
        var countryId = await CreateTenantCountryAsync(TenantConstants.TestTenant1Id);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // Act
        var response = await PutAsJsonAsync($"/api/v1/Countries/{countryId}",
            new CountryInputDto { Name = "Renamed Land", CountryCode = "RL" });

        // Assert
        TestAssertions.AssertHttpSuccess(response);

        var stored = await DbContext.Country.IgnoreQueryFilters().AsNoTracking()
            .FirstAsync(c => c.Id == countryId);
        TestAssertions.AssertEqual("Renamed Land", stored.Name);
    }
}
