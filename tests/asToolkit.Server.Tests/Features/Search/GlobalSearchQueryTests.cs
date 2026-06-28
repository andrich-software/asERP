using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Search;
using asToolkit.Domain.Enums;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Xunit;

namespace asToolkit.Server.Tests.Features.Search;

public class GlobalSearchQueryTests : TenantIsolatedTestBase
{
    private async Task SeedSearchTestDataAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

        DbContext.Customer.AddRange(
            new asToolkit.Domain.Entities.Customer
            {
                Id = Guid.Parse("50000001-0001-0001-0001-000000000001"),
                CustomerId = 1001,
                Firstname = "Alice",
                Lastname = "Schneider",
                CompanyName = "Alpha GmbH",
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = DateTimeOffset.UtcNow.AddDays(-10),
                TenantId = TenantConstants.TestTenant1Id
            },
            new asToolkit.Domain.Entities.Customer
            {
                Id = Guid.Parse("50000002-0002-0002-0002-000000000002"),
                CustomerId = 2001,
                Firstname = "Bob",
                Lastname = "Schneider",
                CompanyName = "Beta AG",
                CustomerStatus = CustomerStatus.Active,
                DateEnrollment = DateTimeOffset.UtcNow.AddDays(-5),
                TenantId = TenantConstants.TestTenant2Id
            });

        DbContext.Product.Add(new asToolkit.Domain.Entities.Product
        {
            Id = Guid.Parse("50000010-0010-0010-0010-000000000010"),
            Sku = "FABRIC-RED-01",
            Name = "Roter Baumwollstoff",
            Ean = "4001234567890",
            TaxClassId = Guid.NewGuid(),
            ProductType = ProductType.Standard,
            TenantId = TenantConstants.TestTenant1Id
        });

        DbContext.Invoice.Add(new asToolkit.Domain.Entities.Invoice
        {
            Id = Guid.Parse("50000020-0020-0020-0020-000000000020"),
            InvoiceNumber = "RE-2026-0042",
            InvoiceDate = DateTime.UtcNow,
            CustomerId = 1001,
            InvoiceAddressFirstName = "Alice",
            InvoiceAddressLastName = "Schneider",
            TenantId = TenantConstants.TestTenant1Id
        });

        await DbContext.SaveChangesAsync();
    }

    [Fact]
    public async Task Search_MatchesCustomerByLastname_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Customers.Count);
        TestAssertions.AssertEqual(SearchEntityType.Customer, result.Data.Customers[0].Type);
    }

    [Fact]
    public async Task Search_MatchesProductByEan_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=400123&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Products.Count);
        TestAssertions.AssertEqual("Roter Baumwollstoff", result.Data.Products[0].Title);
    }

    [Fact]
    public async Task Search_MatchesInvoiceByNumber_ReturnsHit()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=RE-2026&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Invoices.Count);
        TestAssertions.AssertEqual("RE-2026-0042", result.Data.Invoices[0].Title);
    }

    [Fact]
    public async Task Search_TenantIsolation_DoesNotReturnOtherTenantData()
    {
        await SeedSearchTestDataAsync();

        // Tenant 2 has its own "Schneider" customer and must not see tenant 1's.
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(1, result.Data!.Customers.Count);
        TestAssertions.AssertEqual(Guid.Parse("50000002-0002-0002-0002-000000000002"), result.Data.Customers[0].Id);
        // Tenant 1's product/invoice must not leak.
        TestAssertions.AssertEqual(0, result.Data.Products.Count);
        TestAssertions.AssertEqual(0, result.Data.Invoices.Count);
    }

    [Fact]
    public async Task Search_BelowThreshold_ReturnsEmpty()
    {
        await SeedSearchTestDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync("/api/v1/Search?searchString=Sc&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(0, result.Data!.TotalCount);
    }

    [Fact]
    public async Task Search_WithoutTenantHeader_ReturnsEmpty()
    {
        await SeedSearchTestDataAsync();
        RemoveTenantHeader();

        var response = await Client.GetAsync("/api/v1/Search?searchString=Schneider&limit=5");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<GlobalSearchResultDto>>(response);
        TestAssertions.AssertNotNull(result.Data);
        TestAssertions.AssertEqual(0, result.Data!.TotalCount);
    }
}
