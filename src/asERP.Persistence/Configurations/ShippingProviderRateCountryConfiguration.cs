using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class ShippingProviderRateCountryConfiguration : IEntityTypeConfiguration<ShippingProviderRateCountry>
{
    public void Configure(EntityTypeBuilder<ShippingProviderRateCountry> builder)
    {
        builder.HasIndex(e => new { e.ShippingProviderRateId, e.CountryId })
            .IsUnique();

        builder.HasOne(e => e.Country)
            .WithMany()
            .HasForeignKey(e => e.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
