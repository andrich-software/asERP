using System.Net;
using System.Text.RegularExpressions;

namespace asERP.SalesChannels.Text;

/// <summary>
/// Converts the HTML product descriptions returned by sales channels (WooCommerce, Shopware, eBay)
/// into a compact, Markdown-like plain-text form for storage. Dependency-free: it handles the small
/// tag set these shops actually emit (p, br, ul/ol/li, h1-h6, strong/b, em/i, a) and strips everything
/// else (e.g. span/div with inline styles) while keeping the inner text. It is intentionally not a full
/// HTML parser — good enough for the simple, well-formed snippets product descriptions contain.
/// </summary>
public static partial class HtmlToMarkdownConverter
{
    public static string? Convert(string? html)
    {
        if (string.IsNullOrWhiteSpace(html))
        {
            return html;
        }

        var s = html;

        // Anchors: <a href="URL">TEXT</a> -> [TEXT](URL). Handled before the generic tag strip.
        s = AnchorRegex().Replace(s, "[$2]($1)");

        // Emphasis
        s = BoldRegex().Replace(s, "**");
        s = ItalicRegex().Replace(s, "*");

        // Headings: <h2> -> "\n## ", </h2> -> newline
        s = HeadingOpenRegex().Replace(s, m => "\n" + new string('#', int.Parse(m.Groups[1].Value)) + " ");
        s = HeadingCloseRegex().Replace(s, "\n");

        // Lists
        s = ListItemOpenRegex().Replace(s, "\n- ");
        s = ListItemCloseRegex().Replace(s, string.Empty);
        s = ListContainerRegex().Replace(s, "\n");

        // Line breaks and paragraphs
        s = BreakRegex().Replace(s, "\n");
        s = ParagraphOpenRegex().Replace(s, string.Empty);
        s = ParagraphCloseRegex().Replace(s, "\n\n");

        // Strip any remaining tags (span/div/etc.), keeping their inner text.
        s = AnyTagRegex().Replace(s, string.Empty);

        // Decode HTML entities (&amp;, &uuml;, &nbsp; ...) and normalise non-breaking spaces (U+00A0).
        s = WebUtility.HtmlDecode(s).Replace("\u00A0", " ");

        // Whitespace cleanup: normalise newlines, trim each line, collapse runs of spaces and blank lines.
        s = s.Replace("\r\n", "\n").Replace('\r', '\n');
        var lines = s.Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            lines[i] = InlineWhitespaceRegex().Replace(lines[i], " ").Trim();
        }
        s = string.Join("\n", lines);
        s = BlankLinesRegex().Replace(s, "\n\n");

        // Tight lists: drop blank lines between consecutive "- " bullets (a blank line before the
        // first bullet — i.e. after a paragraph/heading — is preceded by a non-bullet line and kept).
        s = TightListRegex().Replace(s, "$1\n");

        return s.Trim();
    }

    [GeneratedRegex(@"<a\b[^>]*?href\s*=\s*[""']([^""']*)[""'][^>]*>(.*?)</a>", RegexOptions.IgnoreCase | RegexOptions.Singleline)]
    private static partial Regex AnchorRegex();

    [GeneratedRegex(@"</?(?:strong|b)\s*>", RegexOptions.IgnoreCase)]
    private static partial Regex BoldRegex();

    [GeneratedRegex(@"</?(?:em|i)\s*>", RegexOptions.IgnoreCase)]
    private static partial Regex ItalicRegex();

    [GeneratedRegex(@"<h([1-6])\b[^>]*>", RegexOptions.IgnoreCase)]
    private static partial Regex HeadingOpenRegex();

    [GeneratedRegex(@"</h[1-6]>", RegexOptions.IgnoreCase)]
    private static partial Regex HeadingCloseRegex();

    [GeneratedRegex(@"<li\b[^>]*>", RegexOptions.IgnoreCase)]
    private static partial Regex ListItemOpenRegex();

    [GeneratedRegex(@"</li>", RegexOptions.IgnoreCase)]
    private static partial Regex ListItemCloseRegex();

    [GeneratedRegex(@"</?(?:ul|ol)\b[^>]*>", RegexOptions.IgnoreCase)]
    private static partial Regex ListContainerRegex();

    [GeneratedRegex(@"<br\s*/?>", RegexOptions.IgnoreCase)]
    private static partial Regex BreakRegex();

    [GeneratedRegex(@"<p\b[^>]*>", RegexOptions.IgnoreCase)]
    private static partial Regex ParagraphOpenRegex();

    [GeneratedRegex(@"</p>", RegexOptions.IgnoreCase)]
    private static partial Regex ParagraphCloseRegex();

    [GeneratedRegex(@"<[^>]+>")]
    private static partial Regex AnyTagRegex();

    [GeneratedRegex(@"[ \t]+")]
    private static partial Regex InlineWhitespaceRegex();

    [GeneratedRegex(@"\n{3,}")]
    private static partial Regex BlankLinesRegex();

    [GeneratedRegex(@"(\n- [^\n]*)\n{2,}(?=- )")]
    private static partial Regex TightListRegex();
}
