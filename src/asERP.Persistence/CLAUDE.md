# CLAUDE.md — asERP.Persistence

EF Core data access layer. Provider-neutral; the three concrete providers live in sibling projects:

- `asERP.Persistence.MSSQL`
- `asERP.Persistence.PostgreSQL`
- `asERP.Persistence.SQLite`

Refer to the root `/CLAUDE.md` for cross-cutting rules.

## Layout

```
DatabaseContext/   ApplicationDbContext (extends IdentityDbContext<ApplicationUser>) — query filters,
                   save hooks, concurrency-token refresh; ApplicationDbContextFactory (design-time)
Repositories/      Generic + entity-specific repository implementations
Configurations/    IEntityTypeConfiguration<T> implementations (Fluent API)
  Options/         DatabaseOptions, etc.
Interceptors/      ChannelExportNotificationInterceptor (SaveChanges interceptor)
ValueConverters/   EncryptedStringConverter etc. (encryption at rest)
Seeders/           Initial data
Services/          Repository-level services (incl. Services/Backup/DatabaseBackupService)
PersistenceServiceRegistration.cs   Provider switch + DI wiring (also registers ASP.NET Identity stores)
```

## Multi-Tenancy via Query Filters

- All tenant-scoped entities derive from `BaseEntity` (`Guid? TenantId`). Apply a global query filter in the `DbContext` for each — read `TenantId` from the injected `ITenantContext`.
- Cross-tenant operations (Superadmin) must explicitly call `IgnoreQueryFilters()` — and only inside the dedicated handlers.
- Never re-filter on `TenantId` in handlers; the filter is the contract.
- `SaveChangesAsync` **requires an active tenant context** for tenant-scoped entities and enforces ownership; `GenericRepository.UpdateAsync/DeleteAsync` additionally verify tenant ownership (`IgnoreQueryFilters` lookup) and pin `TenantId` against overwrites.

## Entities, Ids & Save Hooks

- `BaseEntity` defines `Guid Id`, `DateTime DateCreated`, `DateTime DateModified`, `Guid? TenantId`; `BaseEntityWithoutTenant` for non-scoped data. All Ids are `System.Guid` — no `int` keys.
- Save hooks in `ApplicationDbContext`: `DateCreated` is **overwritten to UtcNow on Add**, `DateModified` on update; `Customer.Email` is lowercased on insert; `IConcurrencyStamped` entities get a fresh `ConcurrencyToken` (app-managed GUID — provider-portable, not a DB rowversion).
- **`GenericRepository.UpdateAsync` copies scalar values only** (`CurrentValues.SetValues`) — new/removed child entities must be added/deleted explicitly with `Id = Guid.NewGuid()` + the parent's `TenantId`. See `src/asERP.Application/CLAUDE.md` for the full pitfall.
- Sensitive columns are encrypted at rest via `ValueConverters/` (`SalesChannel.Password/AccessToken/RefreshToken`, `Setting.Value` when `IsEncrypted`).

## ChannelExportNotificationInterceptor

Registered in `PersistenceServiceRegistration` via `options.AddInterceptors(...)`. Safety net for the sales-channel export outbox: collects Product/ProductSalesChannel/ProductStock/Sales/Customer changes in `SavingChangesAsync`, publishes notifications in `SavedChangesAsync` — i.e. **after** the commit, outside the EF critical section, per-notification try/catch (a handler failure never breaks the save), pending set cleared on failed saves. `IMediator` is resolved lazily so migrations/bootstrap are safe. Details in `src/asERP.SalesChannels/CLAUDE.md`.

Related: `SalesChannelSyncState` (1:1 with `SalesChannel`, deliberately token-free) holds volatile sync cursors/flags so parallel sync operations don't collide on the channel's concurrency token — never move those fields back onto `SalesChannel`.

## Cascade Deletes

Cascade deletion is **not** configured by EF defaults across the schema. Implement deletes explicitly in the handler or repository — fetch dependents, remove them, save. This is intentional to keep tenancy and audit behavior predictable.

## Migrations

Multi-provider — each provider project owns its own migration assembly (no authored code there, only `Migrations/`). Keep the three providers in lockstep: same migration names, same logical content.

```bash
# All three providers (named flags — positional args are rejected)
./create-migrations.sh -n "MigrationName"

# One provider
./create-migrations.sh -n "MigrationName" -d mssql
./create-migrations.sh -n "MigrationName" -d postgresql
./create-migrations.sh -n "MigrationName" -d sqlite

# Windows
./create-migrations.ps1 -name "MigrationName" [-database postgresql]
```

**Never create migrations without asking the user first** — schema changes are deliberate and reviewed.

Practical notes:

- The scripts read connection strings from `src/asERP.Server/appsettings.Development.json` and **fail locally if that file is missing**. Escape hatch: `DatabaseContext/ApplicationDbContextFactory.cs` is an `IDesignTimeDbContextFactory` reading env vars `DatabaseConfig__Provider` (`MSSQL`/`POSTGRESQL`/`SQLITE`, default SQLITE) and `DatabaseConfig__ConnectionStrings__{MSSQL,POSTGRESQL,SQLITE}` — with it, `dotnet ef` runs with the provider project as both `--project` and `--startup-project` (no Server build needed).
- Regenerated migrations/snapshots contain thousands of `UpdateData("country", ... DateCreated/DateModified ...)` lines — **expected seed-timestamp churn**, not a schema change; the meaningful delta is at the top. Don't hand-edit it away.
- SQLite rebuilds the table on column drops — data-preserving `INSERT ... SELECT` must run *before* `DropColumn` (see the `AddSalesChannelSyncState` migration).
- `PendingModelChangesWarning` is suppressed (runtime and design-time) because of the reference-data seed — don't "fix" that suppression.

## Pagination

Zero-based pagination, implemented in `src/asERP.Application/Extensions/QueryableExtensions.cs` (not in this layer). New endpoints **must** use it; do not roll your own.

## Provider Selection

`PersistenceServiceRegistration.cs` reads `DatabaseOptions.Provider` and registers the matching EF Core provider with the matching migrations assembly (three cases + throw). Add a new provider only by adding a new sibling project — do not branch inside the main persistence project. This file also registers ASP.NET Identity (`AddIdentity<ApplicationUser, IdentityRole>` + EF stores) — see `src/asERP.Identity/CLAUDE.md`.

## Tests

Persistence-level tests live in `tests/asERP.Persistence.Tests` (xUnit, EF Core InMemory) — see its `CLAUDE.md` for the save-hook and tenant-context pitfalls. Integration tests that hit the API surface live in `tests/asERP.Server.Tests` — see its `CLAUDE.md`.
