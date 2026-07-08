# CLAUDE.md — asERP.Application

CQRS/application layer: custom Mediator, vertical feature slices, repository contracts, application services. Depends only on `asERP.Domain`; consumed by `asERP.Server` (and siblings via contracts).

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true` — new code must be warning-clean.

## Layout

| Folder | Purpose |
|---|---|
| `Mediator/` | Custom mediator (`IMediator`, `IRequest<T>`, `IRequestHandler<,>`, `INotification`, `CustomMediator`) |
| `Features/{Area}/` | Vertical slices: `Commands/{Name}/`, `Queries/{Name}/`, optional `Shared/`, `Services/`, `NotificationHandlers/` |
| `Contracts/Persistence/` | `IGenericRepository<T>` + ~25 entity-specific repo interfaces |
| `Contracts/Infrastructure/`, `Contracts/Services/`, `Contracts/Identity/`, `Contracts/Logging/` | Interfaces implemented by Infrastructure/Identity/Persistence/Analytics/Shipping |
| `Extensions/` | `QueryableExtensions` (pagination/sorting), `ResultExtensions`, mapping extensions |
| `Specifications/` | Filter specs (`FilterSpecification<T>` base + per-entity specs) |
| `Notifications/` | `INotification` messages (`ProductChangedNotification`, ...) |
| `Models/` | Settings/POCOs (Identity, Email, Analytics, Storage, ...) |
| `Feeds/Rendering/` | Product-feed renderers (`IFeedRenderer` + Google/RSS/Pinterest/Idealo) |
| `Exceptions/` | `ValidationException`, `NotFoundException`, `SourceNullException` |

## Custom Mediator (not MediatR)

- Namespace `asERP.Application.Mediator`. Handler method is `Handle` (not `HandleAsync`). Doc comments mentioning "MediatR" mean this in-house implementation — do **not** add the MediatR package.
- **Handlers are auto-discovered by assembly scan** (`ApplicationServiceRegistration.RegisterHandlersFromAssembly`) — creating the class is enough, no manual registration. **But only within this assembly**: a handler in another project only runs if that project calls `RegisterHandlersFromAssembly` in its own registration (SalesChannels does).
- **No pipeline behaviors.** Validation, logging, and transactions happen inline in each handler.
- `Publish` runs notification handlers **sequentially** and rethrows (single or `AggregateException`). Best-effort handlers (e.g. email notifications) must swallow their own exceptions.

## Canonical Slice Pattern

One folder per request — copy `Features/Customer/Commands/CustomerCreate/` or `Features/Customer/Queries/CustomerList/`:

- `{Name}Command.cs` / `{Name}Query.cs` — often inherits the Domain `{X}InputDto` and adds `IRequest<Result<Guid>>`.
- `{Name}Handler.cs` — ctor-injects `IAppLogger<T>` + repos (with `?? throw new ArgumentNullException`). **Validators are `new`ed inside the handler** (`new CustomerCreateValidator(_repo)`), not resolved from DI — mirror that. Validation failure → `Result<T>.Fail(ResultStatusCode.BadRequest, messages)`, no exception.
- `{Name}Validator.cs` — FluentValidation, usually extends the Domain base validator and adds DB-aware rules.

Return types: mutations `Result<Guid>`/`Result<int>`, detail queries `Result<TDto>`, lists `PaginatedResult<TDto>` (all from `asERP.Domain.Wrapper`).

Error handling: catch broadly, log full detail via `IAppLogger<T>` (never inject `ILogger<T>` directly), return generic `InternalServerError` — **never leak exception text to clients** (`ResultExtensions.FromException`).

## Repositories & the Update-Graph Pitfall (critical)

`IGenericRepository<T>` (`Contracts/Persistence/IGenericRepository.cs`): `Entities` (no-tracking, tenant-filtered `IQueryable`), `CreateAsync`, `GetByIdAsync`, `UpdateAsync`, `DeleteAsync`, `IsUniqueAsync`, `BeginTransactionAsync`, `SaveChangesAsync`. No separate unit-of-work — the DbContext is the UoW.

**`UpdateAsync` copies scalar properties only** (`CurrentValues.SetValues`) — it never inserts/updates/deletes child rows and it pins `TenantId`. Therefore:

- **New child entities must be added explicitly**: set `Id = Guid.NewGuid()` and the parent's `TenantId`, then add via a dedicated repo method or DbSet (see `CustomerUpdateHandler.AddCustomerAddressAsync`, `ProductUpdateHandler.AddVariantAxis/Option`, `ReturnReceiveHandler`).
- Removed children must be deleted explicitly.
- `UpdateAsync`/`DeleteAsync` enforce tenant ownership internally (`IgnoreQueryFilters` + comparison) and throw `UnauthorizedAccessException` on cross-tenant writes.

## Cascade Deletes

Not configured in EF — delete children explicitly before the parent (also required for InMemory test compatibility). Reference: `Features/Customer/Commands/CustomerDelete/CustomerDeleteHandler.cs`. Multi-write handlers wrap the work in `BeginTransactionAsync`/`Commit` (see `GoodsReceiptCreateHandler`).

## Pagination & Sorting (`Extensions/QueryableExtensions.cs`)

- `ToPaginatedListAsync(page, size, ct)` — **zero-based** (`Skip(page * size)`), clamps negative page to 0, size ≤ 0 → 10, max **200**.
- `ApplySafeOrdering(query, sortBy, allowedFields)` — dynamic ordering restricted to an explicit **allow-list** (`static readonly HashSet<string> AllowedSortFields` in the handler); unknown fields are silently dropped (security by design). **Never pass raw client sort strings to `OrderBy`.**
- `Specify(spec)` applies Includes + Criteria from a `Specifications/` class.
- Naming trap: list queries name their sort parameter `SalesBy` — a rename artifact of `SortBy`. It sorts, it does not filter by sales.

## Tenancy

- `ITenantContext` (`Contracts/Services/`) is the runtime source of truth. Rely on the EF global query filters — **do not re-filter on `TenantId`** in normal handlers.
- `IgnoreQueryFilters()` appears in exactly the dedicated cross-tenant handlers (Tenant list/detail, Superadmin queries) — keep it that way.
- On create / child-add, set `TenantId` explicitly from `ITenantContext.GetCurrentTenantId()` or the parent.

## Mapping

Manual, no AutoMapper. Inline object initializers / `.Select(x => new Dto {...})` projections; reused mappings as `To{Target}` extension methods in `Extensions/` or `Features/{Area}/Shared/{X}Mapping.cs`.

## DI (`ApplicationServiceRegistration.cs`)

`AddApplicationServices()`: registers `CustomMediator`, a handful of scoped app services (shipping status/document services, `UserTenantService`), `AddValidatorsFromAssembly`, then handler scanning. Most feature services are registered in Infrastructure/Persistence/Identity, not here.

## Misc

- Some handlers return German user-facing messages, others English — match the surrounding feature's language; identifiers/comments stay English.
- `Exceptions/NotFoundException` etc. exist but are used sparingly — prefer `Result` + `ResultStatusCode`.
