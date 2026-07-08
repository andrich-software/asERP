# CLAUDE.md — asERP.Identity

Auth services on top of ASP.NET Identity: login/registration/refresh tokens (`AuthService`), user lookups (`UserService`), the ambient `TenantContext`, and JWT bearer configuration. Depends only on `asERP.Application`.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true`.

## How Identity Is Wired (split across projects)

- **The Identity DbContext IS the main `ApplicationDbContext`** (`asERP.Persistence`, extends `IdentityDbContext<ApplicationUser>`) — one database; identity tables remapped to `user`, `role`, `user_role`, `user_token`, etc. Identity migrations live with all other migrations in the three provider projects.
- `AddIdentity<ApplicationUser, IdentityRole>()` + EF stores are registered in **`asERP.Persistence`** (`PersistenceServiceRegistration`). This project's `AddIdentityServices` only layers `IdentityOptions` (password/lockout) and JWT on top — order matters, but Persistence runs first.
- `ApplicationDbContext` explicitly `Ignore`s the Identity 10 passkey types (`IdentityPasskeyData`, `IdentityUserPasskey<string>`) because SQLite can't map them — **don't remove those ignores**.

## Roles vs. Permission Flags (important distinction)

- Only **two** Identity roles exist, seeded with fixed GUIDs in `Configurations/RoleConfiguration.cs`: `"User"` and `"Superadmin"`. New registrations get `"User"`.
- **`RoleManageUser` and `RoleManageTenant` are NOT Identity roles** — they are boolean flags on the `UserTenant` entity (per-user-per-tenant grants), checked in handlers, not present in JWT role claims. `[Authorize(Roles = ...)]` works only for `User`/`Superadmin`.
- Known latent bug: `UserService.GetEmployees()` queries a role `"Employee"` that is never seeded — returns empty.

## JWT

- **`JwtSettings` is loaded from the database** (`Jwt.*` rows in the Setting table via `ISettingsService`), not from appsettings; registered **Scoped** with a blocking `.GetAwaiter().GetResult()`. Changing JWT config means changing the Setting rows / `SettingsInitializer` seed.
- Access tokens: HMAC-SHA256, claims include `uid`, `tenantId` (default tenant or `"0"`), `availableTenants` (JSON), role claims. **`ClockSkew = TimeSpan.Zero`** — tokens expire exactly on time; don't assume the default 5-minute grace in tests/clients.
- **Refresh tokens are opaque DB-backed tokens, not JWTs**: 64 random bytes, only the SHA-256 hash stored (`RefreshToken` entity). Token-**family** rotation with replay detection — presenting a revoked token burns the whole family. `IsPersistent` picks `RefreshTokenExpireDays` vs `...Short` (session).
- `SettingsInitializer` self-heals the known-insecure legacy `Jwt.Key` placeholder by rotating to a random key at startup — never reintroduce a static placeholder key.
- **Trap: two JWT bearer configurators exist.** The live one is the inline `AddOptions<JwtBearerOptions>().Configure<IServiceProvider>(...)` block in `IdentityServicesRegistration.cs` (creates a scope to resolve the scoped `ISettingsService`). `Services/ConfigureJwtBearerOptions.cs` appears to be dead/legacy — editing it will likely have no effect; change the registration block instead.

## Registration & Login

- **Registration is gated by the env var `SERVER_REGISTRATION_ENABLED`** (read once at startup by `ServerInfoService` in Infrastructure; off unless explicitly `true`). `AuthService.Register` returns 403 when disabled.
- New users are created with `EmailConfirmed = true` (no confirmation step) and auto-logged-in (JWT + session refresh token).
- Password policy: ≥ 8 chars, upper+lower+digit+special (`IdentityOptions`). Some German error strings still say "mindestens 6 Zeichen" — stale text, the real minimum is 8.
- Lockout: 5 attempts → 15 min (`lockoutOnFailure: true` in Login).
- **Login works without a tenant**: `CurrentTenantId` may be null; users see their own profile and can create tenants regardless.
- Account-enumeration hardening: duplicate email → neutral success; unknown email login runs a dummy hash to equalize timing; forgot-password always succeeds. Preserve these properties when editing.

## TenantContext

`Services/TenantContext.cs` (`ITenantContext`, **Scoped**) is the mutable ambient-tenant holder read by the EF global query filters — setting it wrong silently changes data visibility. `SetAssignedTenantIds` auto-resets the current tenant if not in the assigned set. Tenant selection/validation happens in the Server's `TenantMiddleware`, not here.

## Pitfalls

- `EnsureSuperadminAccessAsync` lives in **asERP.Server** (`Extensions/SuperadminAccessExtensions.cs`) and exists only because the integration-test host maps controllers with `AllowAnonymous()`; in production it's a defensive no-op. The real guard is `[Authorize(Roles = "Superadmin")]` — never rely on the helper as primary authorization.
- `UserService.cs` uses `#nullable disable` file-wide; careful when editing under `TreatWarningsAsErrors`.
- DI lifetimes: `IAuthService`/`IUserService` Transient, `ITenantContext` Scoped.
