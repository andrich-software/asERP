namespace asERP.Client.Features.Shippings.Services;

/// <summary>Maps label MIME types to file extensions (carrier labels are PDF; UPS returns GIF).</summary>
public static class LabelContentTypes
{
    public static string GetExtension(string? contentType) => contentType?.ToLowerInvariant() switch
    {
        "application/pdf" => ".pdf",
        "image/gif" => ".gif",
        "image/png" => ".png",
        _ => ".bin",
    };

    public static bool IsPdf(string? contentType) =>
        string.Equals(contentType, "application/pdf", StringComparison.OrdinalIgnoreCase);
}
