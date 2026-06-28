# asToolkit integrations

Shop-side plugins that feed the asToolkit **Web-Statistiken** (web analytics) feature. Each plugin embeds a
tiny first-party tracker and proxies beacons to your asToolkit server **server-side**, so the per-channel
secret token never reaches visitors' browsers.

| Plugin | Platform | Folder |
|---|---|---|
| asToolkit Web Analytics | WooCommerce (WordPress) | [`woocommerce-astoolkit-analytics/`](woocommerce-astoolkit-analytics/) |
| asToolkit Web Analytics | Shopware 6 | [`shopware6-astoolkit-analytics/`](shopware6-astoolkit-analytics/) |

## How it fits together

```
Browser (storefront)
  │  loads first-party astoolkit-s.js  (no token, no asToolkit URL)
  │  POST beacon → SAME-ORIGIN collector on the shop
  ▼
Shop plugin (server-side)
  │  adds: secret token, visitor IP (X-Forwarded-For), visitor User-Agent,
  │        pseudonymised customer ref (cid) when logged in
  ▼
asToolkit  POST /api/v1/storefront/e
  │  token → sales channel + tenant; enrich (session hash, UA, IP mask) → ClickHouse
  ▼
asToolkit.Client → sales channel dashboard → "Web-Statistiken" tab
```

To set up: generate a tracking token in asToolkit (Sales channel → Web analytics), install the matching plugin,
and paste the asToolkit server URL + token into the plugin settings. See each plugin's readme for details.
