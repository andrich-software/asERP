# maERP integrations

Shop-side plugins that feed the maERP **Web-Statistiken** (web analytics) feature. Each plugin embeds a
tiny first-party tracker and proxies beacons to your maERP server **server-side**, so the per-channel
secret token never reaches visitors' browsers.

| Plugin | Platform | Folder |
|---|---|---|
| maERP Web Analytics | WooCommerce (WordPress) | [`woocommerce-maerp-analytics/`](woocommerce-maerp-analytics/) |
| maERP Web Analytics | Shopware 6 | [`shopware6-maerp-analytics/`](shopware6-maerp-analytics/) |

## How it fits together

```
Browser (storefront)
  │  loads first-party maerp-s.js  (no token, no maERP URL)
  │  POST beacon → SAME-ORIGIN collector on the shop
  ▼
Shop plugin (server-side)
  │  adds: secret token, visitor IP (X-Forwarded-For), visitor User-Agent,
  │        pseudonymised customer ref (cid) when logged in
  ▼
maERP  POST /api/v1/storefront/e
  │  token → sales channel + tenant; enrich (session hash, UA, IP mask) → ClickHouse
  ▼
maERP.Client → sales channel dashboard → "Web-Statistiken" tab
```

To set up: generate a tracking token in maERP (Sales channel → Web analytics), install the matching plugin,
and paste the maERP server URL + token into the plugin settings. See each plugin's readme for details.
