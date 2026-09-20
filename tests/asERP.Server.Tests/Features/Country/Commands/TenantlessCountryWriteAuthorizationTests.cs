using System.Security.Claims;
using asERP.Application.Features.Country.Commands.CountryCreate;
using asERP.Application.Features.Country.Commands.CountryUpdate;
using asERP.Application.Mediator;
using asERP.Domain.Constants;
using asERP.Domain.Wrapper;
using asERP.Persistence.DatabaseContext;
using asERP.Persistence.Repositories;
using asERP.Server.Controllers.Api.V1;
using asERP.Server.Tests.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using IAuthenticationService = Microsoft.AspNetCore.Authentication.IAuthenticationService;

namespace asERP.Server.Tests.Features.Country.Commands;

/// <summary>
/// The reported primitive is a request that reaches the country write endpoints with <b>no tenant
/// context at all</b>: a create then inserts a <c>TenantId == null</c> row into every tenant's
/// country namespace, and a delete removes a shared row installation-wide.
/// <para>
/// The HTTP harness cannot reproduce that state: under the Testing environment
/// <c>TenantMiddleware</c> falls back to <c>Guid.Empty</c> when the X-Tenant-Id header is missing,
/// so <c>ITenantContext.GetCurrentTenantId()</c> is never null there. These tests therefore drive
/// <see cref="CountriesController"/> directly with a genuinely tenant-less
/// <see cref="TestTenantContext"/>, against a real <see cref="CountryRepository"/> over an
/// in-memory database.
/// </para>
/// </summary>
public class TenantlessCountryWriteAuthorizationTests : IDisposable
{
    private readonly ApplicationDbContext _dbContext;
    private readonly TestTenantContext _tenantContext = new();
    private readonly RecordingMediator _mediator = new();

    public TenantlessCountryWriteAuthorizationTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase($"TenantlessCountryWrites_{Guid.NewGuid():N}")
            .Options;

        _dbContext = new ApplicationDbContext(options, _tenantContext);
    }

    private CountriesController CreateController(Guid? currentTenantId, params string[] roles)
    {
        _tenantContext.SetCurrentTenantId(currentTenantId);

        var controller = new CountriesController(
            _mediator,
            _tenantContext,
            new CountryRepository(_dbContext, _tenantContext));

        var claims = new List<Claim> { new(ClaimTypes.Name, "TestUser") };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var services = new ServiceCollection();
        services.AddSingleton<IAuthenticationService>(new NoResultAuthenticationService());

        var httpContext = new DefaultHttpContext
        {
            RequestServices = services.BuildServiceProvider(),
            User = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"))
        };

        controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
        return controller;
    }

    private async Task<Guid> SeedCountryAsync(Guid? tenantId)
    {
        var previousTenantId = _tenantContext.GetCurrentTenantId();
        _tenantContext.SetCurrentTenantId(tenantId);

        var country = new Domain.Entities.Country
        {
            Name = $"Seeded {tenantId?.ToString() ?? "shared"}",
            CountryCode = tenantId is null ? "SH" : "TN",
            TenantId = tenantId,
            DateCreated = DateTime.UtcNow,
            DateModified = DateTime.UtcNow
        };

        _dbContext.Country.Add(country);
        await _dbContext.SaveChangesAsync();
        _dbContext.ChangeTracker.Clear();

        _tenantContext.SetCurrentTenantId(previousTenantId);
        return country.Id;
    }

    private static void AssertForbidden(ActionResult? result)
    {
        var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
        TestAssertions.AssertEqual(StatusCodes.Status403Forbidden, statusCodeResult.StatusCode);
    }

    [Fact]
    public async Task CreateCountry_WithoutTenantContext_AsNonSuperadmin_IsForbiddenAndNeverReachesTheHandler()
    {
        var controller = CreateController(currentTenantId: null);

        var result = await controller.Create(new CountryCreateCommand { Name = "Injected Land", CountryCode = "IJ" });

        AssertForbidden(result.Result);
        TestAssertions.AssertEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task DeleteCountry_WithoutTenantContext_AsNonSuperadmin_IsForbiddenAndNeverReachesTheHandler()
    {
        var sharedCountryId = await SeedCountryAsync(tenantId: null);
        var controller = CreateController(currentTenantId: null);

        var result = await controller.Delete(sharedCountryId);

        AssertForbidden(result);
        TestAssertions.AssertEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task UpdateCountry_WithoutTenantContext_AsNonSuperadmin_IsForbiddenAndNeverReachesTheHandler()
    {
        var sharedCountryId = await SeedCountryAsync(tenantId: null);
        var controller = CreateController(currentTenantId: null);

        var result = await controller.Update(sharedCountryId,
            new CountryUpdateCommand { Name = "Hijacked Land", CountryCode = "HJ" });

        AssertForbidden(result);
        TestAssertions.AssertEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task CreateCountry_WithoutTenantContext_AsSuperadmin_ReachesTheHandler()
    {
        var controller = CreateController(currentTenantId: null, "Superadmin");

        await controller.Create(new CountryCreateCommand { Name = "Shared Land", CountryCode = "SD" });

        TestAssertions.AssertNotEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task DeleteCountry_WithoutTenantContext_AsSuperadmin_ReachesTheHandler()
    {
        var sharedCountryId = await SeedCountryAsync(tenantId: null);
        var controller = CreateController(currentTenantId: null, "Superadmin");

        await controller.Delete(sharedCountryId);

        TestAssertions.AssertNotEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task CreateCountry_WithTenantContext_AsNonSuperadmin_ReachesTheHandler()
    {
        var controller = CreateController(TenantConstants.TestTenant1Id);

        await controller.Create(new CountryCreateCommand { Name = "Tenant Land", CountryCode = "TN" });

        TestAssertions.AssertNotEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task DeleteCountry_OwnTenantRow_AsNonSuperadmin_ReachesTheHandler()
    {
        var countryId = await SeedCountryAsync(TenantConstants.TestTenant1Id);
        var controller = CreateController(TenantConstants.TestTenant1Id);

        await controller.Delete(countryId);

        TestAssertions.AssertNotEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task DeleteCountry_UnknownRow_AsNonSuperadmin_StillReachesTheHandler()
    {
        // A row the caller cannot see must keep answering 404 from the handler, not 403.
        var controller = CreateController(TenantConstants.TestTenant1Id);

        await controller.Delete(Guid.NewGuid());

        TestAssertions.AssertNotEmpty(_mediator.SentRequests);
    }

    [Fact]
    public async Task DeleteCountry_SharedRow_FromTenantContext_AsNonSuperadmin_IsForbidden()
    {
        var sharedCountryId = await SeedCountryAsync(tenantId: null);
        var controller = CreateController(TenantConstants.TestTenant1Id);

        var result = await controller.Delete(sharedCountryId);

        AssertForbidden(result);
        TestAssertions.AssertEmpty(_mediator.SentRequests);
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// <c>EnsureSuperadminAccessAsync</c> re-authenticates through <c>HttpContext.AuthenticateAsync()</c>
    /// (needed because the integration host maps controllers with <c>AllowAnonymous()</c>). Outside the
    /// host there is no scheme to authenticate against, so this stand-in returns "no result" and leaves
    /// the principal the test put on the context in place.
    /// </summary>
    private sealed class NoResultAuthenticationService : IAuthenticationService
    {
        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme)
            => Task.FromResult(AuthenticateResult.NoResult());

        public Task ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
            => Task.CompletedTask;

        public Task ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
            => Task.CompletedTask;

        public Task SignInAsync(HttpContext context, string? scheme, ClaimsPrincipal principal, AuthenticationProperties? properties)
            => Task.CompletedTask;

        public Task SignOutAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
            => Task.CompletedTask;
    }

    /// <summary>
    /// Records what reached the mediator, so a test can prove a write was stopped in the controller
    /// before any handler ran. Every country command answers <see cref="Result{T}"/> of
    /// <see cref="Guid"/>.
    /// </summary>
    private sealed class RecordingMediator : IMediator
    {
        public List<object> SentRequests { get; } = new();

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            SentRequests.Add(request);
            object response = Result<Guid>.Ok(Guid.NewGuid());
            return Task.FromResult((TResponse)response);
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
            => Task.CompletedTask;
    }
}
