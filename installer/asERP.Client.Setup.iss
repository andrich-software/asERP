; asERP Client (Desktop) — Inno Setup installer.
;
; Build (see build-client-installer.ps1 for the full local flow):
;   ISCC.exe /DAppVersion=2026.07.06.123 ^
;            /DClientPublishDir=..\publish\client ^
;            asERP.Client.Setup.iss
;
; What it does:
;   - installs the self-contained Uno desktop client to {app}\Client
;   - creates a Start-menu shortcut (+ optional desktop icon)
;   - upgrade in place: closes a running client, replaces the binaries
;   - uninstall: removes the shortcuts and binaries
;
; This installer is what the Microsoft Store (EXE/MSI product type) distributes.
; The Store invokes it silently, so it must support Inno's /VERYSILENT switches.

#ifndef AppVersion
  #define AppVersion "0.0.0.0"
#endif
#ifndef ClientPublishDir
  #define ClientPublishDir "..\publish\client"
#endif

#define AppName "asERP"
#define ClientExeName "asERP.Client.exe"

[Setup]
; Generated once for the asERP desktop client — never change, upgrades depend on it.
AppId={{A9E4F2C1-6B3D-4E8A-9F27-1C5D8B0A4E63}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher=andrich software
AppPublisherURL=https://www.aserp.de/
; Share the parent folder with the server installer ({autopf}\asERP\{Server,Tray,Client}).
DefaultDirName={autopf}\asERP
DefaultGroupName=asERP
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
OutputBaseFilename=asERP-Desktop-Setup-{#AppVersion}
OutputDir=output
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\Client\{#ClientExeName}
DisableProgramGroupPage=yes
; Close a running client on upgrade so its files can be replaced.
CloseApplications=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#ClientPublishDir}\*"; DestDir: "{app}\Client"; Flags: recursesubdirs ignoreversion

[Icons]
Name: "{group}\asERP"; Filename: "{app}\Client\{#ClientExeName}"
Name: "{group}\Uninstall asERP"; Filename: "{uninstallexe}"
Name: "{autodesktop}\asERP"; Filename: "{app}\Client\{#ClientExeName}"; Tasks: desktopicon

[Registry]
; Discovery info (mirrors the server installer's SOFTWARE\asERP layout).
Root: HKLM; Subkey: "SOFTWARE\asERP\Client"; ValueType: string; ValueName: "InstallDir"; \
  ValueData: "{app}\Client"; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\asERP\Client"; ValueType: string; ValueName: "Version"; \
  ValueData: "{#AppVersion}"

[Run]
; Offer to launch after an interactive install; skipped for the Store's silent run.
Filename: "{app}\Client\{#ClientExeName}"; Description: "{cm:LaunchProgram,asERP}"; \
  Flags: nowait postinstall skipifsilent runasoriginaluser
