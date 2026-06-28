using System.Net;
using System.Net.Http.Headers;
using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Domain.Constants;
using asToolkit.Domain.Dtos.Product;
using asToolkit.Domain.Wrapper;
using asToolkit.Server.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asToolkit.Server.Tests.Features.Product;

public class ProductImageTests : TenantIsolatedTestBase
{
    private async Task<Guid> SeedProductAsync(Guid tenantId, string sku)
    {
        var previous = TenantContext.GetCurrentTenantId();
        TenantContext.SetCurrentTenantId(null);

        try
        {
            if (!await DbContext.TaxClass.AnyAsync())
            {
                await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
            }

            var taxClass = new asToolkit.Domain.Entities.TaxClass
            {
                Id = Guid.NewGuid(),
                TaxRate = 19.0,
                TenantId = tenantId
            };

            var product = new asToolkit.Domain.Entities.Product
            {
                Id = Guid.NewGuid(),
                Sku = sku,
                Name = $"Product {sku}",
                Price = 9.99m,
                TaxClassId = taxClass.Id,
                TenantId = tenantId
            };

            DbContext.TaxClass.Add(taxClass);
            DbContext.Product.Add(product);
            await DbContext.SaveChangesAsync();

            return product.Id;
        }
        finally
        {
            TenantContext.SetCurrentTenantId(previous);
        }
    }

    private async Task<HttpResponseMessage> UploadImageAsync(
        Guid productId, string contentType = "image/png", string fileName = "test.png")
    {
        using var form = new MultipartFormDataContent();
        var fileContent = new ByteArrayContent(new byte[] { 1, 2, 3, 4 });
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        form.Add(fileContent, "file", fileName);

        return await Client.PostAsync($"/api/v1/products/{productId}/images", form);
    }

    private async Task<Guid> UploadAndGetIdAsync(Guid productId)
    {
        var response = await UploadImageAsync(productId);
        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<ProductImageDto>>(response);
        return result.Data!.Id;
    }

    private FakeProductImageStorage Storage =>
        (FakeProductImageStorage)Factory.Services.GetRequiredService<IProductImageStorage>();

    [Fact]
    public async Task Upload_FirstImage_IsCreatedAsPrimary()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-001");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await UploadImageAsync(productId);

        TestAssertions.AssertEqual(HttpStatusCode.Created, response.StatusCode);
        var result = await ReadResponseAsync<Result<ProductImageDto>>(response);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEqual(0, result.Data!.SortOrder);
        TestAssertions.AssertTrue(result.Data.IsPrimary);
    }

    [Fact]
    public async Task Upload_SecondImage_IsAppended()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-002");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await UploadAndGetIdAsync(productId);
        var second = await UploadImageAsync(productId);

        var result = await ReadResponseAsync<Result<ProductImageDto>>(second);
        TestAssertions.AssertEqual(1, result.Data!.SortOrder);
        TestAssertions.AssertFalse(result.Data.IsPrimary);
    }

    [Fact]
    public async Task List_ReturnsImagesOrdered()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-003");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        await UploadAndGetIdAsync(productId);
        await UploadAndGetIdAsync(productId);

        var response = await Client.GetAsync($"/api/v1/products/{productId}/images");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        var result = await ReadResponseAsync<Result<List<ProductImageDto>>>(response);
        TestAssertions.AssertEqual(2, result.Data!.Count);
        TestAssertions.AssertEqual(0, result.Data[0].SortOrder);
        TestAssertions.AssertEqual(1, result.Data[1].SortOrder);
    }

    [Fact]
    public async Task Content_ReturnsImageBytes()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-004");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var imageId = await UploadAndGetIdAsync(productId);

        var response = await Client.GetAsync($"/api/v1/products/{productId}/images/{imageId}/content");

        TestAssertions.AssertEqual(HttpStatusCode.OK, response.StatusCode);
        TestAssertions.AssertEqual("image/png", response.Content.Headers.ContentType!.MediaType);
        var bytes = await response.Content.ReadAsByteArrayAsync();
        TestAssertions.AssertEqual(4, bytes.Length);
    }

    [Fact]
    public async Task Reorder_ChangesPrimary()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-005");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var first = await UploadAndGetIdAsync(productId);
        var second = await UploadAndGetIdAsync(productId);

        var reorder = await PutAsJsonAsync(
            $"/api/v1/products/{productId}/images/reorder",
            new ProductImageReorderDto { OrderedImageIds = new List<Guid> { second, first } });

        TestAssertions.AssertEqual(HttpStatusCode.OK, reorder.StatusCode);

        var list = await ReadResponseAsync<Result<List<ProductImageDto>>>(
            await Client.GetAsync($"/api/v1/products/{productId}/images"));
        TestAssertions.AssertEqual(second, list.Data![0].Id);
        TestAssertions.AssertTrue(list.Data[0].IsPrimary);
    }

    [Fact]
    public async Task Delete_RemovesImageAndRenormalizesOrder()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-006");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var first = await UploadAndGetIdAsync(productId);
        await UploadAndGetIdAsync(productId);
        await UploadAndGetIdAsync(productId);

        var delete = await Client.DeleteAsync($"/api/v1/products/{productId}/images/{first}");
        TestAssertions.AssertEqual(HttpStatusCode.NoContent, delete.StatusCode);

        var list = await ReadResponseAsync<Result<List<ProductImageDto>>>(
            await Client.GetAsync($"/api/v1/products/{productId}/images"));
        TestAssertions.AssertEqual(2, list.Data!.Count);
        TestAssertions.AssertEqual(0, list.Data[0].SortOrder);
        TestAssertions.AssertEqual(1, list.Data[1].SortOrder);
    }

    [Fact]
    public async Task Upload_DisallowedContentType_ReturnsBadRequest()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-007");
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await UploadImageAsync(productId, contentType: "application/pdf", fileName: "doc.pdf");

        TestAssertions.AssertEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task ProductDelete_CascadesImages()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-008");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        await UploadAndGetIdAsync(productId);
        await UploadAndGetIdAsync(productId);

        var delete = await Client.DeleteAsync($"/api/v1/products/{productId}");
        TestAssertions.AssertEqual(HttpStatusCode.NoContent, delete.StatusCode);

        var remaining = await DbContext.ProductImage
            .IgnoreQueryFilters()
            .Where(i => i.ProductId == productId)
            .CountAsync();
        TestAssertions.AssertEqual(0, remaining);
    }

    [Fact]
    public async Task CrossTenant_List_ReturnsNotFound()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-009");
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await Client.GetAsync($"/api/v1/products/{productId}/images");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CrossTenant_Upload_ReturnsNotFound()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-010");
        SetTenantHeader(TenantConstants.TestTenant2Id);

        var response = await UploadImageAsync(productId);

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CrossTenant_Content_ReturnsNotFound()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-011");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var imageId = await UploadAndGetIdAsync(productId);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.GetAsync($"/api/v1/products/{productId}/images/{imageId}/content");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CrossTenant_Delete_ReturnsNotFound()
    {
        var productId = await SeedProductAsync(TenantConstants.TestTenant1Id, "IMG-012");
        SetTenantHeader(TenantConstants.TestTenant1Id);
        var imageId = await UploadAndGetIdAsync(productId);

        SetTenantHeader(TenantConstants.TestTenant2Id);
        var response = await Client.DeleteAsync($"/api/v1/products/{productId}/images/{imageId}");

        TestAssertions.AssertEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
