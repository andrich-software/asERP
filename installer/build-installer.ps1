# Builds the asERP Server Windows installer locally.
#
# Prerequisites: .NET 10 SDK, Inno Setup 6 (https://jrsoftware.org/isinfo.php).
#
# Usage:
#   .\build-installer.ps1                     # version defaults to YYYY.MM.DD.0
#   .\build-installer.ps1 -Version 2026.07.05.1

param(
    [string]$Version = "$(Get-Date -Format 'yyyy.MM.dd').0"
)

$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path -Parent $PSScriptRoot
$publishDir = Join-Path $repoRoot 'publish'

Write-Host "Publishing asERP.Server (self-contained win-x64, version $Version)..."
dotnet publish (Join-Path $repoRoot 'src\asERP.Server\asERP.Server.csproj') `
    --configuration Release `
    --runtime win-x64 `
    --self-contained true `
    -p:Version=$Version `
    -p:GeneratePackageOnBuild=false `
    --output (Join-Path $publishDir 'server')
if ($LASTEXITCODE -ne 0) { throw 'Server publish failed.' }

Write-Host "Publishing asERP.Server.Tray (self-contained win-x64)..."
dotnet publish (Join-Path $repoRoot 'src\asERP.Server.Tray\asERP.Server.Tray.csproj') `
    --configuration Release `
    --runtime win-x64 `
    --self-contained true `
    -p:Version=$Version `
    --output (Join-Path $publishDir 'tray')
if ($LASTEXITCODE -ne 0) { throw 'Tray publish failed.' }

$iscc = @(
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe"
) | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) { throw 'ISCC.exe not found - install Inno Setup 6.' }

Write-Host "Compiling installer..."
& $iscc `
    "/DAppVersion=$Version" `
    "/DServerPublishDir=$(Join-Path $publishDir 'server')" `
    "/DTrayPublishDir=$(Join-Path $publishDir 'tray')" `
    (Join-Path $PSScriptRoot 'asERP.Server.Setup.iss')
if ($LASTEXITCODE -ne 0) { throw 'Installer compilation failed.' }

Write-Host "Installer written to $(Join-Path $PSScriptRoot "output\asERP-Server-Setup-$Version.exe")"
