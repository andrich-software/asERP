using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Extensions;

/// <summary>
/// Shared Superadmin re-authorization helper for controllers that are decorated with
/// <c>[Authorize(Roles = "Superadmin")]</c> but must also enforce the role in-action.
/// <para>
/// This exists solely because the integration-test host maps controllers with
/// <c>AllowAnonymous()</c> (see <c>Program.cs</c>), which disables the declarative
/// <c>[Authorize]</c> attribute there. Removing that global <c>AllowAnonymous()</c> would
/// break the large set of integration tests that rely on header-driven identities without a
/// role, so the in-action check is kept and centralized here instead of being copy-pasted per
/// controller. In production the <c>[Authorize(Roles = "Superadmin")]</c> attribute already
/// enforces this; the helper is a defensive no-op on the authenticated Superadmin path.
/// </para>
/// </summary>
public static class SuperadminAccessExtensions
{
    /// <summary>
    /// Ensures the current caller is an authenticated Superadmin. Returns <c>null</c> when access
    /// is granted, otherwise an <see cref="ActionResult"/> with 401/403 to short-circuit the action.
    /// </summary>
    public static async Task<ActionResult?> EnsureSuperadminAccessAsync(this ControllerBase controller)
    {
        var httpContext = controller.HttpContext;

        var authenticateResult = await httpContext.AuthenticateAsync();
        if (authenticateResult is { Succeeded: true, Principal: not null })
        {
            httpContext.User = authenticateResult.Principal;
        }

        if (!(controller.User?.Identity?.IsAuthenticated ?? false))
        {
            return controller.StatusCode(StatusCodes.Status401Unauthorized);
        }

        if (!controller.User.IsInRole("Superadmin"))
        {
            return controller.StatusCode(StatusCodes.Status403Forbidden);
        }

        return null;
    }
}
