# CLAUDE.md — asERP.Shipping

Carrier-integration module: shipping labels, cancellations, tracking polls, and return labels for **DHL, DPD, GLS, UPS**, with a persistent outbox for resilient retries. Consumed by Application CQRS handlers (`Features/Shipping/*`, `Features/Returns/*`); only `asERP.Server` references this project.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true`.

> Unusual for this solution: this project references `asERP.Persistence` and uses `ApplicationDbContext` **directly** (not repositories). `InternalsVisibleTo("asERP.Server.Tests")`.

## Layout

| Folder | Contents |
|---|---|
| `Abstractions/` | `IShippingCarrierConnector`, `ShippingCarrierConnectorRegistry`, `ShippingCarrierContext`, request/result records (`CarrierLabelResult` etc.), `CarrierTrackingStatus`, `TrackingStatusMapper` |
| `Connectors/Common/` | `ShippingConnectorBase` — config parsing, auth helpers, transient/permanent HTTP classification, no-op return-label default |
| `Connectors/{Dhl,Dpd,Gls,Ups}/` | One connector per `ShippingProviderType` (Dhl=1, Dpd=2, Gls=3, Ups=4); all support return labels |
| `Models/{Carrier}/` | Per-carrier config records (from `ShippingProvider.AdditionalConfigJson`), `Models/Common/CarrierSenderAddress`, `UpsAuthHelper` |
| `Orchestration/` | `ShippingOrchestrator` (hosted service), label/return outbox drainers, `ShippingTrackingPoller`, `ShippingCarrierContextFactory`, Polly extensions |
| `Services/` | `ShippingCarrierService : IShippingCarrierService`, `ReturnCarrierService`, outbox enqueuers |

## Key Patterns

- **Hybrid label creation with outbox fallback**: `CreateLabelAsync` tries synchronously (Polly retries transient HTTP); on **transient** failure it enqueues to `ShippingLabelOutbox` and returns success-with-message; on **permanent** failure returns BadRequest. `TryCreateLabelCoreAsync` is the single code path shared by sync call and drainer — keep it that way.
- **Transient vs. permanent classification is central** (`ShippingConnectorBase.IsPermanentStatusCode`): 4xx (except 408/429) = permanent, 5xx/timeouts/open circuit = transient. Only transient errors retry.
- Outbox: batch 100, max 10 attempts, exp backoff 30s→1h cap, then `DeadLetter` (immediately on permanent failure). Idempotency key `label:{shippingId:N}`, one active row per shipment.
- `ShippingOrchestrator`: 10s tick drains both outboxes; tracking poll every 6th tick. Each unit of work gets its own DI scope/DbContext. Off in Testing (`includeBackgroundServices: false`).
- `ShippingTrackingPoller`: per enabled provider, up to 50 active shipments past `TrackingPollIntervalSeconds` (min 60s); stamps `LastTrackedAt` on every attempt (prevents hot loops); status changes only via `TrackingStatusMapper.IsUpgrade` — **never downgrade or leave a terminal state**; keep `TrackingStatusMapper` the single translation point.
- **Connectors are stateless**; everything call-specific arrives via `ShippingCarrierContext`. Credentials are decrypted by `ShippingCarrierContextFactory` via `ICredentialEncryptor` (legacy plaintext passes through) — connectors never decrypt.
- **Background scopes have no ambient tenant** → services use `IgnoreQueryFilters()` and explicitly `_tenantContext.SetCurrentTenantId(shipping.TenantId)` before downstream calls. Follow this in any new background path.
- Polly (`PollyHttpClientExtensions`): 3 retries exp+jitter on transient+429, circuit breaker after 5 consecutive failures for 30s. Intentionally duplicated from SalesChannels — do not create an inter-project dependency to share it.

## Shipments ↔ Sales

`Shipping` belongs to a `Sales` order. `BuildLabelRequestAsync` includes the Sales row and builds the carrier-agnostic `ShipmentLabelRequest` from `sales.DeliveryAddress*` + `sales.SalesId` (printed reference); country free-text resolves against the `Country` seed table to ISO codes (DHL wants alpha-3). Weight/dimensions come from the `Shipping` row (default 1 kg). Returns mirror this with the customer address.

## Configuration

Per-provider row = tenant-scoped `ShippingProvider` entity: `Type`, credentials (encrypted), `AccountNumber` (DHL EKP), `UseSandbox`, `IsEnabled`, `TrackingPollIntervalSeconds`, `AdditionalConfigJson`. Carrier-specific knobs (e.g. DHL Procedure/Participation/Product/TrackingApiKey/Return* + sender address) live in that JSON, parsed via `ParseConfig<T>`; `CarrierSenderAddress.EnsureComplete` validates the sender block.

## Adding a Carrier

1. New `ShippingProviderType` value (Domain, explicit number).
2. `Connectors/{Name}/` extending `ShippingConnectorBase` + `Models/{Name}/` config record.
3. Register in `ShippingServiceRegistration`: scoped connector **and** its named `HttpClient` with `.AddPollyHandlers()` — the registry throws for a provider type without a connector.

## Caveats

- `[verify]` comments mark carrier details (sandbox hosts, billing numbers, granular status codes) that still need a live smoke test — treat them as unconfirmed.
- UPS uses OAuth via the singleton `UpsAuthHelper` (token cache); DHL uses Basic + `dhl-api-key` header.
