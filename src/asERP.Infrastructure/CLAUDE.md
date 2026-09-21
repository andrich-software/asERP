# CLAUDE.md — asERP.Infrastructure

Cross-cutting service implementations: email, PDF generation, logging adapter, image storage, server info. Implements interfaces owned by `asERP.Application` (its only project reference). No hosted/background services live here — async work runs via outbox tables processed by the Server host.

Refer to the root `/CLAUDE.md` for cross-cutting rules. `TreatWarningsAsErrors=true`.

## Layout

| Folder | Contents |
|---|---|
| `EmailService/` | `TenantAwareEmailService : IEmailService` (file is named `EmailService.cs`), `EmailTemplateService`, `Providers/` (`SmtpEmailProvider`, `Microsoft365EmailProvider`, `GraphMailSender`) |
| `PDF/` | `PdfService` (partial: invoice in `PdfService.cs`, packing slip + pick list in `PdfService.ShippingDocuments.cs`), font resolvers, embedded `Fonts/OpenSans-Regular.ttf` |
| `Logging/` | `LoggerAdapter` — `IAppLogger<T>` → `ILogger<T>` |
| `Storage/` | `ProductImageStorage : IProductImageStorage` (filesystem + SkiaSharp) |
| `Services/` | `ServerInfoService : IServerInfoService` (env-var backed, **Singleton**) |

## Email

- Providers implement `IEmailProvider`, keyed by `EmailProviderType` (`Smtp = 0`, `Microsoft365 = 1` — **there is no SendGrid provider**; stale references in EMAIL-TESTING.md and seed data notwithstanding). To add a provider: implement `IEmailProvider` with a new `ProviderType`, register it in `InfrastructureServiceRegistration` — `TenantAwareEmailService` picks it up via `IEnumerable<IEmailProvider>`.
- SMTP uses **MailKit**; `SmtpEnableSsl == false` → plain (`SecureSocketOptions.None`, e.g. Mailpit on 1025), `true` → `Auto`. Microsoft 365 uses Graph app-only (`ClientSecretCredential`, `Mail.Send` application permission).
- **Settings resolution**: server defaults (Setting table via `ISettingsService`, fallback `appsettings.json` `EmailSettings:*`) merged **field-by-field** with per-tenant overrides (`TenantEmailSettings`, `Coalesce`/`MergeWithTenant`).
- **A tenant-supplied SMTP endpoint is guarded before MailKit connects**: `SmtpEndpointGuard` (injected into `SmtpEmailProvider`) checks host and port against the operator's `SmtpHostPolicy` (section `SmtpHostPolicy`: `AllowedRelayHosts` — exclusive once non-empty —, `AllowedPorts` (default 25/465/587/2525) and `AllowedPrivateNetworks`), so a tenant cannot aim the server's socket at an internal host. **The two halves are independent**: `EmailSettings.SmtpHostIsOperatorConfigured` exempts the host from the address check, `SmtpPortIsOperatorConfigured` exempts the port from the allow-list, and `MergeWithTenant` grants a half **only when the tenant row supplies nothing for it** (provenance, not equality — echoing the server's `localhost` must not buy the exemption), and drops only the half the tenant actually supplied — coupling them would refuse an operator relay on the LAN as soon as a tenant moved from 25 to 587. Both are set by `SettingsService` (Setting table, Superadmin-only) and the appsettings fallback, so an installation-wide relay on a private network or on `localhost` keeps working for the operator's own sends; a tenant row naming that same host needs `SmtpHostPolicy:AllowedPrivateNetworks` or `SmtpHostPolicy:AllowedRelayHosts`. The refusal reason is **log-only**; the caller gets the same `false` as any other failed send. The address list itself is `asERP.Application.Services.OutboundAddressGuard`, shared with `SalesChannelUrlValidator`.
- Templates (`EmailTemplateService`) are inline C# interpolated **German** HTML strings, not files. **All interpolated values must be `WebUtility.HtmlEncode`-d** (tokens additionally `Uri.EscapeDataString`-d) — follow this in new templates.
- Local email testing: Mailpit via `docker-compose.mail.yml` — see `EMAIL-TESTING.md` (repo root; its SendGrid mentions are stale).

## PDF

- Library: **PDFsharp + MigraDoc** (not QuestPDF — no license setting exists or is needed).
- Documents: invoice, packing slip, pick list. New documents: build a MigraDoc `Document` via `CreateShippingDocumentShell()` (A4, 2cm margins, Helvetica 10) or mirror `CreateInvoiceDocument`; render via the shared `RenderDocument()`; reuse `CreateFooter(section, company)`.
- Company data arrives as `CompanySenderInfo` (per-tenant, from the `Tenant` entity) — not a global setting.
- Formatting: quantities `"0.##"` with `CultureInfo.InvariantCulture`, currency hardcoded `€` with `"0.00"`, dates `dd.MM.yyyy`, all text German. Keep consistent.
- **Font resolver is process-global** (`PdfSharp.Fonts.GlobalFontSettings.FontResolver`, guarded by null-check): whichever of `CustomFontResolver` (embedded Open Sans) / `StandardFontResolver` (built-in Helvetica) is installed first wins for the whole process — you cannot switch per call.
- `PDF/Fonts/OpenSans-Regular.ttf` is an `EmbeddedResource` with `LogicalName="asERP.Infrastructure.PDF.Fonts.OpenSans-Regular.ttf"` — renaming/moving it breaks rendering at **runtime**, not compile time.
- Invoice `outputPath` writes go through `ResolveContainedOutputPath` (path-traversal guard) — keep that for new file outputs.

## Storage

`ProductImageStorage`: 20 MB upload cap, storage-root containment check, images re-encoded to PNG via SkiaSharp, sharded by first 2 hex chars of a GUID v7, thumbnails capped via `FileStorageOptions.ThumbnailSize`. Options bound from the `FileStorage` config section (`RootPath` may be relative → resolved against CWD).

## DI (`InfrastructureServiceRegistration.cs`)

Everything **Scoped** except the SMTP host policy pair `SmtpHostPolicy`/`SmtpEndpointGuard` (**Singleton**, the policy parses its configured lists once) and `ServerInfoService` (**Singleton**, reads env vars once at startup — `SERVER_REGISTRATION_ENABLED` gates user registration, `SERVER_MINIMUM_CLIENT_VERSION` sets the minimum client version enforced by the Server's `ClientVersionMiddleware`). `TenantAwareEmailService` depends on scoped repositories/`ITenantContext` — never resolve it from a singleton.

`GraphMailSender` caches `GraphServiceClient` in a static `ConcurrentDictionary` keyed by (tenant, clientId, secret) — process-global; rotated secrets create new entries, old ones linger.
