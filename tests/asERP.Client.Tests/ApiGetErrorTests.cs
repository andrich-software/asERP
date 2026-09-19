using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Extensions;
using asERP.Client.Core.Json;

namespace asERP.Client.Tests;

/// <summary>
/// Reads used to go through <c>HttpClient.GetFromJsonAsync</c>, which throws a bare
/// <see cref="HttpRequestException"/> on an error status — so the server's message and its stable
/// error code never reached the UI and a failed list simply looked empty. These tests pin that
/// <c>GetFromApiAsync</c> closes that gap.
/// </summary>
public class ApiGetErrorTests
{
    private sealed class StubHandler(HttpStatusCode status, string body) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(status)
            {
                Content = new StringContent(body, Encoding.UTF8, "application/json")
            });
    }

    private static HttpClient ClientReturning(HttpStatusCode status, string body)
        => new(new StubHandler(status, body));

    [Test]
    public void FailedGet_ThrowsApiExceptionCarryingCodeAndMessage()
    {
        using var client = ClientReturning(HttpStatusCode.NotFound, """
            {
              "succeeded": false,
              "messages": ["Country not found"],
              "error": { "type": 1, "code": "country.not_found", "message": "Country not found" }
            }
            """);

        var ex = Assert.ThrowsAsync<ApiException>(async () =>
            await client.GetFromApiAsync("https://example.invalid/api/v1/Countries/x",
                AppJsonSerializerContext.Default.ApiResponseCountryDetailDto));

        Assert.That(ex!.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        Assert.That(ex.Code, Is.EqualTo("country.not_found"));
        Assert.That(ex.Messages, Does.Contain("Country not found"));
    }

    [Test]
    public async Task SuccessfulGet_StillDeserializes()
    {
        using var client = ClientReturning(HttpStatusCode.OK, """
            { "succeeded": true, "messages": [], "data": { "name": "Testland", "countryCode": "TL" } }
            """);

        var response = await client.GetFromApiAsync("https://example.invalid/api/v1/Countries/x",
            AppJsonSerializerContext.Default.ApiResponseCountryDetailDto);

        Assert.That(response, Is.Not.Null);
        Assert.That(response!.Succeeded, Is.True);
        Assert.That(response.Data!.Name, Is.EqualTo("Testland"));
    }
}
