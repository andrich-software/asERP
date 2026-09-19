using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;
using asERP.Client.Core.Exceptions;

namespace asERP.Client.Core.Extensions;

/// <summary>
/// GET helpers that fail the same way the mutating calls do.
/// <para>
/// <see cref="HttpClientJsonExtensions.GetFromJsonAsync"/> throws a bare
/// <see cref="HttpRequestException"/> on an error status, which drops the server's message and its
/// stable <c>ErrorCodes</c> string on the floor. Reads go through here instead so a failed GET
/// surfaces an <see cref="ApiException"/> the UI can actually show — and branch on.
/// </para>
/// </summary>
public static class ApiHttpClientExtensions
{
    public static async Task<T?> GetFromApiAsync<T>(
        this HttpClient client,
        string url,
        JsonTypeInfo<T> typeInfo,
        CancellationToken ct = default)
    {
        using var response = await client.GetAsync(url, ct);
        await response.EnsureSuccessOrThrowApiExceptionAsync(ct);

        return await response.Content.ReadFromJsonAsync(typeInfo, ct);
    }
}
