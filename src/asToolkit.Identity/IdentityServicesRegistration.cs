using System.Text;
using asToolkit.Application.Contracts.Identity;
using asToolkit.Application.Contracts.Persistence;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Models.Identity;
using asToolkit.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace asToolkit.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Configure JwtSettings from database
        services.AddScoped<JwtSettings>(serviceProvider =>
        {
            var settingsService = serviceProvider.GetRequiredService<ISettingsService>();
            return settingsService.GetJwtSettingsAsync().GetAwaiter().GetResult();
        });

        services.AddTransient<Application.Contracts.Identity.IAuthService, AuthService>();
        services.AddTransient<Application.Contracts.Identity.IUserService, UserService>();
        services.AddScoped<ITenantContext, TenantContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer();

        // Use PostConfigure to configure JWT options AFTER DI container is built
        // Must inject IServiceProvider and create scope manually because ISettingsService is scoped
        services.AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
            .Configure<IServiceProvider>((options, serviceProvider) =>
            {
                using var scope = serviceProvider.CreateScope();
                var settingsService = scope.ServiceProvider.GetRequiredService<ISettingsService>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();

                logger.LogDebug("🔧 Configuring JWT Bearer (PostConfigure)");

                try
                {
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
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogError($"❌ JWT Authentication failed: {context.Exception.Message}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogDebug($"✅ JWT Token validated for: {context.Principal?.Identity?.Name}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogDebug($"📨 JWT Message received: {context.HttpContext.Request.Path}");
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };

                    logger.LogDebug("✅ JWT Bearer Events configured");
                }
                catch (Exception ex)
                {
                    logger.LogError($"❌ ERROR configuring JWT Bearer: {ex.Message}");
                    throw;
                }
            });

        return services;
    }
}
