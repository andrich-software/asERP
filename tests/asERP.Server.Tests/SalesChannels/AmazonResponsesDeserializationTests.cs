using System.Text.Json;
using asERP.SalesChannels.Models.Amazon;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// Regression guard for the Amazon SP-API wire contract. The connector's DTOs use the project's
/// "Sales" naming for their C# members, but their <c>[JsonPropertyName]</c> values MUST stay pinned
/// to Amazon's real property names ("Orders", "AmazonOrderId", "OrderStatus", "OrderTotal",
/// "OrderItems", ...). A mechanical Order→Sales rename once corrupted these and silently broke every
/// import (each call 404'd or deserialized to empty lists). These fixtures fail loudly if that
/// happens again.
/// </summary>
public class AmazonResponsesDeserializationTests
{
    // Shape mirrors GET /orders/v0/orders — real SP-API property names.
    private const string OrdersFixture = """
    {
      "payload": {
        "Orders": [
          {
            "AmazonOrderId": "111-2222222-3333333",
            "PurchaseDate": "2026-06-01T10:15:00Z",
            "OrderStatus": "Shipped",
            "OrderTotal": { "CurrencyCode": "EUR", "Amount": "119.00" },
            "BuyerInfo": { "BuyerEmail": "buyer@example.com", "BuyerName": "Jane Doe" },
            "ShippingAddress": {
              "Name": "Jane Doe",
              "AddressLine1": "Main St 1",
              "City": "Berlin",
              "PostalCode": "10115",
              "CountryCode": "DE",
              "Phone": "+49 30 1234"
            }
          }
        ],
        "NextToken": "abc123"
      }
    }
    """;

    // Shape mirrors GET /orders/v0/orders/{id}/orderItems — real SP-API property names.
    private const string OrderItemsFixture = """
    {
      "payload": {
        "AmazonOrderId": "111-2222222-3333333",
        "OrderItems": [
          {
            "OrderItemId": "item-1",
            "SellerSKU": "SKU-1",
            "ASIN": "B00TEST",
            "Title": "Test Product",
            "QuantityOrdered": 2,
            "ItemPrice": { "CurrencyCode": "EUR", "Amount": "100.00" },
            "ItemTax": { "CurrencyCode": "EUR", "Amount": "19.00" }
          }
        ],
        "NextToken": "next-items"
      }
    }
    """;

    [Fact]
    public void OrdersResponse_DeserializesRealWireNames()
    {
        var response = JsonSerializer.Deserialize<AmazonSalessResponse>(OrdersFixture);

        Assert.NotNull(response);
        Assert.NotNull(response!.Payload);
        Assert.Equal("abc123", response.Payload!.NextToken);

        var order = Assert.Single(response.Payload.Saless);
        Assert.Equal("111-2222222-3333333", order.AmazonSalesId);
        Assert.Equal("Shipped", order.SalesStatus);
        Assert.Equal("119.00", order.SalesTotal?.Amount);
        Assert.Equal("EUR", order.SalesTotal?.CurrencyCode);
        Assert.Equal("buyer@example.com", order.BuyerInfo?.BuyerEmail);
        Assert.Equal("Jane Doe", order.BuyerInfo?.BuyerName);
        Assert.Equal("Main St 1", order.ShippingAddress?.AddressLine1);
        Assert.Equal("Berlin", order.ShippingAddress?.City);
        Assert.Equal("10115", order.ShippingAddress?.PostalCode);
        Assert.Equal("DE", order.ShippingAddress?.CountryCode);
    }

    [Fact]
    public void OrderItemsResponse_DeserializesRealWireNames()
    {
        var response = JsonSerializer.Deserialize<AmazonSalesItemsResponse>(OrderItemsFixture);

        Assert.NotNull(response);
        Assert.NotNull(response!.Payload);
        Assert.Equal("next-items", response.Payload!.NextToken);
        Assert.Equal("111-2222222-3333333", response.Payload.AmazonSalesId);

        var item = Assert.Single(response.Payload.SalesItems);
        Assert.Equal("item-1", item.SalesItemId);
        Assert.Equal("SKU-1", item.SellerSku);
        Assert.Equal("B00TEST", item.Asin);
        Assert.Equal("Test Product", item.Title);
        Assert.Equal(2, item.QuantityOrdered);
        Assert.Equal("100.00", item.ItemPrice?.Amount);
        Assert.Equal("19.00", item.ItemTax?.Amount);
    }
}
