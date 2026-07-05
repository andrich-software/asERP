using asERP.Application.Models.Grafana;
using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace asERP.Server.ServiceRegistrations;

public static class OpenTelemetryRegistration
{
    /// <summary>
    /// Wires OpenTelemetry against the Grafana stack. The stack has no OTLP receiver — its
    /// Prometheus scrapes app metrics over a basic-auth-protected /metrics endpoint (exposed
    /// via <see cref="UseGrafanaTelemetry"/>; the reverse proxy owns the auth). Traces are
    /// only exported when an OTLP endpoint is explicitly configured.
    /// </summary>
    public static IServiceCollection AddGrafanaTelemetryServices(
        this IServiceCollection services,
        GrafanaSettings grafanaSettings,
        string serviceName)
    {
        var otlpConfigured = Uri.TryCreate(grafanaSettings.OtlpEndpoint, UriKind.Absolute, out var otlpUri);

        if (!grafanaSettings.MetricsEnabled && !otlpConfigured)
        {
            return services;
        }

        var openTelemetry = services.AddOpenTelemetry()
            .ConfigureResource(resource => resource
                .AddService(serviceName)
                .AddEnvironmentVariableDetector());

        if (grafanaSettings.MetricsEnabled)
        {
            openTelemetry.WithMetrics(metrics =>
            {
                metrics
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddPrometheusExporter();

                if (otlpConfigured)
                {
                    metrics.AddOtlpExporter(options =>
                    {
                        options.Endpoint = otlpUri!;
                        options.Protocol = OtlpExportProtocol.HttpProtobuf;
                    });
                }
            });
        }

        if (otlpConfigured)
        {
            openTelemetry.WithTracing(tracing => tracing
                .AddAspNetCoreInstrumentation()
                .AddHttpClientInstrumentation()
                .AddOtlpExporter(options =>
                {
                    options.Endpoint = otlpUri!;
                    options.Protocol = OtlpExportProtocol.HttpProtobuf;
                }));
        }

        return services;
    }

    /// <summary>
    /// Maps the Prometheus scrape endpoint (/metrics) when metrics are enabled. Must run
    /// early in the pipeline so scrapes bypass rate limiting, tenant resolution and auth —
    /// in production the endpoint is protected by the reverse proxy (htpasswd), matching
    /// how the central Prometheus scrapes the other andrich-software apps.
    /// </summary>
    public static IApplicationBuilder UseGrafanaTelemetry(
        this IApplicationBuilder app,
        GrafanaSettings grafanaSettings)
    {
        if (grafanaSettings.MetricsEnabled)
        {
            app.UseOpenTelemetryPrometheusScrapingEndpoint();
        }

        return app;
    }
}
