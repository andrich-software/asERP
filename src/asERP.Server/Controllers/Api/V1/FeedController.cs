using Asp.Versioning;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Features.Feed.Commands.FeedLogCreate;
using asERP.Application.Features.Feed.Queries.FeedRender;
using asERP.Application.Features.ProductImage.Queries.ProductImageContent;
using asERP.Application.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Controllers.Api.V1;

/// <summary>
/// Public, anonymous feed delivery at <c>/feed/{id}</c>. The random feed GUID in the URL is the only access
/// guard; the tenant is resolved server-side from the feed row. No authentication is possible or required.
/// Mirrors the anonymous, tenant-from-row pattern of the storefront/OAuth-callback endpoints.
/// </summary>
[ApiController]
[AllowAnonymous]
[ApiVersionNeutral]
[Route("/feed")]
public class FeedController(
    IMediator mediator,
    IFeedRepository feedRepository,
    ITenantContext tenantContext) : ControllerBase
{
    // GET: /feed/{id}
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFeed(Guid id, CancellationToken cancellationToken)
    {
        var feed = await feedRepository.GetPublicByIdAsync(id, cancellationToken);
        if (feed is null || !feed.IsEnabled)
        {
            return NotFound();
        }

        // Anonymous request carries no tenant context — resolve it from the feed row so the product
        // query filter (and the FeedLog write below) run against the correct tenant.
        tenantContext.SetCurrentTenantId(feed.TenantId);

        var baseUrl = $"{Request.Scheme}://{Request.Host}";
        var render = await mediator.Send(new FeedRenderQuery(feed.Id, baseUrl));
        if (!render.Succeeded || render.Data is null)
        {
            return NotFound();
        }

        // Best-effort access log — tenant context is set, so SaveChangesAsync stamps the tenant.
        await mediator.Send(new FeedLogCreateCommand
        {
            FeedId = feed.Id,
            IpAddress = ResolveVisitorIp(),
            UserAgent = Request.Headers.UserAgent.FirstOrDefault()
        });

        return File(render.Data.Content, render.Data.ContentType);
    }

    // GET: /feed/{feedId}/image/{productId}/{imageId}
    // Publicly serves product images referenced by the feed, scoped to the feed's (unguessable) GUID.
    [HttpGet("{feedId:guid}/image/{productId:guid}/{imageId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetImage(Guid feedId, Guid productId, Guid imageId, CancellationToken cancellationToken)
    {
        var feed = await feedRepository.GetPublicByIdAsync(feedId, cancellationToken);
        if (feed is null || !feed.IsEnabled)
        {
            return NotFound();
        }

        tenantContext.SetCurrentTenantId(feed.TenantId);

        var response = await mediator.Send(new ProductImageContentQuery { ProductId = productId, ImageId = imageId });
        if (!response.Succeeded || response.Data is null)
        {
            return NotFound();
        }

        Response.Headers.CacheControl = "public, max-age=3600";
        return File(response.Data.Content, response.Data.ContentType);
    }

    private string? ResolveVisitorIp()
    {
        var forwarded = Request.Headers["X-Forwarded-For"].FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(forwarded))
        {
            return forwarded.Split(',')[0].Trim();
        }

        return HttpContext.Connection.RemoteIpAddress?.ToString();
    }
}
