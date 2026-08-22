using Asp.Versioning;

namespace asERP.Server.ServiceRegistrations;

public static class ApiVersioningRegistration
{
    public static IServiceCollection AddApiVersioningServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            // AV0016 fires because every controller declares [ApiVersion] explicitly, but
            // version-neutral routes (e.g. /feed) still rely on the default-version fallback.
            // Keep the long-standing runtime behavior instead of changing it for the analyzer.
#pragma warning disable AV0016
            options.AssumeDefaultVersionWhenUnspecified = true;
#pragma warning restore AV0016
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        })
        .AddMvc()
        .AddApiExplorer(x =>
        {
            x.GroupNameFormat = "'v'VVV";
            x.SubstituteApiVersionInUrl = true;
            x.ApiVersionParameterSource = new UrlSegmentApiVersionReader();
        });


        return services;
    }
}
