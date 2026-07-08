namespace asERP.Domain.Dtos.Company;

/// <summary>
/// The sender/company block printed on generated documents (invoice, packing slip, pick list).
/// Populated per tenant from the <c>Tenant</c> entity — there is no installation-wide company
/// default anymore. Values are pre-resolved strings so the PDF layer needs no data access.
/// </summary>
public class CompanySenderInfo
{
    public string Name { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Street2 { get; set; } = string.Empty;

    /// <summary>Combined "postal code + city" line (the Tenant stores them separately).</summary>
    public string ZipCity { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;

    public string TaxId { get; set; } = string.Empty;
    public string VatId { get; set; } = string.Empty;

    public string BankName { get; set; } = string.Empty;
    public string Iban { get; set; } = string.Empty;
    public string Bic { get; set; } = string.Empty;

    /// <summary>Filesystem path to the logo; empty falls back to the company name text.</summary>
    public string LogoPath { get; set; } = string.Empty;
}
