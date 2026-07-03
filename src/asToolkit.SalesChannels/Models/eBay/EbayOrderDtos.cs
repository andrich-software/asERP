#nullable disable

using System.Text.Json.Serialization;

namespace asToolkit.SalesChannels.Models.eBay;

/// <summary>
/// DTOs for the eBay Sell Fulfillment API (<c>GET /sell/fulfillment/v1/order</c>). The page
/// envelope carries <c>orders</c> + offset paging fields; each order holds its own buyer,
/// pricing summary and line items. Property names mirror the eBay API exactly — the
/// domain-side "Sales" naming starts at the mapping layer, not here.
/// </summary>
public class EbayOrdersResponse
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("limit")]
    public int Limit { get; set; }

    [JsonPropertyName("offset")]
    public int Offset { get; set; }

    [JsonPropertyName("orders")]
    public EbayOrder[] Orders { get; set; }
}

public class EbayOrder
{
    [JsonPropertyName("orderId")]
    public string OrderId { get; set; }

    [JsonPropertyName("legacyOrderId")]
    public string LegacyOrderId { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonPropertyName("lastModifiedDate")]
    public DateTime LastModifiedDate { get; set; }

    /// <summary>NOT_STARTED | IN_PROGRESS | FULFILLED</summary>
    [JsonPropertyName("orderFulfillmentStatus")]
    public string OrderFulfillmentStatus { get; set; }

    /// <summary>PENDING | PAID | FAILED | PARTIALLY_REFUNDED | FULLY_REFUNDED</summary>
    [JsonPropertyName("orderPaymentStatus")]
    public string OrderPaymentStatus { get; set; }

    [JsonPropertyName("sellerId")]
    public string SellerId { get; set; }

    [JsonPropertyName("buyer")]
    public EbayBuyer Buyer { get; set; }

    [JsonPropertyName("buyerCheckoutNotes")]
    public string BuyerCheckoutNotes { get; set; }

    [JsonPropertyName("cancelStatus")]
    public EbayCancelStatus CancelStatus { get; set; }

    [JsonPropertyName("pricingSummary")]
    public EbayPricingSummary PricingSummary { get; set; }

    [JsonPropertyName("fulfillmentStartInstructions")]
    public EbayFulfillmentStartInstruction[] FulfillmentStartInstructions { get; set; }

    [JsonPropertyName("lineItems")]
    public EbayLineItem[] LineItems { get; set; }
}

public class EbayBuyer
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>Tax jurisdiction only (city/state/zip/country) — no name, email or phone.</summary>
    [JsonPropertyName("taxAddress")]
    public EbayTaxAddress TaxAddress { get; set; }

    /// <summary>The buyer's registration contact — the only place name/email/phone live on an order.</summary>
    [JsonPropertyName("buyerRegistrationAddress")]
    public EbayOrderContact BuyerRegistrationAddress { get; set; }
}

public class EbayTaxAddress
{
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("stateOrProvince")]
    public string StateOrProvince { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}

/// <summary>Shared shape of <c>buyerRegistrationAddress</c> and <c>shippingStep.shipTo</c>.</summary>
public class EbayOrderContact
{
    [JsonPropertyName("fullName")]
    public string FullName { get; set; }

    [JsonPropertyName("companyName")]
    public string CompanyName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("primaryPhone")]
    public EbayPhone PrimaryPhone { get; set; }

    [JsonPropertyName("contactAddress")]
    public EbayContactAddress ContactAddress { get; set; }
}

public class EbayPhone
{
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }
}

public class EbayContactAddress
{
    [JsonPropertyName("addressLine1")]
    public string AddressLine1 { get; set; }

    [JsonPropertyName("addressLine2")]
    public string AddressLine2 { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("stateOrProvince")]
    public string StateOrProvince { get; set; }

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; set; }
}

public class EbayCancelStatus
{
    /// <summary>NONE_REQUESTED | CANCELED | ...</summary>
    [JsonPropertyName("cancelState")]
    public string CancelState { get; set; }
}

public class EbayPricingSummary
{
    [JsonPropertyName("priceSubtotal")]
    public EbayAmount PriceSubtotal { get; set; }

    [JsonPropertyName("deliveryCost")]
    public EbayAmount DeliveryCost { get; set; }

    [JsonPropertyName("tax")]
    public EbayAmount Tax { get; set; }

    [JsonPropertyName("total")]
    public EbayAmount Total { get; set; }
}

public class EbayAmount
{
    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class EbayFulfillmentStartInstruction
{
    [JsonPropertyName("fulfillmentInstructionsType")]
    public string FulfillmentInstructionsType { get; set; }

    [JsonPropertyName("shippingStep")]
    public EbayShippingStep ShippingStep { get; set; }
}

public class EbayShippingStep
{
    [JsonPropertyName("shippingCarrierCode")]
    public string ShippingCarrierCode { get; set; }

    [JsonPropertyName("shippingServiceCode")]
    public string ShippingServiceCode { get; set; }

    [JsonPropertyName("shipTo")]
    public EbayOrderContact ShipTo { get; set; }
}

public class EbayLineItem
{
    [JsonPropertyName("lineItemId")]
    public string LineItemId { get; set; }

    [JsonPropertyName("legacyItemId")]
    public string LegacyItemId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("sku")]
    public string Sku { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    /// <summary>Selling price for the full line quantity (excl. delivery and tax).</summary>
    [JsonPropertyName("lineItemCost")]
    public EbayAmount LineItemCost { get; set; }

    [JsonPropertyName("total")]
    public EbayAmount Total { get; set; }

    [JsonPropertyName("taxes")]
    public EbayLineItemTax[] Taxes { get; set; }
}

public class EbayLineItemTax
{
    [JsonPropertyName("amount")]
    public EbayAmount Amount { get; set; }
}
