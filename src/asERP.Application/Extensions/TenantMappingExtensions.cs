using asERP.Domain.Dtos.Company;
using asERP.Domain.Entities;

namespace asERP.Application.Extensions;

/// <summary>
/// Manual mappings from the <see cref="Tenant"/> entity to presentation-facing shapes.
/// </summary>
public static class TenantMappingExtensions
{
    /// <summary>
    /// Projects a tenant's company/address/banking data into the sender block printed on
    /// generated documents. Replaces the former installation-wide <c>Company.*</c> settings.
    /// </summary>
    public static CompanySenderInfo ToCompanySenderInfo(this Tenant tenant)
    {
        ArgumentNullException.ThrowIfNull(tenant);

        return new CompanySenderInfo
        {
            // Fall back to the tenant name so the header is never blank.
            Name = FirstNonEmpty(tenant.CompanyName, tenant.Name),
            Street = tenant.Street ?? string.Empty,
            Street2 = tenant.Street2 ?? string.Empty,
            ZipCity = $"{tenant.PostalCode} {tenant.City}".Trim(),
            Country = tenant.Country ?? string.Empty,
            Phone = tenant.Phone ?? string.Empty,
            Email = tenant.ContactEmail ?? string.Empty,
            Website = tenant.Website ?? string.Empty,
            TaxId = tenant.TaxId ?? string.Empty,
            VatId = tenant.VatId ?? string.Empty,
            BankName = tenant.BankName ?? string.Empty,
            Iban = tenant.Iban ?? string.Empty,
            Bic = tenant.Bic ?? string.Empty,
            LogoPath = tenant.LogoPath ?? string.Empty,
        };
    }

    private static string FirstNonEmpty(params string?[] candidates) =>
        candidates.FirstOrDefault(c => !string.IsNullOrWhiteSpace(c)) ?? string.Empty;
}
