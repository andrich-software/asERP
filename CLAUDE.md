# CLAUDE.md

Guidance for Claude Code working in this repository. Subdirectories contain their own `CLAUDE.md` with focused conventions — they are loaded automatically when working in those folders. Read this file first, then defer to the nested files for layer-specific rules.

## Project Overview

asERP is an open-source, multi-tenant ERP system. C#, .NET 10, Clean Architecture, cross-platform UI via Uno Platform.

### Solution layout

| Project | Purpose |
|---|---|
| `src/asERP.Domain` | Entities, DTOs, Enums, Wrappers, Validators. No infrastructure dependencies. |
| `src/asERP.Application` | CQRS handlers (Features/), custom Mediator, contracts, services |
| `src/asERP.Infrastructure` | Email, PDF, logging, cross-cutting services |
| `src/asERP.Persistence` | EF Core DbContext, repositories, configurations, seeders |
| `src/asERP.Persistence.{MSSQL,PostgreSQL,SQLite}` | Provider-specific migration assemblies |
| `src/asERP.Identity` | ASP.NET Identity, JWT auth, token services |
| `src/asERP.SalesChannels` | Channel integrations: PointOfSale, Shopware 6, WooCommerce (REST + direct DB), eBay, Amazon; sync orchestrator + export outbox |
| `src/asERP.Shipping` | Carrier integrations (DHL, DPD, GLS, UPS): labels, returns, tracking polls, outbox-backed retries |
| `src/asERP.Analytics` | ClickHouse-backed cookieless web analytics (ingest pipeline + dashboard queries) |
| `src/asERP.Server` | ASP.NET Core Web API (no frontend) |
| `src/asERP.Server.Tray` | Windows tray app (WinForms) managing the installed Server service: start/stop, health, backup, updates |
| `src/asERP.Client` | Uno Platform app (Desktop, WASM, Android, iOS) |
| `tests/asERP.Server.Tests` | xUnit, multi-tenant integration tests |
| `tests/asERP.Persistence.Tests` | xUnit, persistence layer |
| `tests/asERP.Client.Tests` | NUnit, pure client logic |
| `tests/asERP.Client.UITests` | NUnit + Playwright — WASM boot smoke tests against the served app |

### Architecture in one screen

- **CQRS** — `Features/{Area}/Commands/{Name}` and `Features/{Area}/Queries/{Name}`. Each has a request, handler, and (where applicable) validator.
- **Custom Mediator** — `asERP.Application.Mediator` namespace (not the MediatR NuGet package). Same `IRequest<TResponse>` / `IRequestHandler<TRequest, TResponse>` shape. Some doc comments still mention "MediatR" — they refer to the custom implementation.
- **Manual mapping** — no AutoMapper; mapping done explicitly in handlers/extensions.
- **Repositories** for data access; entities inherit `BaseEntity` (with `Guid? TenantId`) or `BaseEntityWithoutTenant`. All Ids are `System.Guid` (`BaseEntity.cs`).
- **Tenancy** — global EF Core query filters enforce tenant isolation; `ITenantContext` is the runtime source of truth.
- **REST + JWT** — versioned routes (`/api/v{version:apiVersion}/...`), Bearer auth, RFC 7807 problem details via `GlobalExceptionHandler` (an `IExceptionHandler`, not a filter).
- **Client** is API-only — no DB access, talks to Server via HTTP (Kiota + named `HttpClient`).

## Common Commands

```bash
# Build
dotnet build
dotnet build src/asERP.Server/asERP.Server.csproj
dotnet build src/asERP.Client/asERP.Client.csproj

# Run
dotnet run --project src/asERP.Server/asERP.Server.csproj
dotnet run --project src/asERP.Client/asERP.Client.csproj                       # WASM in browser
dotnet run --project src/asERP.Client/asERP.Client.csproj -f net10.0-desktop    # Desktop

# Tests
dotnet test
dotnet test tests/asERP.Server.Tests/asERP.Server.Tests.csproj
dotnet test tests/asERP.Server.Tests/asERP.Server.Tests.csproj --filter "FullyQualifiedName~CustomerCrudTest"

# Format
dotnet format
dotnet format --verify-no-changes

# Migrations — see src/asERP.Persistence/CLAUDE.md (named flags, not positional args)
./create-migrations.sh -n "MigrationName"                  # all providers
./create-migrations.sh -n "MigrationName" -d postgresql    # one provider
# Windows equivalent: ./create-migrations.ps1 -name "MigrationName" [-database postgresql]
```

## Project-wide Rules

### Code style
- All code, comments, identifiers, and commit messages in **English**.
- Comments only when the *why* is non-obvious. Don't restate what the code does.
- C# 10+ features welcome; nullable reference types are enabled solution-wide (`Directory.Build.props`).
- DI is used everywhere — register services in the appropriate layer's `*ServiceRegistration.cs`.

### Consistency before novelty
When adding a feature or layout, **find a similar one and mirror it**. Naming, folder layout, and patterns are repeated by design. Inconsistency is a regression.

### Multi-tenancy (critical)
- `TenantId` is `Guid?` on every tenant-scoped entity (`BaseEntity`).
- Tenant isolation is enforced via EF Core global query filters — never bypass them in queries unless explicitly cross-tenant (e.g. Superadmin operations).
- Cascade deletes must be implemented in handlers/repositories — do not rely on EF cascade defaults.
- Test cross-tenant access prevention for every new tenant-scoped feature (see `tests/asERP.Server.Tests/CLAUDE.md`).

### Roles
- **Superadmin** — only role permitted to use `SuperadminController` to manage users across tenants.
- **RoleManageUser** — within their own tenant, may add/delete users via `SuperadminController`.
- **RoleManageTenant** — may edit/delete their own tenants via `TenantsController`.
- Login is allowed without a tenant. Every user can create tenants and only sees their own.
- All users may view their own profile even without a `UserTenant`.
- `Superadmin`/`User` are the only ASP.NET Identity roles; `RoleManageUser`/`RoleManageTenant` are boolean flags on `UserTenant`, checked in handlers (not in JWT claims).
- `EnsureSuperadminAccessAsync()` (Server) only matters under the test harness — the real guard is `[Authorize(Roles = "Superadmin")]`.

### Validation & errors
- **FluentValidation** for request validation.
- Use **RFC 7807** problem details for error responses; rely on `GlobalExceptionHandler` (Server).
- Pagination is **zero-based** — see `QueryableExtensions.cs`.
- Enum serialization goes through `StrictEnumConverter` to fail fast on unknown values.

### Database
- Configure provider via `appsettings.json` or env vars; the provider-specific migration assembly is selected at runtime in `PersistenceServiceRegistration`.
- **Never create migrations without asking the user first.**

### Logging & observability
- Serilog for application logs.
- OpenTelemetry instrumentation is wired in the Server (`OpenTelemetry.Instrumentation.AspNetCore` / `Http`).

### Tests
- Tests use **per-test factories**, not shared fixtures.
- **Don't use FluentAssertions** — use plain xUnit/NUnit assertions or the `TestAssertions` helper.
- When a test fails, first check whether the test logic is correct. If it is, fix the production code.
- Multi-tenant integration tests inherit `TenantIsolatedTestBase` — see `tests/asERP.Server.Tests/CLAUDE.md`.

## Stack & Versions

- **.NET SDK**: 10.0 (`global.json` pins `latestFeature` of 10.0.0; prerelease allowed)
- **Uno SDK**: 6.5.x (`global.json`)
- **EF Core**: 10.0.x (relational + InMemory for tests)
- **FluentValidation**: 12.x
- **Serilog**: 10.x
- **Swashbuckle**: 10.x, **Asp.Versioning**: 10.x
- **Test runners**: xUnit 2.9 (Server, Persistence), NUnit 4.6 (Client)
- Central package management is on (`Directory.Packages.props`) — bump versions there, not in individual `.csproj` files.

## MCP Servers Available
- **jetbrains** — Rider/IDE operations (do not use for shell commands)
- **uno** — Uno Platform documentation
- **microsoft-docs** — Microsoft / .NET / EF Core docs
- **postgres** — direct DB queries

## Cross-cutting reminders
- Docker Compose files exist for MSSQL/PostgreSQL and mail testing — see `docker-compose.*.yml`.
- CI/CD via GitHub Actions (`.github/workflows`).
- Email-testing setup documented in `EMAIL-TESTING.md`.
