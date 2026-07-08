# CLAUDE.md — asERP.SalesChannels

Sales-channel integration layer: connectors (PointOfSale, Shopware 6, WooCommerce REST, WooCommerce Database, eBay, Amazon), the sync orchestrator, the export outbox, and import repositories. Registered via `SalesChannelServiceRegistration.AddSalesChannelServices(includeBackgroundServices)`.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true`.

## Layout

| Folder | Contents |
|---|---|
| `Abstractions/` | `ISalesChannelConnector`, `SalesChannelConnectorRegistry`, `SalesChannelContext`, result/payload records |
| `Connectors/{Common,Pos,Shopware6,WooCommerce,WooCommerceDatabase,Ebay,Amazon}/` | One connector per `SalesChannelType`; `Common/ConnectorBase.cs` gives NotSupported defaults |
| `Contracts/` + `Repositories/` | Import repositories (`IProductImportRepository`, ...) + `ImportIdAllocator` (per-tenant human sequence numbers) |
| `Orchestration/` | `SalesChannelOrchestrator` (hosted service), `SyncDispatcher`, `OutboxDrainer`, `ChannelExportOutboxEnqueuer`, `SalesChannelContextFactory`, Polly extensions |
| `Models/{Channel}/` | Per-channel config records (typed slices of `SalesChannel.AdditionalConfigJson`) + auth helpers |
| `Logging/` | `SalesChannelSyncLogBuffer` (singleton ring buffer, drained to DB per tick) |
| `NotificationHandlers/` | Fan domain-change notifications into the export outbox |

Related but elsewhere: entities/enums in `asERP.Domain` (`SalesChannel`, `SalesChannelSyncState`, `ChannelSyncRun`, `ChannelExportOutbox`), the SaveChanges interceptor in `asERP.Persistence/Interceptors/ChannelExportNotificationInterceptor.cs`, controllers in `asERP.Server`.

## Core Abstractions

- Connectors implement `ISalesChannelConnector` (stateless — per-run state comes via `SalesChannelContext`: decrypted credentials, Polly-configured `HttpClient`, open `ChannelSyncRun`, `IncrementalSince` watermark, progress callback) and extend `ConnectorBase`, overriding only supported methods + declaring matching `Capabilities` flags.
- Resolution always goes through `SalesChannelConnectorRegistry` (built from all DI-registered connectors) — never inject a concrete connector.
- `SalesChannelType` values are explicit and stable: `PointOfSale=1, Shopware6=11, WooCommerce=20, WooCommerceDatabase=21, eBay=30, Amazon=40`.
- The `ImportSalessAsync`/`ExportSaless`/`UpdateSaless` spelling (double-s) is deliberate and consistent — match it exactly.

## Sync-State Split (critical)

Volatile sync bookkeeping lives on **`SalesChannelSyncState`** (1:1 with `SalesChannel`, **token-free**): `Initial*Completed` flags, `SalesImportBackfillCursor`, `CustomerImportPageCursor`, `LastSyncStartedAt`. `SalesChannel` itself is `IConcurrencyStamped` to protect admin edits.

**Any field written by concurrent sync operations goes on `SalesChannelSyncState`, never on `SalesChannel`** — otherwise parallel ImportSaless/ImportCustomers on separate DbContexts collide on the concurrency token (`DbUpdateConcurrencyException`, historically failed valid backfill orders).

Sync paths always `.Include(s => s.SyncState)`; **a new `SalesChannel` row must get a fresh `SalesChannelSyncState`** or the sync machinery NREs.

## Orchestration

- One hosted service, `SalesChannelOrchestrator`: 10s tick → drain outbox → dispatch queued runs → poll imports → drain sync logs; log purge every 6th tick; `ReconcileMissingProductsAsync` every ~30 min. Off in tests via `includeBackgroundServices: false`.
- Each due (channel, operation) runs as a **detached task on its own DI scope** (own DbContext). Per-(channel, op) `SemaphoreSlim` with non-blocking try-acquire; losers retry next tick. Single-process deployment is a stated assumption.
- Crash recovery: startup marks orphaned `Running` runs Failed and resets `InFlight` outbox rows; drainer reclaims rows stuck `InFlight` > 10 min. Close-run writes use `CancellationToken.None` so shutdown still persists terminal status.
- Manual syncs are durable: `SalesChannelsController.ManualSync` inserts a `Queued` `ChannelSyncRun` (202 + runId); the orchestrator picks it up oldest-first.

## Incremental Watermark (load-bearing)

Only `ImportSaless`/`ImportStock` are incremental. Watermark = `StartedAt` of the last **Success** run minus 1h overlap. **Failed/PartialFailure runs never advance it** (fixed a real ~17% order-coverage bug). Manual triggers force a full sweep (null watermark) as the recovery lever. Imports must stay idempotent upserts — the overlap depends on it.

## Export Pipeline (outbox + interceptor)

- Primary path: handlers publish notifications (`ProductChangedNotification`, `SalesChangedNotification`, ...) → `NotificationHandlers/` enqueue `ChannelExportOutbox` rows. Safety net: `ChannelExportNotificationInterceptor` (Persistence) catches **any** save touching Product/ProductSalesChannel/ProductStock/Sales/Customer and publishes in `SavedChangesAsync` — after the commit, outside the EF critical section, per-notification try/catch, cleared on failed saves.
- Storno trap: the interceptor maps `Modified → StatusChanged`, so a cancellation done as a status flip is *not* seen as `Cancelled` — `SalesCancelHandler` explicitly publishes `SalesChangeKind.Cancelled` after commit; the downstream handler re-reads `Sales.Status` and routes to `CancelSales` vs `UpdateSales`. Idempotency key coalesces the duplicates.
- Outbox: `Pending/InFlight/Done/DeadLetter`, batch 100, max 10 attempts, exp backoff 30s→1h cap. Idempotency key `{op}:{aggType}:{aggregateId}:{channelId}` unique per channel; payload re-hydrated from current DB state at drain time (exception: `DelistProduct` prefers the captured snapshot). Enqueuer swallows only unique-constraint violations.
- Exports do **not** create `ChannelSyncRun` rows (the outbox row is the audit); imports do.

## Tenancy in Background Jobs (critical)

No HTTP request → nothing populates `ITenantContext`. `SyncDispatcher.AlignTenantContext` sets assigned + current tenant from the channel row before dispatch — without it, tenant-scoped writes silently target the null tenant. Orchestrator housekeeping queries use `IgnoreQueryFilters()` deliberately (cross-tenant host work). Anonymous public endpoints (feeds, webhooks, OAuth callback) resolve the tenant **from the row**, never from headers.

## Credentials & Config

- `SalesChannel.Password/AccessToken/RefreshToken/TrackingToken/WebhookSecret` are encrypted at rest (`EncryptedStringConverter`); `SalesChannelContextFactory` decrypts (with legacy-plaintext passthrough).
- WooCommerce quirk: consumer key = `Username`, consumer secret = `Password`.
- Free-form config is JSON in `AdditionalConfigJson`, owned by each connector's `{Name}ChannelConfig.FromSalesChannel`. Known exception: Amazon's `lwaClientSecret` is stored **plaintext** in that JSON (documented in `AmazonChannelConfig`).
- OAuth app-level client id/secret come from `IOAuthAppSettingsService` (tenant row overrides system Setting), not the channel row. eBay uses refresh-token OAuth (`EbayAuthHelper`, token cache + per-channel semaphore); Amazon uses LWA; Shopware 6 uses client_credentials.

## Resilience & Security

- Named HttpClients per channel with `.AddPollyHandlers()` (retry + circuit breaker) and `.AddSsrfGuardedPrimaryHandler()` (ConnectCallback re-validates dialed IPs via `SalesChannelUrlValidator` against DNS-rebind/redirect SSRF). Exception: `"amazon-lwa"` (fixed Amazon host). WooCommerce REST uses the WooCommerceNET SDK transport, not IHttpClientFactory.
- **Any tenant-controlled URL/host (channel URL, image URL, MySQL host) must pass `SalesChannelUrlValidator`.**
- Connectors return `SyncResult`/`ExportResult` instead of throwing; the dispatcher maps to `Success`/`PartialFailure`/`Failed` and catches exceptions — nothing bubbles to the tick loop.

## Domain Invariants

- **Stock master:** a channel with `ImportStock=true` is the stock master — its imported orders do NOT book ledger movements; all other channels book against the mirror. Getting this wrong double-counts stock.
- Orders may arrive before their product: store the SKU on `SalesItem.MissingProductSku`; `ReconcileMissingProductsAsync` links later. Follow this instead of failing imports.
- Webhooks only *accelerate* (enqueue a run); the scheduled poll is the reconciler.

## Adding a New Channel

1. New explicit `SalesChannelType` value (Domain).
2. `Connectors/{Name}/{Name}Connector.cs` : `ConnectorBase` + `Models/{Name}/{Name}ChannelConfig.cs` (+ auth helper).
3. Register in `SalesChannelServiceRegistration`: `AddScoped<ISalesChannelConnector, {Name}Connector>()`; named HttpClient with Polly + SSRF guard; case in `SalesChannelContextFactory.HttpClientNameFor`.
4. Write through the shared import repositories + `ImportIdAllocator`; call `context.ReportProgressAsync` in long imports.
5. UI: mirror an existing channel in `asERP.Client`; CQRS wiring in `Application/Features/SalesChannel*` + `SalesChannelsController`; OAuth via `SalesChannelOAuthController` + `IOAuthAppSettingsService`.

## Product Feeds (separate feature)

Public anonymous product feeds (Google Products RSS, Idealo CSV, Pinterest) are **not** channel connectors — rendering lives in `asERP.Application/Feeds/Rendering/` (resolver keyed by `FeedTemplate`), entities `Feed`/`FeedProduct`/`FeedLog` in Domain, endpoints `GET /feed/{id:guid}` (`FeedController`, anonymous, unguessable GUID as guard, tenant resolved from the feed row) + authenticated management at `/api/v1/feeds`.
