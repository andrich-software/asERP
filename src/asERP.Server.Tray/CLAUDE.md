# CLAUDE.md — asERP.Server.Tray

Windows system-tray app (`net10.0-windows`, WinForms, `WinExe`) to manage an **installed** asERP Server: start/stop/restart the `asERPServer` Windows service, health monitoring, settings, backup/restore, superadmin management, auto-update. Ships in the Inno Setup installer alongside the server.

**Standalone by design: no references to other asERP projects, no DI container.** The settings schema is intentionally duplicated (`Models/ServerSettings.cs`) and kept in sync with the server's appsettings sections by hand.

## Architecture

- The tray does **not** host or launch the server — the server runs as the Windows service `asERPServer` (delayed-auto, restart-on-failure, registered by the installer). The tray controls it via `ServiceControlService` (`ServiceController`; on access-denied falls back to elevated `sc.exe` with one UAC prompt).
- `Program.cs`: single instance via named mutex `Global\asERP.Server.Tray.SingleInstance` (`Program.MutexName`).
- `TrayApplicationContext`: `NotifyIcon` + state machine (`NotInstalled/Stopped/Pending/Running/RunningUnhealthy`), 3s SCM poll + `/health` HTTP probe (`HealthClient`, 2s timeout) every 5th tick; `RunningUnhealthy` = service running but health failing.
- `ServerCliRunner`: runs `asERP.Server.exe cli <args>` out of band for backup/restore/test-connection/superadmin; forces `DOTNET_ENVIRONMENT=Production`; **secrets go via env vars, never command line**.
- `SettingsStore`: read-modify-write of `%ProgramData%\asERP\settings.json` — **only patches keys the tray owns** (`Urls`, `DatabaseConfig.Provider/ConnectionString`, `FileStorage.RootPath`), preserves all unknown JSON (Serilog, DataProtection, ...), atomic temp-file replace. Keep that property.
- `AppPaths`: data in `%ProgramData%\asERP`; server exe at `{app}\Server\asERP.Server.exe` (sibling of `{app}\Tray\`), fallback `HKLM\SOFTWARE\asERP\InstallDir`.
- Runs un-elevated (`asInvoker` manifest, HKCU Run autostart); the installer loosens the service DACL so users can start/stop it.

## Update Mechanism (fragile — read before touching)

`UpdateChecker` polls GitHub Releases. **The repo shares releases with the desktop client**: server releases use the tag prefix `server-v` and the asset `asERP-Server-Setup-*.exe`; client releases use plain `v` tags. Therefore **never use `/releases/latest`** — filter by tag prefix. Downloads to `%TEMP%`, runs installer `/SILENT`; the tray exits itself first so binaries can be replaced.

## Installer Coupling (keep in sync)

`installer/asERP.Server.Setup.iss` (built by `installer/build-installer.ps1`):
- `AppMutex` must equal `Program.MutexName`.
- Service name `asERPServer` must match `AppPaths`.
- Installs server to `{app}\Server`, tray to `{app}\Tray`; writes the HKCU Run autostart value; `taskkill /im asERP.Server.Tray.exe` on upgrade/uninstall.

## Conventions

- Long operations run through `ProgressForm.Run(...)`; failures surface as `MessageBox`.
- `TreatWarningsAsErrors=true`.
- Only package dependency: `System.ServiceProcess.ServiceController` — keep the project dependency-free.
