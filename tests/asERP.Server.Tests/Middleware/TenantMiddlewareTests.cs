using System.Security.Claims;
using System.Text.Json;
using asERP.Application.Contracts.Services;
using asERP.Identity.Services;
using asERP.Server.Middleware;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace asERP.Server.Tests.Middleware;

/// <summary>
/// Direct unit tests for <see cref="TenantMiddleware"/>'s X-Tenant-Id validation.
///
/// These cannot be written as integration tests: under the "Testing" environment the middleware
/// short-circuits header validation on purpose (the harness picks the tenant per request), so the
/// production branch is only reachable by invoking the middleware outside that environment — which
/// is what these tests do by supplying a service provider without an IWebHostEnvironment.
///
/// The header selects the tenant that every EF global query filter trusts, so a header naming a
/// tenant the JWT does not grant must be rejected. Regression guard for the fail-open reported by
/// S9S Security Research: the membership check used to be skipped entirely when the principal had
/// zero tenant assignments, which let a tenant-less (e.g. de-provisioned) user self-grant any
/// tenant GUID and read/write that tenant's data.
/// </summary>
public class TenantMiddlewareTests
{
    private static readonly Guid VictimTenantId = Guid.Parse("04330476-1111-2222-3333-44445555511f");
    private static readonly Guid AssignedTenantId = Guid.Parse("11111111-2222-3333-4444-555555555555");

    [Fact]
    public async Task TenantlessUser_SuppliedForeignTenantHeader_IsDenied()
    {
        var (context, tenantContext) = CreateContext(assignedTenantIds: Array.Empty<Guid>(), headerTenantId: VictimTenantId);

        var nextCalled = await InvokeAsync(context, tenantContext);

        TestAssertions.AssertFalse(nextCalled, "Request must not reach the pipeline");
        TestAssertions.AssertEqual(403, context.Response.StatusCode);
        TestAssertions.AssertNull(tenantContext.GetCurrentTenantId());
        TestAssertions.AssertEmpty(tenantContext.GetAssignedTenantIds());
    }

    [Fact]
    public async Task AssignedUser_SuppliedForeignTenantHeader_IsDenied()
    {
        var (context, tenantContext) = CreateContext(assignedTenantIds: new[] { AssignedTenantId }, headerTenantId: VictimTenantId);

        var nextCalled = await InvokeAsync(context, tenantContext);

        TestAssertions.AssertFalse(nextCalled, "Request must not reach the pipeline");
        TestAssertions.AssertEqual(403, context.Response.StatusCode);
        TestAssertions.AssertNotEqual(VictimTenantId, tenantContext.GetCurrentTenantId() ?? Guid.Empty);
    }

    [Fact]
    public async Task AssignedUser_SuppliedOwnTenantHeader_IsAllowed()
    {
        var (context, tenantContext) = CreateContext(assignedTenantIds: new[] { AssignedTenantId }, headerTenantId: AssignedTenantId);

        var nextCalled = await InvokeAsync(context, tenantContext);

        TestAssertions.AssertTrue(nextCalled, "Request must reach the pipeline");
        TestAssertions.AssertEqual(AssignedTenantId, tenantContext.GetCurrentTenantId() ?? Guid.Empty);
    }

    /// <summary>
    /// A user with no tenants yet must still be able to work the tenant-agnostic endpoints that let
    /// them create their first tenant — denying the header must not turn into denying the user.
    /// </summary>
    [Fact]
    public async Task TenantlessUser_WithoutTenantHeader_IsAllowedWithoutTenant()
    {
        var (context, tenantContext) = CreateContext(assignedTenantIds: Array.Empty<Guid>(), headerTenantId: null);

        var nextCalled = await InvokeAsync(context, tenantContext);

        TestAssertions.AssertTrue(nextCalled, "Request must reach the pipeline");
        TestAssertions.AssertNull(tenantContext.GetCurrentTenantId());
    }

    private static async Task<bool> InvokeAsync(HttpContext context, ITenantContext tenantContext)
    {
        var nextCalled = false;
        var middleware = new TenantMiddleware(_ =>
        {
            nextCalled = true;
            return Task.CompletedTask;
        });

        await middleware.InvokeAsync(context, tenantContext);
        return nextCalled;
    }

    private static (HttpContext Context, ITenantContext TenantContext) CreateContext(
        IReadOnlyCollection<Guid> assignedTenantIds,
        Guid? headerTenantId)
    {
        // No IWebHostEnvironment registered → the middleware treats this as a non-Testing
        // environment and runs the production header-validation branch.
        var services = new ServiceCollection();
        services.AddLogging();
        var provider = services.BuildServiceProvider();

        var tenantsClaim = JsonSerializer.Serialize(assignedTenantIds.Select(id => new { Id = id.ToString(), Name = "Tenant" }));
        var identity = new ClaimsIdentity(
            new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
                new Claim("availableTenants", tenantsClaim)
            },
            authenticationType: "TestBearer");

        var context = new DefaultHttpContext
        {
            RequestServices = provider,
            User = new ClaimsPrincipal(identity)
        };
        context.Request.Path = "/api/v1/customers";
        context.Request.Method = "GET";
        context.Response.Body = new MemoryStream();

        if (headerTenantId.HasValue)
        {
            context.Request.Headers["X-Tenant-Id"] = headerTenantId.Value.ToString();
        }

        return (context, new TenantContext());
    }
}
