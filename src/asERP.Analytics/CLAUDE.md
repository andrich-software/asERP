# CLAUDE.md — asERP.Analytics

ClickHouse-backed, cookieless web-analytics pipeline (Plausible-style): ingests storefront tracking beacons, enriches and batches them into ClickHouse, serves dashboard queries. Fully wired into the Server — this is production code, not scaffolding.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true`. References only `asERP.Application`; only `asERP.Server` references this project.

## Layout

| Folder | Contents |
|---|---|
| `ClickHouse/` | `ClickHouseConnectionFactory`, `ClickHouseSchema` (raw DDL), `ClickHouseSchemaBootstrapper` (hosted service) |
| `Ingest/` | `WebAnalyticsIngestService`, `WebAnalyticsIngestQueue` (bounded channel), `WebAnalyticsBatchWriter` (hosted service) |
| `Query/` | `ClickHouseWebAnalyticsQueryService : IWebAnalyticsQueryService` |
| `Identity/` | `TrackingTokenResolver` — per-channel secret token → tenant/channel |
| `Enrichment/` | `SessionHasher`, `IpMasker`, `UserAgentParser` |

Server surface: `StorefrontController` (`/api/v1/storefront/e`, anonymous, rate-limited, always 202) for ingest; `WebStatisticsController` via CQRS handlers for reads.

## ClickHouse ≠ EF (critical)

- **Never write EF migrations for analytics tables.** Schema is applied idempotently at startup by `ClickHouseSchemaBootstrapper` running the `CREATE ... IF NOT EXISTS` DDL in `ClickHouseSchema.cs` — schema changes are additive edits there.
- Two tables: `web_events` (MergeTree, 24-month TTL) and `web_identities` (ReplacingMergeTree).
- **Bulk copy is positional**: `ClickHouseSchema.EventColumns`, the `ToEventRow` order in `WebAnalyticsBatchWriter`, and the `web_events` DDL must stay in exact sync.
- Config comes from the relational Setting table (`ISettingsService.GetClickHouseSettingsAsync()` → `ClickHouseSettings`: `Enabled`, Host/Port/User/Password/Database/UseTls). `Enabled == false` → the whole pipeline silently no-ops.

## Ingest Path Rules

- The request path **never blocks or throws**: enrich → `TryWrite` into a bounded 50k channel with `DropWrite` overflow (analytics loss is acceptable). The batch writer drains ~1 insert/sec (batch 2000) via `ClickHouseBulkCopy`.
- Background services swallow-and-log and never crash the host — analytics is non-critical.

## Privacy by Design (do not weaken)

- Raw IP and User-Agent are **never persisted**. `SessionHasher` = SHA256 of `dailySalt|host|ip|ua` with a per-UTC-day salt (sessions anonymize overnight). `IpMasker` zeroes IPv4 /24, keeps IPv6 /48. `UserAgentParser` reduces to coarse browser/OS/device buckets and drops bots.

## Tenancy (manual — no EF query filter here)

- ClickHouse has no global query filters. `ClickHouseWebAnalyticsQueryService` reads the tenant from `ITenantContext`, injects it as a **query parameter**, and **fails closed** (returns empty) with no tenant in context. New queries must parameterize everything and require a tenant — never accept a caller-supplied tenant id.
- Ingest resolves the tenant from the channel's tracking token (`TrackingTokenResolver`), never from the request.

## DI (`AnalyticsServiceRegistration.cs`)

`AddAnalyticsServices(includeBackgroundServices)` — hosted services (bootstrapper, batch writer) are skipped in the Testing environment. Singletons (`ConnectionFactory`, `TrackingTokenResolver`, queue, ingest service) reach scoped settings/repositories via `IServiceScopeFactory` with short-lived scopes and ~30s caches — never capture a scope. `IWebAnalyticsQueryService` is Scoped (needs request tenant context).
