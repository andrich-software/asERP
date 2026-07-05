using asERP.Domain.Constants;
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

        // Seed data: Link default users to default tenant.
        // HasData values are compiled into migrations and must be deterministic — use fixed Id/dates
        // instead of Guid.NewGuid()/DateTime.UtcNow so the model does not report pending changes on
        // every build.
        builder.HasData(
            new UserTenant
            {
                Id = new Guid("77777777-7777-7777-7777-777777777701"),
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9", // admin@localhost.com
                TenantId = TenantConstants.DefaultTenantId,
                IsDefault = true,
                RoleManageUser = true, // Admin can manage users
                RoleManageTenant = true, // Admin can manage tenant
                DateCreated = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                DateModified = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
