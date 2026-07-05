using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class TenantEmailSettingsConfiguration : IEntityTypeConfiguration<TenantEmailSettings>
{
    public void Configure(EntityTypeBuilder<TenantEmailSettings> builder)
    {
        builder.HasIndex(s => s.TenantId);

        // Encrypted at rest — stored ciphertext is much longer than the plain credential, so widen
        // the columns beyond the [MaxLength(500)] domain annotation to hold the ciphertext.
        builder.Property(s => s.SmtpPassword).HasMaxLength(4096);
        builder.Property(s => s.M365ClientSecret).HasMaxLength(4096);

        builder
            .HasOne(s => s.Tenant)
            .WithMany()
            .HasForeignKey(s => s.TenantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
