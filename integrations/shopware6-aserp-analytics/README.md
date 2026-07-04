# asERP Web Analytics — Shopware 6 plugin

First-party, privacy-friendly web analytics for Shopware 6, reporting into your asERP server. Visits and
the checkout funnel show up under the sales channel's **Web-Statistiken** tab in asERP.

## Security & privacy by design

- **The tracking token never reaches the browser.** The storefront sends beacons same-origin to
  `/aserp-analytics/c`; the collector controller adds the secret token and proxies them to asERP. Page
  source and network traffic never expose the token or the asERP URL.
- **No cookies.** A random first-party visitor id is kept in `localStorage` for visitor continuity.
- **IPs are masked** server-side in asERP; the raw IP is only used transiently to compute a daily-rotating
  session hash and is never stored.
- **Logged-in customers** are tracked under a pseudonymised reference (an HMAC of the customer number),
  computed server-side, so asERP can attribute product views without the raw number leaving your server.

## Installation

1. In asERP, open the Shopware 6 sales channel → Web analytics → generate a tracking token.
2. Copy this folder to `custom/plugins/MaerpAnalytics` in your Shopware installation.
3. Install & activate:
   ```bash
   bin/console plugin:refresh
   bin/console plugin:install --activate MaerpAnalytics
   bin/console assets:install
   bin/console cache:clear
   ```
4. In the Admin, open **Settings → Extensions → asERP Web Analytics**, enter the asERP server URL and paste
   the tracking token.

## What is captured

Date/time, page URL & title, referrer, hostname, screen/viewport size, scroll depth, language, full UTM
set, ad click ids (gclid, gbraid, wbraid, gad_source, msclkid, fbclid) and the commerce funnel events
(ProductView, AddToBasket, CheckoutBasket, CheckoutPayment, Purchase).
