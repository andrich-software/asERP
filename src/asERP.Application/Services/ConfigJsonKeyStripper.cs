using System.Text.Json;
using System.Text.Json.Nodes;

namespace asERP.Application.Services;

/// <summary>
/// Removes a fixed set of keys from a free-form config JSON blob such as
/// <c>SalesChannel.AdditionalConfigJson</c>, at any nesting depth and matching the key name
/// case-insensitively (the connectors deserialize the blob with web defaults).
///
/// A sibling of <see cref="ConfigJsonSecretRedactor"/> rather than a third method on it: the
/// redactor protects values the <em>server</em> owns and therefore always works on a pair of
/// documents — mask on read, merge the placeholder back over the stored blob on write. Stripping
/// owns no value and needs no stored document: it only ever deletes. That difference is what makes
/// it safe on a caller-supplied blob that is never persisted (the draft connection test), where
/// merging stored data into the request would hand the caller back server-side values.
///
/// Removal is a second line of defence, not the only one: a blob with an exactly repeated key
/// cannot be walked here (<see cref="JsonObject"/> throws while building its dictionary) although
/// <see cref="JsonSerializer"/> would still bind it, so a key that must not be honoured also has to
/// be absent from the typed config the connector binds.
/// </summary>
public sealed class ConfigJsonKeyStripper
{
    private readonly HashSet<string> _keys;

    /// <param name="keys">Key names to remove wherever they appear in the document.</param>
    public ConfigJsonKeyStripper(IEnumerable<string> keys)
    {
        ArgumentNullException.ThrowIfNull(keys);

        _keys = new HashSet<string>(keys, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Returns the blob without the configured keys. Text that cannot be walked is returned
    /// unchanged — unlike the redactor there is nothing to suppress, because stripping never
    /// exposes a value.
    /// </summary>
    public string? Strip(string? json)
    {
        if (string.IsNullOrWhiteSpace(json) || _keys.Count == 0)
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

            return RemoveKeys(root) ? root.ToJsonString() : json;
        }
        catch (JsonException)
        {
            return json;
        }
        catch (ArgumentException)
        {
            // Exactly repeated key in the blob: JsonObject throws while building its dictionary.
            return json;
        }
    }

    private bool RemoveKeys(JsonNode node)
    {
        var changed = false;

        switch (node)
        {
            case JsonObject obj:
                foreach (var key in obj.Select(pair => pair.Key).ToList())
                {
                    if (_keys.Contains(key))
                    {
                        obj.Remove(key);
                        changed = true;
                        continue;
                    }

                    if (obj[key] is { } value)
                    {
                        changed |= RemoveKeys(value);
                    }
                }

                break;

            case JsonArray array:
                foreach (var item in array)
                {
                    if (item is not null)
                    {
                        changed |= RemoveKeys(item);
                    }
                }

                break;
        }

        return changed;
    }
}
