namespace asERP.Domain.Constants;

public static class TenantConstants
{
    // Standard tenant GUIDs for test and initial data
    // These correspond to the original tenant IDs: 1, 2, and 3
    public static readonly Guid TestTenant1Id = new("11111111-1111-1111-1111-111111111111");
    public static readonly Guid TestTenant2Id = new("22222222-2222-2222-2222-222222222222");
    public static readonly Guid TestTenant3Id = new("33333333-3333-3333-3333-333333333333");

    // Default production tenant GUID (corresponds to original ID: 1).
    // Declared as its own literal so it is not semantically coupled to the test-tenant
    // constant; the value is kept stable to match the seeded tenant row.
    public static readonly Guid DefaultTenantId = new("11111111-1111-1111-1111-111111111111");
}
