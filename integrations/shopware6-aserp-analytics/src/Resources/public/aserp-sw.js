/*
 * asERP Shopware 6 glue — fires commerce funnel events on top of the core tracker.
 * Depends on window.aserpTrack (core). Best-effort detection via URL + add-to-cart form submits.
 */
(function () {
  "use strict";

  function track(type, extra) {
    if (window.aserpTrack && typeof window.aserpTrack.event === "function") {
      window.aserpTrack.event(type, extra || {});
    }
  }

  // Funnel step from the Shopware checkout URL structure.
  function funnelStep() {
    var p = window.location.pathname;
    if (p.indexOf("/checkout/finish") !== -1) { return "Purchase"; }
    if (p.indexOf("/checkout/confirm") !== -1) { return "CheckoutPayment"; }
    if (p.indexOf("/checkout/cart") !== -1) { return "CheckoutBasket"; }
    return null;
  }

  function emitFunnel() {
    var step = funnelStep();
    if (step) { track(step); }
  }

  if (document.readyState === "complete" || document.readyState === "interactive") {
    emitFunnel();
  } else {
    window.addEventListener("DOMContentLoaded", emitFunnel);
  }

  // Add-to-cart: Shopware posts a form to /checkout/line-item/add. Capture on the bubbling submit.
  document.addEventListener("submit", function (e) {
    var form = e.target;
    try {
      if (form && form.action && form.action.indexOf("line-item/add") !== -1) {
        var ref = "";
        var input = form.querySelector('input[name$="[id]"]');
        if (input) { ref = input.value; }
        track("AddToBasket", { productRef: ref });
      }
    } catch (err) { /* ignore */ }
  }, true);
})();
