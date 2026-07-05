namespace asERP.Application.Models.Grafana;

public class GrafanaSettings
{
    public string Endpoint { get; set; } = string.Empty;
    public string LokiEndpoint { get; set; } = string.Empty;
    public string LokiUser { get; set; } = string.Empty;
    public string LokiPassword { get; set; } = string.Empty;

    /// <summary>
    /// Optional OTLP/HTTP endpoint for traces (and metrics, in addition to the Prometheus
    /// scrape endpoint). Empty by default — the andrich-software Grafana stack has no OTLP
    /// receiver; set this when a collector (e.g. Alloy/Tempo) becomes available.
    /// </summary>
    public string OtlpEndpoint { get; set; } = string.Empty;

    public bool MetricsEnabled { get; set; }
    public bool LogsEnabled { get; set; }
}
