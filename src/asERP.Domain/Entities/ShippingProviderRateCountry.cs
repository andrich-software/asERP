using asERP.Domain.Entities.Common;

namespace asERP.Domain.Entities;

/// <summary>
/// Join row: a destination country a <see cref="ShippingProviderRate"/> may ship to.
/// Explicit entity (instead of a skip navigation) so the row carries a TenantId and the
/// global tenant filter applies — Country rows themselves are tenant-agnostic seed data.
/// </summary>
public class ShippingProviderRateCountry : BaseEntity, IBaseEntity
{
    public Guid ShippingProviderRateId { get; set; }

    // Not auto-initialized — see the phantom-entity note on ProductSalesChannel.
    public ShippingProviderRate ShippingProviderRate { get; set; } = null!;

    public Guid CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
