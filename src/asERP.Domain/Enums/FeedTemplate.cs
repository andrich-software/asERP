namespace asERP.Domain.Enums;

/// <summary>
/// Output format / target platform of a product <see cref="Entities.Feed"/>. Values are explicit and
/// stable because they are persisted and serialized as numbers (see <c>StrictEnumConverter</c>).
/// <c>Custom</c> (tenant-defined templates) is intentionally reserved for a later iteration.
/// </summary>
public enum FeedTemplate
{
    /// <summary>Google Merchant Center — RSS 2.0 XML with the <c>g:</c> namespace.</summary>
    GoogleProducts = 1,

    /// <summary>idealo — CSV (comma-separated, UTF-8).</summary>
    Idealo = 2,

    /// <summary>Pinterest catalog — reuses the Google RSS 2.0 XML structure (a subset of it).</summary>
    Pinterest = 3,
}
