using System.Text.Json;
using System.Text.Json.Nodes;

namespace asERP.Client.Features.ShippingProviders.Models;

/// <summary>
/// Typed view over <c>ShippingProvider.AdditionalConfigJson</c> so the edit page can offer real
/// input fields instead of a raw JSON box. The schema is owned by the carrier connectors
/// (asERP.Shipping — parsed with web defaults, i.e. case-insensitive), so this editor only
/// touches the keys it knows and preserves everything else verbatim.
/// Empty fields are removed from the JSON so the connector defaults apply.
/// </summary>
public sealed class CarrierConfigEditor
{
    // Sender address — shared by all carriers.
    public string SenderName { get; set; } = string.Empty;
    public string SenderStreet { get; set; } = string.Empty;
    public string SenderZip { get; set; } = string.Empty;
    public string SenderCity { get; set; } = string.Empty;
    public string SenderCountryCode { get; set; } = string.Empty;
    public string SenderEmail { get; set; } = string.Empty;
    public string SenderPhone { get; set; } = string.Empty;

    /// <summary>Default product: DHL "V01PAK", DPD "Classic", GLS "PARCEL" (same JSON key for all three).</summary>
    public string Product { get; set; } = string.Empty;

    // DHL
    public string Procedure { get; set; } = string.Empty;
    public string Participation { get; set; } = string.Empty;
    public string TrackingApiKey { get; set; } = string.Empty;
    public string ReturnReceiverId { get; set; } = string.Empty;
    public string ReturnProcedure { get; set; } = string.Empty;

    // DPD
    public string LabelSize { get; set; } = string.Empty;
    public string ReturnProduct { get; set; } = string.Empty;

    // GLS
    public string ContactId { get; set; } = string.Empty;

    // UPS
    public string ServiceCode { get; set; } = string.Empty;

    private JsonObject _root = new();

    public static CarrierConfigEditor Parse(string? json)
    {
        var editor = new CarrierConfigEditor();

        if (!string.IsNullOrWhiteSpace(json))
        {
            try
            {
                editor._root = JsonNode.Parse(json) as JsonObject ?? new JsonObject();
            }
            catch (JsonException)
            {
                // Broken JSON would also break the connector — starting fresh is the only way the
                // user can repair it from the UI.
                editor._root = new JsonObject();
            }
        }

        var sender = FindObject(editor._root, "Sender");
        editor.SenderName = ReadString(sender, "Name");
        editor.SenderStreet = ReadString(sender, "Street");
        editor.SenderZip = ReadString(sender, "Zip");
        editor.SenderCity = ReadString(sender, "City");
        editor.SenderCountryCode = ReadString(sender, "CountryCode");
        editor.SenderEmail = ReadString(sender, "Email");
        editor.SenderPhone = ReadString(sender, "Phone");

        editor.Product = ReadString(editor._root, "Product");
        editor.Procedure = ReadString(editor._root, "Procedure");
        editor.Participation = ReadString(editor._root, "Participation");
        editor.TrackingApiKey = ReadString(editor._root, "TrackingApiKey");
        editor.ReturnReceiverId = ReadString(editor._root, "ReturnReceiverId");
        editor.ReturnProcedure = ReadString(editor._root, "ReturnProcedure");
        editor.LabelSize = ReadString(editor._root, "LabelSize");
        editor.ReturnProduct = ReadString(editor._root, "ReturnProduct");
        editor.ContactId = ReadString(editor._root, "ContactId");
        editor.ServiceCode = ReadString(editor._root, "ServiceCode");

        return editor;
    }

    /// <summary>Serializes the edited values back, keeping unknown keys. Null when nothing is set.</summary>
    public string? ToJson()
    {
        var sender = FindObject(_root, "Sender");
        if (sender is null)
        {
            sender = new JsonObject();
        }

        WriteString(sender, "Name", SenderName);
        WriteString(sender, "Street", SenderStreet);
        WriteString(sender, "Zip", SenderZip);
        WriteString(sender, "City", SenderCity);
        WriteString(sender, "CountryCode", SenderCountryCode);
        WriteString(sender, "Email", SenderEmail);
        WriteString(sender, "Phone", SenderPhone);

        if (sender.Count > 0)
        {
            if (FindObject(_root, "Sender") is null)
            {
                _root["Sender"] = sender;
            }
        }
        else
        {
            RemoveKey(_root, "Sender");
        }

        WriteString(_root, "Product", Product);
        WriteString(_root, "Procedure", Procedure);
        WriteString(_root, "Participation", Participation);
        WriteString(_root, "TrackingApiKey", TrackingApiKey);
        WriteString(_root, "ReturnReceiverId", ReturnReceiverId);
        WriteString(_root, "ReturnProcedure", ReturnProcedure);
        WriteString(_root, "LabelSize", LabelSize);
        WriteString(_root, "ReturnProduct", ReturnProduct);
        WriteString(_root, "ContactId", ContactId);
        WriteString(_root, "ServiceCode", ServiceCode);

        return _root.Count == 0 ? null : _root.ToJsonString();
    }

    private static string? FindKey(JsonObject obj, string name)
        => obj.FirstOrDefault(kv => string.Equals(kv.Key, name, StringComparison.OrdinalIgnoreCase)).Key;

    private static JsonObject? FindObject(JsonObject obj, string name)
    {
        var key = FindKey(obj, name);
        return key is null ? null : obj[key] as JsonObject;
    }

    private static string ReadString(JsonObject? obj, string name)
    {
        if (obj is null)
        {
            return string.Empty;
        }

        var key = FindKey(obj, name);
        if (key is null)
        {
            return string.Empty;
        }

        return obj[key] is JsonValue value && value.TryGetValue<string>(out var text)
            ? text
            : string.Empty;
    }

    /// <summary>Sets the key (reusing the existing casing) or removes it when the value is blank.</summary>
    private static void WriteString(JsonObject obj, string name, string value)
    {
        var key = FindKey(obj, name);
        if (string.IsNullOrWhiteSpace(value))
        {
            if (key is not null)
            {
                obj.Remove(key);
            }

            return;
        }

        obj[key ?? name] = value.Trim();
    }

    private static void RemoveKey(JsonObject obj, string name)
    {
        var key = FindKey(obj, name);
        if (key is not null)
        {
            obj.Remove(key);
        }
    }
}
