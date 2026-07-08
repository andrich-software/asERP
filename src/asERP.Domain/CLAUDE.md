# CLAUDE.md — asERP.Domain

Dependency-free core: entities, DTOs, enums, result wrappers, base validators. **No ProjectReferences** — only `FluentValidation` and `Microsoft.Extensions.Identity.Stores` packages. Never add EF Core, Persistence, or Infrastructure dependencies here.

Refer to the root `/CLAUDE.md` for cross-cutting rules.

> **Build fails on any warning** — `TreatWarningsAsErrors=true` in this project. Nullable-annotate everything, no unused usings.

## Layout

| Folder | Purpose |
|---|---|
| `Entities/` | EF Core POCO entities; `Entities/Common/BaseEntity.cs` holds all base types |
| `Dtos/{Feature}/` | API DTOs, one subfolder per feature (~38 areas) |
| `Enums/` | Domain enums (explicit numeric values) |
| `Interfaces/` | `I{Feature}InputModel` abstractions shared by DTOs + validators |
| `Validators/` | FluentValidation **base** validators — field-level only, no DB access |
| `Wrapper/` | `Result<T>`, `PaginatedResult<T>`, `ProblemDetailsResult`, `ResultStatusCode` |
| `Constants/` | `TenantConstants` (shared tenant GUIDs) |
| `Services/` | Pure static helpers (no I/O), e.g. `TrackingTokenHasher` |

## Base Types (`Entities/Common/BaseEntity.cs`)

- `BaseEntity` — `Guid Id`, `DateCreated`, `DateModified` (UTC defaults), `Guid? TenantId`. For tenant-scoped entities (~42 of them).
- `BaseEntityWithoutTenant` — same minus `TenantId`. Used by exactly the global/tenant-defining entities: `Tenant`, `RefreshToken`, `Setting`, `TenantEmailSettings`, `TenantOAuthAppSettings`, `UserTenant`, `OAuthState`.
- Convention: entities declare the base class **and** re-implement the matching interface — `class Product : BaseEntity, IBaseEntity`. Follow it.
- `IConcurrencyStamped` — adds `Guid ConcurrencyToken`, app-managed (GUID instead of DB rowversion for MSSQL/PostgreSQL/SQLite parity). Used by the aggregates `Product`, `Sales`, `SalesChannel`, `SalesChannelSyncState`, `Feed`, `Shipping`. Token refresh happens in `ApplicationDbContext.SaveChangesAsync`; adding it to a new entity **requires** the matching `IsConcurrencyToken()` EF config in Persistence.
- `ApplicationUser` is the exception: extends `IdentityUser` (ASP.NET Identity), not `BaseEntity`.

## Entity Conventions

- Child → parent: `Guid {Parent}Id` FK **plus** nullable nav property (`Guid CustomerId` + `Customer? Customer`). Required single navs use `= null!`.
- Collections initialize inline — current idiom is `[]` (collection expression); older code uses `new List<T>()`.
- Strings default to `string.Empty`; optional strings are `string?`.
- **Never set `TenantId` manually** — the persistence/tenancy layer applies it via global query filters.
- Dual keys: `Customer.CustomerId` and `Sales.SalesId` are legacy human-facing `int` numbers; the `Guid Id` from `BaseEntity` is the real PK. Do not introduce `int` keys.
- Some plaintext-looking `string` columns are **encrypted at rest** by Persistence converters (`SalesChannel.Password/AccessToken/RefreshToken`, `Setting.Value` when `IsEncrypted`) — the entity property stays a plain `string`.

## DTO Conventions

- Suffixes: `{Feature}ListDto` (slim grid row), `{Feature}DetailDto` (full read model), `{Feature}InputDto` (create **and** update — carries `Id`; implements the matching `I{Feature}InputModel`). No separate Create/Update DTOs.
- DTOs are `class` with `{ get; set; }` — not records (a single legacy record exists in `Dtos/Shipping/`; don't copy it).
- **Mapping is manual and lives in `asERP.Application`** (`Features/{Area}/Shared/{X}Mapping.cs`, static `ToDto` methods) — never in this project, never AutoMapper.

## Wrappers (`Wrapper/`)

- `Result` / `Result<T>` — `Succeeded` + `ResultStatusCode` + `Messages`; static factories `Success(...)`, `Fail(...)` (+ `...Async` variants). Standard return envelope for handlers/services.
- `PaginatedResult<T> : Result` — **zero-based paging** (page 0 is the first page; `HasNextPage => CurrentPage < TotalPages - 1`). Factory: `Success(data, count, page, pageSize)`.
- `ResultStatusCode` maps 1:1 to HTTP status codes (`Ok=200` … `InternalServerError=500`).
- `ProblemDetailsResult` — RFC 7807 envelope with `BadRequest/NotFound/...` factories and fluent `WithExtension`/`WithInstance`.

## Enums

- Explicit numeric values for anything persisted or serialized; `0` is usually `Unknown`/`None`. Value **gaps are intentional** (reserved slots, e.g. `SalesStatus` skips 9; `SalesChannelType` groups by platform) — **never renumber existing members**, they're persisted and serialized as numbers.
- `[Flags]` bitmasks use `1 << n` (`SalesChannelCapabilities`).
- No `[JsonConverter]` attributes here. Strict API serialization is registered per-enum in `src/asERP.Server/Program.cs` via `StrictEnumConverter<T>` — a new enum that crosses the API and must fail fast on unknown values needs a registration there.

## Validators

- This project holds `{Feature}BaseValidator<T> where T : I{Feature}InputModel` — **field-level rules only, no DB/repository/external dependencies**.
- Client validators (`asERP.Client`) and server validators (`asERP.Application`, e.g. `ProductCreateValidator`) **inherit** from these. Changes here affect Client **and** Server simultaneously — review both sides.
- Anything needing DB access (uniqueness, existence) goes into the Application-layer validator, not here.

## Checklist: adding an entity

Touch these places (all outside this project):
1. EF configuration + `DbSet` in `asERP.Persistence` (query filter for `TenantId`, concurrency token, converters).
2. Migrations for **all three** provider projects (ask the user first — root rule).
3. Seeders in Persistence if seed data is needed.
4. Handlers + manual mapping + DB validators in `asERP.Application`.
5. `StrictEnumConverter` registration in Server for new strict enums.

## Legacy Naming (do not "fix")

The Order→Sales rename is incomplete and baked into persisted data and the API:
- `Customer.Saless`, `SalesChannel.ImportSaless`, `SalesChannelCapabilities.ImportSaless`/`UpdateSaless` (double-s plural)
- `Sales.DateSalesed` (was `DateOrdered`); `Sales` = order, `SalesItem` = order line, `SalesHistory` = status history
- `SalesDetailDto` keeps legacy single-shipment fields (`ShippingMethod/Status/Provider/TrackingId`) alongside the real `Shippings` list for old client bindings.

Renaming any of these is a breaking change across DB, API, and Client — don't do it casually.
