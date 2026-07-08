# CLAUDE.md — asERP.Persistence.Tests

xUnit tests for the persistence layer (DbContext hooks, repositories, persistence-level services). Flat structure, no subfolders. `TreatWarningsAsErrors=true`.

Refer to the root `/CLAUDE.md` for cross-cutting test rules (no FluentAssertions, per-test factories, fix production code only when the test logic is right).

## Patterns

- **No shared base class or fixtures.** Each test class has its own static `Create...` helper building a fresh `DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())`.
- **`ITenantContext` is hand-rolled per file** — `TestTenantContext` (mutable), `FixedTenantContext`, `NullTenantContext`. Use fixed GUIDs like `11111111-...`/`22222222-...`.
- Seeding is manual (`AddRangeAsync` + `SaveChangesAsync`) with small local factory helpers (`NewWarehouse`, `NewSalesChannel`, ...).
- To verify persistence past the tracking cache: open a **second context** over the same named InMemory store and query with `AsNoTracking()`.
- Plain xUnit asserts (`Assert.Equal/True/Single/ThrowsAsync`); `[Theory]`/`[InlineData]` for mapping tables.

## Save-Hook Pitfalls (cost real debugging time)

- `SaveChangesAsync` **requires an active tenant context** for tenant-scoped entities — set a tenant id before saving or the save fails.
- The DbContext **overwrites `DateCreated` to `UtcNow` on Add**. To seed a specific `DateCreated`, save once, re-assign the timestamp, save again.
- `Customer.Email` is **canonicalized to lowercase on insert**.
- Reading soft-merged or cross-tenant rows requires `IgnoreQueryFilters()`.

## What Lives Here

| File | Covers |
|---|---|
| `ApplicationDbContextTests.cs` | Save hooks (`DateCreated`/`DateModified`) |
| `SalesChannelRepositoryTests.cs` | Repository behavior, warehouse-assignment regression |
| `CustomerDedupeServiceTests.cs` | Dedupe/merge, tenant isolation, query filters |
| `DatabaseBackupServiceTests.cs` | Per-provider backup strategies — uses **real SQLite files** (temp dir, `SqliteConnection.ClearAllPools()` + `IDisposable` cleanup for Windows file locks) |
| `PdfServiceTests.cs` | `asERP.Infrastructure.PDF.PdfService` invoice generation |

API-surface integration tests belong in `tests/asERP.Server.Tests` (see its `CLAUDE.md`), not here.
