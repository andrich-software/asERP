using System.Text.Json;

namespace asERP.Server.Tests.Infrastructure;

/// <summary>
/// Reads error messages out of a failed response without caring which of the two shapes the Server
/// used: RFC 9457 problem details (validation failures — an <c>errors</c> dictionary keyed by field,
/// plus a <c>title</c>) or the <c>Result</c> envelope (business failures — a <c>messages</c> array).
/// Tests asserting "the response explains what is wrong" should not have to know which one they get.
/// </summary>
public static class ErrorResponse
{
    public static async Task<List<string>> ReadMessagesAsync(HttpResponseMessage response)
    {
        var messages = new List<string>();
        var content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(content))
        {
            return messages;
        }

        JsonDocument document;
        try
        {
            document = JsonDocument.Parse(content);
        }
        catch (JsonException)
        {
            return messages;
        }

        using (document)
        {
            var root = document.RootElement;
            if (root.ValueKind != JsonValueKind.Object)
            {
                return messages;
            }

            foreach (var property in root.EnumerateObject())
            {
                if (property.NameEquals("errors") && property.Value.ValueKind == JsonValueKind.Object)
                {
                    foreach (var field in property.Value.EnumerateObject())
                    {
                        AddStrings(field.Value, messages);
                    }
                }
                else if (property.NameEquals("messages"))
                {
                    AddStrings(property.Value, messages);
                }
            }

            // Only fall back to the title when nothing more specific was reported.
            if (messages.Count == 0)
            {
                foreach (var property in root.EnumerateObject())
                {
                    if (property.NameEquals("title") && property.Value.GetString() is { } title)
                    {
                        messages.Add(title);
                    }
                }
            }
        }

        return messages;
    }

    /// <summary>
    /// True when any error message contains <paramref name="fragment"/> (case-insensitive).
    /// </summary>
    public static async Task<bool> ContainsMessageAsync(HttpResponseMessage response, string fragment)
    {
        var messages = await ReadMessagesAsync(response);
        return messages.Any(message => message.Contains(fragment, StringComparison.OrdinalIgnoreCase));
    }

    private static void AddStrings(JsonElement element, List<string> target)
    {
        if (element.ValueKind != JsonValueKind.Array)
        {
            return;
        }

        foreach (var item in element.EnumerateArray())
        {
            if (item.GetString() is { } text)
            {
                target.Add(text);
            }
        }
    }
}
