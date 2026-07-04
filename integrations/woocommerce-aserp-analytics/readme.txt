=== asERP Web Analytics ===
Contributors: martinandrich
Tags: analytics, woocommerce, privacy, aserp
Requires at least: 6.0
Requires PHP: 7.4
Stable tag: 1.0.0
License: GPLv2 or later

First-party, privacy-friendly web analytics for WooCommerce, reporting into your asERP server.

== Description ==

This plugin tracks storefront visits and the checkout funnel (product views, add-to-basket, checkout,
purchase) and reports them to your asERP server, where they appear under the sales channel's
"Web-Statistiken" tab.

Privacy & security by design:

* **The tracking token never reaches the browser.** Beacons are sent same-origin to this site
  (`/wp-json/aserp/v1/c`) and proxied to asERP server-side, where the secret token is added. Page source
  and network traffic never expose the token or the asERP URL.
* **No cookies.** A random first-party visitor id is kept in `localStorage` for visitor continuity.
* **IPs are masked** server-side in asERP; the raw IP is only used transiently to compute a daily-rotating
  session hash (and is never stored).
* **Logged-in customers** are tracked under a pseudonymised reference (an HMAC of the customer id) so asERP
  can attribute product views to a customer without the raw number leaving your server.

== Installation ==

1. In asERP, open the WooCommerce sales channel → Web analytics → generate a tracking token.
2. Upload the `woocommerce-aserp-analytics` folder to `/wp-content/plugins/` and activate it.
3. Go to **Settings → asERP Analytics**, enter your asERP server URL and paste the tracking token.
4. Save. Visits start reporting immediately.

== What is captured ==

Date/time, page URL & title, referrer, hostname, screen/viewport size, scroll depth, language, full UTM
set, Google/Microsoft/Meta ad click ids (gclid, gbraid, wbraid, gad_source, msclkid, fbclid), and the
commerce funnel events (ProductView, AddToBasket, CheckoutBasket, CheckoutPayment, Purchase).

== Changelog ==

= 1.0.0 =
* Initial release.
