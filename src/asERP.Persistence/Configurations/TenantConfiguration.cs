using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);

        // TenantCode configuration removed

        builder.Property(q => q.Description)
            .HasMaxLength(500);

        builder.Property(q => q.ContactEmail)
            .HasMaxLength(200);

        // Configure relationship with ApplicationUser through UserTenants
        builder.HasMany(t => t.UserTenants)
            .WithOne(ut => ut.Tenant)
            .HasForeignKey(ut => ut.TenantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}