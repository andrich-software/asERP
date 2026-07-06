# asERP Windows Installers

This folder holds two Inno Setup installers:

| Installer | Script | Built by |
|---|---|---|
| **Server** (Windows service + tray) | `asERP.Server.Setup.iss` | `aserp-server-setup-release.yml` |
| **Desktop client** (Uno app, Microsoft Store) | `asERP.Client.Setup.iss` | `aserp-desktop-release-win-store.yml` |

The desktop-client installer is what the **Microsoft Store** distributes: the Store
product for the client is an *EXE/MSI app* (Partner Center `dashboard/win32apps/...`),
not an MSIX/UWP package, so it is fed a signed `.exe` installer hosted at a public
HTTPS URL and submitted via the Microsoft Store Submission API v2. See the header
comment of `aserp-desktop-release-win-store.yml` for the required repository secrets
(`STORE_*`, and optionally `WINDOWS_CERTIFICATE_*` for code signing).

Build the client installer locally with `.\build-client-installer.ps1 -Version 2026.07.06.1`.

---

## asERP Server — Windows Installer

Inno Setup installer that ships the asERP server as a **Windows service** plus a
**tray app** (status, start/stop/restart, settings, database backup/restore).

## Layout after installation

| Location | Content |
|---|---|
| `C:\Program Files\asERP\Server` | self-contained server (`asERP.Server.exe`, runs as service `asERPServer`) |
| `C:\Program Files\asERP\Tray` | tray app (`asERP.Server.Tray.exe`, autostart via HKCU Run key) |
| `C:\ProgramData\asERP` | all data: `settings.json`, `aserp.db`, `files\`, `dp-keys\`, `logs\`, `backups\` |

`settings.json` is an operator-editable configuration layer read by the server
**after** `appsettings.json` and **before** environment variables (see
`src/asERP.Server/Infrastructure/Configuration/ExternalSettings.cs`). The tray app's
settings dialog edits exactly this file (database provider/connection string, image
storage path, HTTP port). Do **not** set `ASPNETCORE_URLS` machine-wide — it would
silently override the port configured in the tray.

## Building locally

```powershell
# Prerequisites: .NET 10 SDK + Inno Setup 6
.\installer\build-installer.ps1 -Version 2026.07.05.1
# -> installer\output\asERP-Server-Setup-2026.07.05.1.exe
```

CI builds and releases the installer via
`.github/workflows/aserp-server-setup-release.yml` (tag prefix `server-v`, version
scheme `YYYY.MM.DD.RunNumber` — stamped identically into the assemblies' FileVersion,
the Inno `AppVersion` and the release tag).

## Security decisions (deliberate tradeoffs)

- **Service DACL (`sc sdset`)**: the installer grants *Authenticated Users* the rights
  to **start/stop/query** the `asERPServer` service (SDDL adds `RP`/`WP`/`DT` for `AU`).
  This is what lets the tray control the service without UAC prompts. No configuration,
  delete or ACL-change rights are granted. If the machine is shared with untrusted local
  users, tighten this to a dedicated group. The tray falls back to an elevated `sc.exe`
  call (one UAC prompt per action) when access is denied.
- **ProgramData ACL**: `C:\ProgramData\asERP` gets *Users: Modify* so the tray (standard
  user) can edit `settings.json` and write backups. Consequence: when PostgreSQL/MSSQL
  credentials are configured, they are readable by local users. Acceptable for the
  target scenario (single-box LAN server); use SQLite or a locked-down box otherwise.
- **SmartScreen**: the installer is currently **unsigned** — first-run shows
  "Windows protected your PC" (More info → Run anyway). Code signing (e.g. Azure
  Trusted Signing) is the planned fast-follow.

## Updates

The tray app checks GitHub Releases (`server-v*` tags) every 24 h and on demand
("Check for updates"). It downloads the new installer to `%TEMP%` and runs it with
`/SILENT`; the installer stops service + tray, replaces the binaries, restarts the
service and relaunches the tray. Database migrations run automatically on the next
service start. The repository must be public for the unauthenticated update check.

## Backup / restore

Implemented server-side (`asERP.Server.exe cli backup|restore <file>`), driven by the
tray. Database only — the `files\` image folder is not included.

| Provider | Backup | Restore | Notes |
|---|---|---|---|
| SQLite | `VACUUM INTO` (online-safe) | file copy (service stopped) | default setup |
| MSSQL | `BACKUP DATABASE … COPY_ONLY` | `RESTORE … WITH REPLACE` (single-user) | path is interpreted by the **SQL Server host** — remote servers write remotely |
| PostgreSQL | `pg_dump --format=custom` | `pg_restore --clean --if-exists` | needs PostgreSQL client tools on PATH or `BackupConfig:PgToolsPath` in `settings.json` |

Restoring an **older** backup is supported (pending migrations run on service start).
Restoring a backup from a **newer** asERP version is not — the CLI prints a loud warning
when it detects unknown migration ids after a restore.

## Manual test matrix (VM)

1. Fresh install → service running, `settings.json` created, tray autostarts,
   `http://localhost:5000/health` returns 200.
2. As a **standard user**: start/stop via tray without UAC; save settings; create backup.
3. Restore flow: stop → restore → start → healthy.
4. Upgrade install over existing → data/settings preserved, service restarted.
5. Uninstall → asks about data folder; default keeps it.
