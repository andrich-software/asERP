using asToolkit.Application.Contracts.Infrastructure;
using asToolkit.Application.Contracts.Logging;
using asToolkit.Application.Contracts.Services;
using asToolkit.Application.Models.Storage;
using asToolkit.Infrastructure.EmailService;
using asToolkit.Infrastructure.EmailService.Providers;
using asToolkit.Infrastructure.Logging;
using asToolkit.Infrastructure.PDF;
using asToolkit.Infrastructure.Services;
using asToolkit.Infrastructure.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace asToolkit.Infrastructure;

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
