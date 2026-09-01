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
| `Extensions/` | `QueryableExtensions` (pagination/sorting), mapping extensions |
| `Specifications/` | Filter specs (`FilterSpecification<T>` base + per-entity specs) |
| `Notifications/` | `INotification` messages (`ProductChangedNotification`, ...) |
| `Models/` | Settings/POCOs (Identity, Email, Analytics, Storage, ...) |
| `Feeds/Rendering/` | Product-feed renderers (`IFeedRenderer` + Google/RSS/Pinterest/Idealo) |
| `Exceptions/` | `ValidationException`, `NotFoundException`, `SourceNullException` |

## Custom Mediator (not MediatR)

- Namespace `asERP.Application.Mediator`. Handler method is `Handle` (not `HandleAsync`). Doc comments mentioning "MediatR" mean this in-house implementation — do **not** add the MediatR package.
- **Handlers are auto-discovered by assembly scan** (`ApplicationServiceRegistration.RegisterHandlersFromAssembly`) — creating the class is enough, no manual registration. **But only within this assembly**: a handler in another project only runs if that project calls `RegisterHandlersFromAssembly` in its own registration (SalesChannels does).
- **Validation runs in the mediator, before the handler.** `CustomMediator.Send` resolves every
  `IValidator<TRequest>` from DI and runs it; on failure it throws
  `asERP.Application.Exceptions.ValidationException` and the handler is never invoked. Handlers must
  **not** validate inline — writing a `{Name}Validator.cs` is enough, `AddValidatorsFromAssembly`
  registers it. Opt out with `ISkipPipelineValidation` on the request only when the rules need
  runtime state the validator cannot see (three requests do — see below).
- No other pipeline behaviors: logging and transactions still happen inline in each handler.
- `Publish` runs notification handlers **sequentially** and rethrows (single or `AggregateException`). Best-effort handlers (e.g. email notifications) must swallow their own exceptions.

## Canonical Slice Pattern

One folder per request — copy `Features/Customer/Commands/CustomerCreate/` or `Features/Customer/Queries/CustomerList/`:

- `{Name}Command.cs` / `{Name}Query.cs` — often inherits the Domain `{X}InputDto` and adds `IRequest<Result<Guid>>`.
- `{Name}Handler.cs` — ctor-injects `IAppLogger<T>` + repos (with `?? throw new ArgumentNullException`). **No validation code**: the mediator has already validated the request by the time `Handle` runs.
- `{Name}Validator.cs` — FluentValidation, usually extends the Domain base validator and adds DB-aware rules. Constructor-inject the repos it needs; DI resolves it.

**Validators must stay purely about "is this request well-formed".** Anything else fights the
pipeline, which reports every failure as a 400 *before* the handler runs. Six requests carry
`ISkipPipelineValidation` today — don't add a seventh without the same kind of reason:

| Request | Why it opts out |
|---|---|
| `CustomerUpdateCommand`, `ProductUpdateCommand`, `SettingDeleteCommand` | validator carries a "… not found" rule the handler maps to **404**, which a uniform 400 cannot express (REFACTOR.md R5) |
| `AiModelDeleteCommand`, `DeleteSalesCommand` | their controllers discard the result and always answer **204**; a throwing validator would turn a deliberately idempotent DELETE into a 400 |
| `SetupInitializeCommand` | the anonymous setup endpoint must answer 403 for every payload once setup is done — validating first would let the email-uniqueness rule reveal which accounts exist |

Return types: mutations `Result<Guid>`/`Result<int>`, detail queries `Result<TDto>`, lists `PaginatedResult<TDto>` (all from `asERP.Domain.Wrapper`).

**Never name an HTTP status.** A handler reports *what* happened — `Result<T>.NotFound(ErrorCodes.Customer.NotFound, "Customer not found")`, `result.Fail(ErrorType.Validation, ErrorCodes.Product.Invalid, "…")`, `Result<T>.Created(id)` — and the Server maps that to a status code in one place. See `asERP.Domain/CLAUDE.md` for the full vocabulary.

Error handling: **don't wrap the handler body in a broad `try/catch`.** An unexpected exception is
meant to reach the Server's `GlobalExceptionHandler`, which already logs it in full and answers with
generic 500 problem details — no exception text ever reaches a client. Handlers return `Result` for
*expected* outcomes (not found, conflict, state rules) only.

Catch something only when you can do more with it than restate it as a 500:

- a specific exception that maps to a business status (`DbUpdateConcurrencyException` → 404/409),
- per-item continuation (CSV import collecting row errors),
- a best-effort side operation that must not fail the request (notification publish, e-mail),
- compensation before rethrowing (`catch { await CleanUpAsync(); throw; }`),
- an idempotent endpoint whose contract says "already gone is fine" — `AiModelDelete` /
  `SalesDelete` catch exactly `InvalidOperationException` and `UnauthorizedAccessException` from
  `DeleteAsync` for that reason.

Keep such a catch **narrow** (name the exception types) so a real infrastructure failure still
reaches the 500 path instead of being reported as success.

Where you do log, use `IAppLogger<T>` — never inject `ILogger<T>` directly.

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
