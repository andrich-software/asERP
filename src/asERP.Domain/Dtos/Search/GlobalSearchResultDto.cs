using asERP.Domain.Enums;

namespace asERP.Domain.Dtos.Search;

/// <summary>
/// Unified result of a global quick search, grouped by entity type so heterogeneous
/// hits can be rendered as separate sections without nullable-field soup.
/// </summary>
public class GlobalSearchResultDto
{
    public List<GlobalSearchHitDto> Customers { get; set; } = new();
    public List<GlobalSearchHitDto> Sales { get; set; } = new();
    public List<GlobalSearchHitDto> Invoices { get; set; } = new();
    public List<GlobalSearchHitDto> Products { get; set; } = new();
    public List<GlobalSearchHitDto> Shippings { get; set; } = new();

    /// <summary>Total number of hits across all types.</summary>
    public int TotalCount { get; set; }
}

/// <summary>
/// A single search hit. <see cref="Id"/> drives navigation to the entity's detail page.
/// </summary>
public class GlobalSearchHitDto
{
    public Guid Id { get; set; }
    public SearchEntityType Type { get; set; }

    /// <summary>Primary display line (e.g. customer name, product name).</summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>Secondary display line (e.g. "Kunde #1042", SKU, invoice date).</summary>
    public string Subtitle { get; set; } = string.Empty;
}
