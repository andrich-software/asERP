using Asp.Versioning;
using asERP.Application.Features.ProductImage.Commands.ProductImageDelete;
using asERP.Application.Features.ProductImage.Commands.ProductImageReorder;
using asERP.Application.Features.ProductImage.Commands.ProductImageUpload;
using asERP.Application.Features.ProductImage.Queries.ProductImageContent;
using asERP.Application.Features.ProductImage.Queries.ProductImageList;
using asERP.Application.Mediator;
using asERP.Domain.Dtos.Product;
using asERP.Domain.Wrapper;
using asERP.Server.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

[ApiController]
[Authorize]
[ApiVersion(1.0)]
[Route("/api/v{version:apiVersion}/products/{productId:guid}/images")]
public class ProductImagesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Lists a product's images ordered by their position (first = primary).
    /// </summary>
    /// <response code="200">Returns the product's images</response>
    /// <response code="404">Product not found</response>
    [HttpGet]
    [ProducesResponseType(typeof(Result<List<ProductImageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<ActionResult<Result<List<ProductImageDto>>>> GetAll(Guid productId)
    {
        var response = await mediator.Send(new ProductImageListQuery { ProductId = productId });
        return response.ToActionResult();
    }

    /// <summary>
    /// Uploads an image for a product. The file is re-encoded to PNG and appended to the end
    /// of the order. Accepts JPG/JPEG, PNG, WebP, GIF and BMP.
    /// </summary>
    /// <response code="201">Image uploaded successfully</response>
    /// <response code="400">Invalid or unsupported file</response>
    /// <response code="404">Product not found</response>
    [HttpPost]
    [ProducesResponseType(typeof(Result<ProductImageDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<ActionResult<Result<ProductImageDto>>> Upload(Guid productId, IFormFile file)
    {
        var response = await mediator.Send(new ProductImageUploadCommand { ProductId = productId, File = file });
        return response.ToActionResult();
    }

    /// <summary>
    /// Streams an image's binary content. Pass <c>thumbnail=true</c> for the thumbnail.
    /// </summary>
    /// <response code="200">Returns the image bytes (image/png)</response>
    /// <response code="404">Image not found</response>
    [HttpGet("{imageId:guid}/content")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<IActionResult> GetContent(Guid productId, Guid imageId, bool thumbnail = false)
    {
        var response = await mediator.Send(new ProductImageContentQuery
        {
            ProductId = productId,
            ImageId = imageId,
            Thumbnail = thumbnail
        });

        if (!response.Succeeded || response.Data == null)
        {
            return response.ToActionResult();
        }

        // Content is immutable per GUID, but auth-protected — cache privately.
        Response.Headers.CacheControl = "private, max-age=31536000, immutable";
        return File(response.Data.Content, response.Data.ContentType, response.Data.FileName);
    }

    /// <summary>
    /// Reorders a product's images. The body must list exactly the product's image ids in the
    /// desired order; index 0 becomes the primary image.
    /// </summary>
    /// <response code="200">Images reordered successfully</response>
    /// <response code="400">The provided ids do not match the product's images</response>
    /// <response code="404">Product has no images</response>
    [HttpPut("reorder")]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status400BadRequest, "application/problem+json")]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<ActionResult<Result<Guid>>> Reorder(Guid productId, ProductImageReorderDto request)
    {
        var response = await mediator.Send(new ProductImageReorderCommand
        {
            ProductId = productId,
            OrderedImageIds = request.OrderedImageIds
        });
        return response.ToActionResult();
    }

    /// <summary>
    /// Deletes an image and re-normalizes the remaining order.
    /// </summary>
    /// <response code="204">Image deleted successfully</response>
    /// <response code="404">Image not found</response>
    [HttpDelete("{imageId:guid}")]
    [ProducesResponseType(typeof(Result<Guid>), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(Microsoft.AspNetCore.Mvc.ProblemDetails), StatusCodes.Status404NotFound, "application/problem+json")]
    public async Task<ActionResult<Result<Guid>>> Delete(Guid productId, Guid imageId)
    {
        var response = await mediator.Send(new ProductImageDeleteCommand { ProductId = productId, ImageId = imageId });
        return response.ToActionResult();
    }
}
