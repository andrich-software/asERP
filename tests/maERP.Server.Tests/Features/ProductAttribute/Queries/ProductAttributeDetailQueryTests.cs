using System.Net;
using maERP.Domain.Constants;
using maERP.Domain.Dtos.ProductAttribute;
using maERP.Domain.Wrapper;
using maERP.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace maERP.Server.Tests.Features.ProductAttribute.Queries;

public class ProductAttributeDetailQueryTests : TenantIsolatedTestBase
{
    private static readonly Guid Attr1Id = Guid.NewGuid();
    private static readonly Guid Attr2Id = Guid.NewGuid();

    private async Task SeedAttributesAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var hasData = await DbContext.ProductAttribute.AnyAsync();
            if (!hasData)
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);

                // Tenant 1 attribute with deliberately out-of-order SortOrder
                DbContext.ProductAttribute.Add(new maERP.Domain.Entities.ProductAttribute
                {
                    Id = Attr1Id,
                    Name = "Color",
                    SortOrder = 0,
                    TenantId = TenantConstants.TestTenant1Id,
                    Values = new List<maERP.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Value = "Blue", SortOrder = 2, TenantId = TenantConstants.TestTenant1Id },
                        new() { Value = "Red", SortOrder = 0, TenantId = TenantConstants.TestTenant1Id },
                        new() { Value = "Green", SortOrder = 1, TenantId = TenantConstants.TestTenant1Id }
                    }
                });

                // Tenant 2 attribute
                DbContext.ProductAttribute.Add(new maERP.Domain.Entities.ProductAttribute
                {
                    Id = Attr2Id,
                    Name = "Material",
                    SortOrder = 0,
                    TenantId = TenantConstants.TestTenant2Id,
                    Values = new List<maERP.Domain.Entities.ProductAttributeValue>
                    {
                        new() { Value = "Cotton", SortOrder = 0, TenantId = TenantConstants.TestTenant2Id }
                    }
                });

                await DbContext.SaveChangesAsync();
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    [Fact]
    public async Task GetProductAttributeDetail_ShouldReturnValuesSortedBySortOrder()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/ProductAttributes/{Attr1Id}");

        TestAssertions.AssertHttpSuccess(response);
        var result = await ReadResponseAsync<Result<ProductAttributeDetailDto>>(response);
        TestAssertions.AssertNotNull(result?.Data);
        TestAssertions.AssertEqual(3, result!.Data.Values.Count);

        var values = result.Data.Values.Select(v => v.Value).ToList();
        TestAssertions.AssertEqual("Red", values[0]);
        TestAssertions.AssertEqual("Green", values[1]);
        TestAssertions.AssertEqual("Blue", values[2]);
    }

    [Fact]
    public async Task GetProductAttributeDetail_CrossTenant_ShouldReturnNotFound()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/ProductAttributes/{Attr1Id}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task GetProductAttributeDetail_NotFound_ShouldReturnNotFound()
    {
        await SeedAttributesAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await Client.GetAsync($"/api/v1/ProductAttributes/{Guid.NewGuid()}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
