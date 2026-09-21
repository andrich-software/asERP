using System.Text.Json;
using System.Text.Json.Nodes;

namespace asERP.Application.Services;

/// <summary>
/// Read/write protection for the secret-bearing keys inside a free-form config JSON blob such as
/// <c>ShippingProvider.AdditionalConfigJson</c>. The blob is edited as a whole by the client, so a
/// secret cannot simply be dropped on read — it is replaced by the constant
/// <see cref="RedactedValue"/> and merged back over the stored blob on write:
/// <list type="bullet">
/// <item>value equals <see cref="RedactedValue"/> — keep the stored value,</item>
/// <item>key absent — the user cleared the field, the value is gone,</item>
/// <item>any other value — the user entered a new secret.</item>
/// </list>
/// This mirrors the "empty means keep the stored value" convention the dedicated credential
/// columns already use. Keys are matched case-insensitively because the carrier connectors
/// deserialize the blob with web defaults (case-insensitive) and the client editor does the same.
/// Instances are immutable and carry the key list of one blob, so the same logic can serve other
/// config blobs with their own keys.
/// </summary>
public sealed class ConfigJsonSecretRedactor
{
    /// <summary>
    /// What a stored secret looks like on the wire. A constant — never a mask derived from the
    /// value — so neither length nor prefix of the secret leaks.
    /// </summary>
    public const string RedactedValue = "********";

    /// <summary>
    /// Catch-all for secret keys that are added to a connector config later: anything whose name
    /// ends in one of these is treated as secret unless it is listed as a known plain key.
    /// </summary>
    private static readonly string[] SecretNameSuffixes = ["Key", "Secret", "Password", "Token"];

    private readonly HashSet<string> _secretKeys;
    private readonly HashSet<string> _plainKeys;

    /// <param name="secretKeys">Keys whose values must never leave the server.</param>
    /// <param name="plainKeys">
    /// Known non-secret keys of the blob. They are exempt from <see cref="SecretNameSuffixes"/> so
    /// the catch-all can never swallow a key the connectors need round-tripped through the UI.
    /// </param>
    public ConfigJsonSecretRedactor(IEnumerable<string> secretKeys, IEnumerable<string>? plainKeys = null)
    {
        ArgumentNullException.ThrowIfNull(secretKeys);

        _secretKeys = new HashSet<string>(secretKeys, StringComparer.OrdinalIgnoreCase);
        _plainKeys = new HashSet<string>(plainKeys ?? [], StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>Whether the value of <paramref name="key"/> must be kept on the server.</summary>
    public bool IsSecretKey(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return false;
        }

        if (_secretKeys.Contains(key))
        {
            return true;
        }

        return !_plainKeys.Contains(key)
            && SecretNameSuffixes.Any(suffix => key.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Returns the blob with every secret value replaced by <see cref="RedactedValue"/>, keeping
    /// the keys themselves so the client still sees that a value is configured. A blob that cannot
    /// be read is suppressed entirely (<c>null</c>) rather than echoed — unreadable text can
    /// still contain a readable secret.
    /// </summary>
    public string? Redact(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return json;
        }

        try
        {
            var root = JsonNode.Parse(json);
            if (root is null)
            {
                return json;
            }

            return RedactNode(root) ? root.ToJsonString() : json;
        }
        catch (JsonException)
        {
            return null;
        }
        catch (ArgumentException)
        {
            // A blob with an exactly repeated key parses, but JsonObject throws while building its
            // dictionary on the first read. Suppress it like text that does not parse at all.
            return null;
        }
    }

    /// <summary>
    /// Returns the incoming blob with every <see cref="RedactedValue"/> replaced by the value
    /// stored under the same key (dropped when nothing is stored, so the placeholder can never
    /// become a real credential). Everything else is taken from the incoming blob verbatim.
    /// </summary>
    public string? Merge(string? incomingJson, string? storedJson)
    {
        if (string.IsNullOrWhiteSpace(incomingJson))
        {
            return incomingJson;
        }

        var incoming = TryParse(incomingJson);
        if (incoming is null)
        {
            return incomingJson;
        }

        var stored = TryParse(storedJson);

        try
        {
            return MergeNode(incoming, stored) ? incoming.ToJsonString() : incomingJson;
        }
        catch (ArgumentException)
        {
            // Exactly repeated key in the incoming blob: JsonObject throws while building its
            // dictionary. Store the text as it came, like a blob that does not parse at all — the
            // read side suppresses it either way.
            return incomingJson;
        }
    }

    private static JsonNode? TryParse(string? json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            return null;
        }

        try
        {
            return JsonNode.Parse(json);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private bool RedactNode(JsonNode node)
    {
        var changed = false;

        switch (node)
        {
            case JsonObject obj:
                foreach (var key in obj.Select(pair => pair.Key).ToList())
                {
                    var value = obj[key];
                    if (IsSecretKey(key))
                    {
                        if (HasValue(value))
                        {
                            obj[key] = RedactedValue;
                            changed = true;
                        }

                        continue;
                    }

                    if (value is not null)
                    {
                        changed |= RedactNode(value);
                    }
                }

                break;

            case JsonArray array:
                foreach (var item in array)
                {
                    if (item is not null)
                    {
                        changed |= RedactNode(item);
                    }
                }

                break;
        }

        return changed;
    }

    private bool MergeNode(JsonNode node, JsonNode? stored)
    {
        var changed = false;

        switch (node)
        {
            case JsonObject obj:
                var storedObject = stored as JsonObject;
                foreach (var key in obj.Select(pair => pair.Key).ToList())
                {
                    var storedValue = FindValue(storedObject, key);
                    if (IsSecretKey(key))
                    {
                        if (!IsRedacted(obj[key]))
                        {
                            continue;
                        }

                        if (storedValue is null)
                        {
                            obj.Remove(key);
                        }
                        else
                        {
                            obj[key] = storedValue.DeepClone();
                        }

                        changed = true;
                        continue;
                    }

                    var value = obj[key];
                    if (value is not null)
                    {
                        changed |= MergeNode(value, storedValue);
                    }
                }

                break;

            case JsonArray array:
                var storedArray = stored as JsonArray;
                for (var index = 0; index < array.Count; index++)
                {
                    var item = array[index];
                    if (item is null)
                    {
                        continue;
                    }

                    var storedItem = storedArray is not null && index < storedArray.Count
                        ? storedArray[index]
                        : null;
                    changed |= MergeNode(item, storedItem);
                }

                break;
        }

        return changed;
    }

    private static JsonNode? FindValue(JsonObject? obj, string key)
    {
        if (obj is null)
        {
            return null;
        }

        try
        {
            foreach (var pair in obj)
            {
                if (string.Equals(pair.Key, key, StringComparison.OrdinalIgnoreCase))
                {
                    return pair.Value;
                }
            }
        }
        catch (ArgumentException)
        {
            // Stored blob with an exactly repeated key — unreadable, so nothing is stored under
            // this key and the placeholder is dropped rather than kept.
            return null;
        }

        return null;
    }

    private static bool HasValue(JsonNode? node)
        => node is not null && !(node is JsonValue value
            && value.TryGetValue<string>(out var text)
            && string.IsNullOrEmpty(text));

    private static bool IsRedacted(JsonNode? node)
        => node is JsonValue value
            && value.TryGetValue<string>(out var text)
            && string.Equals(text, RedactedValue, StringComparison.Ordinal);
}
