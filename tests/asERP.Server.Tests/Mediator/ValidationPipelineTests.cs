using System.Net;
using System.Text.Json;
using asERP.Application;
using asERP.Domain.Constants;
using asERP.Domain.Dtos.Country;
using asERP.Domain.Dtos.Manufacturer;
using asERP.Server.Tests.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Mediator;

/// <summary>
/// Covers the mediator's validation step: requests are validated before the handler runs and
/// failures are reported as RFC 9457 problem details with a per-field error dictionary.
/// </summary>
public class ValidationPipelineTests : TenantIsolatedTestBase
{
    [Fact]
    public async Task InvalidCommand_ReturnsProblemDetailsWithFieldErrors()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "", CountryCode = "XX" });

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.BadRequest);
        TestAssertions.AssertEqual("application/problem+json", response.Content.Headers.ContentType?.MediaType);

        using var body = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        var errors = body.RootElement.GetProperty("errors");
        var nameErrors = errors.GetProperty("Name");

        TestAssertions.AssertTrue(nameErrors.GetArrayLength() > 0);
    }

    [Fact]
    public async Task InvalidCommand_NeverReachesTheHandler()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        // An empty name fails validation; if the handler still ran, the country would be persisted.
        var response = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "", CountryCode = "ZQ" });

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.BadRequest);

        var persisted = await DbContext.Country
            .IgnoreQueryFilters()
            .AnyAsync(c => c.CountryCode == "ZQ");

        TestAssertions.AssertFalse(persisted);
    }

    [Fact]
    public async Task ValidCommand_StillReachesTheHandler()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var response = await PostAsJsonAsync("/api/v1/Countries",
            new CountryInputDto { Name = "Validation Pipeline Country", CountryCode = "VP" });

        TestAssertions.AssertHttpStatusCode(response, HttpStatusCode.Created);
    }

    /// <summary>
    /// Rules declared on the request as a whole (<c>RuleFor(q =&gt; q)</c>, e.g. the uniqueness check)
    /// carry no property name. They must still reach the client instead of being dropped on the way
    /// into the <c>errors</c> dictionary. Manufacturer is used because its repository actually
    /// overrides <c>IsUniqueAsync</c> — the generic implementation returns true unconditionally.
    /// </summary>
    [Fact]
    public async Task ObjectLevelRule_ReachesTheErrorsDictionary()
    {
        await TestDataSeeder.SeedTestDataAsync(DbContext, TenantContext);
        SetTenantHeader(TenantConstants.TestTenant1Id);

        var manufacturer = new ManufacturerInputDto { Name = "Pipeline Duplicate Manufacturer" };
        TestAssertions.AssertHttpStatusCode(
            await PostAsJsonAsync("/api/v1/Manufacturers", manufacturer), HttpStatusCode.Created);

        var duplicate = await PostAsJsonAsync("/api/v1/Manufacturers", manufacturer);

        TestAssertions.AssertHttpStatusCode(duplicate, HttpStatusCode.BadRequest);

        var content = await duplicate.Content.ReadAsStringAsync();
        using var body = JsonDocument.Parse(content);
        var errors = body.RootElement.GetProperty("errors");

        // The message must survive, whatever key it lands under (object-level rules use "").
        TestAssertions.AssertTrue(errors.EnumerateObject()
            .SelectMany(property => property.Value.EnumerateArray())
            .Any(message => !string.IsNullOrWhiteSpace(message.GetString())),
            $"Object-level rule produced no message. Body: {content}");
    }

    /// <summary>
    /// The mediator resolves validators from DI. A validator whose constructor dependency is not
    /// registered used to be harmless (handlers newed them up by hand) and would now fail at
    /// request time instead — this test turns that into a build-time-ish failure.
    /// </summary>
    [Fact]
    public void EveryRegisteredValidator_CanBeResolvedFromDi()
    {
        var validatorInterfaces = AssemblyScanner
            .FindValidatorsInAssembly(typeof(ApplicationServiceRegistration).Assembly)
            .Select(scanResult => scanResult.InterfaceType)
            .Distinct()
            .ToList();

        TestAssertions.AssertTrue(validatorInterfaces.Count > 0);

        using var scope = Factory.Services.CreateScope();
        var unresolvable = new List<string>();

        foreach (var interfaceType in validatorInterfaces)
        {
            try
            {
                var resolved = scope.ServiceProvider.GetServices(interfaceType).ToList();
                if (resolved.Count == 0)
                {
                    unresolvable.Add($"{interfaceType.Name}: not registered");
                }
            }
            catch (Exception ex)
            {
                unresolvable.Add($"{interfaceType.Name}: {ex.Message}");
            }
        }

        Assert.True(unresolvable.Count == 0,
            "Validators that cannot be constructed from DI:" + Environment.NewLine +
            string.Join(Environment.NewLine, unresolvable));
    }
}
