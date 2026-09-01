using System.Net;
using System.Net.Http;
using System.Text;
using asERP.Client.Core.Exceptions;
using asERP.Client.Core.Extensions;

namespace asERP.Client.Tests;

/// <summary>
/// Tests for the single place that turns a failed HTTP response into an <see cref="ApiException"/>.
/// The Server sends two shapes — the <c>Result</c> envelope for business failures and RFC 9457
/// problem details for validation failures — and both have to survive the trip to the UI.
/// </summary>
public class ApiErrorParsingTests
{
    private static async Task<ApiException> CaptureAsync(HttpStatusCode status, string body)
    {
        var response = new HttpResponseMessage(status)
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json")
        };

        return Assert.ThrowsAsync<ApiException>(
            async () => await response.EnsureSuccessOrThrowApiExceptionAsync())!;
    }

    [Test]
    public async Task ValidationProblemDetails_KeepsFieldNames()
    {
        var ex = await CaptureAsync(HttpStatusCode.BadRequest, """
            {
              "title": "One or more validation errors occurred.",
              "status": 400,
              "errors": {
                "Name": ["'Name' must not be empty."],
                "CountryCode": ["'Country Code' must not be empty.", "'Country Code' is too long."]
              }
            }
            """);

        Assert.That(ex.Errors.ContainsKey("Name"), Is.True);
        Assert.That(ex.Errors["CountryCode"], Has.Length.EqualTo(2));
    }

    [Test]
    public async Task ValidationProblemDetails_ShowsFieldMessagesInsteadOfGenericTitle()
    {
        var ex = await CaptureAsync(HttpStatusCode.BadRequest, """
            {
              "title": "One or more validation errors occurred.",
              "status": 400,
              "errors": { "Name": ["'Name' must not be empty."] }
            }
            """);

        Assert.That(ex.Messages, Does.Contain("'Name' must not be empty."));
        Assert.That(ex.Messages, Does.Not.Contain("One or more validation errors occurred."));
    }

    [Test]
    public async Task SemanticError_ExposesCodeAndKind()
    {
        var ex = await CaptureAsync(HttpStatusCode.NotFound, """
            {
              "succeeded": false,
              "messages": ["Country not found"],
              "error": { "type": 1, "code": "country.not_found", "message": "Country not found" }
            }
            """);

        Assert.That(ex.Code, Is.EqualTo("country.not_found"));
        Assert.That(ex.ErrorType, Is.EqualTo(asERP.Domain.Wrapper.ErrorType.NotFound));
    }

    [Test]
    public async Task ResponseWithoutSemanticError_LeavesCodeNull()
    {
        var ex = await CaptureAsync(HttpStatusCode.BadRequest, """
            { "title": "One or more validation errors occurred.", "status": 400,
              "errors": { "Name": ["'Name' must not be empty."] } }
            """);

        Assert.That(ex.Code, Is.Null);
        Assert.That(ex.ErrorType, Is.Null);
    }

    [Test]
    public async Task ResultEnvelope_StillParsesIntoMessages()
    {
        var ex = await CaptureAsync(HttpStatusCode.NotFound, """
            { "succeeded": false, "statusCode": 404, "messages": ["Country not found"] }
            """);

        Assert.That(ex.Messages, Does.Contain("Country not found"));
        Assert.That(ex.Errors, Is.Empty);
    }

    [Test]
    public async Task ProblemDetailsWithoutFieldErrors_FallsBackToTitle()
    {
        var ex = await CaptureAsync(HttpStatusCode.InternalServerError, """
            { "title": "An internal server error occurred.", "status": 500 }
            """);

        Assert.That(ex.Messages, Does.Contain("An internal server error occurred."));
        Assert.That(ex.Errors, Is.Empty);
    }

    [Test]
    public async Task EmptyBody_ProducesGenericMessage()
    {
        var ex = await CaptureAsync(HttpStatusCode.BadRequest, string.Empty);

        Assert.That(ex.Messages, Has.Count.EqualTo(1));
        Assert.That(ex.Errors, Is.Empty);
    }
}
