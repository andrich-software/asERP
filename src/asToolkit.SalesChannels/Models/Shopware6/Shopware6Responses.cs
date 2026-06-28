using System.Text.Json.Serialization;

namespace asToolkit.SalesChannels.Models.Shopware6;

// Minimal Shopware 6 Admin-API DTOs. We lift just the fields the connector reads/writes;
// new ones can be added without breaking serialization (System.Text.Json ignores extras).

public sealed class Sw6OAuthTokenResponse
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = string.Empty;
    [JsonPropertyName("token_type")] public string TokenType { get; set; } = string.Empty;
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }
}

public sealed class Sw6SearchResult<T>
{
    [JsonPropertyName("data")] public List<T> Data { get; set; } = new();
    [JsonPropertyName("total")] public int Total { get; set; }
}

public sealed class Sw6Product
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("parentId")] public string? ParentId { get; set; }
    [JsonPropertyName("childCount")] public int? ChildCount { get; set; }
    [JsonPropertyName("productNumber")] public string? ProductNumber { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("ean")] public string? Ean { get; set; }
    [JsonPropertyName("manufacturerNumber")] public string? ManufacturerNumber { get; set; }
    [JsonPropertyName("stock")] public int? Stock { get; set; }
    // Null on variants that inherit the parent price (Shopware field inheritance)
    [JsonPropertyName("price")] public List<Sw6Price>? Price { get; set; }
    [JsonPropertyName("translated")] public Sw6Translated? Translated { get; set; }
    [JsonPropertyName("options")] public List<Sw6PropertyGroupOption>? Options { get; set; }
    // Photo gallery: each entry is a product↔media join; the actual file lives on its nested Media.
    [JsonPropertyName("media")] public List<Sw6ProductMedia>? Media { get; set; }
    // The featured image (also one of the Media entries); promoted to the primary photo on import.
    [JsonPropertyName("cover")] public Sw6ProductMedia? Cover { get; set; }
}

public sealed class Sw6ProductMedia
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("position")] public int? Position { get; set; }
    [JsonPropertyName("media")] public Sw6Media? Media { get; set; }
}

public sealed class Sw6Media
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    // Public CDN URL of the original file — what the import downloads.
    [JsonPropertyName("url")] public string? Url { get; set; }
    [JsonPropertyName("alt")] public string? Alt { get; set; }
    [JsonPropertyName("fileName")] public string? FileName { get; set; }
}

public sealed class Sw6PropertyGroupOption
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("translated")] public Sw6Translated? Translated { get; set; }
    [JsonPropertyName("group")] public Sw6PropertyGroup? Group { get; set; }
}

public sealed class Sw6PropertyGroup
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("translated")] public Sw6Translated? Translated { get; set; }
}

public sealed class Sw6Translated
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
}

public sealed class Sw6Price
{
    [JsonPropertyName("gross")] public decimal Gross { get; set; }
    [JsonPropertyName("net")] public decimal Net { get; set; }
    [JsonPropertyName("currencyId")] public string? CurrencyId { get; set; }
}

public sealed class Sw6Sales
{
    [JsonPropertyName("id")] public string Id { get; set; } = string.Empty;
    [JsonPropertyName("salesNumber")] public string? SalesNumber { get; set; }
    [JsonPropertyName("salesDateTime")] public DateTime SalesDateTime { get; set; }
    [JsonPropertyName("amountTotal")] public decimal AmountTotal { get; set; }
    [JsonPropertyName("amountNet")] public decimal AmountNet { get; set; }
    [JsonPropertyName("shippingTotal")] public decimal ShippingTotal { get; set; }
    [JsonPropertyName("salesCustomer")] public Sw6SalesCustomer? SalesCustomer { get; set; }
    [JsonPropertyName("billingAddress")] public Sw6Address? BillingAddress { get; set; }
    [JsonPropertyName("deliveries")] public List<Sw6Delivery> Deliveries { get; set; } = new();
    [JsonPropertyName("lineItems")] public List<Sw6LineItem> LineItems { get; set; } = new();
    [JsonPropertyName("stateMachineState")] public Sw6StateMachineState? StateMachineState { get; set; }
}

public sealed class Sw6SalesCustomer
{
    [JsonPropertyName("email")] public string? Email { get; set; }
    [JsonPropertyName("firstName")] public string? FirstName { get; set; }
    [JsonPropertyName("lastName")] public string? LastName { get; set; }
    [JsonPropertyName("company")] public string? Company { get; set; }
    [JsonPropertyName("customerId")] public string? CustomerId { get; set; }
}

public sealed class Sw6Address
{
    [JsonPropertyName("firstName")] public string? FirstName { get; set; }
    [JsonPropertyName("lastName")] public string? LastName { get; set; }
    [JsonPropertyName("company")] public string? Company { get; set; }
    [JsonPropertyName("street")] public string? Street { get; set; }
    [JsonPropertyName("zipcode")] public string? Zipcode { get; set; }
    [JsonPropertyName("city")] public string? City { get; set; }
    [JsonPropertyName("phoneNumber")] public string? PhoneNumber { get; set; }
    [JsonPropertyName("country")] public Sw6Country? Country { get; set; }
}

public sealed class Sw6Country
{
    [JsonPropertyName("iso")] public string? Iso { get; set; }
}

public sealed class Sw6Delivery
{
    [JsonPropertyName("shippingSalesAddress")] public Sw6Address? ShippingSalesAddress { get; set; }
}

public sealed class Sw6LineItem
{
    [JsonPropertyName("label")] public string? Label { get; set; }
    [JsonPropertyName("payload")] public Sw6LineItemPayload? Payload { get; set; }
    [JsonPropertyName("quantity")] public int Quantity { get; set; }
    [JsonPropertyName("unitPrice")] public decimal UnitPrice { get; set; }
    [JsonPropertyName("totalPrice")] public decimal TotalPrice { get; set; }
}

public sealed class Sw6LineItemPayload
{
    [JsonPropertyName("productNumber")] public string? ProductNumber { get; set; }
    [JsonPropertyName("ean")] public string? Ean { get; set; }
    [JsonPropertyName("taxId")] public string? TaxId { get; set; }
}

public sealed class Sw6StateMachineState
{
    [JsonPropertyName("technicalName")] public string? TechnicalName { get; set; }
}
