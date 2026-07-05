using System.Text;
using asERP.Application.Contracts.Identity;
using asERP.Application.Contracts.Persistence;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Identity;
using asERP.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace asERP.Identity;

public static class IdentityServicesRegistration
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Explicit Identity password / lockout policy. AddIdentity (in the persistence layer)
        // registers the Identity stores; these options are layered on top so the policy is
        // deliberate rather than relying on framework defaults.
        services.Configure<IdentityOptions>(options =>
        {
            // Account lockout: 5 failed attempts locks the account for 15 minutes.
            // Effective only because Login passes lockoutOnFailure: true.
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

            // Password policy.
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredUniqueChars = 1;

            options.User.RequireUniqueEmail = true;
        });

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

                logger.LogDebug("Configuring JWT Bearer (PostConfigure)");

                try
                {
                    var jwtSettings = settingsService.GetJwtSettingsAsync().GetAwaiter().GetResult();
                    logger.LogDebug("JWT settings loaded - Issuer: {Issuer}, Audience: {Audience}", jwtSettings.Issuer, jwtSettings.Audience);

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

                    logger.LogDebug("TokenValidationParameters configured");

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogError(context.Exception, "JWT authentication failed");
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogDebug("JWT token validated for {Name}", context.Principal?.Identity?.Name);
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnMessageReceived = context =>
                        {
                            var eventLogger = context.HttpContext.RequestServices.GetRequiredService<ILogger<ConfigureJwtBearerOptions>>();
                            eventLogger.LogDebug("JWT message received for {Path}", context.HttpContext.Request.Path);
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };

                    logger.LogDebug("JWT Bearer events configured");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error configuring JWT Bearer");
                    throw;
                }
            });

        return services;
    }
}
