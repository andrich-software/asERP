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

Everything **Scoped** except `ServerInfoService` (**Singleton**, reads env vars once at startup — including `SERVER_REGISTRATION_ENABLED`, which gates user registration). `TenantAwareEmailService` depends on scoped repositories/`ITenantContext` — never resolve it from a singleton.

`GraphMailSender` caches `GraphServiceClient` in a static `ConcurrentDictionary` keyed by (tenant, clientId, secret) — process-global; rotated secrets create new entries, old ones linger.
