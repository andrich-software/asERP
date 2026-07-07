using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Exceptions;
using asERP.Application.Extensions;
using asERP.Application.Feeds.Rendering;
using asERP.Application.Mediator;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.Domain.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace asERP.Application.Features.Feed.Queries.FeedRender;

public class FeedRenderHandler : IRequestHandler<FeedRenderQuery, Result<FeedRenderResult>>
{
    private readonly IAppLogger<FeedRenderHandler> _logger;
    private readonly IFeedRepository _feedRepository;
    private readonly IProductRepository _productRepository;
    private readonly IFeedRendererResolver _rendererResolver;

    public FeedRenderHandler(
        IAppLogger<FeedRenderHandler> logger,
        IFeedRepository feedRepository,
        IProductRepository productRepository,
        IFeedRendererResolver rendererResolver)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _feedRepository = feedRepository ?? throw new ArgumentNullException(nameof(feedRepository));
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _rendererResolver = rendererResolver ?? throw new ArgumentNullException(nameof(rendererResolver));
    }

    public async Task<Result<FeedRenderResult>> Handle(FeedRenderQuery request, CancellationToken cancellationToken)
    {
        var result = new Result<FeedRenderResult>();

        try
        {
            // Tenant context has already been set by the caller from the resolved feed.
            var feed = await _feedRepository.GetDetails(request.FeedId);

            var feedProducts = _productRepository.GetContext<FeedProduct>();

            var products = await _productRepository.Entities
                .Where(p => !feedProducts.Any(fp => fp.FeedId == feed.Id && fp.ProductId == p.Id && !fp.IsActive))
                .Include(p => p.Images)
                .Include(p => p.ProductStocks)
                .Include(p => p.Manufacturer)
                .Include(p => p.ProductSalesChannels)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            var baseUrl = request.PublicBaseUrl.TrimEnd('/');
            var rows = products.Select(p => MapProduct(p, feed, baseUrl)).ToList();

            var context = new FeedRenderContext
            {
                FeedName = feed.Name,
                Currency = feed.Currency,
                PublicFeedUrl = $"{baseUrl}/feed/{feed.Id}",
                DefaultDeliveryTime = feed.DefaultDeliveryTime,
                DefaultShippingCost = feed.DefaultShippingCost,
                Products = rows
            };

            var renderer = _rendererResolver.Resolve(feed.Template);
            var bytes = await renderer.RenderAsync(context, cancellationToken);

            result.Data = new FeedRenderResult
            {
                Content = bytes,
                ContentType = renderer.ContentType,
                FileName = $"{BuildSlug(feed.Name, feed.Template)}.{renderer.FileNameSuffix}"
            };
            result.Succeeded = true;
            result.StatusCode = ResultStatusCode.Ok;
        }
        catch (NotFoundException)
        {
            result.Succeeded = false;
            result.StatusCode = ResultStatusCode.NotFound;
            result.Messages.Add($"Feed with ID {request.FeedId} not found");
        }
        catch (Exception ex)
        {
            result.FromException(_logger, ex,
                "An error occurred while rendering the feed.",
                "Error rendering feed {Id}.", request.FeedId);
        }

        return result;
    }

    private static FeedProductData MapProduct(Domain.Entities.Product p, Domain.Entities.Feed feed, string baseUrl)
    {
        var title = p.UseOptimized && !string.IsNullOrWhiteSpace(p.NameOptimized) ? p.NameOptimized! : p.Name;
        var description = p.UseOptimized && !string.IsNullOrWhiteSpace(p.DescriptionOptimized)
            ? p.DescriptionOptimized
            : p.Description;

        var inStock = p.ProductStocks.Sum(s => s.Stock) > 0;
        var brand = !string.IsNullOrWhiteSpace(p.Brand) ? p.Brand : p.Manufacturer?.Name;

        var images = p.Images
            .OrderBy(i => i.SortOrder)
            .Select(i => $"{baseUrl}/feed/{feed.Id}/image/{p.Id}/{i.Id}")
            .ToList();

        return new FeedProductData
        {
            Id = p.Id,
            Sku = p.Sku,
            Title = title,
            Description = description,
            Price = p.Price,
            Currency = feed.Currency,
            Availability = inStock ? "in_stock" : "out_of_stock",
            Brand = brand,
            Gtin = p.Gtin,
            Ean = p.Ean,
            Mpn = p.Mpn,
            Condition = "new",
            ItemGroupId = p.ParentProductId?.ToString(),
            Link = BuildProductLink(feed.SalesChannel, p),
            ImageUrls = images
        };
    }

    /// <summary>Builds a product deep-link from the linked channel's base URL + the product's channel id.</summary>
    private static string? BuildProductLink(Domain.Entities.SalesChannel? channel, Domain.Entities.Product p)
    {
        if (channel == null || string.IsNullOrWhiteSpace(channel.Url))
        {
            return null;
        }

        var remoteId = p.ProductSalesChannels?
            .FirstOrDefault(x => x.SalesChannelId == channel.Id)?
            .RemoteProductId;

        if (string.IsNullOrWhiteSpace(remoteId))
        {
            return null;
        }

        var baseUrl = channel.Url.TrimEnd('/');
        return channel.Type switch
        {
            SalesChannelType.Shopware6 => $"{baseUrl}/detail/{remoteId}",
            SalesChannelType.WooCommerce or SalesChannelType.WooCommerceDatabase => $"{baseUrl}/?p={remoteId}",
            _ => null
        };
    }

    private static string BuildSlug(string name, FeedTemplate template)
    {
        var basis = string.IsNullOrWhiteSpace(name) ? template.ToString() : name;
        var chars = basis.Trim().ToLowerInvariant().Select(c => char.IsLetterOrDigit(c) ? c : '-').ToArray();
        var slug = new string(chars).Trim('-');
        while (slug.Contains("--"))
        {
            slug = slug.Replace("--", "-");
        }

        return string.IsNullOrEmpty(slug) ? template.ToString().ToLowerInvariant() : slug;
    }
}
