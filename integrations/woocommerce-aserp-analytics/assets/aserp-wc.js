/*
 * asERP WooCommerce glue — fires commerce funnel events on top of the core tracker.
 * Depends on window.aserpTrack (core) and, for add-to-cart, jQuery (shipped by WooCommerce).
 */
(function () {
  "use strict";

  function track(type, extra) {
    if (window.aserpTrack && typeof window.aserpTrack.event === "function") {
      window.aserpTrack.event(type, extra || {});
    }
  }

  // Funnel step from the WooCommerce body classes added to cart / checkout / thank-you pages.
  function funnelStep() {
    var c = document.body ? document.body.classList : null;
    if (!c) { return null; }
    if (c.contains("woocommerce-order-received")) { return "Purchase"; }
    if (c.contains("woocommerce-checkout")) { return "CheckoutPayment"; }
    if (c.contains("woocommerce-cart")) { return "CheckoutBasket"; }
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

  // AJAX add-to-cart (WooCommerce fires this jQuery event on the body).
  if (window.jQuery) {
    window.jQuery(document.body).on("added_to_cart", function (event, fragments, cartHash, $button) {
      var ref = "";
      try {
        if ($button && $button.data) { ref = String($button.data("product_id") || ""); }
      } catch (e) { /* ignore */ }
      track("AddToBasket", { productRef: ref });
    });
  }
})();
