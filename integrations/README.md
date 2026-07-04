# asERP integrations

Shop-side plugins that feed the asERP **Web-Statistiken** (web analytics) feature. Each plugin embeds a
tiny first-party tracker and proxies beacons to your asERP server **server-side**, so the per-channel
secret token never reaches visitors' browsers.

| Plugin | Platform | Folder |
|---|---|---|
| asERP Web Analytics | WooCommerce (WordPress) | [`woocommerce-aserp-analytics/`](woocommerce-aserp-analytics/) |
| asERP Web Analytics | Shopware 6 | [`shopware6-aserp-analytics/`](shopware6-aserp-analytics/) |

## How it fits together

```
Browser (storefront)
  │  loads first-party aserp-s.js  (no token, no asERP URL)
  │  POST beacon → SAME-ORIGIN collector on the shop
  ▼
Shop plugin (server-side)
  │  adds: secret token, visitor IP (X-Forwarded-For), visitor User-Agent,
  │        pseudonymised customer ref (cid) when logged in
  ▼
asERP  POST /api/v1/storefront/e
  │  token → sales channel + tenant; enrich (session hash, UA, IP mask) → ClickHouse
  ▼
asERP.Client → sales channel dashboard → "Web-Statistiken" tab
```

To set up: generate a tracking token in asERP (Sales channel → Web analytics), install the matching plugin,
and paste the asERP server URL + token into the plugin settings. See each plugin's readme for details.
