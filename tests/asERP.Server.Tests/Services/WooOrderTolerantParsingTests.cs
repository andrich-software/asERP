using System.Text.Json;
using asERP.SalesChannels.Models.WooCommerce;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Services;

/// <summary>
/// Reproduces the WooCommerce import stall: one order in a page carries an empty-string numeric
/// field, which made WooCommerceNET throw "The value '' cannot be parsed as the type 'UInt64'"
/// and abort the entire 100-order page. The tolerant DTO parser must read the whole page, mapping
/// blank numerics to null.
/// </summary>
public class WooOrderTolerantParsingTests
{
    [Fact]
    public void Deserialize_PageWithEmptyStringNumerics_DoesNotThrowAndYieldsAllOrders()
    {
        // Order 2 mimics the offending payload: empty-string id-like / customer_id / total and a
        // line item with an empty-string quantity. WooCommerceNET would throw on this whole array.
        const string json = """
        [
          {
            "id": 6907879,
            "status": "completed",
            "customer_id": 69697,
            "total": "69.50",
            "total_tax": "11.10",
            "shipping_total": "4.90",
            "date_created_gmt": "2026-06-13T06:34:58",
            "billing": { "first_name": "Anna", "email": "anna@example.com", "country": "DE" },
            "line_items": [
              { "name": "Stoff A", "sku": "SKU-A", "quantity": 2, "price": 27.30, "subtotal": "54.60", "subtotal_tax": "10.37" }
            ]
          },
          {
            "id": 6907880,
            "status": "processing",
            "customer_id": "",
            "parent_id": "",
            "total": "39.25",
            "total_tax": "",
            "shipping_total": "",
            "date_created_gmt": "2026-06-13T07:00:00",
            "date_paid_gmt": "",
            "billing": { "first_name": "Guest", "email": "guest@example.com", "country": "AT" },
            "line_items": [
              { "name": "Stoff B", "sku": "SKU-B", "quantity": "", "price": 39.25, "subtotal": "39.25", "subtotal_tax": "" }
            ]
          }
        ]
        """;

        var orders = JsonSerializer.Deserialize<List<WooOrder>>(json, WooJson.Options);

        TestAssertions.AssertNotNull(orders);
        TestAssertions.AssertEqual(2, orders!.Count);

        // Order 1 — normal values parse, totals-as-strings become decimals.
        var first = orders[0];
        TestAssertions.AssertEqual(6907879L, first.id!.Value);
        TestAssertions.AssertEqual(69697L, first.customer_id!.Value);
        TestAssertions.AssertEqual(69.50m, first.total!.Value);
        TestAssertions.AssertEqual(2m, first.line_items![0].quantity!.Value);

        // Order 2 — the previously fatal empty strings become null instead of throwing.
        var second = orders[1];
        TestAssertions.AssertEqual(6907880L, second.id!.Value);
        TestAssertions.AssertTrue(second.customer_id is null);
        TestAssertions.AssertTrue(second.total_tax is null);
        TestAssertions.AssertTrue(second.shipping_total is null);
        TestAssertions.AssertTrue(second.date_paid_gmt is null);
        TestAssertions.AssertEqual(39.25m, second.total!.Value);
        TestAssertions.AssertTrue(second.line_items![0].quantity is null);
        TestAssertions.AssertEqual("SKU-B", second.line_items![0].sku);
    }

    [Fact]
    public void Deserialize_EmptyArray_ReturnsEmptyList()
    {
        var orders = JsonSerializer.Deserialize<List<WooOrder>>("[]", WooJson.Options);

        TestAssertions.AssertNotNull(orders);
        TestAssertions.AssertEqual(0, orders!.Count);
    }
}
