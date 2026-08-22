using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace asERP.SalesChannels.Text;

/// <summary>
/// Decodes HTML entities in short plain-text fields delivered by sales channels (product names,
/// attribute names/options, order item names). WooCommerce/WordPress returns these entity-encoded
/// ("Schnittmuster &amp;amp; Nähanleitung"); other channels deliver plain text, for which decoding
/// is a no-op. HTML *markup* fields (descriptions) go through <see cref="HtmlToMarkdownConverter"/>
/// instead, which decodes on its own.
/// </summary>
public static class ChannelText
{
    [return: NotNullIfNotNull(nameof(value))]
    public static string? DecodeEntities(string? value)
        => string.IsNullOrEmpty(value) || !value.Contains('&') ? value : WebUtility.HtmlDecode(value);
}
