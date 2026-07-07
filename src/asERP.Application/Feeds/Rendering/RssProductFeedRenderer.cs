using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using asERP.Domain.Enums;

namespace asERP.Application.Feeds.Rendering;

/// <summary>
/// Shared RSS 2.0 renderer for the Google Merchant / Pinterest family (both use the
/// <c>xmlns:g="http://base.google.com/ns/1.0"</c> namespace; Pinterest consumes a subset of the same
/// structure). Concrete renderers only supply their <see cref="FeedTemplate"/>.
/// </summary>
public abstract class RssProductFeedRenderer : IFeedRenderer
{
    private static readonly XNamespace G = "http://base.google.com/ns/1.0";

    public abstract FeedTemplate Template { get; }
    public string ContentType => "application/xml; charset=utf-8";
    public string FileNameSuffix => "xml";

    public Task<byte[]> RenderAsync(FeedRenderContext context, CancellationToken cancellationToken = default)
    {
        var channel = new XElement("channel",
            new XElement("title", context.FeedName),
            new XElement("link", context.PublicFeedUrl),
            new XElement("description", $"{context.FeedName} product feed"));

        foreach (var product in context.Products)
        {
            channel.Add(BuildItem(product));
        }

        var rss = new XElement("rss",
            new XAttribute("version", "2.0"),
            new XAttribute(XNamespace.Xmlns + "g", G.NamespaceName),
            channel);

        var document = new XDocument(new XDeclaration("1.0", "utf-8", null), rss);

        using var memoryStream = new MemoryStream();
        var settings = new XmlWriterSettings
        {
            Encoding = new UTF8Encoding(false), // no BOM
            Indent = true
        };
        using (var writer = XmlWriter.Create(memoryStream, settings))
        {
            document.Save(writer);
        }

        return Task.FromResult(memoryStream.ToArray());
    }

    private static XElement BuildItem(FeedProductData p)
    {
        var item = new XElement("item",
            new XElement(G + "id", p.Sku),
            new XElement(G + "title", Trim(p.Title, 150)),
            new XElement(G + "description", p.Description ?? string.Empty),
            new XElement(G + "availability", p.Availability),
            new XElement(G + "price", FormatPrice(p.Price, p.Currency)),
            new XElement(G + "condition", p.Condition));

        if (!string.IsNullOrWhiteSpace(p.Link))
        {
            item.Add(new XElement(G + "link", p.Link));
        }

        if (p.ImageUrls.Count > 0)
        {
            item.Add(new XElement(G + "image_link", p.ImageUrls[0]));
            foreach (var extra in p.ImageUrls.Skip(1).Take(10))
            {
                item.Add(new XElement(G + "additional_image_link", extra));
            }
        }

        if (!string.IsNullOrWhiteSpace(p.Brand))
        {
            item.Add(new XElement(G + "brand", p.Brand));
        }

        var gtin = !string.IsNullOrWhiteSpace(p.Gtin) ? p.Gtin : p.Ean;
        if (!string.IsNullOrWhiteSpace(gtin))
        {
            item.Add(new XElement(G + "gtin", gtin));
        }

        if (!string.IsNullOrWhiteSpace(p.Mpn))
        {
            item.Add(new XElement(G + "mpn", p.Mpn));
        }

        // No GTIN and no MPN → tell Google identifiers genuinely don't exist (avoids disapproval).
        if (string.IsNullOrWhiteSpace(gtin) && string.IsNullOrWhiteSpace(p.Mpn))
        {
            item.Add(new XElement(G + "identifier_exists", "no"));
        }

        if (!string.IsNullOrWhiteSpace(p.ItemGroupId))
        {
            item.Add(new XElement(G + "item_group_id", p.ItemGroupId));
        }

        if (!string.IsNullOrWhiteSpace(p.CategoryPath))
        {
            item.Add(new XElement(G + "product_type", p.CategoryPath));
        }

        return item;
    }

    private static string FormatPrice(decimal price, string currency) =>
        $"{price.ToString("0.00", CultureInfo.InvariantCulture)} {currency}";

    private static string Trim(string value, int maxLength) =>
        string.IsNullOrEmpty(value) || value.Length <= maxLength ? value : value[..maxLength];
}
