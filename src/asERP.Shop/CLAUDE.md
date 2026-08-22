# CLAUDE.md — asERP.Shop

asShop storefront: multi-tenant Blazor Web App (static SSR; interactive server islands later)
hosted inside `asERP.Server`. Shops are `SalesChannelType.AsShop` channels; incoming requests are
matched by Host header (+ optional port) against their `ShopDomain` rows.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true` (includes
generated `.razor` code). References only `asERP.Application`; only `asERP.Server` references this
project. Registered via `ShopServiceRegistration.AddShopServices()` — no background services, safe
in every environment including Testing.

## Layout

| Folder | Contents |
|---|---|
| `Components/` | Razor components: `App` (root + host guard), `Routes`, `Layout/`, `Pages/` |
| `Hosting/` | `ShopHostMiddleware` (host→channel→tenant), `IShopHostResolver` (cached host map), `IShopRequestFeature`, `ShopHtmlExceptionHandler` |
| `NotificationHandlers/` | Resolver invalidation on `ShopDomainChangedNotification` |
| `wwwroot/` | Static assets, served under `/_content/asERP.Shop/` — incl. `aserp-shop.js` (built-in web-analytics tracker) |

## Host routing (load-bearing)

- `ShopHostMiddleware` runs early in the Server pipeline. Reserved path prefixes (`/api`,
  `/swagger`, `/metrics`, `/health`, `/feed`, `/_framework`, `/_content`) are never shop-routed —
  the ERP API keeps working on EVERY host. `/_blazor` is deliberately shop-routed.
- On a host match the middleware sets `IShopRequestFeature` and binds `ITenantContext` from the
  domain row (anonymous tenant-from-row, cf. `FeedController`). `TenantMiddleware` skips
  shop-marked requests. On a miss the request passes through untouched.
- `ShopHostResolver` mirrors `TrackingTokenResolver` (asERP.Analytics): singleton, in-memory
  host map, 30s TTL, cross-tenant load via `IShopDomainRepository.GetActiveBindingsAsync()`,
  immediate invalidation via `ShopDomainChangedNotification`.
- Hostnames are normalized by `asERP.Domain.Services.ShopHostNormalizer` on write AND lookup —
  never compare raw host input.
- `App.razor` carries the root guard: without the shop feature every component route responds 404,
  so globally mapped shop routes stay invisible on non-shop hosts.

## Built-in web analytics

- When the channel has `TrackingEnabled`, `App.razor` embeds `aserp-shop.js` — an asShop variant of
  the canonical tracker (`integrations/…/aserp-s.js`) that POSTs beacons to the same-origin
  `/asshop/e` collector (`ShopCollectorController` in asERP.Server). No plugin, no token: channel +
  tenant come from the `IShopRequestFeature` binding (`ShopHostBindingRef.TrackingEnabled` rides the
  resolver cache, ≤30s staleness).
- CSP-compatible by construction: no inline scripts — the endpoint is fixed in the file and optional
  page context (product data) goes into a non-executable
  `<script type="application/json" id="aserp-ctx">` data block rendered server-side.
- A caller-supplied `cid` is untrusted here (body comes straight from the browser) and is dropped by
  the collector — when shop logins arrive, the server stamps it itself.

## Rules

- **Components never query data on their own** — pages load data server-side and pass it down
  (a batched `IShopDataResolver` arrives with the template system).
- Interactive island components (when they arrive) must never inject `ApplicationDbContext`,
  repositories, or `IMediator` directly — circuit DI scopes outlive the request and have no tenant
  context. They go through the per-operation-scope executor (`ShopScopedExecutor`, Phase 2).
- The shop CSP is `script-src 'self'` — no inline scripts, and **no `[StreamRendering]`** (its
  framework-injected inline scripts would be blocked).
- German user-facing texts, English identifiers/comments (repo rule).
