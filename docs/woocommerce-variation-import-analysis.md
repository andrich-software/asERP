# Analysis: Importing WooCommerce Product Variations into asToolkit

**Status:** analysis only — no code changed yet. Hand this to a focused implementation task.
**Date:** 2026-06-12
**Channel under test:** `diy-stoffe.de` (WooCommerce), tenant `DIY-Stoffe.de`.

---

## 1. Problem

The ERP is missing products. Verified against both databases:

| | WooCommerce source (`production`, MariaDB `diy-stoffe_production`) | ERP (`astoolkit_01`, Postgres) |
|---|---|---|
| Top-level products (`post_type=product`) | 3,596 `publish` + 3,039 `private` = **6,635** | **6,624** ✅ (≈ complete) |
| **Variations (`post_type=product_variation`, publish)** | **4,609** (across **1,551** variable parents) | **0** ❌ |
| Orders | ~29,100 | 29,477 ✅ |
| Customers | — | 36,475 ✅ |

The **4,609 variations are never imported**. Each variation has its **own SKU, price and stock** and is the actual *sellable* unit — order line items reference variation SKUs, not parent SKUs. Spot check: variation SKUs `6895802`, `6895801`, `6893534` return **0 matches** in the ERP product API.

Consequence: order line items for variations are stored as "missing product" lines (`SalesItem.MissingProductSku`), and stock/price for the real sellable SKUs is absent.

### Root cause
The WooCommerce connector imports only top-level products via `wc.Product.GetAll()`. The REST `/wc/v3/products` endpoint does **not** return variations — they are a sub-resource at `/wc/v3/products/{parent_id}/variations`. The connector never fetches that sub-resource.

---

## 2. Current code (what to change)

### Connector — `src/asToolkit.SalesChannels/Connectors/WooCommerce/WooCommerceConnector.cs`
- `ImportProductsAsync(SalesChannelContext context)` (~line 62): pulls all products via `GetAllProductsAsync` (which uses the generic `GetAllPagedAsync`), then for each:
  - **skips products with an empty `sku`** (`if (string.IsNullOrEmpty(remoteProduct.sku)) continue;`),
  - calls `_productImportRepository.ImportOrUpdateFromSalesChannel(channelId, new SalesChannelImportProduct { Name, Price = price ?? 0, Sku, TaxRate = 19, Description })`.
- `GetAllProductsAsync` → `GetAllPagedAsync(parms => wc.Product.GetAll(parms), p => p.id, ct)`. **Note:** this still **buffers all products in memory** and paginates with the **default `orderby` (date desc)** — the same instability class that caused missing *orders* (see `[[project_woocommerce_sales_import]]` / the order fix that switched to `orderby=id`). Worth fixing here too while in this code.

### Import repository — `src/asToolkit.SalesChannels/Repositories/ProductImportRepository.cs`
- `ImportOrUpdateFromSalesChannel(Guid salesChannelId, SalesChannelImportProduct importProduct)`:
  - Resolves a `TaxClass` by `importProduct.TaxRate` (**throws** if none — currently hard-coded `TaxRate = 19` in the connector; variations inherit the parent's tax class in WooCommerce, so 19 is usually fine, but verify the shop's reduced-rate fabrics).
  - Upserts a `Product` **by SKU** (`GetBySkuAsync`), creating `Product` + a `ProductSalesChannel` link (`RemoteProductId`, `Price`). No stock row on import (intentional).
  - **This repository needs no structural change** — a variation is just another `SalesChannelImportProduct` with the variation's SKU/price/name. It will create one `Product` per variation SKU, which is exactly what order-line matching needs.

### Import model — `src/asToolkit.SalesChannels/Models/SalesChannelImportProduct.cs`
Fields available: `RemoteProductId (int)`, `Name`, `Sku`, `Ean`, `Description`, `TaxRate (double)`, `Price (decimal)`, `Stock (double)`. Sufficient for variations.

---

## 3. WooCommerce / SDK facts

- SDK: `WooCommerceNET` 0.8.6 (`~/.nuget/packages/woocommercenet/0.8.6`).
- `Product` model exposes `type` (`"simple" | "variable" | "grouped" | "external"`) and `variations` (`List<int>` of variation IDs).
- Variations are fetched per parent. In WooCommerceNET this is the product sub-API — **verify the exact accessor** (`wc.Product.Variations.GetAll(parentId, parms)` returning `List<Variation>`). The DLL exposes `get_Variations` on the product items collection and a `Variation` type with `sku`, `price`, `regular_price`, `stock_quantity`, `manage_stock`, `attributes`, `description`, `status`.
- Variation **name**: variations have no standalone title; build it from the parent product name + the variation `attributes` (e.g. `"French Terry – Sommersweat – Cream meliert"`). The order line-item `name` already arrives in that combined form, so mirror that.
- Pagination: `/products/{id}/variations` supports `per_page` (max 100) + `page`; most fabrics have ≤ ~10 variations, so usually one page per parent. Use `orderby=id&order=asc` for stable paging (same lesson as orders).

---

## 4. Proposed implementation

**Recommended approach (user choice pending — they leaned "variations as own products"):** import each variation as its own ERP `Product` (keyed by the variation SKU). Keep importing variable parents as today *or* skip them (see Open Questions).

In `ImportProductsAsync`, after importing each top-level product, if it is variable, fetch and import its variations:

```csharp
// after upserting the top-level product:
if (string.Equals(remoteProduct.type, "variable", StringComparison.OrdinalIgnoreCase))
{
    foreach (var variation in await GetAllVariationsAsync(wc, remoteProduct.id, context.CancellationToken))
    {
        if (string.IsNullOrEmpty(variation.sku)) continue;   // unsellable / no SKU
        try
        {
            await _productImportRepository.ImportOrUpdateFromSalesChannel(context.SalesChannel.Id, new SalesChannelImportProduct
            {
                RemoteProductId = (int)variation.id,
                Sku             = variation.sku,
                Name            = BuildVariationName(remoteProduct, variation), // parent name + attributes
                Price           = variation.price ?? variation.regular_price ?? 0m,
                TaxRate         = 19,                  // or map from parent/variation tax_class
                Description     = remoteProduct.description,
                Stock           = (double)(variation.stock_quantity ?? 0),
            });
            processed++;
        }
        catch (Exception ex) { failed++; _logger.LogError(ex, "Variation import failed for {Sku}", variation.sku); }
    }
}
```

`GetAllVariationsAsync` mirrors the order/customer paging: `per_page=100`, `orderby=id&order=asc`, page until a short/empty page, with the `PageFetchTimeout` + cancellation checks already used elsewhere in this file.

### Robustness to copy from the sales-import fix
1. **Stable pagination** for both products and variations: `orderby=id&order=asc` (don't rely on the default mutable `date`/`modified` sort).
2. **Per-item context reset (cascade guard):** `ProductImportRepository` shares the scoped `ApplicationDbContext`. One failed `SaveChanges` (e.g. a duplicate or a bad row) currently risks poisoning the context for every later product — the exact failure that wrecked the order import (`ArgumentOutOfRangeException: Unexpected entry.EntityState: Detached`). Inject `ApplicationDbContext` and call `ChangeTracker.Clear()` at the start of `ImportOrUpdateFromSalesChannel`, same as `SalesImportRepository` now does.
3. **Volume:** ~1,551 variable parents → ~1,551 extra variation calls (mostly 1 page). Acceptable; consider logging progress every N parents. The product import is gated by `InitialProductImportCompleted` (runs once scheduled) — clear that flag (or use the manual "Sync products" button) to force a full re-import after the change.
4. Don't buffer all products+variations first; persist incrementally (current code buffers all top-level products — fine for 6.6k, but variations multiply memory; stream them).

---

## 5. Open questions / decisions for the implementer
- **Variable parents:** keep them as ERP products (current behaviour) or skip them since only variations are sellable? Skipping avoids ~1,551 non-sellable "parent" SKUs in the catalogue. Parents currently have their own SKU in this shop, so they import today.
- **Tax class:** connector hard-codes `TaxRate = 19`. Variations of reduced-rate goods would need the parent/variation `tax_class` mapped to a real `TaxClass`; otherwise `ProductImportRepository` throws for them. Check whether any fabrics use a reduced rate.
- **Stock:** import path intentionally creates no `ProductStock`. If channel stock should reflect WooCommerce `stock_quantity`, that is a separate feature (warehouses/goods-receipts), out of scope here.
- **Incremental:** variations change (price/stock) frequently. The product import is currently full-once-then-manual. If variations need ongoing sync, consider a `modified_after`-style incremental for products too (see the order watermark in `SyncDispatcher.ComputeIncrementalSinceAsync`).

---

## 6. Verification plan
After implementing and running a full "Sync products":
1. **WooCommerce source counts** (phpstorm conn `production` = `1ae1f88a-737b-4891-a8ca-b3356ce5764b`, schema `diy-stoffe_production`, prefix `diystoffe_`):
   ```sql
   SELECT COUNT(*) FROM diystoffe_posts WHERE post_type='product_variation' AND post_status='publish'; -- 4609
   ```
2. **ERP product count** via API (`GET /api/v1/products?pageSize=1` → `totalCount`) should rise from ~6,624 toward **~11,233** (6,624 + 4,609), or ~9,683 if variable parents are skipped.
3. **Spot-check variation SKUs** now resolve: `GET /api/v1/products?searchString=6895802` → `totalCount=1`.
4. **Order line-item health:** previously-"missing product" `SalesItem` rows for variation SKUs should now match real products on a re-sync of orders (the sales import looks products up by SKU at import time, so re-running "Sync saless" after products are complete will attach them).

### Access notes for the implementer
- **rider** SQL bridge (`mcp__rider__execute_sql_query`) returns "not done" — broken in this environment; use the asToolkit REST API for ERP reads instead (login `admin@localhost.com` / `P@ssword1`, send `X-Tenant-Id: d97a2d78-d929-4c4a-a823-d117ed0ec1a3`, base `https://localhost:8443`).
- **phpstorm** SQL works for the WooCommerce source DB (project `/Users/martin/Projekte/andrich-software/diy-stoffe.de`).
- The dev server runs Development config → Postgres `astoolkit_01` on `localhost:5432` (rider "Testsystem"). Rider "Produktivsystem" (`localhost:5434/astoolkit`) was offline during analysis.

---

## 7. Related
- `[[project_woocommerce_sales_import]]` — the order-import fixes (stable `orderby=id`, per-order `ChangeTracker.Clear()` cascade guard, per-channel run serialization, manual=full-sweep). Apply the same patterns here.
