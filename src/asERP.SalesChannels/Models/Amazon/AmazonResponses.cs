using System.Text.Json.Serialization;

namespace asERP.SalesChannels.Models.Amazon;

// Minimal subset of the SP-API JSON contract we need. The full schemas are huge; we lift only
// the fields the connector reads. New fields can be added as we wire up more operations.
//
// The [JsonPropertyName] values below are WIRE CONTRACTS — they must match the real SP-API
// property names ("Orders", "AmazonOrderId", "OrderStatus", ...). An earlier mechanical
// Order→Sales rename corrupted them and silently broke every import. The C# member names keep
// the project's "Sales" naming; only the wire names are pinned to Amazon's schema.

public sealed class AmazonLwaTokenResponse
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;
    [JsonPropertyName("refresh_token")] public string? RefreshToken { get; set; }
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = string.Empty;
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}

public sealed class AmazonSalessResponse
{
    [JsonPropertyName("payload")] public AmazonSalessPayload? Payload { get; set; }
}

public sealed class AmazonSalessPayload
{
    [JsonPropertyName("Orders")] public List<AmazonSales> Saless { get; set; } = new();
    [JsonPropertyName("NextToken")] public string? NextToken { get; set; }
}

public sealed class AmazonSales
{
    [JsonPropertyName("AmazonOrderId")] public string AmazonSalesId { get; set; } = string.Empty;
    [JsonPropertyName("PurchaseDate")] public DateTime PurchaseDate { get; set; }
    [JsonPropertyName("OrderStatus")] public string SalesStatus { get; set; } = string.Empty;
    [JsonPropertyName("OrderTotal")] public AmazonMoney? SalesTotal { get; set; }
    [JsonPropertyName("BuyerInfo")] public AmazonBuyerInfo? BuyerInfo { get; set; }
    [JsonPropertyName("ShippingAddress")] public AmazonAddress? ShippingAddress { get; set; }
}

public sealed class AmazonMoney
{
    [JsonPropertyName("CurrencyCode")] public string CurrencyCode { get; set; } = string.Empty;
    [JsonPropertyName("Amount")] public string Amount { get; set; } = "0";
}

public sealed class AmazonBuyerInfo
{
    [JsonPropertyName("BuyerEmail")] public string? BuyerEmail { get; set; }
    [JsonPropertyName("BuyerName")] public string? BuyerName { get; set; }
}

public sealed class AmazonAddress
{
    [JsonPropertyName("Name")] public string? Name { get; set; }
    [JsonPropertyName("AddressLine1")] public string? AddressLine1 { get; set; }
    [JsonPropertyName("City")] public string? City { get; set; }
    [JsonPropertyName("PostalCode")] public string? PostalCode { get; set; }
    [JsonPropertyName("CountryCode")] public string? CountryCode { get; set; }
    [JsonPropertyName("Phone")] public string? Phone { get; set; }
}

// getOrderItems response: GET /orders/v0/orders/{orderId}/orderItems
public sealed class AmazonSalesItemsResponse
{
    [JsonPropertyName("payload")] public AmazonSalesItemsPayload? Payload { get; set; }
}

public sealed class AmazonSalesItemsPayload
{
    [JsonPropertyName("AmazonOrderId")] public string AmazonSalesId { get; set; } = string.Empty;
    [JsonPropertyName("OrderItems")] public List<AmazonSalesItem> SalesItems { get; set; } = new();
    [JsonPropertyName("NextToken")] public string? NextToken { get; set; }
}

public sealed class AmazonSalesItem
{
    [JsonPropertyName("OrderItemId")] public string SalesItemId { get; set; } = string.Empty;
    [JsonPropertyName("SellerSKU")] public string? SellerSku { get; set; }
    [JsonPropertyName("ASIN")] public string? Asin { get; set; }
    [JsonPropertyName("Title")] public string? Title { get; set; }
    [JsonPropertyName("QuantityOrdered")] public int QuantityOrdered { get; set; }
    [JsonPropertyName("ItemPrice")] public AmazonMoney? ItemPrice { get; set; }
    [JsonPropertyName("ItemTax")] public AmazonMoney? ItemTax { get; set; }
}
