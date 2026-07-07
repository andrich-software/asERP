using asERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace asERP.Persistence.Configurations;

public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
{
    public void Configure(EntityTypeBuilder<UserTenant> builder)
    {
        builder.HasKey(ut => new { ut.UserId, ut.TenantId });

        // The composite PK is the identity of the row, but the repository's IGenericRepository
        // contract also exposes a single-Guid GetByIdAsync/ExistsAsync keyed on the surrogate Id.
        // A unique index makes those by-Id lookups well-defined and fast.
        builder.HasIndex(ut => ut.Id).IsUnique();

        builder.HasOne(ut => ut.User)
            .WithMany(u => u.UserTenants)
            .HasForeignKey(ut => ut.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ut => ut.Tenant)
            .WithMany(t => t.UserTenants)
            .HasForeignKey(ut => ut.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(ut => ut.IsDefault).HasDefaultValue(false);
        builder.Property(ut => ut.RoleManageUser).HasDefaultValue(false);
        builder.Property(ut => ut.RoleManageTenant).HasDefaultValue(false);
    }
}
