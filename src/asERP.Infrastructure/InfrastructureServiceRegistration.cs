using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Email;
using asERP.Application.Models.Storage;
using asERP.Infrastructure.EmailService;
using asERP.Infrastructure.EmailService.Providers;
using asERP.Infrastructure.Logging;
using asERP.Infrastructure.PDF;
using asERP.Infrastructure.Services;
using asERP.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace asERP.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Email Service Registration
        // Operator-owned policy for the SMTP endpoints a tenant may configure (relay hosts, ports,
        // private CIDRs); an absent section allows the default submission ports and no private
        // address at all. Singletons: the policy parses its lists once, the guard is stateless.
        services.Configure<SmtpHostPolicyOptions>(configuration.GetSection(SmtpHostPolicyOptions.Section));
        services.AddSingleton(sp =>
            new SmtpHostPolicy(sp.GetRequiredService<IOptions<SmtpHostPolicyOptions>>().Value));
        services.AddSingleton<SmtpEndpointGuard>();

        services.AddScoped<IEmailProvider, SmtpEmailProvider>();
        services.AddScoped<IEmailProvider, Microsoft365EmailProvider>();
        services.AddScoped<IGraphMailSender, GraphMailSender>();
        services.AddScoped<IEmailTemplateService, EmailTemplateService>();
        services.AddScoped<IEmailService, TenantAwareEmailService>();

        // Logging
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        // PDF Service
        services.AddScoped<IPdfService, PdfService>();

        // Product image storage (filesystem)
        services.Configure<FileStorageOptions>(configuration.GetSection(FileStorageOptions.Section));
        services.AddScoped<IProductImageStorage, ProductImageStorage>();

        // Server info (env-var-backed, immutable after startup)
        services.AddSingleton<IServerInfoService, ServerInfoService>();

        return services;
    }
}
