using System.Net;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.ProductAttribute;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace asToolkit.Server.Tests.Features.ProductAttribute.Commands;

public class ProductAttributeUpdateCommandTests : TenantIsolatedTestBase
{
    private async Task SeedBaseDataAsync()
    {
        var currentTenant = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);
        try
        {
            var hasData = await DbContext.TaxClass.AnyAsync();
            if (!hasData)
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
            }
        }
        finally
        {
            TenantContext.SetCurrentTenantId(currentTenant);
        }
    }

    private async Task<Guid> CreateAttributeAsync(string name)
    {
        var dto = new ProductAttributeInputDto
        {
            Name = name,
            SortOrder = 0,
            Values = new List<ProductAttributeValueInputDto>
            {
                new() { Value = "A", SortOrder = 0 },
                new() { Value = "B", SortOrder = 1 }
            }
        };
        var response = await PostAsJsonAsync("/api/v1/ProductAttributes", dto);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<Guid>>(response);
        return result.Data;
    }

    private async Task<ProductAttributeDetailDto> GetDetailAsync(Guid id)
    {
        var getResponse = await Client.GetAsync($"/api/v1/ProductAttributes/{id}");
        TestAssertions.AssertHttpSuccess(getResponse);
        var detail = await ReadResponseAsync<Result<ProductAttributeDetailDto>>(getResponse);
        TestAssertions.AssertNotNull(detail?.Data);
        return detail!.Data;
    }

    private static ProductAttributeInputDto ToInput(ProductAttributeDetailDto detail)
    {
        return new ProductAttributeInputDto
        {
            Id = detail.Id,
            Name = detail.Name,
            SortOrder = detail.SortOrder,
            Values = detail.Values
                .Select(v => new ProductAttributeValueInputDto { Id = v.Id, Value = v.Value, SortOrder = v.SortOrder })
                .ToList()
        };
    }

    [Fact]
    public async Task UpdateProductAttribute_NameAndSortOrder_ShouldPersist()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync("UpdName");

        var input = ToInput(await GetDetailAsync(id));
        input.Name = "Renamed";
        input.SortOrder = 5;

        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{id}", input);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);

        var detail = await GetDetailAsync(id);
        TestAssertions.AssertEqual("Renamed", detail.Name);
        TestAssertions.AssertEqual(5, detail.SortOrder);
    }

    [Fact]
    public async Task UpdateProductAttribute_AddValue_ShouldIncreaseValueCount()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync("AddVal");

        var input = ToInput(await GetDetailAsync(id));
        input.Values.Add(new ProductAttributeValueInputDto { Value = "C", SortOrder = 2 });

        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{id}", input);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);

        var detail = await GetDetailAsync(id);
        TestAssertions.AssertEqual(3, detail.Values.Count);
        TestAssertions.AssertTrue(detail.Values.Any(v => v.Value == "C"));
    }

    [Fact]
    public async Task UpdateProductAttribute_RemoveValue_ShouldDecreaseValueCount()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync("RemoveVal");

        var input = ToInput(await GetDetailAsync(id));
        input.Values.RemoveAt(input.Values.Count - 1);

        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{id}", input);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);

        var detail = await GetDetailAsync(id);
        TestAssertions.AssertEqual(1, detail.Values.Count);
    }

    [Fact]
    public async Task UpdateProductAttribute_RenameExistingValue_ShouldPersist()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync("RenameVal");

        var input = ToInput(await GetDetailAsync(id));
        input.Values[0].Value = "Renamed-A";

        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{id}", input);

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);

        var detail = await GetDetailAsync(id);
        TestAssertions.AssertTrue(detail.Values.Any(v => v.Value == "Renamed-A"));
        TestAssertions.AssertFalse(detail.Values.Any(v => v.Value == "A"));
    }

    [Fact]
    public async Task UpdateProductAttribute_NotFound_ShouldReturnNotFound()
    {
        await SeedBaseDataAsync();
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var missingId = Guid.NewGuid();

        var input = new ProductAttributeInputDto
        {
            Id = missingId,
            Name = "Ghost",
            SortOrder = 0,
            Values = new List<ProductAttributeValueInputDto> { new() { Value = "X", SortOrder = 0 } }
        };

        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{missingId}", input);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UpdateProductAttribute_CrossTenant_ShouldReturnNotFound()
    {
        await SeedBaseDataAsync();

        // Create in tenant 1
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var id = await CreateAttributeAsync($"CrossUpd-{Guid.NewGuid():N}");
        var input = ToInput(await GetDetailAsync(id));
        input.Name = "HackedName";

        // Try to update from tenant 2
        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await PutAsJsonAsync($"/api/v1/ProductAttributes/{id}", input);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
