; asERP Server + Tray — Inno Setup installer.
;
; Build (see build-installer.ps1 for the full local flow):
;   ISCC.exe /DAppVersion=2026.07.05.123 ^
;            /DServerPublishDir=..\publish\server ^
;            /DTrayPublishDir=..\publish\tray ^
;            asERP.Server.Setup.iss
;
; What it does:
;   - installs the self-contained server to {app}\Server and the tray app to {app}\Tray
;   - creates C:\ProgramData\asERP (+ files/logs/backups) with Users-Modify ACLs so the
;     tray (running as a standard user) can edit settings.json and write backups
;   - writes an initial settings.json (SQLite, absolute paths) on first install only
;   - registers the "asERPServer" Windows service (delayed-auto, restart-on-failure)
;   - loosens the service DACL so Authenticated Users may start/stop/query exactly this
;     service (documented tradeoff — no config/delete rights are granted)
;   - upgrade in place: stops service + tray, replaces binaries, restarts (data preserved;
;     EF migrations run automatically on the next service start)
;   - uninstall: removes service + binaries and ASKS before deleting the data folder

#ifndef AppVersion
  #define AppVersion "0.0.0.0"
#endif
#ifndef ServerPublishDir
  #define ServerPublishDir "..\publish\server"
#endif
#ifndef TrayPublishDir
  #define TrayPublishDir "..\publish\tray"
#endif

#define AppName "asERP Server"
#define ServiceName "asERPServer"
#define ServiceDisplayName "asERP Server"
#define TrayExeName "asERP.Server.Tray.exe"

[Setup]
; Generated once for asERP Server — never change, upgrades depend on it.
AppId={{7E1B7A46-3A34-4C0D-9C1E-52B7D9E9A11F}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher=andrich software
AppPublisherURL=https://www.aserp.de/
; Own folder, deliberately separate from the desktop installer ({autopf}\asERP Desktop) —
; sharing {autopf}\asERP caused conflicts when both products were installed on one machine.
; Existing installs keep their previous folder (Inno's UsePreviousAppDir default).
DefaultDirName={autopf}\asERP Server
DefaultGroupName=asERP Server
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
OutputBaseFilename=asERP-Server-Setup-{#AppVersion}
OutputDir=output
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
; Matches Program.MutexName in asERP.Server.Tray — lets Setup detect a running tray.
AppMutex=Global\asERP.Server.Tray.SingleInstance
CloseApplications=yes
UninstallDisplayIcon={app}\Tray\{#TrayExeName}
DisableProgramGroupPage=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
; Autostart is on by default (matches the pre-checkbox behavior); silent upgrades
; keep the user's previous choice (UsePreviousTasks default).
Name: "autostart"; Description: "{cm:AutoStartProgram,asERP Server Tray}"; \
  GroupDescription: "{cm:AutoStartProgramGroupDescription}"
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; \
  GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "{#ServerPublishDir}\*"; DestDir: "{app}\Server"; Flags: recursesubdirs ignoreversion
Source: "{#TrayPublishDir}\*"; DestDir: "{app}\Tray"; Flags: recursesubdirs ignoreversion

[Dirs]
; Users-Modify so the tray can edit settings.json / write backups without elevation and
; the LocalSystem/service account can write DB, images and logs. Note: settings.json may
; contain DB credentials readable by local users — acceptable for the single-box scenario.
Name: "{commonappdata}\asERP"; Permissions: users-modify
Name: "{commonappdata}\asERP\files"; Permissions: users-modify
Name: "{commonappdata}\asERP\logs"; Permissions: users-modify
Name: "{commonappdata}\asERP\backups"; Permissions: users-modify
Name: "{commonappdata}\asERP\dp-keys"; Permissions: users-modify

[Icons]
Name: "{group}\asERP Server Tray"; Filename: "{app}\Tray\{#TrayExeName}"
Name: "{group}\asERP Data Folder"; Filename: "{commonappdata}\asERP"
Name: "{autodesktop}\asERP Server Tray"; Filename: "{app}\Tray\{#TrayExeName}"; Tasks: desktopicon

[Registry]
; Tray autostart for the installing user (opt-out via the "autostart" task).
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; \
  ValueType: string; ValueName: "asERP Server Tray"; \
  ValueData: """{app}\Tray\{#TrayExeName}"""; Flags: uninsdeletevalue; Tasks: autostart
; Remove a previously configured autostart when the task is unchecked on an upgrade.
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; \
  ValueType: none; ValueName: "asERP Server Tray"; Flags: deletevalue; \
  Check: not WizardIsTaskSelected('autostart')
; Discovery info for the tray and its update checker. Delete only our own values on
; uninstall — SOFTWARE\asERP\Client belongs to the desktop installer and must survive.
Root: HKLM; Subkey: "SOFTWARE\asERP"; ValueType: string; ValueName: "InstallDir"; \
  ValueData: "{app}"; Flags: uninsdeletevalue uninsdeletekeyifempty
Root: HKLM; Subkey: "SOFTWARE\asERP"; ValueType: string; ValueName: "Version"; \
  ValueData: "{#AppVersion}"; Flags: uninsdeletevalue uninsdeletekeyifempty

[Run]
; Create the service on first install; on upgrades just re-apply the binPath/start config.
Filename: "{sys}\sc.exe"; \
  Parameters: "create {#ServiceName} binPath= ""\""{app}\Server\asERP.Server.exe\"""" start= delayed-auto DisplayName= ""{#ServiceDisplayName}"""; \
  Flags: runhidden; Check: not ServiceExists
Filename: "{sys}\sc.exe"; \
  Parameters: "config {#ServiceName} binPath= ""\""{app}\Server\asERP.Server.exe\"""" start= delayed-auto"; \
  Flags: runhidden; Check: ServiceExists
Filename: "{sys}\sc.exe"; Parameters: "description {#ServiceName} ""asERP application server (https://www.aserp.de/)"""; Flags: runhidden
; Recovery: restart after 5s/10s/30s, reset the failure counter daily.
Filename: "{sys}\sc.exe"; Parameters: "failure {#ServiceName} reset= 86400 actions= restart/5000/restart/10000/restart/30000"; Flags: runhidden
; Stock service DACL plus RP (start), WP (stop), DT (pause) for Authenticated Users (AU):
; lets the tray control this one service without UAC. No change/delete rights are granted.
Filename: "{sys}\sc.exe"; \
  Parameters: "sdset {#ServiceName} D:(A;;CCLCSWRPWPDTLOCRRC;;;SY)(A;;CCDCLCSWRPWPDTLOCRSDRCWDWO;;;BA)(A;;CCLCSWRPWPDTLOCRRC;;;AU)(A;;CCLCSWLOCRRC;;;SU)"; \
  Flags: runhidden
Filename: "{sys}\sc.exe"; Parameters: "start {#ServiceName}"; Flags: runhidden
; Relaunch the tray as the original (non-elevated) user. Runs after silent upgrades too,
; so the tray comes back after a tray-initiated update.
Filename: "{app}\Tray\{#TrayExeName}"; Description: "Start asERP tray"; \
  Flags: nowait postinstall runasoriginaluser

[UninstallRun]
Filename: "{sys}\taskkill.exe"; Parameters: "/f /im {#TrayExeName}"; Flags: runhidden; RunOnceId: "KillTray"
Filename: "{sys}\sc.exe"; Parameters: "stop {#ServiceName}"; Flags: runhidden; RunOnceId: "StopService"
Filename: "{sys}\sc.exe"; Parameters: "delete {#ServiceName}"; Flags: runhidden; RunOnceId: "DeleteService"

[Code]
function ServiceExists: Boolean;
var
  ResultCode: Integer;
begin
  Result := Exec(ExpandConstant('{sys}\sc.exe'), 'query {#ServiceName}', '',
    SW_HIDE, ewWaitUntilTerminated, ResultCode) and (ResultCode = 0);
end;

procedure StopServiceAndTray;
var
  ResultCode: Integer;
  Attempt: Integer;
begin
  Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im {#TrayExeName}', '',
    SW_HIDE, ewWaitUntilTerminated, ResultCode);

  if ServiceExists then
  begin
    { Poll up to 60 s: "sc stop" returns 1062 ("not started") once the service is down. }
    for Attempt := 1 to 60 do
    begin
      Exec(ExpandConstant('{sys}\sc.exe'), 'stop {#ServiceName}', '',
        SW_HIDE, ewWaitUntilTerminated, ResultCode);
      if ResultCode = 1062 then
        Break;
      Sleep(1000);
    end;
  end;
end;

function PrepareToInstall(var NeedsRestart: Boolean): String;
begin
  StopServiceAndTray;
  Result := '';
end;

function JsonEscapePath(const Path: String): String;
begin
  Result := Path;
  StringChangeEx(Result, '\', '\\', True);
end;

procedure WriteDefaultSettings;
var
  SettingsPath, DataDir, Json: String;
begin
  SettingsPath := ExpandConstant('{commonappdata}\asERP\settings.json');
  if FileExists(SettingsPath) then
    Exit;

  DataDir := JsonEscapePath(ExpandConstant('{commonappdata}\asERP'));
  Json :=
    '{' + #13#10 +
    '  "Urls": "http://localhost:5000",' + #13#10 +
    '  "DatabaseConfig": {' + #13#10 +
    '    "Provider": "Sqlite",' + #13#10 +
    '    "ConnectionString": "Data Source=' + DataDir + '\\aserp.db"' + #13#10 +
    '  },' + #13#10 +
    '  "FileStorage": {' + #13#10 +
    '    "RootPath": "' + DataDir + '\\files"' + #13#10 +
    '  },' + #13#10 +
    '  "DataProtection": {' + #13#10 +
    '    "KeyDirectory": "' + DataDir + '\\dp-keys"' + #13#10 +
    '  },' + #13#10 +
    '  "Serilog": {' + #13#10 +
    '    "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],' + #13#10 +
    '    "WriteTo": [' + #13#10 +
    '      { "Name": "Console" },' + #13#10 +
    '      {' + #13#10 +
    '        "Name": "File",' + #13#10 +
    '        "Args": {' + #13#10 +
    '          "path": "' + DataDir + '\\logs\\aserp-.log",' + #13#10 +
    '          "rollingInterval": "Day",' + #13#10 +
    '          "retainedFileCountLimit": 14,' + #13#10 +
    '          "shared": true' + #13#10 +
    '        }' + #13#10 +
    '      }' + #13#10 +
    '    ]' + #13#10 +
    '  }' + #13#10 +
    '}' + #13#10;

  SaveStringToFile(SettingsPath, Json, False);
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
    WriteDefaultSettings;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
  if CurUninstallStep = usPostUninstall then
  begin
    if MsgBox('Delete all asERP data (database, images, backups, settings) in ' +
              ExpandConstant('{commonappdata}\asERP') + '?' + #13#10#13#10 +
              'Choose No to keep your data for a future reinstall.',
              mbConfirmation, MB_YESNO or MB_DEFBUTTON2) = IDYES then
      DelTree(ExpandConstant('{commonappdata}\asERP'), True, True, True);
  end;
end;
