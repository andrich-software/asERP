namespace asToolkit.Domain.Enums;

/// <summary>
/// Visitor-behaviour events captured by the sales-channel web tracker.
/// New funnel steps can be appended; <c>Custom</c> carries a free-form name in the beacon.
/// Stored as the string name in ClickHouse so values stay readable and stable across renames.
/// </summary>
public enum WebAnalyticsEventType
{
    /// <summary>A page was viewed (the default beacon emitted on every navigation).</summary>
    PageView = 1,

    /// <summary>A product detail page was viewed — carries the product reference.</summary>
    ProductView = 2,

    /// <summary>An on-site search was performed.</summary>
    Search = 3,

    /// <summary>A product was added to the basket.</summary>
    AddToBasket = 10,

    /// <summary>A product was removed from the basket.</summary>
    RemoveFromBasket = 11,

    /// <summary>The basket / cart page was opened (checkout funnel step 1).</summary>
    CheckoutBasket = 20,

    /// <summary>The delivery/shipping step was reached (checkout funnel step 2).</summary>
    CheckoutDelivery = 21,

    /// <summary>The payment step was reached (checkout funnel step 3).</summary>
    CheckoutPayment = 22,

    /// <summary>An order was placed / purchase completed.</summary>
    Purchase = 30,

    /// <summary>A custom event; the concrete name is carried in the beacon's event name field.</summary>
    Custom = 99
}
