using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace asERP.SalesChannels.Models.WooCommerce;

// Tolerant DTOs for the WooCommerce REST "orders" endpoint. We parse the raw JSON ourselves
// instead of using WooCommerceNET's deserializer because the latter throws
// "The value '' cannot be parsed as the type 'UInt64'" when the API returns an empty string for
// a numeric field on a single order — which aborts the whole 100-order page and stalls the import.
// The converters below treat empty/blank strings as null and accept both JSON numbers and strings.

public sealed class WooOrder
{
    public long? id { get; set; }
    public string? status { get; set; }
    public long? customer_id { get; set; }
    public string? customer_note { get; set; }
    public DateTime? date_created { get; set; }
    public DateTime? date_created_gmt { get; set; }
    public DateTime? date_paid { get; set; }
    public DateTime? date_paid_gmt { get; set; }
    public string? payment_method { get; set; }
    public string? payment_method_title { get; set; }
    public string? transaction_id { get; set; }
    public decimal? total { get; set; }
    public decimal? total_tax { get; set; }
    public decimal? shipping_total { get; set; }
    public WooAddress? billing { get; set; }
    public WooAddress? shipping { get; set; }
    public List<WooLineItem>? line_items { get; set; }
}

public sealed class WooAddress
{
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public string? company { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address_1 { get; set; }
    public string? city { get; set; }
    public string? postcode { get; set; }
    public string? country { get; set; }
}

public sealed class WooLineItem
{
    public string? name { get; set; }
    public string? sku { get; set; }
    public decimal? quantity { get; set; }
    public decimal? price { get; set; }
    public decimal? subtotal { get; set; }
    public decimal? subtotal_tax { get; set; }
}

public static class WooJson
{
    public static readonly JsonSerializerOptions Options = BuildOptions();

    private static JsonSerializerOptions BuildOptions()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        options.Converters.Add(new TolerantInt64Converter());
        options.Converters.Add(new TolerantDecimalConverter());
        options.Converters.Add(new TolerantDateTimeConverter());
        return options;
    }
}

/// <summary>Reads a nullable long from a JSON number or string; blank/empty string → null.</summary>
public sealed class TolerantInt64Converter : JsonConverter<long?>
{
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return reader.TryGetInt64(out var n) ? n : (long?)reader.GetDouble();
            case JsonTokenType.String:
                var s = reader.GetString();
                if (string.IsNullOrWhiteSpace(s)) return null;
                return long.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed) ? parsed : null;
            default:
                reader.Skip();
                return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
        if (value.HasValue) writer.WriteNumberValue(value.Value);
        else writer.WriteNullValue();
    }
}

/// <summary>Reads a nullable decimal from a JSON number or string; blank/empty string → null.</summary>
public sealed class TolerantDecimalConverter : JsonConverter<decimal?>
{
    public override decimal? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return reader.GetDecimal();
            case JsonTokenType.String:
                var s = reader.GetString();
                if (string.IsNullOrWhiteSpace(s)) return null;
                return decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsed) ? parsed : null;
            default:
                reader.Skip();
                return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, decimal? value, JsonSerializerOptions options)
    {
        if (value.HasValue) writer.WriteNumberValue(value.Value);
        else writer.WriteNullValue();
    }
}

/// <summary>Reads a nullable DateTime from an ISO-8601 string; blank/empty string → null.</summary>
public sealed class TolerantDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var s = reader.GetString();
            if (string.IsNullOrWhiteSpace(s)) return null;
            return DateTime.TryParse(s, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsed)
                ? parsed
                : null;
        }

        reader.Skip();
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue) writer.WriteStringValue(value.Value);
        else writer.WriteNullValue();
    }
}
