/*
 * asERP storefront tracker — asShop (built-in) variant of the canonical core
 * (integrations/…/aserp-s.js). Differences to the plugin-served core:
 *  - No plugin proxy: beacons POST to the same-origin /asshop/e collector; the server resolves the
 *    channel + tenant from the request's Host header (ShopHostMiddleware binding). No token exists
 *    anywhere in this flow.
 *  - No inline config (the shop CSP is script-src 'self'): the endpoint is fixed, and optional page
 *    context (product data) comes from a non-executable JSON data block
 *    <script type="application/json" id="aserp-ctx">{"product":{"ref":"...","name":"...","value":0,"currency":"EUR"}}</script>
 *    which pages render server-side.
 *
 * Privacy model is unchanged: no cookies; a random first-party visitor id (vid) in localStorage for
 * visitor continuity; IP/User-Agent are only used transiently server-side (session hash + masking).
 */
(function () {
  "use strict";

  var ENDPOINT = "/asshop/e";
  var VID_KEY = "aserp_vid";

  var ctx = {};
  try {
    var ctxEl = document.getElementById("aserp-ctx");
    if (ctxEl) { ctx = JSON.parse(ctxEl.textContent) || {}; }
  } catch (e) { ctx = {}; }

  function uuid() {
    try {
      if (window.crypto && crypto.randomUUID) { return crypto.randomUUID(); }
    } catch (e) { /* fall through */ }
    return "xxxxxxxxxxxx4xxxyxxxxxxxxxxxxxxx".replace(/[xy]/g, function (c) {
      var r = (Math.random() * 16) | 0;
      var v = c === "x" ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }

  var vid;
  try {
    vid = localStorage.getItem(VID_KEY);
    if (!vid) { vid = uuid(); localStorage.setItem(VID_KEY, vid); }
  } catch (e) { vid = uuid(); }

  function qp(name) {
    try {
      return new URLSearchParams(window.location.search).get(name) || "";
    } catch (e) { return ""; }
  }

  var maxScroll = 0;
  function computeScroll() {
    try {
      var doc = document.documentElement;
      var height = (doc.scrollHeight || document.body.scrollHeight) - window.innerHeight;
      if (height <= 0) { return 100; }
      var pct = Math.round((window.scrollY / height) * 100);
      if (pct > maxScroll) { maxScroll = Math.min(100, Math.max(0, pct)); }
    } catch (e) { /* ignore */ }
    return maxScroll;
  }

  var scrollTimer = null;
  window.addEventListener("scroll", function () {
    if (scrollTimer) { return; }
    scrollTimer = setTimeout(function () { scrollTimer = null; computeScroll(); }, 500);
  }, { passive: true });

  function basePayload() {
    return {
      vid: vid,
      url: window.location.href,
      path: window.location.pathname,
      title: document.title || "",
      referrer: document.referrer || "",
      hostname: window.location.hostname,
      language: navigator.language || "",
      screenWidth: screen.width || 0,
      screenHeight: screen.height || 0,
      viewportWidth: window.innerWidth || 0,
      viewportHeight: window.innerHeight || 0,
      scrollDepth: maxScroll,
      utmSource: qp("utm_source"),
      utmMedium: qp("utm_medium"),
      utmCampaign: qp("utm_campaign"),
      utmTerm: qp("utm_term"),
      utmContent: qp("utm_content"),
      gclid: qp("gclid"),
      gbraid: qp("gbraid"),
      wbraid: qp("wbraid"),
      gadSource: qp("gad_source"),
      msclkid: qp("msclkid"),
      fbclid: qp("fbclid")
    };
  }

  function send(payload) {
    try {
      var body = JSON.stringify(payload);
      if (navigator.sendBeacon) {
        navigator.sendBeacon(ENDPOINT, new Blob([body], { type: "application/json" }));
        return;
      }
      fetch(ENDPOINT, {
        method: "POST",
        body: body,
        headers: { "Content-Type": "application/json" },
        keepalive: true,
        credentials: "same-origin"
      });
    } catch (e) { /* never break the page over analytics */ }
  }

  function track(eventType, extra) {
    var p = basePayload();
    p.eventType = eventType || "PageView";
    if (extra) {
      for (var k in extra) {
        if (Object.prototype.hasOwnProperty.call(extra, k)) { p[k] = extra[k]; }
      }
    }
    send(p);
  }

  // Public API for shop components to fire commerce events (AddToBasket, CheckoutPayment, ...).
  window.aserpTrack = { event: track };

  // Initial hit: ProductView when product context is present, otherwise PageView.
  function initialHit() {
    computeScroll();
    if (ctx.product && ctx.product.ref) {
      track("ProductView", {
        productRef: String(ctx.product.ref),
        productName: ctx.product.name || "",
        value: ctx.product.value || 0,
        currency: ctx.product.currency || ""
      });
    } else {
      track("PageView");
    }
  }

  if (document.readyState === "complete" || document.readyState === "interactive") {
    initialHit();
  } else {
    window.addEventListener("DOMContentLoaded", initialHit);
  }

  // Capture final scroll depth when the user leaves the page. Sent as a Custom event so it never
  // inflates PageView/ProductView counts (sessions are de-duplicated by session id regardless).
  var scrollSent = false;
  window.addEventListener("visibilitychange", function () {
    if (document.visibilityState === "hidden" && maxScroll > 0 && !scrollSent) {
      scrollSent = true;
      track("Custom", { eventName: "scroll", scrollDepth: maxScroll });
    }
  });
})();
