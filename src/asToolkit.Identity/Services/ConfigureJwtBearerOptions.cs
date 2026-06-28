using System.Text;
using asToolkit.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace asToolkit.Identity.Services;

public class ConfigureJwtBearerOptions : IConfigureOptions<JwtBearerOptions>
{
    private readonly IServiceProvider _serviceProvider;

    public ConfigureJwtBearerOptions(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Configure(JwtBearerOptions options)
    {
        using var scope = _serviceProvider.CreateScope();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();

        logger.LogDebug("🔧 ConfigureJwtBearerOptions.Configure() called");

        try
        {
            var settingsService = scope.ServiceProvider.GetRequiredService<ISettingsService>();
            logger.LogDebug("✅ SettingsService resolved");

            var jwtSettings = settingsService.GetJwtSettingsAsync().GetAwaiter().GetResult();
            logger.LogDebug($"✅ JWT Settings loaded - Issuer: {jwtSettings.Issuer}, Audience: {jwtSettings.Audience}");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                RoleClaimType = System.Security.Claims.ClaimTypes.Role
            };

            logger.LogDebug("✅ TokenValidationParameters configured");

            options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                logger.LogError($"❌ JWT Authentication failed: {context.Exception.Message}");
                logger.LogError($"   Path: {context.HttpContext.Request.Path}");
                logger.LogError($"   Exception: {context.Exception.GetType().Name}");
                return System.Threading.Tasks.Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                logger.LogDebug($"✅ JWT Token validated successfully for: {context.Principal?.Identity?.Name}");
                logger.LogDebug($"   Path: {context.HttpContext.Request.Path}");
                var roles = context.Principal?.Claims.Where(c => c.Type == System.Security.Claims.ClaimTypes.Role).Select(c => c.Value);
                logger.LogDebug($"   Roles: {string.Join(", ", roles ?? Array.Empty<string>())}");
                return System.Threading.Tasks.Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                logger.LogWarning($"⚠️ JWT Challenge issued for: {context.HttpContext.Request.Path}");
                logger.LogWarning($"   Error: {context.Error}");
                logger.LogWarning($"   ErrorDescription: {context.ErrorDescription}");
                return System.Threading.Tasks.Task.CompletedTask;
            },
            OnMessageReceived = context =>
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                var hasAuthHeader = context.HttpContext.Request.Headers.ContainsKey("Authorization");
                logger.LogDebug($"📨 JWT Message received for: {context.HttpContext.Request.Path}");
                logger.LogDebug($"   Authorization header present: {hasAuthHeader}");
                return System.Threading.Tasks.Task.CompletedTask;
            }
        };

            logger.LogDebug("✅ JWT Bearer Events configured");
        }
        catch (Exception ex)
        {
            logger.LogError($"❌ ERROR in ConfigureJwtBearerOptions: {ex.Message}");
            logger.LogError($"   StackTrace: {ex.StackTrace}");
            throw;
        }
    }
}