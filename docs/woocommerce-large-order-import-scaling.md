# Analysis: WooCommerce order import does not scale past 100,000 orders

**Status:** analysis only — no code changed. Hand to a focused implementation task.
**Date:** 2026-06-14
**Channel:** `diy-stoffe.de` (WooCommerce, HPOS), tenant `DIY-Stoffe.de`, ERP DB `maerp_01`.

---

## 1. Problem

The shop is far larger than the importer can handle in one pass. Source counts (phpstorm conn `production` = `1ae1f88a-737b-4891-a8ca-b3356ce5764b`, HPOS table `diystoffe_wc_orders`):

| status | count |
|---|---|
| wc-completed | 170,911 |
| wc-cancelled | 5,365 |
| wc-refunded | 654 |
| wc-failed | 593 |
| wc-processing | 110 |
| trash | 66,653 (excluded by REST) |
| **non-trash total** | **~177,600** |

The connector caps a single import run at **100,000 orders**:

```
// src/maERP.SalesChannels/Connectors/WooCommerce/WooCommerceConnector.cs:553-554
private const int PageSize = 100;
private const int MaxPages = 1000;          // 100 * 1000 = 100,000 rows hard ceiling
```

`ImportSalessAsync` loops `for (var page = 1; page <= MaxPages; page++)` (line ~215). With `orderby=id&order=asc`, a full manual sweep therefore imports only the **oldest 100,000 orders by id** and silently stops at the cap. The newest ~77,600 orders are never fetched by the full sweep. (The same `MaxPages` ceiling applies to product and customer imports — products ~11k and customers ~63k are under it today, so only orders are affected now.)

> Note: this ceiling was added as a runaway-loop backstop. It is doing its job, but 100k is below this shop's real volume.

## 2. Why this leaves a *permanent* gap (not just "slow")

The two import modes interact badly at this scale:

- **Full sweep** (manual "Sync saless", no watermark): `orderby=id asc`, stops at the 100k cap → imports the oldest 100k, **misses the newest ~77.6k**.
- **Incremental** (scheduled): `modified_after = lastRun.StartedAt − 1h` (`SyncDispatcher.IncrementalOverlap`, line 214). This only pulls orders **modified since the watermark**. New orders are caught (they're recently modified). But an *old, never-modified* order whose id sits beyond the 100k cap is **never** pulled — not by the capped full sweep, not by the modified-since incremental.

Result: a stable band of older-but-high-id orders is permanently absent, and there is no self-healing path. (Observed live: after sweeps the ERP held ~39.7k sales and kept growing — legitimate, not duplicates, but far short of 177.6k, and a single sweep can never close the gap.)

## 3. Secondary issue: long imports block the orchestrator

`SalesChannelOrchestrator.PollImportsAsync` awaits each import **synchronously** on the single tick loop:

```
// src/maERP.SalesChannels/Orchestration/SalesChannelOrchestrator.cs:188
if (channel.ImportSaless)
    await dispatcher.RunImportAsync(channel, ChannelSyncOperation.ImportSaless, ChannelSyncTriggerSource.Scheduler, cancellationToken);
```

A 100k-order sweep takes tens of minutes. While it runs, the **entire** tick loop is blocked — `DrainOutboxAsync`, `DrainSyncLogsAsync` (so the in-app sync log stops updating), `PurgeSyncLogsAsync`, and **every other channel's** sync are all starved until it finishes. Raising the cap to import 177.6k in one go makes this much worse (multi-hour stall). So "just raise MaxPages" is not sufficient on its own.

Also relevant: deep offset pagination. WooCommerce REST `page`/`per_page` is offset-based under the hood; pages in the hundreds/thousands get progressively slower and some hosts cap deep pagination. Walking ~1,776 pages in one request stream is fragile.

## 4. Options

| Option | Pros | Cons |
|---|---|---|
| **A. Raise/remove `MaxPages`** | one-line | multi-hour single run; blocks orchestrator (§3); deep-pagination slowness/fragility; still one giant lock hold |
| **B. Date-window chunking** (`after`/`before` on `date_created`, e.g. month/quarter windows, each paged id-asc) | each window << 100k; avoids deep offset pagination; resumable; bounded run length | more code; must iterate windows across the full history |
| **C. Cursor resume across ticks** (persist "imported up to id/date X"; each scheduled run imports the next chunk until caught up, then switches to `modified_after`) | non-blocking (one chunk per tick); self-completing; survives restarts | needs a per-channel progress cursor; careful state machine |
| **D. Configurable history cutoff** (only import orders after date X) | drastically smaller; often what's actually wanted | loses old history; product decision |

**Recommended: B + C together** — chunk the backfill by date window *and* advance one window per scheduled tick (or run the backfill off the orchestrator thread). Concretely:
1. Add a per-channel **backfill cursor** (no migration needed — derive from `MIN/MAX(date_created)` already imported, or the latest `ChannelSyncRun` of a new `ImportSalessBackfill` operation; or store a watermark column if a migration is acceptable).
2. While backfilling, each run pulls one date window (`after`/`before`) paged id-asc, persists per order (already the pattern), advances the cursor.
3. When the cursor reaches "now", flip to the existing `modified_after` incremental mode.
4. Decide with the user whether to bound history (Option D) so the ERP isn't loaded with 170k completed + 66k trashed historical orders it may not need.

**Also fix §3 regardless of chunking:** don't run a long import on the orchestrator's tick thread. Either move imports to a dedicated background worker/channel, or keep chunks small enough (Option C) that each tick returns quickly. The per-channel lock added in `SyncDispatcher` (try-acquire) already prevents overlap, so a chunk that runs long simply makes the next tick skip that channel — acceptable only if chunks are bounded.

## 5. Open questions for the implementer
- **Scope of history:** import *all* ~177.6k non-trash orders, or only a recent window? (Big ERP/data-volume implication.)
- **Statuses:** include cancelled/refunded/failed, or only completed/processing? The REST default `status=any` returns all non-trash.
- **Migration allowed?** A dedicated cursor/watermark column is cleanest; the project rule is *never migrate without asking*.
- **Trash:** confirm trashed orders (66,653) must stay excluded (REST excludes them by default).

## 6. Verification plan
1. Source total (phpstorm, schema `diy-stoffe_production`):
   ```sql
   SELECT COUNT(*) FROM diystoffe_wc_orders WHERE status <> 'trash';   -- ~177,600
   ```
2. After a complete chunked backfill, ERP sales `totalCount` (maERP API `GET /api/v1/saless?pageSize=1`) should approach that number (minus any chosen cutoff/status filter).
3. Confirm **no permanent gap**: pick a high-id, old, never-modified order from WooCommerce and verify it imported (`GET /saless?searchString=<RemoteSalesId>`).
4. Confirm the orchestrator stays responsive during backfill: `DrainSyncLogsAsync`/outbox keep ticking (watch server log timestamps) rather than freezing for the import's duration.

### Access notes
- maERP API: login `admin@localhost.com` / `P@ssword1`, header `X-Tenant-Id: d97a2d78-d929-4c4a-a823-d117ed0ec1a3`, base `https://localhost:8443`; channel id `29954d29-14f6-48c2-8525-2e11c645a6ec`.
- **rider** SQL bridge is broken ("not done") — use the API for ERP reads. **phpstorm** SQL works for the WooCommerce source.
- Dev server runs Development → Postgres `maerp_01` on `localhost:5432`.

## 7. Related
- `[[project_woocommerce_sales_import]]` — current order-import design (stable `orderby=id`, per-order `ChangeTracker.Clear()`, per-channel serialization, manual=full-sweep, `modified_after` watermark). This analysis builds directly on it.
- `docs/woocommerce-variation-import-analysis.md` — the parallel "missing products = variations" gap.
