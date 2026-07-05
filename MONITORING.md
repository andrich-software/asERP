# Monitoring — Grafana / Loki / Prometheus

The server ships logs, metrics and traces to a Grafana stack. Everything is configured at
runtime through the system-wide settings (Superadmin → Global Settings → Observability tab,
`Grafana.*` keys) — no appsettings changes or restarts of config files are required, but the
server must be **restarted** after changing these settings because logging/telemetry pipelines
are wired during startup.

## Settings

| Key | Default | Purpose |
|---|---|---|
| `Grafana.Endpoint` | `https://www.andrich-software.de/grafana` | Base URL of the Grafana UI (informational). |
| `Grafana.LokiEndpoint` | `https://www.andrich-software.de/grafana/loki` | Loki base URL. The sink appends `/loki/api/v1/push`. |
| `Grafana.LokiUser` | `worker` | Basic-auth user for the Loki push route (htpasswd on the Grafana host). |
| `Grafana.LokiPassword` | *(empty, encrypted)* | Basic-auth password. Stored encrypted at rest. |
| `Grafana.LogsEnabled` | `False` | Enables the Serilog → Loki sink. |
| `Grafana.MetricsEnabled` | `False` | Exposes the Prometheus scrape endpoint at `/metrics`. |
| `Grafana.OtlpEndpoint` | *(empty)* | Optional OTLP/HTTP endpoint for traces (+ metrics). Leave empty until the stack runs a collector/Tempo. |

## Logs (Loki)

- Serilog sends all logs — including unhandled exceptions from `ExceptionMiddleware` /
  `GlobalExceptionHandler` with full stack traces — to Loki with the labels
  `app=asERP.Server` and `environment=<ASPNETCORE_ENVIRONMENT>`.
- The push route is protected by basic auth on the Grafana host
  (`/etc/nginx/htpasswd_loki`, see the Grafana repo's `nginx/grafana.conf`); query routes
  are not publicly exposed.
- To enable: set `Grafana.LokiPassword`, switch `Grafana.LogsEnabled` to `True`, restart.

## Metrics (Prometheus)

The Grafana stack has **no push/remote-write endpoint** — its Prometheus scrapes apps.
With `Grafana.MetricsEnabled = True` the server exposes OpenTelemetry metrics
(ASP.NET Core + HttpClient instrumentation) at `GET /metrics`, unauthenticated at the
app level. In production the reverse proxy must protect it, matching the other apps:

```nginx
location = /metrics/web {
    auth_basic "Prometheus";
    auth_basic_user_file /etc/nginx/htpasswd_metrics;
    proxy_pass http://127.0.0.1:<aserp-port>/metrics;
}
```

Then add a scrape job for the deployment in the Grafana repo (`prometheus/prometheus.yml`),
mirroring the existing `*-web` jobs (HTTPS + basic auth, `metrics_path: /metrics/web`).

## Traces (OTLP)

The stack currently runs no Tempo/OTel collector, so `Grafana.OtlpEndpoint` is empty and
no traces are exported. Once a collector is available, set the full OTLP/HTTP endpoint
there; ASP.NET Core and HttpClient spans are then exported (protocol: HTTP protobuf).
