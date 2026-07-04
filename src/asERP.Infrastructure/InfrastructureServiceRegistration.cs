using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Logging;
using asERP.Application.Contracts.Services;
using asERP.Application.Models.Storage;
using asERP.Infrastructure.EmailService;
using asERP.Infrastructure.EmailService.Providers;
using asERP.Infrastructure.Logging;
using asERP.Infrastructure.PDF;
using asERP.Infrastructure.Services;
using asERP.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asERP.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Email Service Registration
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
