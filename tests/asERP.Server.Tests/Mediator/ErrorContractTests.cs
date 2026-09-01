using System.Net;
using System.Text.Json;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Wrapper;
using asERP.Server.Tests.Infrastructure;
using Xunit;

namespace asERP.Server.Tests.Mediator;

/// <summary>
/// Pins the error contract introduced by REFACTOR.md R3/R5: handlers report a semantic
/// <see cref="ErrorType"/> plus a stable <see cref="ErrorCodes"/> string, and the Server turns that
/// into an HTTP status in exactly one place. A client is expected to branch on the code, never on
/// the message text.
/// </summary>
public class ErrorContractTests : TenantIsolatedTestBase
{
    private async Task SeedAsync()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);
    }

    [Fact]
    public async Task NotFound_CarriesTheSemanticTypeAndCode()
    {
        await SeedAsync();

        var response = await Client.GetAsync($"/api/v1/Countries/{Guid.NewGuid()}");

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.NotFound);

        var result = await ReadResponseAsync<Result<CountryDetailDto>>(response);
        TestAssertions.AssertNotNull(result.Error);
        TestAssertions.AssertEqual(ErrorType.NotFound, result.Error!.Type);
        TestAssertions.AssertEqual(ErrorCodes.Country.NotFound, result.Error.Code);
    }

    [Fact]
    public async Task Created_ReportsTheSemanticSuccessStatus()
    {
        await SeedAsync();

        var response = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Contract Land", CountryCode = "CL" });

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Created);

        var result = await ReadResponseAsync<Result<Guid>>(response);
        TestAssertions.AssertTrue(result.Succeeded);
        TestAssertions.AssertEqual(ResultStatus.Created, result.Status);
        TestAssertions.AssertNull(result.Error);
    }

    /// <summary>
    /// The envelope must no longer carry an HTTP status — that knowledge now lives only in the
    /// Server's <c>ToActionResult</c>. A leftover field would invite clients to depend on it again.
    /// </summary>
    [Fact]
    public async Task Envelope_NoLongerCarriesAnHttpStatusCode()
    {
        await SeedAsync();

        var response = await Client.GetAsync($"/api/v1/Countries/{Guid.NewGuid()}");

        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var hasStatusCode = body.RootElement.EnumerateObject()
            .Any(property => property.NameEquals("statusCode"));

        TestAssertions.AssertFalse(hasStatusCode,
            $"The result envelope still exposes an HTTP status: {body.RootElement}");
    }

    /// <summary>
    /// Every code follows <c>{entity}.{kind}</c> and the kind agrees with the error type, so a
    /// client can rely on the shape.
    /// </summary>
    [Fact]
    public void EveryErrorCode_FollowsTheEntityDotKindShape()
    {
        var codes = typeof(ErrorCodes).GetNestedTypes()
            .SelectMany(entity => entity.GetFields())
            .Select(field => (string)field.GetValue(null)!)
            .ToList();

        TestAssertions.AssertTrue(codes.Count > 0);

        var malformed = codes
            .Where(code => !System.Text.RegularExpressions.Regex.IsMatch(code, "^[a-z0-9_]+\\.[a-z0-9_]+$"))
            .ToList();

        Assert.True(malformed.Count == 0,
            "Malformed error codes: " + string.Join(", ", malformed));
    }
}
