using System.Globalization;
using System.Text;
using asERP.Domain.Enums;
using CsvHelper;
using CsvHelper.Configuration;

namespace asERP.Application.Feeds.Rendering;

/// <summary>
/// idealo CSV feed: comma-separated, UTF-8, "." decimal separator, ";" list separator (image URLs).
/// One row per offer. Column names follow the idealo CSV importer specification.
/// </summary>
public class IdealoFeedRenderer : IFeedRenderer
{
    private static readonly string[] Header =
    {
        "sku", "title", "brand", "price", "url", "eans", "hans",
        "imageUrls", "categoryPath", "description", "delivery", "deliveryCosts_standard"
    };

    public FeedTemplate Template => FeedTemplate.Idealo;
    public string ContentType => "text/csv; charset=utf-8";
    public string FileNameSuffix => "csv";

    public async Task<byte[]> RenderAsync(FeedRenderContext context, CancellationToken cancellationToken = default)
    {
        using var memoryStream = new MemoryStream();
        using var writer = new StreamWriter(memoryStream, new UTF8Encoding(false)); // no BOM

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            // Escape spreadsheet formula triggers (= + - @) as text.
            InjectionOptions = InjectionOptions.Escape
        };

        using var csv = new CsvWriter(writer, config);

        foreach (var column in Header)
        {
            csv.WriteField(column);
        }
        await csv.NextRecordAsync();

        var deliveryCosts = context.DefaultShippingCost?.ToString("0.00", CultureInfo.InvariantCulture) ?? string.Empty;

        foreach (var p in context.Products)
        {
            csv.WriteField(p.Sku);
            csv.WriteField(p.Title);
            csv.WriteField(p.Brand ?? string.Empty);
            csv.WriteField(p.Price.ToString("0.00", CultureInfo.InvariantCulture));
            csv.WriteField(p.Link ?? string.Empty);
            csv.WriteField(!string.IsNullOrWhiteSpace(p.Ean) ? p.Ean : p.Gtin ?? string.Empty);
            csv.WriteField(p.Mpn ?? string.Empty);
            csv.WriteField(string.Join(";", p.ImageUrls));
            csv.WriteField(p.CategoryPath ?? string.Empty);
            csv.WriteField(p.Description ?? string.Empty);
            csv.WriteField(context.DefaultDeliveryTime ?? string.Empty);
            csv.WriteField(deliveryCosts);
            await csv.NextRecordAsync();
        }

        await writer.FlushAsync();
        return memoryStream.ToArray();
    }
}
